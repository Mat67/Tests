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
    public class FakeClientRepository : IRepositoryClient
    {
        //Mock<IRepositoryClient> _Mock = new Mock<IRepositoryClient>();
        public FakeClientRepository()
        {
            //_Mock.Setup(s => s.GetById(It.IsAny<string>())).Returns<string>(p => Catalogue.OfType<Client>().FirstOrDefault(d => d.Id == p));
        }

        public List<Client> GetAll()
        {
            return Magasin.OfType<Client>().ToList();
        }

        public Client GetById(string id)
        {
            return Magasin.OfType<Client>().FirstOrDefault(d => d.Id == id);
        }
    }
}
