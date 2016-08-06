using Core.DTO;
using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Impl.Command
{
    public class CommandResiliationContrat
    {
        public void Execute(string contratId, string login)
        {
            var contrat = AEContainer.Container.Resolve<IRepositoryContrat>().GetById(contratId);
            var utilisateur = AEContainer.Container.Resolve<IRepositoryUtilisateur>().GetByLogin(login);

            if (!utilisateur.Profil.Habilitations.Any(h => h is HabilitationAdministrateur))
                throw new Exception();

            contrat.DateFin = DateTime.Now;

            AEContainer.Container.Resolve<IRepositoryContrat>().Save(contrat);
        }
    }
}
