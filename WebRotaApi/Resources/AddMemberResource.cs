using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRotaApi.Resources
{
    public class AddMemberResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public int OrganisationId { get; set; }
    }
}
