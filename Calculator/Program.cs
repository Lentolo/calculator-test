using System;
using System.IO;
using Autofac;

namespace Calculator
{
  public class Program
  {
    public static IContainer InstancesBuyilder; 
    static void Register()
    {
      var b=new Autofac.ContainerBuilder();
      b.RegisterType<Classes.ConsoleCalculator>().Keyed<Interfaces.ICalculator>("interactive");
      InstancesBuyilder=b.Build();
    }
    public static void Main(string[] args)
    {
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
        var readAllText = File.ReadAllText(args[0]);
        var strings = readAllText.Split("\r\n".ToCharArray());
        var firstArgument = strings[0];
        var secondArgoument = strings[1];
        Console.WriteLine("Result" + (int.Parse(firstArgument) + int.Parse(secondArgoument)));
      }
    }
  }
}