using System;
using System.Collections.Generic;
using System.Data;

namespace ToDo
{
    // AddCard class provides functionality to add new cards to the board
    public class AddCard
    {
        // Method to add cards to the board
        public static void AddCards(Board taskBoard)
        {
            // Prompt the user to add new tasks
            Console.WriteLine("<><>->Add a few things to do<-<><>");

            // Get user input for card properties
            Console.Write("||Title||: ");
            string? title = Console.ReadLine();

            Console.Write("||Content||: ");
            string? content = Console.ReadLine();

            int assignedPersonID;
            Console.Write("||Assigned Person ID||: ");

            // Validate assigned person ID input
            while (!int.TryParse(Console.ReadLine(), out assignedPersonID) || !TeamMember.teamMembersID.Contains(assignedPersonID))
            {
                Console.WriteLine("***|>Invalid or non-existent Team Member ID. Please enter a valid Team Member ID<|***");
                Console.WriteLine("||Assigned Person||");
            }

            Console.Write("||Select Size||--> XS(1), S(2), M(3), L(4), XL(5): ");
            Sizes selectedSize;

            // Validate selected size input
            while (!Enum.TryParse(Console.ReadLine(), out selectedSize) || !Enum.IsDefined(typeof(Sizes), selectedSize))
            {
                Console.WriteLine("Invalid login please try again !");
                Console.WriteLine("||Select Size||--> XS(1), S(2), M(3), L(4), XL(5): ");
            }
            // Create and initialize a new Card instance
            Card newCard = new Card(title, content, assignedPersonID, selectedSize);

            // Prompt user to select the section to add the card
            Console.WriteLine("In which section would you like to add the card to be added?\n(1)TODO\n(2)INPROGRESS\n(3)DONE");
            string? Inwhich = Console.ReadLine();

            // Add the new card to the specified section
            switch (Inwhich)
            {
                case "1":
                    taskBoard.Columns["TODO"].Add(newCard);
                    break;
                case "2":
                    taskBoard.Columns["INPROGRESS"].Add(newCard);
                    break;
                case "3":
                    taskBoard.Columns["DONE"].Add(newCard);
                    return;
                default:
                    // Handle invalid input and add the card to the TODO section by default
                    Console.WriteLine("|-|Invalid value|-|\nPlease enter <>-|1,2,3|-<> value");
                    taskBoard.Columns["TODO"].Add(newCard);
                    break;
            }

            // Display information about the new card
            Console.WriteLine($"|{{{title}}}\n{{{content}}}\n{{{assignedPersonID}}} assigned to with ID number.\n{{{selectedSize}}} with added size and added to the board.");
        }
    }

}
