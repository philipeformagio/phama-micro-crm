﻿using PhamaMicroCrm.Model.Entities;
using System;
using System.Threading.Tasks;

namespace PhamaMicroCrm.Business.Interfaces
{
    public interface ICompanyService : IDisposable
    {
        Task Add(Company company);
        Task Update(Company company);
        Task Remove(Guid id);
    }
}
