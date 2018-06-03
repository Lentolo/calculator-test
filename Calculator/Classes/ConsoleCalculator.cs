using System;
using Calculator.Data;
using Calculator.Interfaces;

namespace Calculator.Classes
{
  public class ConsoleCalculator : Interfaces.ICalculator
  {
    public UiResult ReadData()
    {
      Console.WriteLine("First argument: ");
      var readLine = Console.ReadLine();
      Console.WriteLine("Second Argument: ");
      var secondArgoument = Console.ReadLine();
      return new UiResult
      {
          Operation = "+"
      };
    }
    public void DisplayResult(IEngine engine, UiData data)
    {
      throw new System.NotImplementedException();
    }
  }
}