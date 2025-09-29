using System;

class Program
{
    static void Main(string[] args)
    {
        Job Job1 = new Job();
        Job1.JobTitle = "Software Engineer";
        Job1.Company = "Microsoft";
        Job1.StartYear = 2000;
        Job1.EndYear = 2002;

        Job Job2 = new Job();
        Job2.JobTitle = "Manager";
        Job2.Company = "Apple";
        Job2.StartYear = 2000;
        Job2.EndYear = 2002;

        Resume Resume1 = new Resume();
        Resume1.Name = "John Doe";
        Resume1.Jobs.Add(Job1);
        Resume1.Jobs.Add(Job2);
        Resume1.DisplayInfo();
    }
}