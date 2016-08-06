using Core.DTO;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Dsl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Core.Data
{
    public static class Catalogue
    {
        private static Fixture _Fixture = new Fixture();

        public static ICustomizationComposer<T> Build<T>()
        {
            return _Fixture.Build<T>();
        }
    }

    public class CatalogueSingleton<T>
        where T : class
    {
        static T singleton;
        protected static T _Singleton
        {
            get
            {
                BaseTest.TearDownEvent += (s, e) => { singleton = null; };
                
                return singleton == null ? singleton = Activator.CreateInstance<T>() : singleton;
            }
        }
    }
}
