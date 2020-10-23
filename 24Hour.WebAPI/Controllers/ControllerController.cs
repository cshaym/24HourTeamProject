using _24Hour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Services.Description;

namespace _24Hour.WebAPI.Controllers
{
    [Authorize]
    public class ControllerController : ApiController
    {
        private Service CreateService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var Service = new Service(userId);
            return Service;
        }
    }
    public IHttpActionResult Post(Create note)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var service = CreateService();

        if (!service.CreateNote(note))
            return InternalServerError();

        return Ok();
    }
}
