using Ocelot.Responses;

namespace CasesService.Models
{
    public class filterCase 
    {
        public DateTime OpeningDateFrom {  get; set; }
        public DateTime OpeningDateTo { get; set; }
        public string Name { get; set; }    
        public List<int> filterOptions { get; set; }
    }
}
