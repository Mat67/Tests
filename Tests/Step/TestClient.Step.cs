using Castle.MicroKernel.Registration;
using Core;
using Core.DTO;
using Core.Repository;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Tests.Core;
using Tests.Core.Data;
using Tests.Mock;

namespace Tests.Step
{
    [Binding, Scope(Tag = "TestClient")]
    public sealed class TestClient : BaseStep
    {
        Client resultat;

        [Given(@"un repository client fake")]
        public void GivenUnRepositoryClientFake()
        {
            AEContainer.Container.Register(Component.For<IRepositoryClient>().Instance(new MockClientRepository().Object));
        }

        [Given(@"un client existant")]
        public void GivenUnClientExistant()
        {
            var client = Catalogue.Build<Client>()
                   .With(w => w.Id, "1").Create();

            Magasin.Populate(client);

            var client2 = Catalogue.Build<Client>()
                  .With(w => w.Id, "2").Create();

            Magasin.Populate(client2);
        }

        [When(@"je recupere le client par selon l Id (.*)")]
        public void WhenJeRecupereLeClientParSelonLId(string p0)
        {
            resultat = AEContainer.Container.Resolve<IRepositoryClient>().GetById(p0.ToString());
        }


        [When(@"je recupere le client par selon l Id '(.*)'")]
        public void WhenJeRecupereLeClientParSelonLId(int p0)
        {
            resultat = AEContainer.Container.Resolve<IRepositoryClient>().GetById(p0.ToString());
        }

        [Then(@"j'obtient le client")]
        public void ThenJObtientLeClient()
        {
            Assert.IsNotNull(resultat);
            //Assert.AreEqual("1", resultat.Id);
        }
    }
}
