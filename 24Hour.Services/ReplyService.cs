using _24Hour.Data;
using _24Hour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Services
{// In here we make the class public, perform CRUD, make the methods public, add using statements along the way
    public class ReplyService
    {
        // FIRST: Since the Reply class does not have a Guid, we can skip the Guid code
        // SECOND: We will add our CRUD methods

        // Create: Make a new reply
        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    ReplyComment = model.ReplyComment
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replys.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Read Single: View a reply 
        public ReplyDetail GetReply()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replys;
                return
                    new ReplyDetail
                    {
                        ReplyComment = entity.ReplyComment
                    };
            }
        }

        // Update: Update a reply
        public bool UpdateReply(ReplyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replys;

                entity.ReplyComment = model.ReplyComment;

                return ctx.SaveChanges() == 1;
            }
        }

        // Delete: delete a reply
        public bool DeleteReply()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replys;

                ctx.Replys.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}
