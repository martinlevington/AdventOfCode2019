namespace Day_06_2019_Code
{
    public class Orbit
    {
        public Orbit(string parent, string child)
        {
            ParentPlanet = parent;
            ChildPlanet = child;
        }

        public string ParentPlanet { get; set; }

        // a child planet orbits a parent
        public string ChildPlanet { get; set; }
    }
}