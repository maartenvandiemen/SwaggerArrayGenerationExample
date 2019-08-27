using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace SwaggerGenerationSample.Controllers
{
    [ApiController]
    [Route("companies/{companyId}/employees")]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        [Route("", Name = nameof(GetEmployees))]
        [SwaggerOperation(OperationId = nameof(GetEmployees))]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<Models.Response.Employee>))]
        [SwaggerResponse((int)HttpStatusCode.Forbidden, Type = typeof(Exception), Description = "")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(Exception), Description = "")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(Exception), Description = "")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(Exception), Description = "")]
        public async Task<IActionResult> GetEmployees(string companyId)
        {
            return Ok(GetEmployees());
        }

        [HttpPost]
        [Route("", Name = nameof(PostEmployee))]
        [SwaggerOperation(OperationId = nameof(PostEmployee))]
        [SwaggerResponse((int)HttpStatusCode.Accepted, Type = typeof(Models.Request.Employee))]
        [SwaggerResponse((int)HttpStatusCode.Forbidden, Type = typeof(Exception), Description = "")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(Exception), Description = "")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(Exception), Description = "")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(Exception), Description = "")]
        public async Task<IActionResult> PostEmployee([FromBody]Models.Request.Employee employee)
        {
            return Accepted(true);
        }

        private IEnumerable<Models.Response.Employee> GetEmployees()
        {
            yield return new Models.Response.Employee("John");
            yield return new Models.Response.Employee("Martin");
            yield return new Models.Response.Employee("Jack");
        }
    }
}
