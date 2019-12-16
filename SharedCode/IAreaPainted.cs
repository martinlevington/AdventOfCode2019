namespace SharedCode
{
    public interface IAreaPainted
    {
        void PaintSquare((int, int) coordinates, PaintColour colour);
        bool IsPainted((int, int) position);
        PaintColour GetPaintedSquareColour((int, int) position);
        int GetNumberOfPaintedPanels();
    }
}