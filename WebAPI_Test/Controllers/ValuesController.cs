using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_Test.Models;
using WebAPI_Test.Services;
using Swashbuckle.Swagger.Annotations;

namespace WebAPI_Test.Controllers
{
    public class ValuesController : ApiController
    {
        private SqlDataAccess _sqlDataAccess;

        public ValuesController()
        {
            _sqlDataAccess = new SqlDataAccess();
        }

        [HttpGet]
        [Route("api/TechAppLauncher/GetAllUserDownloadSessions")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the list of records when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Bad Request - Invalid Data!")]
        public IEnumerable<UserDownloadSession> GetAllUserDownloadSessions()
        {
            return _sqlDataAccess.GetUserDownloadSessions();
        }


        [HttpPost]
        [Route("api/TechAppLauncher/AddUserDownloadSession")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the specific record when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Bad Request - Invalid Data!")]
        public IEnumerable<UserDownloadSession> AddUserDownloadSession([FromBody] UserDownloadSession userDownloadSession)
        {
            return _sqlDataAccess.AddUserDownloadSession(userDownloadSession);
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
