﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyClub.Data.Entities
{
    public class Interest
    {
        public Guid InterestId { get; set; }
        public virtual Photo Logo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
