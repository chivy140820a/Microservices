﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructures.Viewmodel
{
  public class CatalogProductViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal LastPrice { get; set; }
    public string PathImage { get; set; }
  }
}
