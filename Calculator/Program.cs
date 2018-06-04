using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Calculator.Classes;
using Calculator.Data;
using Calculator.Interfaces;

namespace Calculator
{
  public class Program
  {
    public static IContainer InstancesBuilder;
    private static void Register()
    {
      var containerBuilder = new ContainerBuilder();
      //IStringParser
      containerBuilder.RegisterType<DefaultStringParser>().As<IStringParser>();
      //ICalculator
      containerBuilder.RegisterType<ConsoleCalculator>().As<ICalculator>();
      containerBuilder.RegisterType<FileCalculator>().As<ICalculator>();
      //IEngine
      containerBuilder.RegisterType<AddEngine>().As<IEngine>();
      containerBuilder.RegisterType<MultiplyEngine>().As<IEngine>();
      containerBuilder.RegisterType<DivideEngine>().As<IEngine>();
      containerBuilder.RegisterType<SubtractEngine>().As<IEngine>();
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

      UiResult data;
      IEngine engine;
      while (true)
      {
        data = calculator.ReadData();
        engine = InstancesBuilder.Resolve<IEnumerable<IEngine>>().FirstOrDefault(r => string.Compare(r.Operation, data.Operation, StringComparison.OrdinalIgnoreCase) == 0);
        if (engine == null)
        {
          throw new ArgumentOutOfRangeException("Engine not found!");
        }

        if (calculator.CheckData(engine, data))
        {
          break;
        }
      }

      calculator.DisplayResult(engine, data);
    }
  }
}