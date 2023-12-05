using RESTful.Models;

namespace RESTful.Interfaces
{
    public interface IFakeDB
    {
        public List<HouseTask> HouseTasks { get; set; }
    }
}
