using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebRotaApi.Models;
using WebRotaApi.Persistence;

namespace WebRotaApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Organisations")]
    public class OrganisationsController : Controller
    {
        private readonly WebRotaDbContext context;

        private Organisation dummyOrganisation = new Organisation { Id = 1, Name = "Organisation 1", OwnerId = "1234" };

        public OrganisationsController(WebRotaDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Organisation value)
        {
            value.Id = 0;
            context.Organisations.Add(value);
            context.SaveChanges();
            return Ok(value);
        }

        [HttpGet("{ownerId}")]
        public IActionResult GetOwnersOrganisations(string ownerId)
        {
            List<Organisation> ownerOrganisations = context.Organisations.Where(o => o.OwnerId == ownerId).ToList();

            return Ok(ownerOrganisations);
        }
    }
}