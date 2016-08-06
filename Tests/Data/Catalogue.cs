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

        public static IPostprocessComposer<Utilisateur> Administrateur(this ICustomizationComposer<Utilisateur> utilisateur)
        {
            return utilisateur
                .With(w => w.Login, "Admin")
                .With(w =>w.Profil, Catalogue.Build<Profil>().ProfilAdmin().Create());
        }

        public static IPostprocessComposer<Utilisateur> UtilisateurLambda(this ICustomizationComposer<Utilisateur> utilisateur)
        {
            return utilisateur
                .With(w => w.Login, "Admin")
                .With(w => w.Profil, Catalogue.Build<Profil>()
                .With(m => m.Habilitations, new List<Habilitation>()).Create());
        }

        public static IPostprocessComposer<Profil> ProfilAdmin(this ICustomizationComposer<Profil> profil)
        {
            return profil
                .With(w => w.Habilitations, new List<Habilitation>() { new HabilitationAdministrateur() })
                .With(w => w.Libelle, "Admnistrateur");
        }
    }
}
