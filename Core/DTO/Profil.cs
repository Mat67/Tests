using System.Collections.Generic;

namespace Core.DTO
{
    public class Profil
    {
        public string Id { get; set; }

        public string Libelle { get; set; }

        public List<Habilitation> Habilitations { get; set; }
    }
}