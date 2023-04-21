using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_v1
{
    internal class Rook : Piece
    {
        public bool moved = false;
        public Rook(int x, int y, string color) : base(x, y, color)
        {
            points = 5;
            name = "[" + color + "R]";
        }

        public bool GetMoved()
        {
            return moved;
        }
        public void Move(int y, int x, Board board)
        {
            if (board.cells[y, x].GetPiece().GetColor() != color)
            {
                if (this.x == x)
                {
                    int num = Math.Abs(this.y - y);
                    if (y > this.y)
                    {
                        for (int i = 1; i < num; i++)
                        {
                            if (board.cells[this.y + i, this.x].GetPiece().Name() != "[  ]")
                            {
                                Console.WriteLine("Illegal move!");
                                return;
                            }
                        }
                        //adding points
                        if (color == "W")
                            board.Wcounter += board.cells[y, x].GetPiece().GetPoints();
                        if (color == "B")
                            board.Bcounter += board.cells[y, x].GetPiece().GetPoints();

                        //change board 
                        board.cells[this.y, this.x].ChangePiece(new Empty(this.x, this.y, "E"));
                        this.y = this.y - (this.y - y);
                        this.x = this.x - (this.x - x);
                        board.cells[y, x].ChangePiece(this);
                        moved = true;
                        return;
                    }
                    if (y < this.y)
                    {
                        for (int i = 1; i < num; i++)
                        {
                            if (board.cells[this.y - i, this.x].GetPiece().Name() != "[  ]")
                            {
                                Console.WriteLine("Illegal move!");
                                return;
                            }
                        }
                        //adding points
                        if (color == "W")
                            board.Wcounter += board.cells[y, x].GetPiece().GetPoints();
                        if (color == "B")
                            board.Bcounter += board.cells[y, x].GetPiece().GetPoints();

                        //change board 
                        board.cells[this.y, this.x].ChangePiece(new Empty(this.x, this.y, "E"));
                        this.y = this.y - (this.y - y);
                        this.x = this.x - (this.x - x);
                        board.cells[y, x].ChangePiece(this);
                        moved = true;
                        return;

                    }
                }
                if (this.y == y)
                {
                    int num = Math.Abs(this.x - x);
                    if (x > this.x)
                    {
                        for (int i = 1; i < num; i++)
                        {
                            if (board.cells[this.y, this.x + i].GetPiece().Name() != "[  ]")
                            {
                                Console.WriteLine("Illegal move!");
                                return;
                            }
                        }
                        //adding points
                        if (color == "W")
                            board.Wcounter += board.cells[y, x].GetPiece().GetPoints();
                        if (color == "B")
                            board.Bcounter += board.cells[y, x].GetPiece().GetPoints();

                        //change board 
                        board.cells[this.y, this.x].ChangePiece(new Empty(this.x, this.y, "E"));
                        this.y = this.y - (this.y - y);
                        this.x = this.x - (this.x - x);
                        board.cells[y, x].ChangePiece(this);
                        moved = true;
                        return;
                    }
                    if (y < this.y)
                    {
                        for (int i = 1; i < num; i++)
                        {
                            if (board.cells[this.y, this.x - i].GetPiece().Name() != "[  ]")
                            {
                                Console.WriteLine("Illegal move!");
                                return;
                            }
                        }
                        //adding points
                        if (color == "W")
                            board.Wcounter += board.cells[y, x].GetPiece().GetPoints();
                        if (color == "B")
                            board.Bcounter += board.cells[y, x].GetPiece().GetPoints();

                        //change board 
                        board.cells[this.y, this.x].ChangePiece(new Empty(this.x, this.y, "E"));
                        this.y = this.y - (this.y - y);
                        this.x = this.x - (this.x - x);
                        board.cells[y, x].ChangePiece(this);
                        moved = true;
                        return;
                    }
                }

            }
            Console.WriteLine("Illegal move!");
        }

    }
}
