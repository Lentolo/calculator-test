using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Calculator.Classes;
using Calculator.Interfaces;

namespace Calculator
{
  public class Program
  {
    public static IContainer InstancesBuilder;
    private static void Register()
    {
      var containerBuilder = new ContainerBuilder();
      containerBuilder.RegisterType<DefaultStringParser>().As<IStringParser>();
      containerBuilder.RegisterType<ConsoleCalculator>().As<ICalculator>();
      containerBuilder.RegisterType<FileCalculator>().As<ICalculator>();
      containerBuilder.RegisterType<AddEngine>().As<IEngine>();
      InstancesBuilder = containerBuilder.Build();
    }
    public static void Main(string[] args)
    {
      Register();
      var calculator = InstancesBuilder.Resolve<IEnumerable<ICalculator>>().FirstOrDefault(r => r.UseMe(args));
      if (calculator == null)
      {
        throw new ArgumentOutOfRangeException("Calculator not found!");
      }

      var data = calculator.ReadData();
      var engine = InstancesBuilder.Resolve<IEnumerable<IEngine>>().FirstOrDefault(r => string.Compare(r.Operation, data.Operation, StringComparison.OrdinalIgnoreCase) == 0);
      if (engine == null)
      {
        throw new ArgumentOutOfRangeException("Engine not found!");
      }

      calculator.DisplayResult(engine, data);
    }
  }
}