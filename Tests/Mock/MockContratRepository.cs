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
    public class MockContratRepository : Mock<IRepositoryContrat>
    {
        public MockContratRepository()
        {
            Setup(s => s.GetById(It.IsAny<string>())).Returns<string>(p => Magasin.OfType<Contrat>().FirstOrDefault(d => d.Id == p));
            Setup(s => s.GetAll()).Returns<string>(p => Magasin.OfType<Contrat>().ToList());
            Setup(s => s.Save(It.IsAny<Contrat>())).Callback<Contrat>((c) => 
            {
                var r = Magasin.OfType<Contrat>().FirstOrDefault(w => w.Id == c.Id);
                r = c;
            });
        }
    }
}
