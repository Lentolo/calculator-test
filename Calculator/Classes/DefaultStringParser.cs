using Calculator.Interfaces;

namespace Calculator.Classes
{
  public class DefaultStringParser : IStringParser
  {
    public int? Parse(string input)
    {
      if (int.TryParse(input, out var rval))
      {
        return rval;
      }

      return null;
    }
  }
}