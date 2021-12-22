using System;

namespace Ekklesia.Entities.DTOs
{
    public class GroupReportDTO
    {
        //ABSTRACT
        //ATIVIDADES BÁSICAS DE RELATÓRIO
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int PreacherId { get; set; }
        public MemberDTO Preacher { get; set; }
        public int CoordinatorId { get; set; }
        public MemberDTO Coordinator { get; set; }

        //ATIVIDADES BÁSICAS PARA EVENTOS        
        public int Reunions { get; set; }
        public int Convertions { get; set; }

        //MOVIMENTO FINANCEIRO
        public float PreviousMonth { get; set; }
        public float Income { get; set; }
        public float Expense { get; set; }
        public float Tenth { get; set; }
        public float Balance { get; set; }

        //CONCRET
        public int NumberExternalCults { get; set; }        
        public int NumberOfCells{ get; set; }        
        public int NumberOfBaptizeds { get; set; }        
        public int NumberOfMeetingsWithTheCoordination { get; set; }

        public GroupReportDTO()
        {
            this.Preacher = new MemberDTO();
            this.Coordinator = new MemberDTO();
        }

    }
}
