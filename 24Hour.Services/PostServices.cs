using _24Hour.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Services
{
    public class PostServices
    {
        private readonly Guid _userId;

        public PostServices(Guid userId)
        {
            _userId = userId;
        }
    }
    public bool CreatePost(PostCreate model)
    {
        var entity =
            new Post)
            {
                OwnerId = _userId,
                Title = model.Title,
                Content = model.Content,
                CreatedUtc = DateTimeOffset.Now
            };

        using (var ctx = new ApplicationDbContext())
        {
            ctx.Post.Add(entity);
            return ctx.SaveChanges() == 1;
        }
    }
    public IEnumerable<PostListItem> GetPosts()
    {
        using (var ctx = new ApplicationDbContext())
        {
            var query =
                ctx
                    .Posts
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                            new PostListItem
                            {
                                NoteId = e.NoteId,
                                Title = e.Title,
                                CreatedUtc = e.CreatedUtc
                            }
                    );

            return query.ToArray();
        }
    }
}
