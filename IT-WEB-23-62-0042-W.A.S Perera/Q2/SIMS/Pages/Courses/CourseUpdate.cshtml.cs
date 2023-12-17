using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using SIMS.Data;
using Microsoft.EntityFrameworkCore;
namespace SIMS.Pages.Courses;

public class CourseUpdate : PageModel
{

    private readonly SIMSContext _sIMSContext;
    public CourseUpdate(SIMSContext sIMSContext){
        _sIMSContext = sIMSContext;
    }

    [BindProperty]
    public SIMS.Data.Entities.Courses CourseToUpdate{get; set;}

    public async Task<IActionResult> OnGetAsync(int id)
    {
       CourseToUpdate = await _sIMSContext.Courses.Where(_ => _.Id == id)
        .Include(_ => _.Students).FirstOrDefaultAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        _sIMSContext.Courses.Update(CourseToUpdate);
        await _sIMSContext.SaveChangesAsync();
        return Redirect("/Courses/CoursesIndex");
        // return Page();
    }
}