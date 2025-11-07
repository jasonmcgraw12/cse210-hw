using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Develop04 World!");
        // BreathingActivity breathingActivity = new(2, startMessage, endMessage);
        // breathingActivity.StartBreathing();
        // string startMessage = ;
        // ReflectionActivity reflectionActivity = new(2, startMessage, endMessage);
        // reflectionActivity.StartReflection();
        // string startMessage = 
        // ListeningActivity listeningActivity = new(2, startMessage, endMessage);
        // listeningActivity.StartListening(20);
        string input = "";
        // This end message is put out here because the message is exactly the same for all activities
        string endMessage = "This activity is now over. Hope you had fun!";
        Dictionary<string, int> activityCount = new()
        {
            {"breathing", 0},
            {"reflection", 0},
            {"listening", 0}
        };
        while (input != "4")
        {
            Console.WriteLine("""
            What would you like to do?
            1. Breathing activity
            2. Reflection activity
            3. Listing activity
            4. exit
            """);
            input = Console.ReadLine();
            if (input == "1")
            {
                activityCount["breathing"]++;
                // the start message changes for each activity, 
                // I have another start message that asks how much time someone would like to spend in the activity built into each activity
                string startMessage = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
                BreathingActivity activity = new(startMessage, endMessage);
                activity.StartBreathing();
            }
            else if (input == "2")
            {
                activityCount["reflection"]++;
                string startMessage = "Reflect on times in your life when you have shown strength and resilience.";
                ReflectionActivity activity = new(startMessage, endMessage);
                activity.StartReflection();
            }
            else if (input == "3")
            {
                activityCount["listening"]++;
                string startMessage = "Reflect on the good things in your life by having you list as many things as you can in a certain area.";
                ListeningActivity activity = new(startMessage, endMessage);
                activity.StartListening();
            }
            else if (input == "4")
            {
                Console.WriteLine("Have a great day!");
                break;
            }
            else
            {
                Console.WriteLine("That isn't a valid responce, please enter 1,2,3, or 4.");
            }
            // for the stretch it keeps track of how much of each activity you do in a session
            foreach (string key in activityCount.Keys)
            {
                if (activityCount[key] > 0)
                {
                    if (activityCount[key] == 1)
                    {
                        Console.WriteLine($"You have performed the {key} activity {activityCount[key]} time.");
                    }
                    else
                    {
                        Console.WriteLine($"You have performed the {key} activity {activityCount[key]} times.");
                    }
                }
            }
        }
    }
}