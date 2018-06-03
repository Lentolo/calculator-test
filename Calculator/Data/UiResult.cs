using Calculator.Interfaces;

namespace Calculator.Data
{
  public class UiResult : UiData, IOperation
  {
    public string Operation
    {
      get;
      set;
    }
  }
}