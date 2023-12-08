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

        //public IEnumerable<HouseTask> GetAllTasks()
        //{
        //    return _FDB.HouseTasks;
        //}

        public ActionResult<List<HouseTask>> GetAllTask()
        {
            return Ok(_FDB.HouseTasks.ToList());
        }
        #endregion

        #region Afficher une tâche selon l'ID

        [HttpGet("{id}")]

        public ActionResult<HouseTask> GetTaskById(int id)
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

             if (_FDB.HouseTasks.Any(task => task.Title == houseTask.Title))
            {
                return Conflict($"La tâche {houseTask.Title} existe déjà.");
            }

            _FDB.HouseTasks.Add(houseTask);
            return Ok($"La tâche {houseTask.Title} portant l'id {houseTask.TaskId} ayant comme description {houseTask.Description} et à bien été ajouté et a comme statut complétée: {houseTask.IsCompleted}");
            

        }
        #endregion

        #region Modifier une tâche

        [HttpPut]

        //public IEnumerable<HouseTask> UpdateTask(int id, HouseTask houseTask)
        //{
        //    _FDB.HouseTasks[id] = houseTask;

        //    return _FDB.HouseTasks;
        //}

        public ActionResult UpdateTask(int id, HouseTask houseTask)
        {
            var existingTask = _FDB.HouseTasks.FirstOrDefault(houseTask => houseTask.TaskId == id);

            if (existingTask == null)
            {
                return NotFound(); // Retourner 404 (Not Found) si la tâche avec l'ID spécifié n'est pas trouvée
            }

            // Mettre à jour les propriétés de la tâche existante avec les données de la tâche mise à jour
            existingTask.Title = houseTask.Title;
            existingTask.Description = houseTask.Description;
            existingTask.IsCompleted = houseTask.IsCompleted;
            // Mettez à jour d'autres propriétés si nécessaire

            return Ok(houseTask);
            //return Ok($"{houseTask.TaskId}| {houseTask.Title}| {houseTask.Description}| {houseTask.IsCompleted} "); // Retourner la tâche mise à jour avec le statut 200 (OK)
        }

        #endregion

        #region Supprimer une tâche

        [HttpDelete] 
        public ActionResult DeleteTask(int id)
        {
            var existringTask = _FDB.HouseTasks.FirstOrDefault(task => task.TaskId == id);

            if (existringTask == null)
            {
                return NotFound();
            }

            _FDB.HouseTasks.Remove(existringTask);

            return Ok($"La tâche {existringTask.Title} portant l'id {existringTask.TaskId} a bien été supprimée");
        }
        #endregion

    }
}
