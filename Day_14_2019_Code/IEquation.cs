using System.Collections.Generic;

namespace Day_14_2019_Code
{
    public interface IEquation
    {
        List<IEquationElement> Inputs { get;  }
        IEquationElement Output { get; }

    }
}