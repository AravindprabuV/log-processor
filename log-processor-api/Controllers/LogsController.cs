using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using service;
using service.Interface;

namespace log_processor_api.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private ILoggerService _loggerService;

        public LogsController(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        // GET: api/Logs
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var data = await this._loggerService.GetApiIdFromFile("Docs/1.log");
            return new JsonResult( new
            { result= data.ToList()
            });
        }

        // GET: api/Logs/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Logs
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Logs/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Logs/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
