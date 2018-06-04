using Calculator.Data;

namespace Calculator.Interfaces
{
  public interface ICalculator
  {
    bool UseMe(string[] argv);
    UiResult ReadData();
    bool CheckData(IEngine engine, UiData data);
    void DisplayResult(IEngine engine, UiData data);
  }
}