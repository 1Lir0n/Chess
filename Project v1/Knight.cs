using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project_v1
{
    internal class Knight : Piece
    {
        public Knight(int x, int y, string color) : base(x, y, color)
        {
            points = 3;
            name = "[" + color + "N]";
        }

        public void Move(int y, int x, Board board)
        {
            if (board.cells[y, x].GetPiece().GetColor() != color)
            {
                //down
                if (y - 2 == this.y)
                {
                    //right
                    if (x - 1 == this.x)
                    {
                        if (color == "W")
                            board.Wcounter += board.cells[y, x].GetPiece().GetPoints();
                        if (color == "B")
                            board.Bcounter += board.cells[y, x].GetPiece().GetPoints();
                        board.cells[this.y, this.x].ChangePiece(new Empty(this.x, this.y, "E"));
                        this.y += 2;
                        this.x++;
                        board.cells[y, x].ChangePiece(this);
                        return;
                    }
                    
                    //left
                    if (x + 1 == this.x)
                    {
                        if (color == "W")
                            board.Wcounter += board.cells[y, x].GetPiece().GetPoints();
                        if (color == "B")
                            board.Bcounter += board.cells[y, x].GetPiece().GetPoints();
                        board.cells[this.y, this.x].ChangePiece(new Empty(this.x, this.y, "E"));
                        this.y += 2;
                        this.x--;
                        board.cells[y, x].ChangePiece(this);
                        return;
                    }
                }
                
                //up
                if (y + 2 == this.y)
                {
                    //right
                    if (x - 1 == this.x)
                    {
                        if (color == "W")
                            board.Wcounter += board.cells[y, x].GetPiece().GetPoints();
                        if (color == "B")
                            board.Bcounter += board.cells[y, x].GetPiece().GetPoints();
                        board.cells[this.y, this.x].ChangePiece(new Empty(this.x, this.y, "E"));
                        this.y += 2;
                        this.x++;
                        board.cells[y, x].ChangePiece(this);
                        return;
                    }
                    
                    //left
                    if (x + 1 == this.x)
                    {
                        if (color == "W")
                            board.Wcounter += board.cells[y, x].GetPiece().GetPoints();
                        if (color == "B")
                            board.Bcounter += board.cells[y, x].GetPiece().GetPoints();
                        board.cells[this.y, this.x].ChangePiece(new Empty(this.x, this.y, "E"));
                        this.y += 2;
                        this.x--;
                        board.cells[y, x].ChangePiece(this);
                        return;
                    }
                }

                //right
                if (x - 2 == this.x)
                {
                    //down
                    if (y - 1 == this.y)
                    {
                        if (color == "W")
                            board.Wcounter += board.cells[y, x].GetPiece().GetPoints();
                        if (color == "B")
                            board.Bcounter += board.cells[y, x].GetPiece().GetPoints();
                        board.cells[this.y, this.x].ChangePiece(new Empty(this.x, this.y, "E"));
                        this.x += 2;
                        this.y++;
                        board.cells[y, x].ChangePiece(this);
                        return;
                    }
                    
                    //up
                    if (y + 1 == this.y)
                    {
                        if (color == "W")
                            board.Wcounter += board.cells[y, x].GetPiece().GetPoints();
                        if (color == "B")
                            board.Bcounter += board.cells[y, x].GetPiece().GetPoints();
                        board.cells[this.y, this.x].ChangePiece(new Empty(this.x, this.y, "E"));
                        this.x += 2;
                        this.y--;
                        board.cells[y, x].ChangePiece(this);
                        return;
                    }
                }

                //left
                if (x + 2 == this.x)
                {
                    //down
                    if (y - 1 == this.y)
                    {
                        if (color == "W")
                            board.Wcounter += board.cells[y, x].GetPiece().GetPoints();
                        if (color == "B")
                            board.Bcounter += board.cells[y, x].GetPiece().GetPoints();
                        board.cells[this.y, this.x].ChangePiece(new Empty(this.x, this.y, "E"));
                        this.x += 2;
                        this.y++;
                        board.cells[y, x].ChangePiece(this);
                        return;
                    }
                    
                    //up
                    if (y + 1 == this.y)
                    {
                        if (color == "W")
                            board.Wcounter += board.cells[y, x].GetPiece().GetPoints();
                        if (color == "B")
                            board.Bcounter += board.cells[y, x].GetPiece().GetPoints();
                        board.cells[this.y, this.x].ChangePiece(new Empty(this.x, this.y, "E"));
                        this.x += 2;
                        this.y--;
                        board.cells[y, x].ChangePiece(this);
                        return;
                    }
                }
            }
            Console.WriteLine("Illegal move!");
        }

    }
}
