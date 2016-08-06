using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTO;
using Moq;
using Tests.Data;
using Tests.Core.Data;

namespace Tests.Mock
{
    public class MockClientRepository : Mock<IRepositoryClient>
    {
        public MockClientRepository()
        {
            Setup(s => s.GetById(It.IsAny<string>())).Returns<string>(p => Magasin.OfType<Client>().FirstOrDefault(d => d.Id == p));
            Setup(s => s.GetAll())
                .Returns(() => { return Magasin.OfType<Client>().ToList(); });
            Setup(s => s.Save(It.IsAny<Client>())).Callback<Client>((c) =>
            {
                var r = Magasin.OfType<Client>().FirstOrDefault(w => w.Id == c.Id);
                if (r == null)
                    Magasin.Populate(c);
                else
                    r = c;
            });
        }
    }
}
