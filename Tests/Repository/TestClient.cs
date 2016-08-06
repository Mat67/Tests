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
using Tests.Core.Data;
using Core;
using Moq;

namespace Tests.Repository
{
    [TestFixture]
    public class TestClient : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            
        }

        [Test]
        public void TestGetByIdSuccess()
        {
            var client = Catalogue.Build<Client>()
                   .With(w => w.Id, "1").Create();

            Magasin.Populate(client);

            AEContainer.Container.Register(Component.For<IRepositoryClient>().Instance(new MockClientRepository().Object));

            var result = AEContainer.Container.Resolve<IRepositoryClient>().GetById("1");
            Assert.IsNotNull(result);
            Assert.AreEqual("1", result.Id);
        }

        [Test]
        public void TestGetByIdFailed()
        {
            var client = Catalogue.Build<Client>()
                .With(w => w.Id, "1").Create();

            Magasin.Populate(client);

            var instance = new MockClientRepository();
            instance.Setup(s => s.GetById(It.IsAny<string>())).Returns(new Client());

            AEContainer.Container.Register(Component.For<IRepositoryClient>().Instance(instance.Object));


            var result = AEContainer.Container.Resolve<IRepositoryClient>().GetById("1");
            Assert.IsNotNull(result);
            Assert.AreNotEqual("1", result.Id);
        }

        [Test]
        public void TestGetAll()
        {
            AEContainer.Container.Register(Component.For<IRepositoryClient>().Instance(new MockClientRepository().Object));
            Magasin.Populate(Catalogue.Build<Client>().CreateMany());

            var resultat = AEContainer.Container.Resolve<IRepositoryClient>().GetAll();

            Assert.IsNotNull(resultat);
            Assert.Greater(resultat.Count, 0);
        }

        [Test]
        public void TestCreateClient()
        {
            AEContainer.Container.Register(Component.For<IRepositoryClient>().Instance(new MockClientRepository().Object));
            var client = Catalogue.Build<Client>().Create();

            AEContainer.Container.Resolve<IRepositoryClient>().Save(client);

            Assert.AreEqual(1, Magasin.OfType<Client>().Count());
            Assert.IsNotNull(Magasin.OfType<Client>().FirstOrDefault());
            Assert.AreEqual(Magasin.OfType<Client>().FirstOrDefault(), client);
        }

        [Test]
        public void TestUpdateClient()
        {
            AEContainer.Container.Register(Component.For<IRepositoryClient>().Instance(new MockClientRepository().Object));
            var client = Catalogue.Build<Client>().Create();
            Magasin.Populate(client);

            client.Nom = "566";
            AEContainer.Container.Resolve<IRepositoryClient>().Save(client);

            Assert.AreEqual(1, Magasin.OfType<Client>().Count());
            Assert.IsNotNull(Magasin.OfType<Client>().FirstOrDefault());
            Assert.AreEqual(Magasin.OfType<Client>().FirstOrDefault(), client);
            Assert.AreEqual(Magasin.OfType<Client>().FirstOrDefault().Nom, client.Nom);
        }
    }
}
