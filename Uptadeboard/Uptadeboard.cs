using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDo
{
    // Uptadeboard class provides functionality to update card information on the board
    public class Uptadeboard
    {
        // Method to initiate the card updating process
        public static void Uptadedboard(Board board)
        {
            // Infinite loop to continuously prompt the user for card updates
            while (true)
            {
                // Prompt the user to type the card title to update
                Console.WriteLine("<><>|<><>Please type the card title you want to update<><>|<><>");

                // Read the user input for the card title
                string? Uptadeboarded = Console.ReadLine();

                // Check if the input is empty or contains only whitespace
                if (string.IsNullOrWhiteSpace(Uptadeboarded))
                {
                    // Display an error message and continue to the next iteration
                    Console.WriteLine($"<>|<>Please enter a valid title<>|<>");
                    continue;
                }

                // Find cards with matching titles case-insensitively
                var Matchingcards = board.Columns
                    .SelectMany(column => column.Value
                    .Where(Card => Card.Title.Equals(Uptadeboarded, StringComparison.OrdinalIgnoreCase)))
                    .ToList();

                // Check if any matching cards are found
                if (Matchingcards.Any())
                {
                    // Iterate through each matching card and display its information
                    foreach (var card in Matchingcards)
                    {
                        Console.WriteLine($"<>|<>Card Found<>|<>: **|Title|**{card.Title}\n**|Content|**{card.Content}\n**|AssignedPersonID|**{card.AssignedPersonID}\n**|Size|**{card.Size}");

                        // Prompt the user to enter updated information for the card
                        Console.WriteLine("**|Enter the updated information for the card|**");
                        Console.WriteLine("**|Enter the new title|**");
                        string? Newtitle = Console.ReadLine();
                        card.Title = Newtitle;

                        Console.WriteLine("**|Enter the new Content|**");
                        string? Newcontent = Console.ReadLine();
                        card.Content = Newcontent;

                        Console.WriteLine("**|Enter the new ID|**");
                        int NewassignedpersonID;
                        while (!int.TryParse(Console.ReadLine(), out NewassignedpersonID))
                        {
                            Console.WriteLine("<><>->Invalid input.Please enter a valid ID<-<><>:");
                        }
                        card.AssignedPersonID = NewassignedpersonID;

                        Sizes newsize;
                        Console.WriteLine("**|Enter the new size|**");

                        // Prompt user to enter the new size, validate until a valid size is entered
                        while (!Enum.TryParse(Console.ReadLine(), true, out newsize))
                        {
                            Console.WriteLine("<><>->Invalid input.Please enter valid size input<-<><>");
                        }
                        card.Size = newsize;

                        // Display the updated information for the card
                        Console.WriteLine($"<>|<>Card Uptaded<>|<>: **|Title|**{card.Title}\n**|Content|**{card.Content}\n**|AssignedPersonID|**{card.AssignedPersonID}\n**|Size|**{card.Size}");
                    }

                    // Display success message and prompt for the next action
                    Console.WriteLine("<>|<>Card(s) updated successfully<>|<>");
                    Console.WriteLine("||Select the action you want to take|| ");
                }
                    // Prompt the user to try again or exit
                    Console.WriteLine("To try again(y),To exit(n)");

                    // Read the user input for the next action
                    string? selectaction = Console.ReadLine();

                    // Check if the input is empty or contains only whitespace
                    if (string.IsNullOrWhiteSpace(selectaction))
                    {
                        // Display an error message for an invalid entry
                        Console.WriteLine("<>|Invalid entry, please enter a valid option|<>");

                    }
                    else
                    {
                        // Check if the user wants to try again or exit
                        if (string.Equals(selectaction, "y", StringComparison.OrdinalIgnoreCase))
                        {
                            // Restart the updating process
                            Uptadeboard.Uptadedboard(board);
                        }
                        else
                        {
                            // Display a message and return to the ToDo-Menu
                            Console.WriteLine("<><>Back to ToDo-Menu<><>");
                            return;
                        }
                    }
                
            }
        }
    }

}
