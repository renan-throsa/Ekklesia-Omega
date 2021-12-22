using System;

namespace Ekklesia.Entities.Entities
{
    public abstract class Report : BaseModel
    {
        //ATIVIDADES BÁSICAS DE RELATÓRIO
        public DateTime Date { get; set; }
        public int PreacherId { get; set; }
        public Member Preacher { get; set; }
        public int CoordinatorId { get; set; }
        public Member Coordinator { get; set; }

        //ATIVIDADES BÁSICAS PARA EVENTOS        
        public int Reunions { get; set; }
        public int Convertions { get; set; }

        //MOVIMENTO FINANCEIRO
        public float PreviousMonth { get; set; }
        public float Income { get; set; }
        public float Expense { get; set; }
        public float Tenth { get; set; }
        public float Balance { get; set; }

        public Report()
        {
            this.Preacher = new Member();
            this.Coordinator = new Member();
        }
    }
}
