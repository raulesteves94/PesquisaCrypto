using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PesquisaCrypto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PesquisaCrypto.ViewComponents
{
    public class MoedasViewComponents:ViewComponent
    {
        private readonly MoedasContexto _moedasContexto;

        public MoedasViewComponents(MoedasContexto moedasContexto)
        {
            _moedasContexto = moedasContexto;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _moedasContexto.Moedas.ToListAsync());
        }
    }
}
