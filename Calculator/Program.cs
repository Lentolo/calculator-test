using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
  public class Program
  {
    public static void Main(string[] args)
    {
      System.Diagnostics.Debugger.Break();
      if (args[0] == "interactive")
      {
        Console.WriteLine("First argument: ");
        var readLine = Console.ReadLine();

        Console.WriteLine("Second Argument: ");
        var secondArgoument = Console.ReadLine();

        Console.WriteLine("Result" + (int.Parse(readLine) + int.Parse(secondArgoument)));
      }
      else
      {
        var readAllText = System.IO.File.ReadAllText(args[0]);
        var strings = readAllText.Split("\r\n".ToCharArray());

        var firstArgument = strings[0];

        var secondArgoument = strings[1];

        Console.WriteLine("Result" + (int.Parse(firstArgument) + int.Parse(secondArgoument)));
      }
    }
  }
}
