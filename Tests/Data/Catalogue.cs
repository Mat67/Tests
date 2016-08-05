using Core.DTO;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Dsl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Data
{
    public static class Catalogue
    {
        private static Fixture _Fixture = new Fixture();

        public static ICustomizationComposer<T> Build<T>()
        {
            return _Fixture.Build<T>();
        }

        public static IPostprocessComposer<Client> Administrateur(this ICustomizationComposer<Client> client)
        {
            return client.With(w => w.Nom, "Nom");
        }
    }
}
