using System;
using System.Collections.Generic;
using System.Text;
using SharedCode;

namespace Day_11_2019_Code
{
    public  class PaintLayer
    {
        private List<PaintColour> _layers = new List<PaintColour>();

        public void AddLayer(PaintColour layer)
        {
            _layers.Add(layer);
        }

        public int GetNumberOfLayers()
        {
            return _layers.Count;
        }

        public PaintColour GetColour()
        {
            return _layers[_layers.Count-1];
        }

    }
}
