﻿using System;

namespace TP.Models.WebModels
{
    public class EventModel
    {

        public long EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ScheduledDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? RegistrationStartDate { get; set; }
        public DateTime? RegistrationEndDate { get; set; }
        public string RecCreatedBy { get; set; }
        public DateTime RecCreatedDate { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public DateTime RecLastUpdatedDate { get; set; }


        
    }
}