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
using Core;
using Moq;

namespace Tests
{
    [TestFixture]
    public class TestClient : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            var client = Catalogue.Build<Client>()
                .With(w => w.Id, "1").Create();

            Magasin.Populate(client);
        }

        [Test]
        public void TestGetByIdSuccess()
        {
            AEContainer.Container.Register(Component.For<IRepositoryClient>().Instance(new MockClientRepository().Object));

            var result = AEContainer.Container.Resolve<IRepositoryClient>().GetById("1");
            Assert.IsNotNull(result);
            Assert.AreEqual("1", result.Id);
        }

        [Test]
        public void TestGetByIdFailed()
        {
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
    }
}
