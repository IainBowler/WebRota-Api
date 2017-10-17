using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRotaApi.Models
{
    public class Organisation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OwnerId { get; set; }
    }
}
