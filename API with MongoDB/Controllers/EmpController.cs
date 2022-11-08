using DAL.Model;
using IObejects;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_with_MongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly IDataRepositroy _dataRepositroy;

        public EmpController(IDataRepositroy dataRepositroy)
        {
            _dataRepositroy = dataRepositroy;    
        }
        // GET: api/<EmpController>
        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            return _dataRepositroy.Get();
        }

        // GET api/<EmpController>/5
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(string id)
        {
            var emp = _dataRepositroy.Get(id);
            return emp;
        }

        // POST api/<EmpController>
        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {
            _dataRepositroy.Create(employee);
            return NoContent();
        }

        // PUT api/<EmpController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Employee employee)
        {
            var emptoupdate = _dataRepositroy.Get(id);
            _dataRepositroy.Update(id, employee);
            return NoContent();
        }

        // DELETE api/<EmpController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var emp=_dataRepositroy.Get(id);
            _dataRepositroy.Delete(emp.Id);
            return Ok();
        }
    }
}
