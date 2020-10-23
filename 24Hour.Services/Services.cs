using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Services
{
    public class Services
    {
        private readonly Guid _userId;

        public Service(Guid userId)
        {
            _userId = userId;
        }
    }
}
