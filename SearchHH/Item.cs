using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchHH
{
    public class Item
    {
        public Salary Salary { get; set; }
        public Snippet Snippet { get; set; }
        public Type Type { get; set; }
        public Area Area { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Responce
    {
        public int Count { get; set; }
        public List<Item> Items { get; set; }
    }

    public class Salary
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Currency { get; set; }
    }

    public class Snippet
    {
        public string Requirement { get; set; }
        public string Responsibility { get; set; }
    }

    public class Type
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Area
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
    }
}
