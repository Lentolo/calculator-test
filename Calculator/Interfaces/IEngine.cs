namespace Calculator.Interfaces
{
  public interface IEngine : IOperation
  {
    double Calculate(int first, int second);
  }
}