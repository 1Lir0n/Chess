using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_v1
{
    internal class Board
    {
        public Cell[,] cells;
        public int Wcounter = 0, Bcounter = 0;

        //white pawns
        Pawn[] WPawns = new Pawn[8] { new Pawn(0, 6, "W"), new Pawn(1, 6, "W"), new Pawn(2, 6, "W"), new Pawn(3, 6, "W"), new Pawn(4, 6, "W"), new Pawn(5, 6, "W"), new Pawn(6, 6, "W"), new Pawn(7, 6, "W") };

        //black pawns
        Pawn[] BPawns = new Pawn[8] { new Pawn(0, 1, "B"), new Pawn(1, 1, "B"), new Pawn(2, 1, "B"), new Pawn(3, 1, "B"), new Pawn(4, 1, "B"), new Pawn(5, 1, "B"), new Pawn(6, 1, "B"), new Pawn(7, 1, "B") };

        //constractur
        public Board()
        {
            //creates empty board
            cells = new Cell[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Empty empty = new Empty(j, i, "E");
                    if (i % 2 != 0 && j % 2 != 0) cells[i, j] = new Cell("W", j, i, empty);
                    if (i % 2 == 0 && j % 2 == 0) cells[i, j] = new Cell("W", j, i, empty);
                    if (i % 2 != 0 && j % 2 == 0) cells[i, j] = new Cell("B", j, i, empty);
                    if (i % 2 == 0 && j % 2 != 0) cells[i, j] = new Cell("B", j, i, empty);
                }
            }
            //fills it with:
            //pawns
            for (int i = 0; i < 8; i++)
            {
                cells[1, i].ChangePiece(BPawns[i]);
            }
            for (int i = 0; i < 8; i++)
            {
                cells[6, i].ChangePiece(WPawns[i]);
            }

            //knights
            cells[0, 1].ChangePiece(new Knight(1, 0, "B"));
            cells[7, 1].ChangePiece(new Knight(1, 7, "W"));
            cells[0, 6].ChangePiece(new Knight(6, 0, "B"));
            cells[7, 6].ChangePiece(new Knight(6, 7, "W"));

            //kings
            cells[0, 4].ChangePiece(new King(4, 0, "B"));
            cells[7, 4].ChangePiece(new King(4, 7, "W"));

            //Rooks
            cells[0, 0].ChangePiece(new Rook(0, 0, "B"));
            cells[0, 7].ChangePiece(new Rook(7, 0, "B"));
            cells[7, 0].ChangePiece(new Rook(0, 7, "W"));
            cells[7, 7].ChangePiece(new Rook(7, 7, "W"));

            //Bishops
            cells[0, 2].ChangePiece(new Bishop(2, 0, "B"));
            cells[0, 5].ChangePiece(new Bishop(5, 0, "B"));
            cells[7, 2].ChangePiece(new Bishop(2, 7, "W"));
            cells[7, 5].ChangePiece(new Bishop(5, 7, "W"));

            //Queens
            cells[0, 3].ChangePiece(new Queen(3, 0, "B"));
            cells[7, 3].ChangePiece(new Queen(3, 7, "W"));
        }

        //converts Aa Bb Cc Dd Ee Ff Gg Hh to 0 1 2 3 4 5 6 7
        public int ConvertLetter(string letter)
        {
            if (letter == "A" || letter == "a") return 0;
            else if (letter == "B" || letter == "b") return 1;
            else if (letter == "C" || letter == "c") return 2;
            else if (letter == "D" || letter == "d") return 3;
            else if (letter == "E" || letter == "e") return 4;
            else if (letter == "F" || letter == "f") return 5;
            else if (letter == "G" || letter == "g") return 6;
            else if (letter == "H" || letter == "h") return 7;

            return 8;

        }

        //check if white king is alive
        public bool WKingAlive()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (cells[i, j].GetPiece().Name() == "[WK]")
                        return true;
                }
            }
            return false;
        }
        
        //check if black king is alive
        public bool BKingAlive()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (cells[i, j].GetPiece().Name() == "[BK]")
                        return true;
                }
            }
            return false;
        }

        //move
        public void Move(string cellPiece, string cell)
        {
            char[] tocords = cell.ToCharArray();
            char[] cords = cellPiece.ToCharArray();

            int x = ConvertLetter(cords[0].ToString());
            int y = Math.Abs(int.Parse(cords[1].ToString()) - 8);

            int tx = ConvertLetter(tocords[0].ToString());
            int ty = Math.Abs(int.Parse(tocords[1].ToString()) - 8);

            string piece = cells[y, x].GetPiece().Name();

            //check if a piece is in that location
            if (piece == "[  ]")
            {
                Console.WriteLine("There aren't any pieces there.");
                return;
            }

            //checks if pawn
            if (piece.Substring(2, piece.Length - 3) == "P" || piece.Substring(2, piece.Length - 3) == "p")
            {
                Pawn p = (Pawn)cells[y, x].GetPiece();
                p.Move(ty, tx, this);
            }

            //checks if knight
            if (piece.Substring(2, piece.Length - 3) == "N" || piece.Substring(2, piece.Length - 3) == "n")
            {
                Knight n = (Knight)cells[y, x].GetPiece();
                n.Move(ty, tx, this);
            }

            //checks if king
            if (piece.Substring(2, piece.Length - 3) == "K" || piece.Substring(2, piece.Length - 3) == "k")
            {
                King k = (King)cells[y, x].GetPiece();
                k.Move(ty, tx, this);
            }

            //check if rook
            if (piece.Substring(2, piece.Length - 3) == "R" || piece.Substring(2, piece.Length - 3) == "r")
            {
                Rook r = (Rook)cells[y, x].GetPiece();
                r.Move(ty, tx, this);
            }

            //check if bishop
            if (piece.Substring(2, piece.Length - 3) == "B" || piece.Substring(2, piece.Length - 3) == "b")
            {
                Bishop b = (Bishop)cells[y, x].GetPiece();
                b.Move(ty, tx, this);
            }

            //checks if queen
            if (piece.Substring(2, piece.Length - 3) == "Q" || piece.Substring(2, piece.Length - 3) == "q")
            {
                Queen q = (Queen)cells[y, x].GetPiece();
                q.Move(ty, tx, this);
            }
        }

        //ToString
        public override string ToString()
        {
            string str = ""; int z = 8;
            for (int i = 0; i < 8; i++)
            {

                for (int j = 0; j < 8; j++)
                {
                    str += cells[i, j].ToString();
                }
                
                str += "|" + z + "|\n";
                z = z - 1;
            }
            str += "̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄\u0304\n";
            for (int i = 65; i <= 72; i++)
            {
                str += "[" + ((char)i).ToString()+ ((char)i).ToString().ToLower() + "]";
            }
            str += "\n̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄̄\u0304\n";
            str += $"[White Points: {Wcounter}] [Black Points: {Bcounter}]\n";
            return str;
        }
    }
}
