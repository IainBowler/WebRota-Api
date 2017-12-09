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
    [Route("api/Members")]
    public class MembersController : Controller
    {
        private readonly WebRotaDbContext context;
        private readonly IMapper mapper;

        public MembersController(WebRotaDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddMember([FromBody]AddMemberResource addMemberResource)
        {
            Member member = new Member
            {
                Name = addMemberResource.Name,
                UserId = addMemberResource.UserId
            };

            context.Members.Add(member);

            context.SaveChanges();

            OrganisationMember organisationMember = new OrganisationMember
            {
                OrganisationId = addMemberResource.OrganisationId,
                MemberId = member.Id
            };

            context.OrganisationMembers.Add(organisationMember);

            context.SaveChanges();

            addMemberResource.Id = member.Id;

            return Ok(addMemberResource);
        }
    }
}