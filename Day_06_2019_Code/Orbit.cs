using System;
using System.Collections.Generic;
using System.Text;

namespace Day_06_2019_Code
{
    public class Orbit
    {

        public string parentPlanet { get; set; }

        // a child planet orbits a parent
        public string childPlanet { get; set; }

        public Orbit(string parent, string child)
        {
            parentPlanet = parent;
            childPlanet = child;
        }
    }
}
