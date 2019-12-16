using System;
using System.Collections.Generic;
using System.Text;

namespace Day_12_2019_Code
{
    public class Moon
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int VelocityX { get; set; }
        public int VelocityY { get; set; }
        public int VelocityZ { get; set; }

        private int _gravity;

        public Moon(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Moon(int x, int y, int z, int velocityX, int velocityY, int velocityZ)
        {
            X = x;
            Y = y;
            Z = z;

            VelocityX = velocityX;
            VelocityY = velocityY;
            VelocityZ = velocityZ;
        }

        public int GetPotentialEnergy()
        {
            return Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);
        }

        public int GetKineticEnergy()
        {
            return Math.Abs(VelocityX) + Math.Abs(VelocityY) + Math.Abs(VelocityZ);
        }

        public int GetTotalEnergy()
        {
            return GetKineticEnergy() * GetPotentialEnergy();
        }


    }
}
