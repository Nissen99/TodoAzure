namespace Models;

public class Todo
{
    public int Id { get; set; }
    public string Title { get; set; }
    public User Responsible { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    
}