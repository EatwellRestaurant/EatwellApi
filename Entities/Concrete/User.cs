﻿using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User : BaseEntity
    {
        public int OperationClaimId { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Password { get; set; }
        
        public string Email { get; set; }
        
        public bool? Verification { get; set; }
        
        public string? VerificationCode { get; set; }
        
        public DateTime? VerificationCodeDuration { get; set; }
        
        public DateTime? LastLoginDate { get; set; }




        
        
        public OperationClaim OperationClaim { get; set; }

        public Employee Employee { get; set; }

        public ICollection<Evaluation> Evaluations { get; set; }
    } 
}
