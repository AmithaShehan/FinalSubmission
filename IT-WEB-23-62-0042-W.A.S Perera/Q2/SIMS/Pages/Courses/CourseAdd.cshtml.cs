using SIMS.Pages.Courses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SIMS.Data;
namespace SIMS.Pages.Courses;

public class CourseAdd: PageModel
{
    private readonly SIMSContext _sIMSContext;
    public CourseAdd(SIMSContext sIMSContext){
        _sIMSContext = sIMSContext;
    }
    [BindProperty]
    public SIMS.Data.Entities.Courses NewCourse{get; set;}

    public async Task<IActionResult> OnGetAsync()
    {
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        _sIMSContext.Courses.Add(NewCourse); 
        await _sIMSContext.SaveChangesAsync();
        return Redirect("CoursesIndex");
    }
}