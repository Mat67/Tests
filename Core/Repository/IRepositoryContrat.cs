using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IRepositoryContrat
    {
        Contrat GetById(string id);

        List<Contrat> GetAll();

        void Save(Contrat contrat);
    }
}
