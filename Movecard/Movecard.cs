using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDo
{
    // MoveCard class provides functionality to move a card to a different section on the board
    public class MoveCard
    {
        // Method to initiate the card moving process
        public static void MoveCardToAnotherLine(Board board)
        {
            // Prompt user to select the card to move
            Console.WriteLine("To move a card, please first select the card.");
            Console.WriteLine("Please enter the card title:");

            // Read the user input for the card title
            string? cardTitleToMove = Console.ReadLine();

            // Check if the input is empty or contains only whitespace
            if (string.IsNullOrWhiteSpace(cardTitleToMove))
            {
                // Display an error message and cancel the operation
                Console.WriteLine("Invalid card title. Operation canceled.");
            }
            else
            {
                // Find the card based on the entered title
                Card cardToMove = board.Columns
                    .SelectMany(column => column.Value)
                    .FirstOrDefault(card => card.Title.Equals(cardTitleToMove, StringComparison.OrdinalIgnoreCase));

                // Check if the card is found
                if (cardToMove != null)
                {
                    // Display information about the found card
                    Console.WriteLine("Found Card Information:");
                    Console.WriteLine($"Title: {cardToMove.Title}");
                    Console.WriteLine($"Content: {cardToMove.Content}");
                    Console.WriteLine($"AssignedPersonID: {cardToMove.AssignedPersonID}");
                    Console.WriteLine($"Size: {cardToMove.Size}");

                    // Prompt user to select the new line for the card
                    Console.WriteLine("Select the Line to move the card to: (1) TODO, (2) IN PROGRESS, (3) DONE");
                    string lineChoice = Console.ReadLine();

                    // Check the user's choice and initiate the move
                    if (lineChoice.Equals("1"))
                    {
                        MoveCardToLine(board, cardToMove, "TODO");
                    }
                    else if (lineChoice.Equals("2"))
                    {
                        MoveCardToLine(board, cardToMove, "INPROGRESS");
                    }
                    else if (lineChoice.Equals("3"))
                    {
                        MoveCardToLine(board, cardToMove, "DONE");
                    }
                    else
                    {
                        // Display an error message for an invalid choice
                        Console.WriteLine("Invalid choice. Operation canceled.");
                    }
                }
                else
                {
                    // Display a message if no card is found with the entered title
                    Console.WriteLine($"No card found with title \"{cardTitleToMove}\". Operation canceled.");
                }
            }
        }

        // Method to move the card to the specified destination line
        private static void MoveCardToLine(Board board, Card card, string destinationLine)
        {
            // Remove the card from its current line
            foreach (var column in board.Columns.Values)
            {
                column.Remove(card);
            }

            // Add the card to the specified destination line
            board.Columns[destinationLine].Add(card);

            // Display the updated board after moving the card
            Console.WriteLine($"Card moved to {destinationLine} successfully. Updated Board:");
            Displayboard.Displayboards(board);
        }
    }

}
