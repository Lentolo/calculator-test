using Calculator.Data;
using Calculator.Interfaces;

namespace Calculator.Classes
{
  public class DivideEngine : IEngine
  {
    public string Operation => "/";
    public double Calculate(UiData DATA)
    {
      return DATA.First / (double) DATA.Second;
    }
    public bool CheckData(UiData data)
    {
      return data.Second != 0;
    }
  }
}