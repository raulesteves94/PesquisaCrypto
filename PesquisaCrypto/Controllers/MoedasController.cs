using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PesquisaCrypto.Models;

namespace PesquisaCrypto.Controllers
{
    public class MoedasController : Controller
    {
        private readonly MoedasContexto _context;

        public MoedasController(MoedasContexto context)
        {
            _context = context;
        }

        // GET: Moedas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Moedas.ToListAsync());
        }

        // GET: Moedas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Moedas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MoedasId,Nome,Quantidade")] Moedas moedas)
        {
            if (ModelState.IsValid)
            {
                moedas.Quantidade = 0;
                _context.Add(moedas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moedas);
        }                
    }
}
