using Calculator.Data;

namespace Calculator.Interfaces
{
  public interface IEngine : IOperation
  {
    double Calculate(Data.UiData data);
    bool CheckData(Data.UiData data);
  }
}