using Calculator.Interfaces;

namespace Calculator.Classes
{
  public class AddEngine : IEngine
  {
    public string Operation => "+";
    public double Calculate(int first, int second)
    {
      return first + second;
    }
  }
}