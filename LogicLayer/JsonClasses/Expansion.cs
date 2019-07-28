using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.JsonClasses
{
    public class Expansion
    {
        public List<Contain> contains { get; set; }
        public List<Parameter2> parameter { get; set; }
        public DateTime timestamp { get; set; }
    }
}
