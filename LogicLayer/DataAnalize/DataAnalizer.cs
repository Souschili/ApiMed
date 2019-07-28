using LogicLayer.JsonClasses;
using LogicLayer.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicLayer.DataAnalize
{
    public class DataAnalizer:IDataAnalizer
    {
        private IDataRepository dataRepository;
        private RootObject rootObject { get; set; }
        private List<Contain> contains { get; set; }

        

        public DataAnalizer(IDataRepository data)
        {
            this.dataRepository = data;
            ParseJson();
        }


        private void ParseJson()
        {
            var json = this.dataRepository.GetData().Result;
            rootObject = JsonConvert.DeserializeObject<RootObject>(json);
            
        }

        public object GetDataByName(string str)
        {

            object t = rootObject?.parameter.FirstOrDefault().resource.expansion.contains.Where(x=>x.display==str).
                Select(x=> new {id=x.code,x.display }).FirstOrDefault();
            //var jsonrezult = JsonConvert.SerializeObject(t);
            return t;
        }
    }
}
