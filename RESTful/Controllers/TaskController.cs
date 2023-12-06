using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTful.Models;
using System.Linq;

namespace RESTful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly FakeDB _FDB = new FakeDB();

        #region Afficher les tâches

        [HttpGet]

        public IEnumerable<HouseTask> GetAllTasks()
        {
            return _FDB.HouseTasks;
        }

        #endregion

        #region Afficher une tâche selon l'ID

        [HttpGet("{id}")]

        public ActionResult GetTaskById(int id)
        {
            HouseTask houseTask = _FDB.HouseTasks.Find(hs => hs.TaskId == id);

            if (houseTask == null)
            {
                return NotFound();
            }

            return Ok(houseTask);
        }

        #endregion

        #region Ajouter une tâche

        [HttpPost]
        public ActionResult CreateTask(HouseTask houseTask)
        {

            if (_FDB.HouseTasks.Any(task => task.TaskId == houseTask.TaskId))
            {
                return Conflict($"Une tâche avec l'ID {houseTask.TaskId} existe déjà.");
            }
            else if (_FDB.HouseTasks.Any(task => task.Title == houseTask.Title))
            {
                return Conflict($"La tâche {houseTask.Title} existe déjà.");
            }
            else
            {
            _FDB.HouseTasks.Add(houseTask);
            return Ok($"La tâche {houseTask.Title} portant l'id {houseTask.TaskId} ayant comme description {houseTask.Description} et à bien été ajouté et a comme statut complétée: {houseTask.IsCompleted}");
            }
          
        }




        #endregion




        /* 
● CreateTask(Task task)
● UpdateTask(int id, Task task)
● DeleteTask(int id)
*/

    }
}
