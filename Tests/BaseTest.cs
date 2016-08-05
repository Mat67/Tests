using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [SetUpFixture]
    public class BaseTest
    {
        public static Castle.Windsor.WindsorContainer Container = new Castle.Windsor.WindsorContainer();

        [OneTimeSetUp]
        public void BaseSetUp()
        {
            // Traitement effectué une seule fois au lancement des tests
            // Initialisation base
            // Chargement de données
        }

        [OneTimeTearDown]
        public void BaseTearDown()
        {
            // Traitement effectué une seule fois après l'exécution des tests
            // Suppression de la base
        }
    }
}
