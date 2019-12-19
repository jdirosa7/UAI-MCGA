﻿using MCGA_Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA_Safari.Services.Contracts
{
    public interface IContract<T> where T : IEntity
    {
        List<T> ToList();
        T Find(int id);
        T Add(T ServiceType);
        T Update(int id, T obj);
        void Delete(int id);
    }
}
