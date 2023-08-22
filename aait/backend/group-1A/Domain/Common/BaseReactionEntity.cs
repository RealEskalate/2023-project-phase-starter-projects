using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class BaseReactionEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public bool Like { get; set; } = false;

        public bool Dislike { get; set; } = false;
    }
}
