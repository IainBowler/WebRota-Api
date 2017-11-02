using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebRotaApi.Models;
using WebRotaApi.Persistence;
using AutoMapper;
using WebRotaApi.Resources;
using System.Collections.Generic;

namespace WebRotaApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Organisations")]
    public class OrganisationsController : Controller
    {
        private readonly WebRotaDbContext context;
        private readonly IMapper mapper;

        public OrganisationsController(WebRotaDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetOrganisations(int orgId)
        {
            List<Organisation> organisations = context.Organisations.Include(o => o.Members)
                                                                .ThenInclude(om => om.Member)
                                                                .ToList();

            List<OrganisationResource> returnOrgs = mapper.Map<List<Organisation>, List<OrganisationResource>>(organisations);

            return Ok(returnOrgs);
        }

        [HttpGet("{orgId}")]
        public IActionResult GetOrganisation(int orgId)
        {
            Organisation organisation = context.Organisations.Include(o => o.Members)
                                                                .ThenInclude(om => om.Member)
                                                                .SingleOrDefault(o => o.Id == orgId);

            OrganisationResource returnOrg = mapper.Map<Organisation, OrganisationResource>(organisation);

            return Ok(returnOrg);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Organisation value)
        {
            value.Id = 0;
            context.Organisations.Add(value);
            context.SaveChanges();
            return Ok(value);
        }
    }
}