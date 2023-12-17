using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using SIMS.Data;
using Microsoft.EntityFrameworkCore;
namespace SIMS.Pages.Students;

public class StudentDelete: PageModel
{
    private readonly SIMSContext _sIMSContext;

    public StudentDelete(SIMSContext sIMSContext){
        _sIMSContext = sIMSContext;
    }

    public SIMS.Data.Entities.Students StudentData{get; set;}

    public async Task<IActionResult> OnGetAsync(int id)
    {
        StudentData = await _sIMSContext.Students.Where(_ => _.Id == id)
        .Include(_=> _.Courses).FirstOrDefaultAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id){
       var StudentToDelete = await _sIMSContext.Students.Where(_ => _.Id == id)
        .Include(_=> _.Courses).FirstOrDefaultAsync();

        _sIMSContext.Students.Remove(StudentToDelete);
        await _sIMSContext.SaveChangesAsync();
        return Redirect("/Students/StudentsIndex");
    }

    
}