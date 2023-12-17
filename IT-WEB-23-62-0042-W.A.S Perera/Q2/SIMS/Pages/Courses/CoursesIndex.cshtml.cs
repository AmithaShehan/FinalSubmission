using SIMS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SIMS.Pages.Courses;

public class CoursesIndex: PageModel{
    private readonly SIMSContext _sIMSContext;
    public CoursesIndex(SIMSContext sIMSContext){
        _sIMSContext = sIMSContext;
    }

    public List<Data.Entities.Courses> AllCourses{get; set;}

    public async Task<IActionResult> OnGetAsync(){
        AllCourses = await _sIMSContext.Courses.ToListAsync();
        return Page();
    }
}