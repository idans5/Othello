using System.Collections.Generic;
using System.Drawing;

namespace Othello
{
    public class Directions
    {
        public List<Point> m_DirectionList = new List<Point>();

        public Directions()
        {
            Point north = new Point(-1, 0);
            m_DirectionList.Add(north);
            Point south = new Point(1, 0);
            m_DirectionList.Add(south);
            Point west = new Point(0, -1);
            m_DirectionList.Add(west);
            Point east = new Point(0, 1);
            m_DirectionList.Add(east);
            Point northEast = new Point(-1, 1);
            m_DirectionList.Add(northEast);
            Point northWest = new Point(-1, -1);
            m_DirectionList.Add(northWest);
            Point southEast = new Point(1, 1);
            m_DirectionList.Add(southEast);
            Point southWest = new Point(1, -1);
            m_DirectionList.Add(southWest);
        }
    }
}