using System.Collections.Generic;

namespace Ekkleisa.Business.Contract.Scheduler
{
    public sealed class SchedulerSettings
    {
        public string BaseURL { get; set; }        
        public bool IniciarJobsNoStartup { get; set; }        
        public string Sistema { get; set; }        
        public Dictionary<string, SchedulerDTO> Jobs { get; set; } = new Dictionary<string, SchedulerDTO>();
    }
}
