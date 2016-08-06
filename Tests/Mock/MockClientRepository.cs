﻿using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTO;
using Moq;
using Tests.Data;

namespace Tests.Mock
{
    public class MockClientRepository : Mock<IRepositoryClient>
    {
        public MockClientRepository()
        {
            Setup(s => s.GetById(It.IsAny<string>())).Returns<string>(p => Magasin.OfType<Client>().FirstOrDefault(d => d.Id == p));
            Setup(s => s.GetAll()).Returns(Magasin.OfType<Client>().ToList());
        }
    }
}