using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentiSoft.TimeRegistration.DataAccessLayer;
using CentiSoft.TimeRegistration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CentiSoft.TimeRegistration.Controllers
{
    public class ClientController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly EntityFactory<IClient> _clientFactory;

        public ClientController(IConfiguration configuration, EntityFactory<IClient> clientFactory)
        {
            _configuration = configuration;
            _clientFactory = clientFactory;
        }

        public IActionResult Index(int id)
        {
            var client = _clientFactory.GetById(id);

            return View(client);
        }

        public IActionResult Edit(int id)
        {
            return View(new ClientModel(_clientFactory.GetById(id)));
        }

        [HttpPost]
        public IActionResult Save(ClientModel clientModel)
        {
            var client = _clientFactory.GetById(clientModel.Id);

            if (client == null)
            {
                client = _clientFactory.Create();
            }

            client.Name = clientModel.Name;
            client.Token = clientModel.Token;

            client.Update();

            return RedirectToAction("Index", "Home");
        }


        public IActionResult Delete(int id)
        {
            var client = _clientFactory.GetById(id);
            client.Delete();

            return RedirectToAction("Index", "Home");
        }
    }
}