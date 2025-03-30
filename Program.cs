namespace ChessBoardConsoleApp
{
    using ChessBoardModel;
    using System.Transactions;

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Chess Players!");
            Board myBoard = new Board(8);
            printBoard(myBoard);

            
            try
            {
                Console.WriteLine("Enter the row for your piece.");
                int row = int.Parse(Console.ReadLine());
                while ((0 > row) || (row > myBoard.Size))
                {
                    Console.WriteLine("Please enter a number between 0 and " + myBoard.Size);
                    row = int.Parse(Console.ReadLine());
                }

                Console.WriteLine("Enter the column for your piece.");
                int col = int.Parse(Console.ReadLine());
                while ((0 > col) || (col > myBoard.Size))
                {
                    Console.WriteLine("Please enter a number between 0 and " + (myBoard.Size - 1));
                    col = int.Parse(Console.ReadLine());
                }

                Console.WriteLine("Enter the name of your piece.");
                string piece = Console.ReadLine();

                myBoard.MarkNextLegalMove(myBoard.theGrid[row, col], piece);
                printBoard(myBoard);
            }
            catch (Exception) 
            {
                Console.WriteLine("Please intput a valid number for the row and column.");
            }
        }



        //Show the empty chessboard.
        //Get the location of the chess piece.
        //Calculate and mark the cells where legal moves are possible.
        //Show the chessboard.Use. for an empty square, X for the piece location and + for a possible legal move.
        private static void printBoard(Board myBoard)
        {
            for (int i = -1; i < myBoard.Size; i++) 
            {
                for (int s = 0; s < 2; s++)
                {
                    if (s == 1)
                    {
                        Console.Write("   +");
                        for (int c = 0; c < myBoard.Size; c++)
                        {
                            Console.Write("-----+");
                        }
                        Console.WriteLine();
                    }
                    if (s == 0)
                    {
                        for (int j = 0; j < myBoard.Size; j++)
                        {

                            if ((j == 0) && (i != -1))
                            {
                                Console.Write("" + i + "  | ");
                            }
                            else if (i > -1)
                            {
                                Console.Write(" | ");
                            }

                            if ((i == -1) && (j == 0))
                            {
                                Console.Write("      " + j);
                            }

                            else if (i == -1)
                            {
                                Console.Write("     " + j);
                            }
                            else if (myBoard.theGrid[i, j].isLegalNextMove)
                            {
                                Console.Write(" + ");
                            }
                            else if (myBoard.theGrid[i, j].isCurrentlyOccupied != "")
                            {
                                Console.Write(" " + myBoard.theGrid[i, j].isCurrentlyOccupied + " ");
                            }
                            else
                            {
                                Console.Write(" . ");
                            }

                            if ((j == myBoard.Size - 1) && (i != -1))
                            {
                                Console.Write(" |");
                            }

                        }
                        Console.WriteLine();
                    }
                }
                
            }
        }

    }
}
