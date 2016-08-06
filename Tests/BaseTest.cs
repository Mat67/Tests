using Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Data;

namespace Tests
{
    public class BaseTest
    {
        [TearDown]
        public void TearDown()
        {
            Data.Magasin.Clear();
            AEContainer.Container.Dispose();
            //Container.Dispose();
            AEContainer.Container = new Castle.Windsor.WindsorContainer();

            if (TearDownEvent != null)
                TearDownEvent(this, new EventArgs());
        }

        public static event EventHandler TearDownEvent;
    }
}
