using System;
using System.Collections.Generic;
using System.Text;

namespace SharedCode
{
    public interface IAreaPainted
    {
        void PaintSquare((int , int) cordinates, PaintColour colour);
        bool IsPainted((int,int) position);
        PaintColour GetPaintedSquareColour((int,int) position);
        int  GetNumberOfPaintedPanels();
    }
}
