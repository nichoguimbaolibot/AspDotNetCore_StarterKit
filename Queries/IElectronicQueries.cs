using System;
using System.Linq;
using ElectronicShop.Models;
using System.Collections.Generic;

namespace ElectronicShop.Queries
{
  public interface IElectronicQueries
  {
    IEnumerable<Electronic> GetElectronics();
    Electronic GetElectronic(Guid Id);
  }
}