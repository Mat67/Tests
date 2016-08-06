using Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Core.Data;

namespace Tests
{
    public abstract class BaseTest
    {
        [TearDown]
        public void TearDown()
        {
            Magasin.Clear();
            AEContainer.Container.Dispose();
            //Container.Dispose();
            AEContainer.Container = null;

            if (TearDownEvent != null)
                TearDownEvent(this, new EventArgs());
        }

        [SetUp]
        public void SetUp()
        {
            AEContainer.Container = new Castle.Windsor.WindsorContainer();
        }

        public static event EventHandler TearDownEvent;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            // Traitement effectué une seule fois au lancement des tests
            // Initialisation base
            // Chargement de données
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            // Traitement effectué une seule fois après l'exécution des tests
            // Suppression de la base
        }
    }
}
