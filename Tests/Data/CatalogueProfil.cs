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
    public static class CatalogueProfilExtension
    {
        public static IPostprocessComposer<Profil> TemplateProfilAdmin(this ICustomizationComposer<Profil> profil)
        {
            return profil
                .With(w => w.Habilitations, new List<Habilitation>() { new HabilitationAdministrateur() })
                .With(w => w.Libelle, "Admnistrateur");
        }
    }
}
