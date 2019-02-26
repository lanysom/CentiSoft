using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CentiSoft.TimeRegistration.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CentiSoft.TimeRegistration.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly EntityFactory<IClient> _clientFactory;

        public HomeController(IConfiguration configuration, EntityFactory<IClient> clientFactory)
        {
            _configuration = configuration;
            _clientFactory = clientFactory;
        }

        public IActionResult Index()
        {
            var clients = _clientFactory.GetAll().ToList();

            return View(clients);
        }
    }
}