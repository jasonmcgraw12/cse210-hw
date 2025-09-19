using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade?");
        float grade = float.Parse(Console.ReadLine());
        string letterGrade = "F";
        string aOrAn = "";
        if (grade >= 90)
        {
            letterGrade = "A";
            aOrAn = "n";
        }
        else if (grade >= 80)
        {
            letterGrade = "B";
        }
        else if (grade >= 70)
        {
            letterGrade = "C";
        }
        else if (grade >= 60)
        {
            letterGrade = "D";
        }
        // No need for an else because I already assigned it the value F when I made the variable
        string gradeSign = "";
        if (grade % 10 >= 7)
        {
            gradeSign = "+";
        }
        else if (grade % 10 < 3) {
            gradeSign = "-";
        }
        if (letterGrade == "F")
        {
            gradeSign = "";
        }
        else if (grade >= 97)
        {
            gradeSign = "";
        }
        
        // if (letterGrade == "A")
        // {
        //     aOrAn = "n";
        // }

        if (grade >= 70)
        {

            Console.WriteLine($"You passed with a{aOrAn} {letterGrade}{gradeSign}!!!");
        }
        else
            {
                Console.WriteLine($"You got a{aOrAn} {letterGrade}{gradeSign}, so you didn't pass. I'll pray for you next time.");
            }
        }
}