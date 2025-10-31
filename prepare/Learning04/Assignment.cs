class Assignment
{
    private string _studentName;
    private string _topic;


    // public Assignment() { }

    public Assignment(string studentName, string topic)
    {
        _topic = topic;
        _studentName = studentName;
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    public string GetStudentName()
    {
        return _studentName;
    }
}