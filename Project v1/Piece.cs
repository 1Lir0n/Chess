using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_v1
{
    internal class Piece 
    {
        public string color;
        public string name;
        public int x, y;
        public int points;
        public bool moved = false;

        public Piece(int x, int y, string color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }

        public int GetPoints()
        {
            return points;
        }

        public string GetColor()
        {
            return color;
        }

        public string Name()
        {
            return name;
        }
    
    }
}
