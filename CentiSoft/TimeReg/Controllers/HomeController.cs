using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentiSoft.TimeReg.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CentiSoft.TimeReg.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEntityFactory<IClient> _clientFactory;

        public HomeController(IEntityFactory<IClient> clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}