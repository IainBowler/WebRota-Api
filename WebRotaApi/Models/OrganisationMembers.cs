using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRotaApi.Models
{
    public class OrganisationMember
    {
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int OrganisationId { get; set; }
        public Organisation Organisation { get; set; }
    }
}
