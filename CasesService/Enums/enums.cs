using System.ComponentModel;

namespace CasesService.Enums
{
    public class enums
    {
        public enum CaseStatus
        {
            [Description("תיק פעיל")]
            OpendCase = 1,

            [Description("תיק סגור")]
            closedCase,

            [Description("תיק מוקפא")]
            FreezeCase
        }
    }
}
