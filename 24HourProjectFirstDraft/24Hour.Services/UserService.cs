using _24Hour.Data;
using _24Hour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Services
{// In here we make the class public, perform CRUD, make the methods public, add using statements along the way
    public class UserService
    {
        // FIRST: (Check for a Guid) Since the User class has a Guid, we include code here
        private readonly Guid _userId;      // We want a private field of type Guid called _userId
        public UserService(Guid userId)     // We want a constructor with parameters for UserService
        {
            _userId = userId;
        }

        // SECOND: We will add our CRUD methods

        // Create: Make a new user
        public bool CreateUser(UserCreate model)
        {
            var entity =
                new User()
                {
                    Name = model.Name,
                    Email = model.Email
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Users.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Read All: view all users
        public IEnumerable<UserListItem> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Users
                        .Where(e => e.Id == _userId)
                        .Select(
                            e =>
                                new UserListItem
                                {
                                    Name = e.Name,
                                    Email = e.Email
                                }
                        );

                return query.ToArray();
            }
        }

        // Read Single: Get user by id (other code is in UserController)
        public UserDetail GetUserById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(e => e.Id == _userId);
                return
                    new UserDetail
                    {
                        Name = entity.Name,
                        Email = entity.Email
                    };
            }
        }

        // Update: Update user info
        public bool UpdateUser(UserEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(e => e.Id == _userId);

                entity.Name = model.Name;
                entity.Email = model.Email;

                return ctx.SaveChanges() == 1;
            }
        }

        // Delete: delete a user by its guid id
        public bool DeleteUser(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(e => e.Id == _userId);

                ctx.Users.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}
