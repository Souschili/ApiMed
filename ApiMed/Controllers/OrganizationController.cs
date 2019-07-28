using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicLayer.DataAnalize;
using Microsoft.AspNetCore.Http;
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


        
        [HttpGet]
        public ActionResult<object> Get(string search)
        {
            return data.GetDataByName(search);
        }

        [HttpGet]
        public ActionResult<object>GetGuid(string guid)
        {
            return
        }



        [HttpGet]
        [Route("Test")]
        public string Test()
        {
            return "Test!!";
        }



    }
}