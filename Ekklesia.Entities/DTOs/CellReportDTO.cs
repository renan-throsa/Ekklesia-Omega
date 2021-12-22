using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekklesia.Entities.DTOs
{
    public class CellReportDTO
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
        public int CoordenationMeatings { get; set; }        
        public int NumberOfVisits { get; set; }        
        public int NumberOfEvangelisms { get; set; }        
        public int NumberOfBoardMembers { get; set; }

        public CellReportDTO()
        {
            this.Preacher = new MemberDTO();
            this.Coordinator = new MemberDTO();
        }
    }
}
