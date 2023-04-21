using Project_v1;

Board board = new Board();
Console.WriteLine(board.ToString());
bool turn=true;//true=white false=black

while (board.WKingAlive() && board.BKingAlive())
{
    if (turn)
    {
        Console.WriteLine("White's turn!\n");
    }

    else
    {
        Console.WriteLine("Black's turn!\n");
    }
        
    Console.WriteLine("Choose piece square or type "+'"'+"reset"+'"'+".");
    string request = Console.ReadLine();
    

    if (request.ToUpper() == ("reset").ToUpper())
    {
        board = new Board();
        turn = true;
    }
    else
    {
        char[] cords = request.ToCharArray();
        int x = board.ConvertLetter(cords[0].ToString());
        int y = Math.Abs(int.Parse(cords[1].ToString()) - 8);

        if (board.cells[y, x].GetPiece().GetColor() == "W" && turn)
        {
            turn = false;
            Console.WriteLine("Choose square to move to.");
            board.Move(request, Console.ReadLine());
        }

        else if (board.cells[y, x].GetPiece().GetColor() == "B" && !turn)
        {
            turn = true;
            Console.WriteLine("Choose square to move to.");
            board.Move(request, Console.ReadLine());
        }

    }
    Thread.Sleep(500);
    Console.Clear();
    Console.WriteLine(board.ToString());
}
if (board.WKingAlive()) Console.WriteLine($"White Won! with {board.Wcounter-100} points not including king.");
if (board.BKingAlive()) Console.WriteLine($"Black Won! with {board.Bcounter - 100} points not including king.");


/*

Console.WriteLine("Choose square to move to.");
board.Move(Console.ReadLine(), Console.ReadLine());
Console.WriteLine(board.ToString());
Console.WriteLine("Choose square to move to.");
board.Move(Console.ReadLine(), Console.ReadLine());
Console.WriteLine(board.ToString());
Console.WriteLine("Choose square to move to.");
board.Move(Console.ReadLine(), Console.ReadLine());
Console.WriteLine(board.ToString());
Console.WriteLine("Choose square to move to.");
board.Move(Console.ReadLine(), Console.ReadLine());
Console.WriteLine(board.ToString());
Console.WriteLine("Choose square to move to.");
board.Move(Console.ReadLine(), Console.ReadLine());
Console.WriteLine(board.ToString());
Console.WriteLine("Choose square to move to.");
board.Move(Console.ReadLine(), Console.ReadLine());
Console.WriteLine(board.ToString());
Console.WriteLine("Choose square to move to.");
board.Move(Console.ReadLine(), Console.ReadLine());
Console.WriteLine(board.ToString());
Console.WriteLine("Choose square to move to.");
board.Move(Console.ReadLine(), Console.ReadLine());
Console.WriteLine(board.ToString());
Console.WriteLine("Choose square to move to.");
board.Move(Console.ReadLine(), Console.ReadLine());
Console.WriteLine(board.ToString());
Console.WriteLine("Choose square to move to.");
board.Move(Console.ReadLine(), Console.ReadLine());
Console.WriteLine(board.ToString());
Console.WriteLine("Choose square to move to.");
board.Move(Console.ReadLine(), Console.ReadLine());
Console.WriteLine(board.ToString());
Console.WriteLine("Choose square to move to.");
board.Move(Console.ReadLine(), Console.ReadLine());
Console.WriteLine(board.ToString());
*/