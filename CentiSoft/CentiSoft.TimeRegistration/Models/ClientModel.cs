using CentiSoft.TimeRegistration.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentiSoft.TimeRegistration.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        
        public ClientModel()
        {

        }

        public ClientModel(IClient client = null)
        {
            if (client != null)
            {
                Id = client.Id;
                Name = client.Name;
                Token = client.Token;
            }
        }
    }
}
