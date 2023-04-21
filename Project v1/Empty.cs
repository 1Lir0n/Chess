using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_v1
{
    internal class Empty : Piece
    {
        public Empty(int x,int y,string color) : base(x,y,color) 
        {
            points = 0;
            this.name = "[  ]";
        }

    }
}
