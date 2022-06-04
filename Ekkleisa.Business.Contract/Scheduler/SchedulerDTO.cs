namespace Ekkleisa.Business.Contract.Scheduler
{
    public sealed class SchedulerDTO
    {
        public string Route { get; set; }        
		public string Cron { get; set; }        
        public bool ImmediateExecution { get; set; }
    }
}
