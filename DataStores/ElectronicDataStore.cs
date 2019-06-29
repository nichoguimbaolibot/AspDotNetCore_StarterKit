using System;
using System.Collections.Generic;
using ElectronicShop.Models;
using System.Threading.Tasks;

namespace ElectronicShop.DataStores
{
  public class ElectronicsDataStore
  {
    public static ElectronicsDataStore Current { get; set; } = new ElectronicsDataStore();
    public List<Electronic> Electronics { get; set; }
    
    public ElectronicsDataStore()
    {
      Electronics = new List<Electronic>()
      {
        new Electronic {
          Id = Guid.NewGuid(),
          Name = "Aircon",
          Description = "Sa sobrang lamig kayang palamigin ang nag babagang kalan niyo, kaso wala pa din mas lalamig sa ex ko.",
          Price = 99.99M,
        },
        new Electronic {
          Id = Guid.NewGuid(),
          Name = "Washing machine",
          Description = "Kayang paikutin ang mundo mo, parang pag papaikot sayo ng ex mo.",
          Price = 199.99M,
        },
        new Electronic {
          Id = Guid.NewGuid(),
          Name = "Dryer",
          Description = "Kayang patuyuin ang damit mo kasing bilis ng pag papatuyo sayo ng girlfriend mo.",
          Price = 199.99M,
        },
      };
    }
  }
}