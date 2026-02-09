namespace AutoRepairJsonWersion.Components.Models;

public class Services
{
    public Guid Id {get; set;} = Guid.NewGuid();
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public bool Completed { get; set; }

    public Services(string name, DateTime startDate, bool completed)
    {
        Name = name;
        StartDate = startDate;
        Completed = completed;
    }
}
