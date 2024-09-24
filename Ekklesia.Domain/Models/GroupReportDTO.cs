using Ekklesia.Domain.Entities;
using MongoDB.Bson;
using System;

namespace Ekklesia.Domain.DTOs
{
    public class GroupReportDTO : ReportDTO
    {

        //CONCRET
        public int NumberOfExternalCults { get; set; }
        public int NumberOfCells { get; set; }
        public int NumberOfBaptizeds { get; set; }
        public int NumberOfCoordinationMeetings { get; set; }

        public override Report ToEntity(params string[] props)
        {
            return new GroupReport
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
                NumberOfExternalCults = this.NumberOfExternalCults,
                NumberOfCells = this.NumberOfCells,
                NumberOfBaptizeds = this.NumberOfBaptizeds,
                NumberOfCoordinationMeetings = this.NumberOfCoordinationMeetings,

            };
        }
    }
}
