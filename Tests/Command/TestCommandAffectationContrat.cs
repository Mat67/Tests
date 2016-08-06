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
using Core.Impl.Command;
using Tests.Core.Data;

namespace Tests
{
    [TestFixture]
    public class TestCommandAffectationContrat : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            Magasin.Populate(CatalogueUtilisateur.Administrateur);
            Magasin.Populate(Catalogue.Build<Contrat>().Without(w => w.DateFin).With(x => x.Id, "5").Create());

            AEContainer.Container.Register(Component.For<IRepositoryUtilisateur>().Instance(new MockUtilisateurRepository().Object));
            AEContainer.Container.Register(Component.For<IRepositoryContrat>().Instance(new MockContratRepository().Object));
        }

        [Test]
        public void TestCommand()
        {
            var cmd = new CommandResiliationContrat();
            cmd.Execute("5", CatalogueUtilisateur.Administrateur.Login);

            var ct = Magasin.OfType<Contrat>().FirstOrDefault();
            Assert.IsNotNull(ct.DateFin);
        }
    }
}
