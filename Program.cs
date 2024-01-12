using System;
using System.Collections.Generic;
using System.Data;

namespace ToDo
{
    public class ToDo
    {
        public static void Main(string[] args)
        {
            Board taskBoard = new Board();

            while (true)
            {
                Console.Write("--<>|Welcome to the ToDo Line|<>--\n|-|-|Please select the operation you want to do|-|-|\n" +
                              "--||(1) List Board||--\n" +
                              "--||(2) Add Card to Board||--\n" +
                              "--||(3) Delete Card from Board||--\n" +
                              "--||(4) Move Card||--\n" +
                              "--||(5) Update Card||--\n" +
                              "--||(6) Exit||--\n|----->");

                string? Selectoperation = Console.ReadLine();
                Console.WriteLine("");

                switch (Selectoperation)
                {
                    case "1":
                        Displayboard.Displayboards(taskBoard);
                        break;
                    case "2":
                        AddCard.AddCards(taskBoard);
                        break;
                    case "3":
                        DeleteCard.DeletingCard(taskBoard);
                        break;
                    case "4":
                        MoveCard.MoveCardToAnotherLine(taskBoard);
                        break;
                    case "5":
                        Uptadeboard.Uptadedboard(taskBoard);
                        break;
                    case "6":
                        Console.WriteLine("<<--||Goodbye! Mr. Or Mrs. You have a job to do. Don't forget.||-->>");
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again!");
                        break;
                }
            }
        }
    }
}
