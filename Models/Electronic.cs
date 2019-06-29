using System;

namespace ElectronicShop.Models
{
  public class Electronic
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
  }
}