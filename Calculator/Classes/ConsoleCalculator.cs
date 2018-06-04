using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Calculator.Data;
using Calculator.Interfaces;

namespace Calculator.Classes
{
  public class ConsoleCalculator : ICalculator
  {
    public bool UseMe(string[] argv)
    {
      return string.Compare((argv ?? new string[0]).FirstOrDefault(), "interactive", StringComparison.OrdinalIgnoreCase) == 0;
    }
    public UiResult ReadData()
    {
      var rval = new UiResult
      {
          Operation = "+"
      };
      var actionsArray = new[]
      {
          new
          {
              Text = "First argument: ",
              ErrorMessage = "Invalid value [{0}]",
              Parser = (Func<string, bool>) (str =>
                                              {
                                                var val = Program.InstancesBuilder.Resolve<IStringParser>().Parse(str);
                                                if (val != null)
                                                {
                                                  rval.First = val.Value;
                                                  return true;
                                                }

                                                return false;
                                              })
          },
          new
          {
              Text = "Operation: ",
              ErrorMessage = "Invalid operation [{0}]",
              Parser = (Func<string, bool>) (str =>
                                              {
                                                if (Program.InstancesBuilder.Resolve<IEnumerable<IEngine>>().Any(i => string.Compare(i.Operation, str, StringComparison.OrdinalIgnoreCase) == 0))
                                                {
                                                  rval.Operation = str;
                                                  return true;
                                                }

                                                return false;
                                              })
          },
          new
          {
              Text = "Second argument: ",
              ErrorMessage = "Invalid value [{0}]",
              Parser = (Func<string, bool>) (str =>
                                              {
                                                var val = Program.InstancesBuilder.Resolve<IStringParser>().Parse(str);
                                                if (val != null)
                                                {
                                                  rval.Second = val.Value;
                                                  return true;
                                                }

                                                return false;
                                              })
          }
      };
      foreach (var i in actionsArray)
      {
        while (true)
        {
          Console.WriteLine(i.Text);
          var str = Console.ReadLine();
          if (i.Parser(str))
          {
            break;
          }

          Console.WriteLine(i.ErrorMessage, str);
        }
      }

      return rval;
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
    public void DisplayResult(IEngine engine, UiData data)
    {
      Console.WriteLine("Result " + engine.Calculate(data));
      Console.ReadLine();
    }
  }
}