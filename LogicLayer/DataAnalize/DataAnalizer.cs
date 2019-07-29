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

        /// <summary>
        /// Возращает обьекты по имени если есть совпадения 
        /// </summary>
        /// <param name="str">Имя искомого объекта</param>
        /// <returns></returns>
        public object GetDataByName(string str)
        {

            object t = rootObject?.parameter.FirstOrDefault().resource.expansion.contains.
                Where(x=>x.display.ToLower().Contains(str.ToLower())).
                Select(x=> new {id=x.code,x.display });
            //var jsonrezult = JsonConvert.SerializeObject(t);
            return t;
        }

        /// <summary>
        /// Возращает объект по найдему коду
        /// </summary>
        /// <param name="guid">код искомого объкта</param>
        /// <returns></returns>
        public object GetDataByGuid(string guid)
        {
            object t = rootObject.parameter.FirstOrDefault().
                       resource.expansion.contains.Where(x => x.code == guid).
                       Select(x => new { id = x.code, x.display }).FirstOrDefault();
            
            return t;
        }




       

        public object GetDataByQuery(int skip, int take, string orderby)
        {  
                object t = rootObject.parameter.FirstOrDefault().resource.expansion.contains.
                Skip(skip).Take(take).Select(x => new { id = x.code, x.display }).OrderBy(x => x.display);
                return t;
           
        }
    }

  
    }


    

