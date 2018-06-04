using System;
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
      var rval = new UiResult
      {
          Operation = "+"
      };
      var readAllText = File.ReadAllText(_file);
      var strings = readAllText.Split("\r\n".ToCharArray());
      var val = Program.InstancesBuilder.Resolve<IStringParser>().Parse(strings.FirstOrDefault() ?? "");
      if (val == null)
      {
        throw new InvalidCastException();
      }

      rval.First = val.Value;
      val = Program.InstancesBuilder.Resolve<IStringParser>().Parse(strings.ElementAtOrDefault(1) ?? "");
      if (val == null)
      {
        throw new InvalidCastException();
      }

      rval.Second = val.Value;
      return rval;
    }
    public void DisplayResult(IEngine engine, UiData data)
    {
      Console.WriteLine("Result " + engine.Calculate(data.First, data.Second));
    }
  }
}