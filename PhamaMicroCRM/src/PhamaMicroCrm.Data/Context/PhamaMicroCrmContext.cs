using Microsoft.EntityFrameworkCore;
using PhamaMicroCrm.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhamaMicroCrm.Data.Context
{
    public class PhamaMicroCrmContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
    }
}
