using Ekklesia.Entities.Entities;
using MongoDB.Bson;

namespace Ekklesia.Entities.DTOs
{
    public class BiblicalReportDTO : ReportDTO
    {

        //CONCRET
        public int NumberOfBibles { get; set; }
        public int NumberOfReunionWithTeachers { get; set; }
        public int NumberOfVisitants { get; set; }
        public int NumberOfPeopleAttending { get; set; }
        public int NumberOfPeopleInPedagogicalBody { get; set; }


        public override Report ToEntity(params string[] props)
        {
            return new BiblicalReport
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
                NumberOfBibles = this.NumberOfBibles,
                NumberOfReunionWithTeachers = this.NumberOfReunionWithTeachers,
                NumberOfVisitants = this.NumberOfVisitants,
                NumberOfPeopleAttending = this.NumberOfPeopleAttending,
                NumberOfPeopleInPedagogicalBody = this.NumberOfPeopleInPedagogicalBody,

            };
        }
    }
}
