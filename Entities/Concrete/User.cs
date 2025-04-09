using Core.Entities.Abstract;
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
        public User()
        {
            UserOperationClaims = new HashSet<UserOperationClaim>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }



        public ICollection<UserOperationClaim> UserOperationClaims { get; set; }
        public ICollection<Evaluation> Evaluations { get; set; }
    } 
}
