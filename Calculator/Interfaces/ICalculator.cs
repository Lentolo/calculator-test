using Calculator.Data;

namespace Calculator.Interfaces
{
  public interface ICalculator
  {
    bool UseMe(string[] argv);
    UiResult ReadData();
    void DisplayResult(IEngine engine, UiData data);
  }
}