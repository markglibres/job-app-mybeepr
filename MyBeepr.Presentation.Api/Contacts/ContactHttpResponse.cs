﻿using System;

namespace MyBeepr.Presentation.Api.Contacts
{
    public class ContactHttpResponse
    {
        public Guid ContactId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}