using System;
using System.Collections.Generic;
using System.Data;

namespace ToDo
{
    public class TeamMember
    {
        public int ID { get; }
        public string Name { get; }
        public TeamMember(int id, string name)
        {
            ID = id;
            Name = name;
        }
        public static List<long> teamMembersID = new List<long> { 101, 102, 103, 104, 105, 106, 107 };
        
    }
}