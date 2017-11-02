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
    [Route("api/UserOrganisations")]
    public class UserOrganisations : Controller
    {
        private readonly WebRotaDbContext context;
        private readonly IMapper mapper;

        public UserOrganisations(WebRotaDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("{usersId}")]
        public IActionResult GetUsersOrganisations(string usersId)
        {
            List<Organisation> ownerOrganisations = context.Organisations.Where(o => o.OwnerId == usersId).ToList();

            List<Organisation> memberOrganisations = context.Organisations
                                                                .Include(o => o.Members)
                                                                .ThenInclude(om => om.Member)
                                                                .Where(o => o.Members.Any(om => om.Member.UserId == usersId))
                                                                .ToList();

            List<List<OrganisationResource>> returnList = new List<List<OrganisationResource>>();

            returnList.Add(mapper.Map<List<Organisation>, List<OrganisationResource>>(ownerOrganisations));

            returnList.Add(mapper.Map<List<Organisation>, List<OrganisationResource>>(memberOrganisations));

            return Ok(returnList);
        }
    }
}