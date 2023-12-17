using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using SIMS.Data;
using Microsoft.EntityFrameworkCore;
namespace SIMS.Pages.Students;

public class StudentUpdate : PageModel
{

    private readonly SIMSContext _sIMSContext;
    public StudentUpdate(SIMSContext sIMSContext){
        _sIMSContext = sIMSContext;
    }

    [BindProperty]
    public SIMS.Data.Entities.Students StudentToUpdate{get; set;}

    public async Task<IActionResult> OnGetAsync(int id)
    {
       StudentToUpdate = await _sIMSContext.Students.Where(_ => _.Id == id)
        .Include(_ => _.Courses).FirstOrDefaultAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        _sIMSContext.Students.Update(StudentToUpdate);
        await _sIMSContext.SaveChangesAsync();
        return Redirect("/Students/StudentsIndex");
        // return Page();
    }
}