using System;
using System.Collections.Generic;
using System.Text;

namespace PhamaMicroCrm.Model.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        protected Entity()
        {
            Id = new Guid();
        }
    }
}
