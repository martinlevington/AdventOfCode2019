using System;
using System.Collections.Generic;
using System.Text;

namespace SharedCode
{
    public interface IAreaSize
    {
        int GetMinX();
        int GetMaxX();
        int GetMaxY();
        int GetMinY();
        void AddElement((int,int) position, char element);
        bool  ElementExists((int, int) position);
        char GetElement((int, int) position);
    }
}
