using Ekklesia.Entities.Entities;
using System;

namespace Ekklesia.Entities.DTOs
{
    public abstract class ReportDTO : BaseDto<Report>
    {
        //ATIVIDADES BÁSICAS DE RELATÓRIO
        public DateTime Date { get; set; }
        public MemberDTO Preacher { get; set; }
        public MemberDTO Coordinator { get; set; }

        //ATIVIDADES BÁSICAS PARA EVENTOS        
        public int NumberOfReunions { get; set; }
        public int NumberOfConvertions { get; set; }

        //MOVIMENTO FINANCEIRO
        public float PreviousMonth { get; set; }
        public float Income { get; set; }
        public float Expense { get; set; }
        public float Tenth { get; set; }
        public float Balance { get; set; }

        public ReportDTO()
        {
            this.Preacher = new MemberDTO();
            this.Coordinator = new MemberDTO();
        }

    }
}
