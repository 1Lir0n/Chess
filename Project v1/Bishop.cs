using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_v1
{
    internal class Bishop : Piece
    {
        public Bishop(int x, int y, string color) : base(x, y, color)
        {
            points = 2;
            name = "[" + color + "B]";
        }

        public void Move(int y, int x, Board board)
        {
            if (board.cells[y, x].GetPiece().GetColor() != color)
            {

                int num = Math.Abs(this.y - y);//4
                if (num == Math.Abs(this.x - x))//4 true
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
