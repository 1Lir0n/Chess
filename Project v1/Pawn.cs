using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_v1
{
    internal class Pawn : Piece
    {
        public bool enPassant=false;

        public Pawn(int x, int y, string color) : base(x, y, color)
        {
            points = 1;
            name = "[" + color + "P]";

        }

        public void Promote(Board board)
        {
            //white promote
            if (color == "W" && y == 0)
            {
                Console.WriteLine("Choose promotion: Rook,Knight,Bishop,Queen.");
                string promo = Console.ReadLine();
                if (promo.ToUpperInvariant() == ("rook").ToUpperInvariant())
                {
                    board.cells[y, x].ChangePiece(new Rook(x, y, "W"));
                }
                if (promo.ToUpperInvariant() == ("knight").ToUpperInvariant())
                {
                    board.cells[y, x].ChangePiece(new Knight(x, y, "W"));
                }
                if (promo.ToUpperInvariant() == ("bishop").ToUpperInvariant())
                {
                    board.cells[y, x].ChangePiece(new Bishop(x, y, "W"));
                }
                if (promo.ToUpperInvariant() == ("queen").ToUpperInvariant())
                {
                    board.cells[y, x].ChangePiece(new Queen(x, y, "W"));
                }
            }

            //black promote
            if (color == "B" && y == 7)
            {
                Console.WriteLine("Choose promotion: Rook,Knight,Bishop,Queen.");
                string promo = Console.ReadLine();
                if (promo.ToUpperInvariant() == ("rook").ToUpperInvariant())
                {
                    board.cells[y, x].ChangePiece(new Rook(x, y, "B"));
                }
                if (promo.ToUpperInvariant() == ("knight").ToUpperInvariant())
                {
                    board.cells[y, x].ChangePiece(new Knight(x, y, "B"));
                }
                if (promo.ToUpperInvariant() == ("bishop").ToUpperInvariant())
                {
                    board.cells[y, x].ChangePiece(new Bishop(x, y, "B"));
                }
                if (promo.ToUpperInvariant() == ("queen").ToUpperInvariant())
                {
                    board.cells[y, x].ChangePiece(new Queen(x, y, "B"));
                }
            }
        }

        public void EnPassant(int x,int y,Board board)
        {
            Console.WriteLine(((Pawn)board.cells[this.y, x].GetPiece()).enPassant);
            if (x - 1 == this.x)
            {
                if (board.cells[y,x].GetPiece().Name()=="[  ]" && ((Pawn)board.cells[this.y, x].GetPiece()).enPassant)
                {
                    
                    //points
                    if (color == "W")
                        board.Wcounter += 1;
                    if (color == "B")
                        board.Bcounter += 1;

                    //board change
                    board.cells[this.y, this.x].ChangePiece(new Empty(this.x, this.y, "E"));
                    board.cells[this.y, x].ChangePiece(new Empty(x, this.y, "E"));
                    this.y = this.y - (this.y - y);
                    this.x = this.x - (this.x - x);
                    board.cells[y, x].ChangePiece(this);
                }
            }
            if (x + 1 == this.x)
            {
                if (board.cells[y, x].GetPiece().Name() == "[  ]" && ((Pawn)board.cells[this.y, x].GetPiece()).enPassant)
                {
                    //points
                    if (color == "W")
                        board.Wcounter += 1;
                    if (color == "B")
                        board.Bcounter += 1;

                    //board change
                    board.cells[this.y, this.x].ChangePiece(new Empty(this.x, this.y, "E"));
                    board.cells[this.y, x].ChangePiece(new Empty(x, this.y, "E"));
                    this.y = this.y - (this.y - y);
                    this.x = this.x - (this.x - x);
                    board.cells[y, x].ChangePiece(this);
                }
            }
        }

        public void Move(int y, int x, Board board)
        {
            if (board.cells[y, x].GetPiece().GetColor() != color)
            {
                //check color
                if (color == "W")
                {
                    //making sure its forward by 1 or 2 if its first move
                    if ((y + 1 == this.y && ((x == this.x && board.cells[y, x].GetPiece().Name() == "[  ]") || ((x + 1 == this.x || x - 1 == this.x) && board.cells[y, x].GetPiece().Name() != "[  ]"))) || (y + 2 == this.y && this.y == 6 && (x == this.x && board.cells[y, x].GetPiece().Name() == "[  ]")))
                    {
                        if (y + 2 == this.y)
                            enPassant = true;
                        else enPassant = false;
                        //points
                        board.Wcounter += board.cells[y, x].GetPiece().GetPoints();

                        //board change
                        board.cells[this.y, this.x].ChangePiece(new Empty(this.x, this.y, "E"));
                        this.y = this.y - (this.y - y);
                        this.x = this.x - (this.x - x);
                        board.cells[y, x].ChangePiece(this);
                        this.Promote(board);
                        return;
                    }

                    if (this.y == 3 && (x-1==this.x||x+1==this.x))
                    {
                        Console.WriteLine("EN PASSANT");
                        this.EnPassant(x,y, board);
                        return;
                    }

                }

                if (color == "B")
                {
                    //making sure its forward by 1 or 2 if its first move
                    if ((y - 1 == this.y && ((x == this.x && board.cells[y, x].GetPiece().Name() == "[  ]") || ((x + 1 == this.x || x - 1 == this.x) && board.cells[y, x].GetPiece().Name() != "[  ]"))) || (y - 2 == this.y && this.y == 1 && (x == this.x && board.cells[y, x].GetPiece().Name() == "[  ]")))
                    {
                        if (y + 2 == this.y)
                            enPassant = true;
                        else enPassant = false;
                        //points
                        board.Bcounter += board.cells[y, x].GetPiece().GetPoints();

                        //board change
                        board.cells[this.y, this.x].ChangePiece(new Empty(this.x, this.y, "E"));
                        this.y = this.y - (this.y - y);
                        this.x = this.x - (this.x - x);
                        board.cells[y, x].ChangePiece(this);
                        this.Promote(board);
                        return;
                    }
                    if (this.y == 4 && (x - 1 == this.x || x + 1 == this.x))
                    {
                        this.EnPassant(x, y, board);
                        return;
                    }
                }

            }
            Console.WriteLine("Illegal move!");
        }

    }
}
