using Calculator.Data;

namespace Calculator.Interfaces
{
  public interface ICalculator
  {
    UiResult ReadData();
    void DisplayResult(IEngine engine, UiData data);
  }
}