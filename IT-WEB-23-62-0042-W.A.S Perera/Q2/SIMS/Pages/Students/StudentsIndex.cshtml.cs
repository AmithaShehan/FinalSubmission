using SIMS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SIMS.Pages.Students;

public class StudentsIndex: PageModel{
    private readonly SIMSContext _sIMSContext;
    public StudentsIndex(SIMSContext sIMSContext){
        _sIMSContext = sIMSContext;
    }

    public List<Data.Entities.Students> AllStudents{get; set;}

    public async Task<IActionResult> OnGetAsync(){
        AllStudents = await _sIMSContext.Students.ToListAsync();
        return Page();
    }
}