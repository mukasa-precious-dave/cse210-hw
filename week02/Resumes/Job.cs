using System;

public class Job
{
    // Member variables for job attributes
    public string _jobTitle = "";
    public string _company = "";
    public int _startYear = 0;
    public int _endYear = 0;

    // Method to display job details in the required format
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}