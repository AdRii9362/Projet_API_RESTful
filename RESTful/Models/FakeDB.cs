
using RESTful.Interfaces;

namespace RESTful.Models
{

    // Créez une classe statique FakeDb pour simuler une base de données en mémoire. Ajoutez
    //une liste statique de tâches dans FakeDb et initialisez-la avec quelques tâches fictives.

    public class FakeDB : IFakeDB
    {

        private List<HouseTask> _HouseTasks;

        public FakeDB() 
        {
            _HouseTasks = new List<HouseTask>()
            {
                new HouseTask(1,"Faire la vaisselle", "Nettoyer dans lévier les assiettes, etc..",false),
                new HouseTask(2,"Passer l'aspirateur", "Il faut passer l'aspirateur dans toute la maison",false),
                new HouseTask(3,"Ranger la chambre", "Il faut retirer les vêtements sales dans la chambre, etc..",false),

            };
        }

        public List<HouseTask> HouseTasks
        {
          get {return _HouseTasks; }
          set { _HouseTasks = value; }
        }

    }
}
