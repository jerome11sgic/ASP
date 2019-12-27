using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DistrictApi.Models
{
    public class DistrictContext : DbContext
    {
        public DistrictContext(DbContextOptions<DistrictContext> options)
            : base(options)
        {
        }

        public DbSet<DistrictData> DistrictDatas { get; set; }
    }
}
