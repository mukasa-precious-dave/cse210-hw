using System;

class Program
{
    // EXCEEDING REQUIREMENTS NOTE:
    // To exceed requirements for the Eternal Quest project, this program implements:
    // 1. A dynamic Leveling / Rank System ("Novice Seeker" up to "Legendary Eternal Knight") 
    //    that updates automatically in real time based on total points.
    // 2. A custom "NegativeGoal" class that allows users to track bad habits and deduct 
    //    points when a bad habit is triggered, adding strategic challenge to point accumulation.
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}