using System;
using System.Collections.Generic;

public class Resume
{
    // Member variables for name and a list of Job instances
    public string _name = "";
    public List<Job> _jobs = new List<Job>();

    // Method to display resume details and iterate through the jobs list
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}