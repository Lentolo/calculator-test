using System;
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
              Setter = (Action<int>) (v => rval.First = v)
          },
          new
          {
              Text = "Second argument: ",
              Setter = (Action<int>) (v => rval.Second = v)
          }
      };
      foreach (var i in actionsArray)
      {
        while (true)
        {
          Console.WriteLine(i.Text);
          var str = Console.ReadLine();
          var val = Program.InstancesBuilder.Resolve<IStringParser>().Parse(str);
          if (val != null)
          {
            i.Setter(val.Value);
            break;
          }

          Console.WriteLine($"Invalid value [{str}]");
        }
      }

      return rval;
    }
    public void DisplayResult(IEngine engine, UiData data)
    {
      Console.WriteLine("Result " + engine.Calculate(data.First, data.Second));
    }
  }
}