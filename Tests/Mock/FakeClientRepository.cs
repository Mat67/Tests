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
        Mock<IRepositoryClient> _Mock = new Mock<IRepositoryClient>();
        

        public FakeClientRepository()
        {
            _Mock.Setup(s => s.GetById(It.IsAny<string>())).Returns<string>(p => Data.Catalogue.OfType<Client>().FirstOrDefault(d => d.Id == p));
        }


        public List<Client> GetAll()
        {
            throw new NotImplementedException();
        }

        public Client GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
