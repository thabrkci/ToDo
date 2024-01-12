using System;
using System.Collections.Generic;
using System.Data;

namespace ToDo
{
    // Card class represents a task card with properties like Title, Content, AssignedPersonID, and Size.
    public class Card
    {
        // Properties

        // Title property represents the title of the task card
        public string Title { get; set; }

        // Content property represents the content or description of the task card
        public string Content { get; set; }

        // AssignedPersonID property represents the ID of the person assigned to the task card
        public int AssignedPersonID { get; set; }

        // Size property represents the size category of the task card (XS, S, M, L, XL)
        public Sizes Size { get; set; }

        // Constructor to initialize Card instance with given values
        public Card(string title, string content, int assignedpersonID, Sizes size)
        {
            // Initialize properties with provided values
            Title = title;
            Content = content;
            AssignedPersonID = assignedpersonID;
            Size = size;
        }
    }

}