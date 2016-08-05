using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IRepositoryProfil
    {
        Profil GetById(string id);

        Profil GetByLibelle(string libelle);
    }
}
