using System;

namespace TicTacToe
{
    class Program
    {
        private static string s = " ";
        private static string u = "-";
        private static string l = "|";

        private static string[,] gameBoard = {
            {s, s, s, s, s, l, s, s, s, s, s, l, s, s, s, s, s },
            {s, s, "1", s, s, l, s, s, "2", s, s, l, s, s, "3", s, s },
            {s, s, s, s, s, l, s, s, s, s, s, l, s, s, s, s, s },
            {u, u, u, u, u, l, u, u, u, u, u, l, u, u, u, u, u },
            {s, s, s, s, s, l, s, s, s, s, s, l, s, s, s, s, s },
            {s, s, "4", s, s, l, s, s, "5", s, s, l, s, s, "6", s, s },
            {s, s, s, s, s, l, s, s, s, s, s, l, s, s, s, s, s },
            {u, u, u, u, u, l, u, u, u, u, u, l, u, u, u, u, u },
            {s, s, s, s, s, l, s, s, s, s, s, l, s, s, s, s, s },
            {s, s, "7", s, s, l, s, s, "8", s, s, l, s, s, "9", s, s },
            {s, s, s, s, s, l, s, s, s, s, s, l, s, s, s, s, s },
        };

        static void Main(string[] args)
        {
            bool gameOver = false;
            int activePlayer;

            int i = 0;

            
            do
            {
                Console.Clear();

                activePlayer = SetActivePlayer(i);

                DrawGameBoard();

                bool validMove = false;


                do
                {

                    Console.WriteLine("Player {0}: Choose your tile!", activePlayer);
                    string tileString = Console.ReadLine();
                    int tileSelected = 0;

                    bool isValidInt = int.TryParse(tileString, out tileSelected);


                    // not an integer, try again... 
                    if (!isValidInt)
                    {
                        Console.WriteLine("Invalid tile, must be a number. Press enter to try again.");
                        Console.ReadLine();
                    }

                    // Out of the range of the board.. try again
                    else if (tileSelected < 0 || tileSelected > 10)
                    {

                        Console.WriteLine("Invalid tile, out of range. Press enter to try again.");
                        Console.ReadLine();

                    }

                    // it's valid and in range
                    else
                    {

                        // Is it already selected?
                        string currentVal = GetBoardSelection(tileSelected);

                        if (currentVal.Equals("X") || currentVal.Equals("O"))
                        {

                            // value already selected, try again...
                            Console.WriteLine("Tile already selected. Press enter to try again.");
                            Console.ReadLine();

                        }
                        else
                        {
                            // success.

                            // add the value to the board.
                            SetPlayerSelection(tileSelected, activePlayer);

                            // check for game win
                            gameOver = CheckWinGame();

                            validMove = true;

                        }

                    }


                } while (!validMove);
          

                i++;

            } while (!gameOver);

            Console.Clear();

            DrawGameBoard();

            Console.WriteLine("Game over, player {0} wins!", activePlayer);
            Console.Read();

        }


        // Set the Active Player
        static int SetActivePlayer(int i)
        {
            if (i % 2 == 0)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }


        // Get the array row based on the users selection.
        static int GetRow(int tile)
        {
            if (tile >= 1 && tile <= 3)
            {
                return 1;
            }
            else if (tile >= 4 && tile <= 6)
            {
                return 5;
            }
            else
            {
                return 9;
            }
        }


        // Get the column based on the users selction.
        static int GetCol(int tile)
        {
            if (tile == 1 || tile == 4 || tile == 7)
            {
                return 2;
            }
            else if (tile == 2 || tile == 5 || tile == 8)
            {
                return 8;
            }
            else
            {
                return 14;
            }
        }


        // Get the users mark.
        static string GetPlayerMark(int player)
        {
            if(player == 1)
            {
                return "X";
            } else
            {
                return "O";
            }
        }


        // Set the Players selection
        static string GetBoardSelection(int tile)
        {
            return gameBoard[GetRow(tile), GetCol(tile)];

        }


        // Set the Players selection
        static string[,] SetPlayerSelection(int tile, int player)
        {
            gameBoard[GetRow(tile), GetCol(tile)] = GetPlayerMark(player);

            return gameBoard;
        }


        
        // Check for game win.
        static bool CheckWinGame()
        {

            int[,] winConditions =
            {
                { 1,2,3 },
                { 4,5,6 },
                { 7,8,9 },
                { 1,4,7 },
                { 2,5,8 },
                { 3,6,9 },
                { 1,5,9 },
                { 3,5,7 }
            };
    
            for(int i = 0; i < 8; i++)
            {
                string pos1 = GetBoardSelection(winConditions[i, 0]);
                string pos2 = GetBoardSelection(winConditions[i, 1]);
                string pos3 = GetBoardSelection(winConditions[i, 2]);


                if (pos1.Equals(pos2) && pos2.Equals(pos3))
                {
                    return true;
                }
                //Console.WriteLine("Position 1: {0}, Position 2: {1}, Position 3: {2}, Iteration: {3} ", pos1, pos2, pos3, i);
                

            }

            return false;
        }

        
        // Draw the gameboard
        static void DrawGameBoard()
        {

            for (int row = 0; row < 11; row++)
            {
                for (int col = 0; col < 17; col++)
                {
                    Console.Write(gameBoard[row, col]);
                }

                Console.WriteLine("");

            }

            Console.WriteLine();
        }



    }
}