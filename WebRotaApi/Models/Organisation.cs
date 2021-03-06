﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebRotaApi.Models
{
    public class Organisation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OwnerId { get; set; }
        public ICollection<OrganisationMember> Members { get; set; }

        public Organisation()
        {
            Members = new Collection<OrganisationMember>();
        }
    }
}
