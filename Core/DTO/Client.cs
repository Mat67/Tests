﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class Client
    {
        public string Id { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public Profil Profil { get; set; }
    }
}
