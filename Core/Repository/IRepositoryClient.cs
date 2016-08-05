using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IRepositoryClient
    {
        Client GetById(string id);

        List<Client> GetAll();
    }
}
