using _24Hour.Data;
using _24Hour.Models;
using _24Hour.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24Hour.WebAPI.Controllers
{
    [RoutePrefix("api/user")]   //--------services?------------ 
    [Authorize] // added attribute tag
    public class UserController : ApiController
    {
        //--------services?------------ 
        // First new up DbContext and add using statements
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // Next adding a method and a using statement to allow us to use our UserService in our methods
        private UserService CreateUserService() 
        {
            var id = Guid.Parse(User.Identity.GetUserId());     
            var userService = new UserService(id);
            return userService;
        }

        // Next add our Get, Put, Post, Delete methods

        // Post method (Create)
        //--------services?------------ 
        //[HttpPost]
        //public IHttpActionResult Post(UserCreate user)      
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var service = CreateUserService();

        //    if (!service.CreateUser(user))
        //        return InternalServerError();

        //    return Ok("Done");
        //}
        [HttpPost]
        public IHttpActionResult Create(User userToAdd)
        {
            _context.Users.Add(userToAdd);

            if (_context.SaveChanges() == 1)
            {
                return Ok(userToAdd);
            }

            return BadRequest();
        }

        // Get All method (Read all)
        //--------services?------------ 
        //[HttpGet]
        //public IHttpActionResult Get()
        //{
        //    UserService userService = CreateUserService();
        //    var users = userService.GetUsers();
        //    return Ok(users);
        //}
        [HttpGet]
        public IHttpActionResult Index()
        {
            List<User> usersInDB = _context.Users.ToList();
            return Ok(usersInDB);
        }

        // Get user by ID method (Read single)
        //--------services?------------ 
        //[HttpGet]
        //public IHttpActionResult Get(int id)
        //{
        //    UserService userService = CreateUserService();
        //    var user = userService.GetUserById(id);
        //    return Ok(user);
        //}
        [HttpGet]   
        [Route("{id}")] // Route lets us customise what the endpoint(last part of the url) is to get/activate this method. For this one we want to use the id
        public IHttpActionResult GetByID(int id)    
        {
            User requestedUser = _context.Users.Find(id); 
              
            if (requestedUser == null)    
            {
                return NotFound();      
            }
            return Ok(requestedUser); 
        }

        // Put method (Update)
        //--------services?------------ 
        //[HttpPut]
        //public IHttpActionResult Put(UserEdit user)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var service = CreateUserService();

        //    if (!service.UpdateUser(user))
        //        return InternalServerError();

        //    return Ok("Updated");
        //}
        [HttpPut]
        public IHttpActionResult Update(User updatedUser)
        {
            User requestedUser = _context.Users.Find(updatedUser);
            if (requestedUser == null)
            {
                return BadRequest("Not found");
            }

            requestedUser.Name = updatedUser.Name;
            requestedUser.Email = updatedUser.Email;

            if (_context.SaveChanges() == 1)
            {
                return Ok(updatedUser);
            }
            return BadRequest("Not updated");
        }

        // Delete method
        //--------services?------------ 
        //[HttpDelete]
        //public IHttpActionResult Delete(int id)
        //{
        //    var service = CreateUserService();

        //    if (!service.DeleteUser(id))
        //        return InternalServerError();

        //    return Ok("Deleted");    
        //}   // More code for this method is connected to UserService.cs 
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete([FromUri] int id)
        {
            User requestedUser = _context.Users.Find(id);

            if (requestedUser == null)
            {
                return BadRequest("Not Found");
            }

            _context.Users.Remove(requestedUser);

            if (_context.SaveChanges() == 1)
            {
                return Ok("User deleted");
            }
            return BadRequest("Not deleted");
        }

    }
}
