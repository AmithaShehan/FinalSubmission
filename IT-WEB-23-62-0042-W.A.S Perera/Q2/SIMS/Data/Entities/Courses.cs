namespace SIMS.Data.Entities;

public class Courses{
    public int Id { get; set; }

    public string? CourseName{get; set;}

    public string? LecturerName{get; set;}


    public List<Students> Students{get; set;}
}