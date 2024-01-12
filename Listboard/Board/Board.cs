using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace ToDo
{
  // Board class represents the task board with columns for TODO, INPROGRESS, and DONE
  public class Board
  {
    // Properties
    public Dictionary<string, List<Card>> Columns { get; }
    public List<TeamMember> TeamMembers { get; }

    // Constructor to initialize the board with default values
    public Board()
    {
      // Initialize Columns property with a dictionary representing task board sections
      Columns = new Dictionary<string, List<Card>>
        {
            {"TODO",new List<Card>()},         // Initialize TODO section with an empty list of cards
            {"INPROGRESS",new List<Card>()},   // Initialize INPROGRESS section with an empty list of cards
            {"DONE",new List<Card>()}          // Initialize DONE section with an empty list of cards
        };

      // Initialize TeamMembers property with a list representing team members
      TeamMembers = new List<TeamMember>
      {
        // List of default team members
        // This can be extended with additional team members as needed
      };
    }
  }
}
