using _24Hour.Data;
using _24Hour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Services
{
    public class LikeService
    {
        private readonly Guid _userId;
        public LikeService(Guid id)
        {
            _userId = id;
        }

        public bool CreateLike(LikeCreate model)
        {
            var entity =
                new Like()
                {
                    = _userId,
                    Liker = model.Liker,
                    LikedPost = model.LikedPost
                }
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Likes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LikeListItem> GetLikes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Likes
                        .Where(e => e. == _userId)
                        .Select(
                            e =>
                                new LikeListItem
                                {
                                    LikedPost = e.LikedPost,
                                    Liker = e.Liker
                                }
                      };
            return query.ToArray();
        }


        public LikeDetail GetLikeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Likes
                        .Single(e => e. == id && e. == _userId);
                return
                    new LikeDetail
                    {
                        LikedPost = entity.LikedPost,
                        Liker = entity.Liker
                    };
            }
        }

        public bool UpdateLike(LikeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Likes
                        .Single(e => e. == model. && e. == _userId);

                entity.LikedPost = model.LikedPost;
                entity.Liker = model.Liker;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLike(int likeID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Likes
                        .Single(e => e. == && e. == _userId);

                ctx.Likes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
