
class Job
{
    public string Company = "";
    public string JobTitle = "";
    public int StartYear = 0;
    public int EndYear = 0;


    public void DisplayInfo()
    {
        Console.WriteLine($"{JobTitle}: ({Company}) {StartYear} - {EndYear}");
    }
}