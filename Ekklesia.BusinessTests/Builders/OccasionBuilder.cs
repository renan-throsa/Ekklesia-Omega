using Ekkleisa.Business.Models;
using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Enums;
using System;
using System.Collections.Generic;

namespace Ekklesia.IntegrationTesting.Builders
{
    public class OccasionBuilder
    {
        private OccasionType _type;
        private DateTime _startTime;
        private DateTime _endTime;
        private SaveOccasionMemberModel _host;
        private ISet<SaveOccasionMemberModel> _attendees;
        private string _place;
        private string _topic;
        private string _description = string.Empty;
        private int _numberOfConvertions;
        private int _numberOfVisitants;
        private SaveCultModel? _cult;
        private SaveSundaySchoolModel? _sundaySchool;

        public OccasionBuilder()
        {
            _attendees = new HashSet<SaveOccasionMemberModel>();
        }

        public SaveOccasionModel Build()
        {
            return new SaveOccasionModel
            {
                Attendees = _attendees,
                Cult = _cult,
                Description = _description,
                EndTime = _endTime,
                Host = _host,
                Topic = _topic,
                NumberOfConvertions = _numberOfConvertions,
                NumberOfVisitants = _numberOfVisitants,
                Place = _place,
                StartTime = _startTime,
                SundaySchool = _sundaySchool,
                Type = _type
            };
        }

        public OccasionBuilder WithType(OccasionType type)
        {
            _type = type;
            return this;
        }

        public OccasionBuilder WithStarTime(DateTime date)
        {
            _startTime = date;
            return this;
        }

        public OccasionBuilder WithEndTime(DateTime date)
        {
            _endTime = date;
            return this;
        }

        public OccasionBuilder WithHost(SaveOccasionMemberModel host)
        {
            _host = host;
            return this;
        }

        public OccasionBuilder WithAttendee(SaveOccasionMemberModel member)
        {
            _attendees.Add(member);
            return this;
        }

        public OccasionBuilder WithTopic(string topic = "Um tópico qualquer")
        {
            _topic = topic;
            return this;
        }

        public OccasionBuilder WithPlace(string place = "Um local bonito")
        {
            _place = place;
            return this;
        }

        public OccasionBuilder WithDescription(string desription = "Uma descrição qualquer")
        {
            _description = desription;
            return this;
        }

        public OccasionBuilder WithNumberOfConvertions(int number = 10)
        {
            _numberOfConvertions = number;
            return this;
        }
        public OccasionBuilder WithNumberOfVisitants(int number = 5)
        {
            _numberOfVisitants = number;
            return this;
        }

    }
}
