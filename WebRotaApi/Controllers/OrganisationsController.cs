using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebRotaApi.Models;
using WebRotaApi.Persistence;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using WebRotaApi.Resources;

namespace WebRotaApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Organisations")]
    public class OrganisationsController : Controller
    {
        private readonly WebRotaDbContext context;
        private readonly IMapper mapper;
        private Organisation dummyOrganisation = new Organisation { Id = 1, Name = "Organisation 1", OwnerId = "1234" };

        public OrganisationsController(WebRotaDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Organisation value)
        {
            value.Id = 0;
            context.Organisations.Add(value);
            context.SaveChanges();
            return Ok(value);
        }

        [HttpGet("{usersId}")]
        public IActionResult GetUsersOrganisations(string usersId)
        {
            List<Organisation> ownerOrganisations = context.Organisations.Where(o => o.OwnerId == usersId).ToList();

            List<Organisation> memberOrganisations = context.OrganisationMembers
                                                                .Include(om => om.Organisation)
                                                                .Include(om => om.Member)
                                                                .Where(om => om.Member.UserId == usersId)
                                                                .Select(om => om.Organisation)
                                                                .Include(o => o.Members)
                                                                .ToList();

            List<List<OrganisationResource>> returnList = new List<List<OrganisationResource>>();

            returnList.Add(mapper.Map<List<Organisation>, List<OrganisationResource>>(ownerOrganisations));

            returnList.Add(mapper.Map<List<Organisation>, List<OrganisationResource>>(memberOrganisations));

            return Ok(returnList);
        }
    }
}