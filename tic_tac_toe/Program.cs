using System;
using System.Collections.Generic;

bool game_over = false;
string top_left = " ";
string top_center = " ";
string top_right = " ";
string left = " ";
string center = " ";
string right = " ";
string bottom_left = " ";
string bottom_center = " ";
string bottom_right = " ";
List<string> board_list = new List<string>();

board_list.Add(top_left);
board_list.Add(top_center);
board_list.Add(top_right);
board_list.Add(left);
board_list.Add(center);
board_list.Add(right);
board_list.Add(bottom_left);
board_list.Add(bottom_center);
board_list.Add(bottom_right);

string current_player = get_first_player();
while (!game_over)
{
   board_list = take_turn(board_list, current_player);
   
   print_game(board_list);
   
   bool is_win = check_for_win(board_list);
   bool is_draw = check_if_draw(board_list);
   if (is_draw || is_win)
   {
      game_over = true;
   }
   else 
   {
      current_player = switch_turn(current_player);
   }
   if (is_win)
   {
      Console.WriteLine($"The winner is {current_player}");
   }
   if (is_draw)
   {
      Console.WriteLine("The game is a draw");
   }
}

string get_first_player()
{
   bool valid = false;
   string player_symbol = " ";
   while (!valid)
   {
      Console.WriteLine("First player choose x's or o's.");
      player_symbol = Console.ReadLine();
      if (player_symbol == "x" || player_symbol == "o")
      {
         valid = true;
      }
      else
      {
         Console.WriteLine("Please enter 'x' or 'o'.");
      }
   }
   return player_symbol;
}

List<string> take_turn(List<string> board_list, string current_player)
{
   bool valid_spot = false;
   Console.WriteLine("1|2|3");
   Console.WriteLine("-+-+-");
   Console.WriteLine("4|5|6");
   Console.WriteLine("-+-+-");
   Console.WriteLine("7|8|9");
   Console.WriteLine($"{current_player}'s turn. Please type 1 - 9 as indicated above to place your symbol.");
   
   while (!valid_spot)
   {
      string player_choice = Console.ReadLine();
      int board_spot = int.Parse(player_choice) - 1;
      if (board_list[board_spot] == " ")
      {
         board_list[board_spot] = current_player;
         valid_spot = true;
      }
      else
      {
         Console.WriteLine("Please pick an unoccupied square. The current board is as shown:");
         print_game(board_list);
      }
   }
   return board_list;
}

void print_game(List<string> board_list)
{
   Console.WriteLine($"{board_list[0]}|{board_list[1]}|{board_list[2]}");
   Console.WriteLine("-+-+-");
   Console.WriteLine($"{board_list[3]}|{board_list[4]}|{board_list[5]}");
   Console.WriteLine("-+-+-");
   Console.WriteLine($"{board_list[6]}|{board_list[7]}|{board_list[8]}");
}

bool check_for_win(List<string> board_list)
{
   bool is_win = false;
   if (board_list[0] == board_list[1] && board_list[0] == board_list[2] && board_list[0] != " ")
   {
      is_win = true;
   }
   
   if (board_list[0] == board_list[4] && board_list[0] == board_list[8] && board_list[0] != " ")
   {
      is_win = true;
   }

   if (board_list[0] == board_list[3] && board_list[0] == board_list[6] && board_list[0] != " ")
   {
      is_win = true;
   }

   if (board_list[1] == board_list[4] && board_list[1] == board_list[7] && board_list[1] != " ")
   {
      is_win = true;
   }

   if (board_list[2] == board_list[5] && board_list[2] == board_list[8] && board_list[2] != " ")
   {
      is_win = true;
   }

   if (board_list[2] == board_list[4] && board_list[2] == board_list[6] && board_list[2] != " ")
   {
      is_win = true;
   }

   if (board_list[3] == board_list[4] && board_list[3] == board_list[5] && board_list[3] != " ")
   {
      is_win = true;
   }   

   if (board_list[6] == board_list[7] && board_list[6] == board_list[8] && board_list[6] != " ")
   {
      is_win = true;
   }
   return is_win;
}

bool check_if_draw(List<string> board_list)
{   
   bool is_draw = true;

   for (int i = 0; i < 9; i++)
   {
      bool is_x = board_list[i] == "x";
      bool is_o = board_list[i] == "o";
       if (!is_x && !is_o)
       {
          is_draw = false;
       }
   }
   return is_draw;
}

string switch_turn(string current_player)
{
   if (current_player == "x")
   {
      current_player = "o";
   }
   else
   {
      current_player = "x";
   }
   return current_player;
}