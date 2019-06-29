using System;
using System.Linq;
using ElectronicShop.Models;
using ElectronicShop.DataStores;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectronicShop.Datas;

namespace ElectronicShop.Queries
{
  public class ElectronicQueries : IElectronicQueries
  {
    private readonly ElectronicDbContext _electronicDbContext;

    public ElectronicQueries(ElectronicDbContext electronicDbContext)
    {
      _electronicDbContext = electronicDbContext;
    }

    public IEnumerable<Electronic> GetElectronics()
    {
      var electronics = _electronicDbContext.Electronics.ToList();
      return electronics;
    }
    
    public Electronic GetElectronic(Guid Id)
    {
      var electronic = _electronicDbContext.Electronics.Where(electronicData => electronicData.Id == Id).SingleOrDefault();
      return electronic;
    }
  }
}