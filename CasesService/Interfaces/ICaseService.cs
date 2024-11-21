using CasesService.Models;

namespace CasesService.Interfaces
{
    public interface ICaseService
    {
        Task<int> CreateCaseDetails(CaseDetail caseDetail);
        Task<List<CaseDetail>> GetCaseDetails(filterCase filterCase);

    }
}
