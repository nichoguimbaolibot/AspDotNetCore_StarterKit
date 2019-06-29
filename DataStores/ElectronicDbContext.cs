using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ElectronicShop.Models;

namespace ElectronicShop.Datas
{
  public class ElectronicDbContext : DbContext
  {
    public ElectronicDbContext(DbContextOptions<ElectronicDbContext> options): base(options)
    {

    }
    public DbSet<Electronic> Electronics {get; set;}
  }
}