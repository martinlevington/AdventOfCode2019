using System;
using System.Linq;

namespace SharedCode
{
    public class OpCodeInstruction
    {
        private long _opcode;
        private long _parameterModeA;
        private long _parameterModeB;
        private long _parameterModeC;


        public OpCodeInstruction(long instruction)
        {

            var parts = instruction.ToString().Select(x => Convert.ToInt64(x.ToString()))
                .Reverse().ToArray();
            _opcode = parts.Length >= 2 ? Convert.ToInt64(parts[1].ToString() + parts[0].ToString()) : Convert.ToInt64(parts[0].ToString());

            if (parts.Length >= 3) _parameterModeC = parts[2];
            if (parts.Length >= 4) _parameterModeB = parts[3];
            if (parts.Length >= 5) _parameterModeA = parts[4];




        }

        public long GetOpCode()
        {
            return _opcode;
        }



        public ReadMode Parameter1Mode()
        {
            if (_parameterModeC == 0) return ReadMode.Position;
            if (_parameterModeC == 1) return ReadMode.Immediate;
            if (_parameterModeC == 2) return ReadMode.Offset;

            throw new Exception("Error: Unknown Mode fpr Paremeter 1");

        }

        public ReadMode Parameter2Mode()
        {
            if (_parameterModeB == 0) return ReadMode.Position;
            if (_parameterModeB == 1) return ReadMode.Immediate;
            if (_parameterModeB == 2) return ReadMode.Offset;

            throw new Exception("Error: Unknown Mode fpr Paremeter 2");

        }

        public ReadMode Parameter3Mode()
        {
            if (_parameterModeA == 0) return ReadMode.Position;
            if (_parameterModeA == 1) return ReadMode.Immediate;
            if (_parameterModeA == 2) return ReadMode.Offset;

            throw new Exception("Error: Unknown Mode fpr Paremeter 3");

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
