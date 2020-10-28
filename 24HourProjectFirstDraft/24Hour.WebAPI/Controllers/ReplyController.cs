using _24Hour.Data;
using _24Hour.Models;
using _24Hour.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24Hour.WebAPI.Controllers
{
    [RoutePrefix("api/reply")]  //--------services?------------ 
    [Authorize] // added attribute tag
    public class ReplyController : ApiController
    {
        //--------services?------------ 
        // First new up DbContext and add using statements
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // Next adding a method and a using statement to allow us to use our ReplyService in our methods
        private ReplyService CreateReplyService()
        {
            var replyService = new ReplyService();
            return replyService;
        }

        // Next add our Get, Put, Post, Delete methods

        // Post method (Create)
        //--------services?--------------
        //[HttpPost]
        //public IHttpActionResult Post(ReplyCreate reply)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var service = CreateReplyService();

        //    if (!service.CreateReply(reply))
        //        return InternalServerError();

        //    return Ok("Done");
        //}
        [HttpPost]  
        public IHttpActionResult Create(Reply replyToAdd)     
        {
            _context.Replys.Add(replyToAdd);  

            if (_context.SaveChanges() == 1)    
            {
                return Ok(replyToAdd);
            }

            return BadRequest();
        }

        // Get All method (Read All)
        //public IHttpActionResult Get()
        //{
        //ReplyService replyService = CreateReplyService();
        //var replys = replyService.GetReplys();
        //return Ok(replys);
        //}
        // Get All method (Read All) 
        [HttpGet]   
        public IHttpActionResult Index()    
        {
            List<Reply> replysInDB = _context.Replys.ToList();   
            return Ok(replysInDB);    
        }

        // Put method (Update)
        //----------services?---
        //[HttpPut]
        //public IHttpActionResult Put(ReplyEdit reply)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var service = CreateReplyService();

        //    if (!service.UpdateReply(reply))
        //        return InternalServerError();

        //    return Ok("Updated");
        //}
        [HttpPut]   
        public IHttpActionResult Update(Reply updatedReply)
        {
            Reply requestedReply = _context.Replys.Find(updatedReply); 
            if (requestedReply == null)
            {
                return BadRequest("Not found");    
            }
            
            requestedReply.ReplyComment = updatedReply.ReplyComment;   

            if (_context.SaveChanges() == 1)
            {
                return Ok(updatedReply);
            }
            return BadRequest("Not updated");      
        }

        // Delete method
        //----------services?---
        //[HttpDelete]
        //public IHttpActionResult Delete()
        //{
        //    var service = CreateReplyService();

        //    if (!service.DeleteReply())
        //        return InternalServerError();

        //    return Ok("Deleted");
        //}   // More code for this method is connected to ReplyService.cs 
        [HttpDelete]
        public IHttpActionResult Delete()   
        {
            Reply requestedReply = _context.Replys.Find();
            
            if (requestedReply == null)
            {
                return BadRequest("Not Found");   
            }
            
            _context.Replys.Remove(requestedReply);

            if (_context.SaveChanges() == 1)     
            {
                return Ok("Reply deleted");    
            }
            return BadRequest("Not deleted");    
        }

    }
}
