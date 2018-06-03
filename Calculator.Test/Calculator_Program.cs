using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculator.Test
{
  public class Calculator_Program
  {
    [Fact]
    void Main_Interactive()
    {
      using (var output = new System.IO.StringWriter())
      {
        using (var input = new System.IO.StringReader("5\r\n3\r\n"))
        {
          Console.SetOut(output);
          Console.SetIn(input);
          Calculator.Program.Main(new[] { "interactive" });
          Assert.Equal("First argument: \r\nSecond Argument: \r\nResult8\r\n", output.ToString());
        }
      }
    }
    [Fact]
    void Main_TestFile()
    {
      using (var output = new System.IO.StringWriter())
      {
        Console.SetOut(output);
        Calculator.Program.Main(new[] { "testfile.txt" });
        Assert.Equal("Result13\r\n", output.ToString());
      }
    }
  }
}
