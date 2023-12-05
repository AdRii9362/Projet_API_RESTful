using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTful.Models;
namespace RESTful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly FakeDB _FDB = new FakeDB();

        [HttpGet(nameof(GetAll))]
        
        public IEnumerable<HouseTask> GetAll()
        {
            return _FDB.HouseTasks ;
        }



    }
}
