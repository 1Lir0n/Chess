using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_v1
{
    internal class Queen : Piece
    {
        public Queen(int x, int y, string color) : base(x, y, color)
        {
            points = 9;
            name = "[" + color + "Q]";
        }

        public void Move(int y, int x, Board board)
        {
            if (board.cells[y, x].GetPiece().GetColor() != color)
            {
                //rook like moves
                //horizontal
                if (this.x == x)
                {
                    int num1 = Math.Abs(this.y - y);
                    if (y > this.y)
                    {
                        for (int i = 1; i < num1; i++)
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
                        for (int i = 1; i < num1; i++)
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
                //vertical
                if (this.y == y)
                {
                    int num1 = Math.Abs(this.x - x);
                    if (x > this.x)
                    {
                        for (int i = 1; i < num1; i++)
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
                        for (int i = 1; i < num1; i++)
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


                //bishop like moves

                int num = Math.Abs(this.y - y);
                if (num == Math.Abs(this.x - x))
                {
                    //down right
                    if (this.y < y && this.x < x)
                    {
                        for (int i = 1; i < num; i++)
                        {
                            if (board.cells[this.y + i, this.x + i].GetPiece().Name() != "[  ]")
                            {
                                Console.WriteLine("Illegal move!");
                                return;
                            }
                        }
                    }
                    //down left
                    if (this.y < y && this.x > x)
                    {
                        for (int i = 1; i < num; i++)
                        {
                            if (board.cells[this.y + i, this.x - i].GetPiece().Name() != "[  ]")
                            {
                                Console.WriteLine("Illegal move!");
                                return;
                            }
                        }
                    }
                    //up right
                    if (this.y > y && this.x < x)
                    {
                        for (int i = 1; i < num; i++)
                        {
                            if (board.cells[this.y - i, this.x + i].GetPiece().Name() != "[  ]")
                            {
                                Console.WriteLine("Illegal move!");
                                return;
                            }
                        }
                    }
                    //up left
                    if (this.y > y && this.x > x)
                    {
                        for (int i = 1; i < num; i++)
                        {
                            if (board.cells[this.y - i, this.x - i].GetPiece().Name() != "[  ]")
                            {
                                Console.WriteLine("Illegal move!");
                                return;
                            }
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
                    return;
                }
            }
            Console.WriteLine("Illegal move!");
        }

    }
}
