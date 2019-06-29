using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ElectronicShop.Datas;
using ElectronicShop.Models;

namespace ElectronicShop.Commands
{
  public class ElectronicCommands: IElectronicCommands
  {
    private readonly ElectronicDbContext _electronicDbContext;
    public ElectronicCommands(ElectronicDbContext electronicDbContext)
    {
      _electronicDbContext = electronicDbContext;
    }

    public Electronic CreateElectronic(ElectronicModel electronicData)
    {
      var electronics = new Electronic()
      {
        Id = Guid.Empty,
        Name = electronicData.Name,
        Price = electronicData.Price,
        Description = electronicData.Description
      };
      _electronicDbContext.Electronics.Add(electronics);
      _electronicDbContext.SaveChanges();
      return electronics;
    }
    public Electronic UpdateElectronicById(Guid id, ElectronicDescriptionModel electronicDescriptionData)
    {
      var electronic = _electronicDbContext.Electronics.Where(electronicData => electronicData.Id == id).SingleOrDefault();
      electronic.Description = electronicDescriptionData.Description;
      _electronicDbContext.Entry(electronic).State = EntityState.Modified;
      _electronicDbContext.SaveChanges();
      return electronic;
    }

    public Electronic DeleteElectronicById(Guid id)
    {
      var electronic = _electronicDbContext.Electronics.Find(id);
      if (electronic == null)
      {
        return electronic;
      }
      _electronicDbContext.Electronics.Remove(electronic);
      _electronicDbContext.SaveChanges();
      return electronic;
    }
  }
}