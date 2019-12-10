using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day_07_2019_Code
{
    public class OpCodeInstruction
    {
        private int _opcode;
        private int _parameterModeA;
        private int _parameterModeB;
        private int _parameterModeC;
        

        public  OpCodeInstruction(int instruction)
        {
      
            var parts = instruction.ToString().Select(x => Convert.ToInt32(x.ToString()))
                .Reverse().ToArray();
            _opcode = parts.Length >= 2 ? Convert.ToInt32(parts[1].ToString() + parts[0].ToString()) : Convert.ToInt32(parts[0].ToString());

            if (parts.Length >= 3) _parameterModeC = parts[2];
            if (parts.Length >= 4) _parameterModeB = parts[3];
            if (parts.Length >= 5) _parameterModeA = parts[4];




        }

        public int GetOpCode()
        {
            return _opcode;
        }

        public bool IsPositionMode(char position)
        {
            switch (position)
            {
                case 'A':
                    return _parameterModeA == 0;
                case 'B':
                    return _parameterModeB == 0;
                case 'C':
                    return _parameterModeC == 0;
                default:
                    throw new Exception("Error Unknown Mode");
            }

            
        }

    }
}
