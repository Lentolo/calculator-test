﻿using Calculator.Data;
using Calculator.Interfaces;

namespace Calculator.Classes
{
  public class AddEngine : IEngine
  {
    public string Operation => "+";
    public double Calculate(UiData data)
    {
      return data.First + data.Second;
    }
    public bool CheckData(UiData data)
    {
      return true;
    }
  }
}