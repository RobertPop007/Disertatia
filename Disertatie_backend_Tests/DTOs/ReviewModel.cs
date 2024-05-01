﻿using Disertatie_backend.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Disertatie_backend_Tests.DTOs
{
    public class ReviewModel
    {
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        public string ItemId { get; set; }
        public string Short_description { get; set; }
        public string Main_description { get; set; }
        public byte Stars { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}