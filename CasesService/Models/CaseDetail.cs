using static CasesService.Enums.enums;

namespace CasesService.Models
{
    public class CaseDetail
    {
        public int CaseId { get; set; }
        public string CaseName { get; set; }
        public DateTime OpeningDate { get; set; }
        public CaseStatus Status { get; set; }
        public string AssignedTo { get; set; }
        public int? JudgeId { get; set; }
        public string JudgeName { get; set; }
        public string CaseType { get; set; }

        
    }
}
