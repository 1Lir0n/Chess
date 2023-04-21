using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_v1
{
    internal class Cell
    {
        public string color;
        public int x, y;
        public Piece piece;

        public Cell(string color,int x,int y,Piece piece)
        {
            this.color = color;
            this.piece = piece;
            this.x = x;
            this.y = y;
        }

        public void ChangePiece(Piece piece)
        {
            this.piece = piece;
        }
        
        public Piece GetPiece()
        {
            return this.piece;
        }
        
        public string GetColor()
        {
            return this.color;
        }
        
        public override string ToString()
        {
            return piece.Name();
        }
    
    }
}
