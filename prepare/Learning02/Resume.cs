
class Resume
{
    public string Name = "";
    public List<Job> Jobs = [];


    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine("Jobs:");
        foreach (Job _Job in Jobs)
        {
            _Job.DisplayInfo();
        }
    }
}