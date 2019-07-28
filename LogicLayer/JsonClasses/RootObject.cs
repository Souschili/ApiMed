using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.JsonClasses
{
    public class RootObject
    {
        public List<Parameter> parameter { get; set; }
        public string resourceType { get; set; }
    }
}
