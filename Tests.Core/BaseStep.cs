using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Tests.Core.Data;

namespace Tests.Core
{
    public class BaseStep
    {
        public static event EventHandler TearDownEvent;

        [BeforeScenario]
        public void BeforeScenario()
        {
            AEContainer.Container = new Castle.Windsor.WindsorContainer();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Magasin.Clear();
            AEContainer.Container.Dispose();
            AEContainer.Container = null;

            if (TearDownEvent != null)
                TearDownEvent(this, new EventArgs());
        }
    }
}
