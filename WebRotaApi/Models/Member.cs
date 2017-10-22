using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebRotaApi.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public ICollection<OrganisationMember> Organisations { get; set; }

        public Member()
        {
            Organisations = new Collection<OrganisationMember>();
        }
    }
}
