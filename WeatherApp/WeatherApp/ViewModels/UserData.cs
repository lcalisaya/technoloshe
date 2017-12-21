using System;
using System.Collections.Generic;
using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
  public abstract class ViewModelBase
  {
    public String UserName { get; set; }
  }

  public class HomeViewModel : ViewModelBase
  {
  }
}
