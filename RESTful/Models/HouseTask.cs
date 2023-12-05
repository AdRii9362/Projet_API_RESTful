namespace RESTful.Models
{
    public class HouseTask
    {

        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public HouseTask(int taskId, string title, string description, bool isCompleted)
        {
            TaskId = taskId;
            Title = title;
            Description = description;
            IsCompleted = isCompleted;
        }
        
    }
}
