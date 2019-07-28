using LogicLayer.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public class DataRepository:IDataRepository
    {


        private readonly string url = "http://r78-rc.zdrav.netrika.ru/nsi/fhir/term/ValueSet/$expand?_format=json";

        /// <summary>
        /// Возращает Json строку
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetData()
        {
            //параметры json  в теле пост запроста
            var parameters = new
            {
                resourceType = "Parameters",
                parameter = new object[]
               {
                    new
                    {
                        name="system",
                        valueString="urn:oid:1.2.643.2.69.1.1.1.64"
                    }

               }
            };
            var text = "";

            string json = JsonConvert.SerializeObject(parameters);


            var body = Encoding.UTF8.GetBytes(json);
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = body.Length;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(body, 0, body.Length);
                stream.Close();
            }

            WebResponse response = await request.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    text = reader.ReadToEnd();

                }
            }
            response.Close();

            return text;
        }
    }
}
