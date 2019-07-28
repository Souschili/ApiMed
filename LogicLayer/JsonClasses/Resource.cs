using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.JsonClasses
{
    public class Resource
    {
        public string id { get; set; }
        public string url { get; set; }
        public Meta meta { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public List<Contact> contact { get; set; }
        public string version { get; set; }
        public Expansion expansion { get; set; }
        public string publisher { get; set; }
        public bool experimental { get; set; }
        public string resourceType { get; set; }
    }
}
