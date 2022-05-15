using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Enums;
using System;
using System.Collections.Generic;

namespace Ekklesia.UnitTesting.Occasion
{
    public class OccasionBuilder
    {
        private OccasionType _type;
        private DateTime _startTime;
        private DateTime _endTime;
        private MemberDTO _host;
        private ISet<MemberDTO> _attendees;
        private string _place;
        private string _topic;
        private string _description = string.Empty;
        private int _numberOfConvertions;
        private int _numberOfVisitants;
        private CultDTO? _cult;
        private SundaySchoolDTO? _sundaySchool;

        public OccasionBuilder()
        {
            this._attendees = new HashSet<MemberDTO>();
        }

        public OccasionDTO Build()
        {
            return new OccasionDTO
            {
                Attendees = this._attendees,
                Cult = this._cult,
                Description = this._description,
                EndTime = this._endTime,
                Host = this._host,
                Topic = this._topic,
                NumberOfConvertions = this._numberOfConvertions,
                NumberOfVisitants = this._numberOfVisitants,
                Place = this._place,
                StartTime = this._startTime,
                SundaySchool = this._sundaySchool,
                Type = _type
            };
        }

        public OccasionBuilder WithType(OccasionType type)
        {
            this._type = type;
            return this;
        }

        public OccasionBuilder WithStarTime(DateTime date)
        {
            this._startTime = date;
            return this;
        }

        public OccasionBuilder WithEndTime(DateTime date)
        {
            this._endTime = date;
            return this;
        }

        public OccasionBuilder WithHost(MemberDTO host)
        {
            this._host = host;
            return this;
        }

        public OccasionBuilder WithAttendees(MemberDTO member)
        {
            this._attendees.Add(member);
            return this;
        }

        public OccasionBuilder WithTopic(string topic = "Um tópico qualquer")
        {
            this._topic = topic;
            return this;
        }

        public OccasionBuilder WithPlace(string place = "Um local bonito")
        {
            this._place = place;
            return this;
        }

        public OccasionBuilder WithDescription(string desription = "Uma descrição qualquer")
        {
            this._description = desription;
            return this;
        }

        public OccasionBuilder WithNumberOfConvertions(int number = 10)
        {
            this._numberOfConvertions = number;
            return this;
        }
        public OccasionBuilder WithNumberOfVisitants(int number = 5)
        {
            this._numberOfVisitants = number;
            return this;
        }

    }
}
