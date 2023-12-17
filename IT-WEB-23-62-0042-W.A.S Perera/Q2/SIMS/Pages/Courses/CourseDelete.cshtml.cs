using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using SIMS.Data;
using Microsoft.EntityFrameworkCore;
namespace SIMS.Pages.Courses;

public class CourseDelete: PageModel
{
    private readonly SIMSContext _sIMSContext;

    public CourseDelete(SIMSContext sIMSContext){
        _sIMSContext = sIMSContext;
    }

    public SIMS.Data.Entities.Courses CourseData{get; set;}

    public async Task<IActionResult> OnGetAsync(int id)
    {
        CourseData = await _sIMSContext.Courses.Where(_ => _.Id == id)
        .Include(_=> _.Students).FirstOrDefaultAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id){
       var CourseToDelete = await _sIMSContext.Courses.Where(_ => _.Id == id)
        .Include(_=> _.Students).FirstOrDefaultAsync();

        _sIMSContext.Courses.Remove(CourseToDelete);
        await _sIMSContext.SaveChangesAsync();
        return Redirect("/Courses/CoursesIndex");
    }

    
}