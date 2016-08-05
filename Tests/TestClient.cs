using Core.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class TestClient
    {
        IRepositoryClient _ClientRepository;

        [SetUp]
        public void SetUp()
        {
            _ClientRepository = BaseTest.Container.Resolve<IRepositoryClient>();
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
