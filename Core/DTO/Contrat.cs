using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class Contrat
    {
        public string Id { get; set; }

        public string NumeroContrat { get; set; }

        public Client Assure { get; set; }

        public Client Souscripteur { get; set; }

        public Client Payeur { get; set; }

        public List<Contrat> Contrats { get; set; }
    }
}
