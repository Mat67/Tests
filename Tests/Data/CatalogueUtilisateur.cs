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
    public class CatalogueSingleton<T>
        where T: CatalogueUtilisateur
    {
        static CatalogueUtilisateur singleton;
        protected static CatalogueUtilisateur _Singleton
        {
            get
            {
                BaseTest.TearDownEvent += (s, e) => { singleton = null; };

                return singleton == null ? singleton = new CatalogueUtilisateur() : singleton;
            }
        }
    }

    public class CatalogueUtilisateur : CatalogueSingleton<CatalogueUtilisateur>
    {
        private Utilisateur administrateur;
        public static Utilisateur Administrateur
        {
            get
            {
                if (_Singleton.administrateur == null)
                    _Singleton.administrateur = Catalogue.Build<Utilisateur>().TemplateAdministrateur().Create();

                return _Singleton.administrateur;
            }
        }
    }

    public static class CatalogueUtilisateurExtension
    {
        public static IPostprocessComposer<Utilisateur> TemplateAdministrateur(this ICustomizationComposer<Utilisateur> utilisateur)
        {
            return utilisateur
                .With(w => w.Login, "Admin")
                .With(w => w.Profil, Catalogue.Build<Profil>().TemplateProfilAdmin().Create());
        }

        public static IPostprocessComposer<Utilisateur> TemplateUtilisateurLambda(this ICustomizationComposer<Utilisateur> utilisateur)
        {
            return utilisateur
                .With(w => w.Login, "Admin")
                .With(w => w.Profil, Catalogue.Build<Profil>()
                .With(m => m.Habilitations, new List<Habilitation>()).Create());
        }
    }
}
