using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.JsonClasses
{
    public class Contain
    {
        public string code { get; set; }
        public string display { get; set; }
        public string version { get; set; }
        public List<Contain2> contains { get; set; }
    }
}
