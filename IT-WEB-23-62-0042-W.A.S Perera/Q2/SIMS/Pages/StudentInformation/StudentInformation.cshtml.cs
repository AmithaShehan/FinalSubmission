using SIMS.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SIMS.Pages.StudentInformation
{
    public class StudentInformationModel : PageModel
    {
        private readonly SIMSContext _sIMSContext;
        public StudentInformationModel(SIMSContext sIMSContext)
        {
            _sIMSContext = sIMSContext;
        }

        public List<Data.Entities.Students> AllStudents { get; set; }

        public async Task OnGetAsync()
        {
            AllStudents = await _sIMSContext.Students
                .Include(s => s.Courses)
                .ToListAsync();
        }
    }
}
