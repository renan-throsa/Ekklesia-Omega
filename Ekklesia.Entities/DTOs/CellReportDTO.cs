using Ekklesia.Entities.Entities;
using MongoDB.Bson;
using System;

namespace Ekklesia.Entities.DTOs
{
    public class CellReportDTO : ReportDTO
    {

        //CONCRET
        public int NumberOfCoordinationMeetings { get; set; }
        public int NumberOfVisitants { get; set; }
        public int NumberOfEvangelisms { get; set; }
        public int NumberOfBoardMembers { get; set; }


        public override Report ToEntity(params string[] props)
        {
            return new CellReport
            {
                Id = string.IsNullOrEmpty(this.Id) ? ObjectId.Empty : ObjectId.Parse(this.Id),
                Date = this.Date,
                Preacher = this.Preacher.ToEntity(nameof(MemberDTO.Name), nameof(MemberDTO.Id)),
                Coordinator = this.Coordinator.ToEntity(nameof(MemberDTO.Name), nameof(MemberDTO.Id)),
                NumberOfReunions = this.NumberOfReunions,
                NumberOfConvertions = this.NumberOfConvertions,
                PreviousMonth = this.PreviousMonth,
                Income = this.Income,
                Expense = this.Expense,
                Tenth = this.Tenth,
                Balance = this.Balance,
                NumberOfCoordenationMeatings = this.NumberOfCoordinationMeetings,
                NumberOfVisitants = this.NumberOfVisitants,
                NumberOfEvangelisms = this.NumberOfEvangelisms,
                NumberOfBoardMembers = this.NumberOfBoardMembers,

            };
        }
    }
}
