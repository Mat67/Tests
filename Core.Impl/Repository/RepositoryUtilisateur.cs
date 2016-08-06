using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTO;

namespace Core.Impl.Repository
{
    public class RepositoryUtilisateur : IRepositoryUtilisateur
    {
        public List<Client> GetAll()
        {
            throw new NotImplementedException();
        }

        public Utilisateur GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Utilisateur GetByLogin(string login)
        {
            throw new NotImplementedException();
        }
    }
}
