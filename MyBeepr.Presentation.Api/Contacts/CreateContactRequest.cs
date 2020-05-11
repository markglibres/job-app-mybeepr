﻿using Microsoft.AspNetCore.Mvc;

namespace MyBeepr.Presentation.Api.Contacts
{
    public class CreateContactRequest
    {
        [FromBody]
        public string Email { get; set; }
        [FromBody]
        public string Firstname { get; set; }
        [FromBody]
        public string Lastname { get; set; }
    }
}