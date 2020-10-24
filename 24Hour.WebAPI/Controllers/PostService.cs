using System;

namespace _24Hour.WebAPI.Controllers
{
    internal class PostService
    {
        private Guid userId;

        public PostService(Guid userId)
        {
            this.userId = userId;
        }
    }
}