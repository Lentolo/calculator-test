using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Autofac;
using Calculator.Data;
using Calculator.Interfaces;

namespace Calculator.Classes
{
  public class FileCalculator : ICalculator
  {
    private string _file = "";
    public bool UseMe(string[] argv)
    {
      _file = (argv ?? new string[0]).FirstOrDefault() ?? "";
      return File.Exists(_file);
    }
    public UiResult ReadData()
    {
      var rval = new UiResult();
      var readAllText = File.ReadAllText(_file);
      var strings = readAllText.Split("\r\n".ToCharArray());
      var val = Program.InstancesBuilder.Resolve<IStringParser>().Parse(strings.FirstOrDefault() ?? "");
      if (val == null)
      {
        throw new InvalidCastException();
      }

      rval.First = val.Value;
      rval.Operation = strings.ElementAtOrDefault(1) ?? "";
      if (!Program.InstancesBuilder.Resolve<IEnumerable<IEngine>>().Any(i => string.Compare(i.Operation, rval.Operation, StringComparison.OrdinalIgnoreCase) == 0))
      {
        throw new InvalidOperationException();
      }

      val = Program.InstancesBuilder.Resolve<IStringParser>().Parse(strings.ElementAtOrDefault(2) ?? "");
      if (val == null)
      {
        throw new InvalidCastException();
      }

      rval.Second = val.Value;
      return rval;
    }
    public void DisplayResult(IEngine engine, UiData data)
    {
      Console.WriteLine("Result " + engine.Calculate(data));
    }
    public bool CheckData(IEngine engine, UiData data)
    {
      if (!engine.CheckData(data))
      {
        Console.WriteLine($"Invalid data for the operator [{engine.Operation}]");
        return false;
      }

      return true;
    }
  }
}