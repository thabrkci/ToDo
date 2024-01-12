using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDo
{
    // DeleteCard class provides functionality to delete cards from the board
    public class DeleteCard
    {
        // Method to initiate the card deletion process
        public static void DeletingCard(Board board)
        {
            // Prompt user to enter the title of the card to delete
            Console.WriteLine("<><><>Please enter the title of the card you want to delete<><><>");
            string? cardTitleToDelete = Console.ReadLine();

            // Check if the input is empty or contains only whitespace
            if (string.IsNullOrWhiteSpace(cardTitleToDelete))
            {
                // Validate input and display an error message
                Console.WriteLine("||Please enter a valid title||");
            }
            else
            {
                // Find all cards with the specified title case-insensitively
                List<Card> cardsToDelete = board.Columns
                    .SelectMany(column => column.Value)
                    .Where(card => card.Title.Equals(cardTitleToDelete, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                // Check if there are cards to delete
                if (cardsToDelete.Count > 0)
                {
                    // Display found cards
                    foreach (var card in cardsToDelete)
                    {
                        Console.WriteLine($"Found Card: {card.Title}");
                    }

                    // Ask user for confirmation to delete the cards
                    Console.WriteLine("Do you want to delete these cards? (yes/no)");

                    // Read user response
                    string response = Console.ReadLine();

                    // Check user response
                    if (response.Equals("yes", StringComparison.OrdinalIgnoreCase))
                    {
                        // Delete the cards
                        foreach (var column in board.Columns.Values)
                        {
                            foreach (var cardToDelete in cardsToDelete)
                            {
                                column.Remove(cardToDelete);
                            }
                        }
                        Console.WriteLine("Cards deleted successfully.");
                    }
                    else if (response.Equals("no", StringComparison.OrdinalIgnoreCase))
                    {
                        // Deletion canceled
                        Console.WriteLine("Deletion canceled.");
                    }
                    else
                    {
                        // Invalid option entered
                        Console.WriteLine("Invalid option entered. Deletion canceled.");
                    }
                }
                else
                {
                    // No cards found with the specified title
                    Console.WriteLine($"No cards found with title \"{cardTitleToDelete}\". Press ||Enter|| to try again or any key to cancel deletion.");

                    // Wait for user to read the message
                    Console.ReadLine();
                }
            }
        }
    }

}
