using LogicLayer.DataAnalize;
using Microsoft.AspNetCore.Mvc;

namespace ApiMed.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {

        private IDataAnalizer data;

        public OrganizationController(IDataAnalizer dataAnalizer)
        { 
            this.data = dataAnalizer;
        }

        
        //GET api/organization?search=
        [HttpGet]
        public ActionResult<object> Get(string search)
        {
            if(search==null)
            {
                //пока так,так как по умолчанию это корневой маршрут 
                //заменить надпись если неустраивает
                return "Bad Request";
            }
            return data.GetDataByName(search);
        }

        // GET api/organization/guid
        [HttpGet("{guid}")]
        public ActionResult<object> GetGuid(string guid)
        {
            //если ноль мы дико сожалеем о чем и сообщаем
            return data.GetDataByGuid(guid) ?? BadRequest("No data dude sorry !");
        }

       ///GET api/organization/query?
       [HttpGet]
       [Route("query")]
       public ActionResult<object> Get(int skip=0,int take=0,string orderby="name")
       {
       
           
           return data.GetDataByQuery(skip,take,orderby) ;
       }


        [HttpGet]
        [Route("Test")]
        public string Test()
        {
            return "Test!!";
        }



    }
}