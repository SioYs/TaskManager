using TaskManager.Data.Models.Enums;

public class TaskViewModel
{
    public int Id { get; set; } 
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public Status Status { get; set; }
    public PrioirtyLevel PrioirtyLevel { get; set; }
    public int  TaskListId{ get; set; }
}
