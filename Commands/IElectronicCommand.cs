using System;
using System.Collections.Generic;
using ElectronicShop.Models;

namespace ElectronicShop.Commands
{
  public interface IElectronicCommands
  {
      Electronic CreateElectronic(ElectronicModel electronicData);
      Electronic UpdateElectronicById(Guid id, ElectronicDescriptionModel electronicDescriptionData);
      Electronic DeleteElectronicById(Guid id);
  }
}