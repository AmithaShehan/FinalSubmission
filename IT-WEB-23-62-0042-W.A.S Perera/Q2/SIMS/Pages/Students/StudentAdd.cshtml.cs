using SIMS.Pages.Students;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SIMS.Data;
namespace SIMS.Pages.Students;

public class StudentAdd: PageModel
{
    private readonly SIMSContext _sIMSContext;
    public StudentAdd(SIMSContext sIMSContext){
        _sIMSContext = sIMSContext;
    }
    [BindProperty]
    public SIMS.Data.Entities.Students NewStudent{get; set;}

    public async Task<IActionResult> OnGetAsync()
    {
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        _sIMSContext.Students.Add(NewStudent); 
        await _sIMSContext.SaveChangesAsync();
        return Redirect("StudentsIndex");
    }
}