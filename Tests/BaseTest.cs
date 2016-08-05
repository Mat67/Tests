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
            Tests.SetUp.Container.Dispose();
            //Container.Dispose();
            Tests.SetUp.Container = new Castle.Windsor.WindsorContainer();
        }
    }
}
