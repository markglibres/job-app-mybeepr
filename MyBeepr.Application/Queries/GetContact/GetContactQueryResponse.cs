﻿using System;

namespace MyBeepr.Application.Queries.GetContact
{
    public class GetContactQueryResponse
    {
        public Guid ContactId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}