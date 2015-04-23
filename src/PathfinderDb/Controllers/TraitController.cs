using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Microsoft.Framework.Caching.Memory;

namespace PathfinderDb.Controllers
{
    public class TraitController : Controller
    {
        [FromServices]
        public Models.PathfinderDbContext DbContext { get; set; }

        public IActionResult Index()
        {
            var vm = new ViewModels.TraitIndexViewModel();
            vm.Docs = this.DbContext.TraitDocs.ToList();
            return this.View(vm);
        }
    }
}
