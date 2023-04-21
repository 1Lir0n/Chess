using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_v1
{
    internal class King : Piece
    {
        bool moved = false;
        public King(int x, int y, string color) : base(x, y, color)
        {
            name = "[" + color + "K]";
            points = 100;
        }

        //castle
        public bool Castle(int x,int y,Board board)
        {
            //castle king side
            //checks if king and rook didnt moved 
            if(this.x<x)
            if (!moved && !((Rook)board.cells[y,7].GetPiece()).GetMoved())
            {
                board.cells[y, 6].ChangePiece(this);
                board.cells[y, 5].ChangePiece((Rook)board.cells[0, 7].GetPiece());
                board.cells[y, 4].ChangePiece(new Empty(4, y, "E"));
                board.cells[y, 7].ChangePiece(new Empty(7, y, "E"));
                this.x = 6;
                ((Rook)board.cells[y, 5].GetPiece()).x = 5;
                ((Rook)board.cells[y, 5].GetPiece()).moved = true;
                moved = true;
                return true;
            }
            //castle queen side
            if(this.x>x)
                if (!moved && !((Rook)board.cells[y, 0].GetPiece()).GetMoved())
                {
                    board.cells[y, 1].ChangePiece(this);
                    board.cells[y, 2].ChangePiece((Rook)board.cells[0, 0].GetPiece());
                    board.cells[y, 4].ChangePiece(new Empty(4, y, "E"));
                    board.cells[y, 0].ChangePiece(new Empty(7, y, "E"));
                    this.x = 6;
                    ((Rook)board.cells[y, 2].GetPiece()).x = 2;
                    ((Rook)board.cells[y, 2].GetPiece()).moved = true;
                    moved = true;
                    return true;
                }

            return false;
        }
        public void Move(int y, int x, Board board)
        {
            if (board.cells[y, x].GetPiece().GetColor() != color)
            {
                //down
                if (this.y == y + 1 && this.x == x)
                {
                    if (color == "W")
                        board.Wcounter += board.cells[y, x].GetPiece().GetPoints();
                    if (color == "B")
                        board.Bcounter += board.cells[y, x].GetPiece().GetPoints();
                    board.cells[this.y, this.x].ChangePiece(new Empty(this.x, this.y, "E"));
                    this.y -= 1;
                    board.cells[y, x].ChangePiece(this);
                    moved = true;
                    return;
                }

                //up
                if (this.y == y - 1 && this.x == x)
                {
                    if (color == "W")
                        board.Wcounter += board.cells[y, x].GetPiece().GetPoints();
                    if (color == "B")
                        board.Bcounter += board.cells[y, x].GetPiece().GetPoints();
                    board.cells[this.y, this.x].ChangePiece(new Empty(this.x, this.y, "E"));
                    this.y += 1;
                    board.cells[y, x].ChangePiece(this);
                    moved = true;
                    return;
                }

                //down right
                if (this.y == y + 1 && this.x == x - 1)
                {
                    if (color == "W")
                        board.Wcounter += board.cells[y, x].GetPiece().GetPoints();
                    if (color == "B")
                        board.Bcounter += board.cells[y, x].GetPiece().GetPoints();
                    board.cells[this.y, this.x].ChangePiece(new Empty(this.x, this.y, "E"));
                    this.y -= 1;
                    this.x += 1;
                    board.cells[y, x].ChangePiece(this);
                    moved = true;
                    return;
                }

                //up right
                if (this.y == y - 1 && this.x == x - 1)
                {
                    if (color == "W")
                        board.Wcounter += board.cells[y, x].GetPiece().GetPoints();
                    if (color == "B")
                        board.Bcounter += board.cells[y, x].GetPiece().GetPoints();
                    board.cells[this.y, this.x].ChangePiece(new Empty(this.x, this.y, "E"));
                    this.y += 1;
                    this.x += 1;
                    board.cells[y, x].ChangePiece(this);
                    moved = true;
                    return;
                }

                //down left
                if (this.y == y + 1 && this.x == x + 1)
                {
                    if (color == "W")
                        board.Wcounter += board.cells[y, x].GetPiece().GetPoints();
                    if (color == "B")
                        board.Bcounter += board.cells[y, x].GetPiece().GetPoints();
                    board.cells[this.y, this.x].ChangePiece(new Empty(this.x, this.y, "E"));
                    this.y -= 1;
                    this.x -= 1;
                    board.cells[y, x].ChangePiece(this);
                    moved = true;
                    return;
                }

                //up left
                if (this.y == y - 1 && this.x == x + 1)
                {
                    if (color == "W")
                        board.Wcounter += board.cells[y, x].GetPiece().GetPoints();
                    if (color == "B")
                        board.Bcounter += board.cells[y, x].GetPiece().GetPoints();
                    board.cells[this.y, this.x].ChangePiece(new Empty(this.x, this.y, "E"));
                    this.y += 1;
                    this.x -= 1;
                    board.cells[y, x].ChangePiece(this);
                    moved = true;
                    return;
                }

                //right
                if (this.y == y && this.x == x - 1)
                {
                    if (color == "W")
                        board.Wcounter += board.cells[y, x].GetPiece().GetPoints();
                    if (color == "B")
                        board.Bcounter += board.cells[y, x].GetPiece().GetPoints();
                    board.cells[this.y, this.x].ChangePiece(new Empty(this.x, this.y, "E"));
                    this.x += 1;
                    board.cells[y, x].ChangePiece(this);
                    moved = true;
                    return;
                }

                //left
                if (this.y == y && this.x == x + 1)
                {
                    if (color == "W")
                        board.Wcounter += board.cells[y, x].GetPiece().GetPoints();
                    if (color == "B")
                        board.Bcounter += board.cells[y, x].GetPiece().GetPoints();
                    board.cells[this.y, this.x].ChangePiece(new Empty(this.x, this.y, "E"));
                    this.x -= 1;
                    board.cells[y, x].ChangePiece(this);
                    moved = true;
                    return;
                }

                Console.WriteLine(y+"y "+x+"x ");
                //castle black king side
                if (y == 0 && x == 6 && !moved)
                    if (Castle(x,y,board)) return;
                
                //castle black queen side
                if (y == 0 && x == 1 && !moved)
                    if (Castle(x,y,board)) return;
               
                //castle white king side
                if (y == 7 && x == 6 && !moved)
                    if (Castle(x,y,board)) return;
                
                //castle white queen side
                if (y == 7 && x == 1 && !moved)
                    if(Castle(x, y,board)) return;
            }
            Console.WriteLine("Illegal move!");
        }

    }
}
