//CSE210
//Jay Patterson
//BYUI Fall 2022

using System;
using System.Collections.Generic;

namespace SandboxProject
{
    class Program
    { 
        static void Main(string[] args)
        {
            display_greeting();
            List<string> board = get_new_board();

            string current_player = "x";

            while (!game_over(board))
            {
                display_board(board);

                int choice = square_choice(current_player);
                make_move(board, current_player, choice);

                current_player = next_player(current_player);
            }

            display_board(board);
            Console.WriteLine("Good game. Thanks for playing!");
        }



        static int get_user_choice(string current_player)
        {
            Console.WriteLine($"{current_player}'s turn to choose a square (1-9): ");
            int square_choice = int.Parse(Console.ReadLine());

            return square_choice;
        }

        static void make_move(List<string> board, string current_player, int square_choice)
        {
            int board_index = square_choice - 1;
            board[board_index] = current_player;
        }

        static List<string> get_new_board()
        {
            List<string> board = new List<string>();

            board.Add("1");
            board.Add("2");
            board.Add("3");
            board.Add("4");
            board.Add("5");
            board.Add("6");
            board.Add("7");
            board.Add("8");
            board.Add("9");

            return get_new_board();
        }

        static void display_board(List<string> board)
        {
            Console.WriteLine($"{board[0]} {board[1]} {board[2]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[3]} {board[4]} {board[5]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[6]} {board[7]} {board[8]}");
        }
    
        static void display_greeting()
        {
            Console.WriteLine("Welcome to the Tic-Tack-Toe program!");
        }

        static bool game_over(List<string> board)
        {
            bool game_over = false;

            if (is_winner(board, "x") || is_winner(board, "o") || is_tie(board))
            {
                game_over = true;
            }

            return game_over;
        }

        static string next_player(string current_player)
        {
            string next_player = "x";

            if (current_player == "x")
            {
                next_player = "o";
            }

            return next_player;
        }

        static int square_choice(string current_player)
        {
            Console.Write($"{current_player}'s turn to choose a square (1-9): ");
            string move_string = Console.ReadLine();
            int choice = int.Parse(move_string);
            return choice;
        }

        static bool is_winner(List<string> board, string player)
        {
            bool is_winner = false;

            if ((board[0] == player && board[1] == player && board[2] == player)
                || (board[3] == player && board[4] == player && board[5] == player)
                || (board[6] == player && board[7] == player && board[8] == player)
                || (board[0] == player && board[3] == player && board[6] == player)
                || (board[1] == player && board[4] == player && board[7] == player)
                || (board[2] == player && board[5] == player && board[8] == player)
                || (board[0] == player && board[4] == player && board[8] == player)
                || (board[2] == player && board[4] == player && board[6] == player)
                )
            {
                is_winner = true;
            }

            return is_winner; 
        }
        static bool is_tie(List<string> board)
        {
            bool found_digit = false;

            foreach (string value in board)
            {
                if (char.IsDigit(value[0]))
                {
                    found_digit = true;
                    break;
                }
            }
            return !found_digit;
        }
        
    }
}