using LogicLayer.JsonClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.DataAnalize
{
    public interface IDataAnalizer
    {
        object GetDataByName(string s);
        object GetDataByGuid(string q);
    }


}
