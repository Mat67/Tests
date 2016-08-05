using Castle.MicroKernel.Registration;
using Core.DTO;
using Core.Repository;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Mock;
using Tests.Data;

namespace Tests
{
    [TestFixture]
    public class TestClient : BaseTest
    {
        IRepositoryClient _ClientRepository;

        [SetUp]
        public void SetUp()
        {
            Tests.SetUp.Container.Register(Component.For<IRepositoryClient>().ImplementedBy<FakeClientRepository>());
            _ClientRepository = Tests.SetUp.Container.Resolve<IRepositoryClient>();

            //Magasin.Populate()
            var client = Catalogue.Build<Client>().Administrateur()
                .With(w => w.Id, "1").Create();
            Magasin.Populate(client);
        }

        [Test]
        public void TestGetById()
        {
            Assert.IsNotNull(_ClientRepository.GetById("1"));
        }

        [Test]
        public void TestGetAll()
        {
            var resultat = _ClientRepository.GetAll();

            Assert.IsNotNull(resultat);
            Assert.Greater(resultat.Count, 0);
        }
    }
}
