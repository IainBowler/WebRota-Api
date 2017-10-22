using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebRotaApi.Resources
{
    public class OrganisationResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OwnerId { get; set; }
        public ICollection<MemberResource> Members { get; set; }

        public OrganisationResource()
        {
            Members = new Collection<MemberResource>();
        }
    }
}
