using System;
using System.Collections.Generic;
using System.Data;

namespace ToDo
{
    // Displayboard class provides functionality to display the contents of the board
    public class Displayboard
    {
        // Method to display the content of the board
        public static void Displayboards(Board board)
        {
            // Print a header indicating the start of board lists
            Console.WriteLine("\nBoard Lists\n");

            // Iterate through each column in the board
            foreach (var column in board.Columns)
            {
                // Display the column key within decorative symbols
                Console.WriteLine($"<>-<>||{column.Key}||<>-<>");

                // Display a line of dashes to separate the column header from card details
                Console.WriteLine(new string('-', 25)); // 25 pieces --- used to add

                // Check if the column has any cards
                if (column.Value.Any())
                {
                    // Iterate through each card in the column and display details
                    foreach (var card in column.Value)
                    {
                        Console.WriteLine($"Title: {card.Title}");
                        Console.WriteLine($"Content: {card.Content}");
                        Console.WriteLine($"AssignedPersonID: {card.AssignedPersonID}");
                        Console.WriteLine($"Size: {card.Size}\n-----------------");
                    }
                }
                else
                {
                    // Display a message indicating that the column has no cards
                    Console.WriteLine("-Null-\n");
                }
            }
        }
    }

}