using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTO;
using Moq;
using Tests.Data;

namespace Tests.Mock
{
    public class MockUtilisateurRepository : Mock<IRepositoryUtilisateur>
    {
        public MockUtilisateurRepository()
        {
            Setup(s => s.GetById(It.IsAny<string>())).Returns<string>(p => Magasin.OfType<Utilisateur>().FirstOrDefault(d => d.Id == p));
            Setup(s => s.GetByLogin(It.IsAny<string>())).Returns<string>(p => Magasin.OfType<Utilisateur>().FirstOrDefault(d => d.Login == p));
        }
    }
}
