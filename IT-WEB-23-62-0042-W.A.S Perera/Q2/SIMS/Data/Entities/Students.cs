namespace SIMS.Data.Entities;

public class Students{
    public int Id { get; set; }

    public string? StudentName{get; set;}

    public string? City{get; set;}

     public int CourseId{get; set;}

    public Courses Courses{get; set;}
}