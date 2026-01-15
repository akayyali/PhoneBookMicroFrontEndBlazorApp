using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Kernel
{
    public interface IEntity<TId>
    {
        TId? Id { get;}
        public DateTime? CreatedOn { get; init; }
        public DateTime? UpdatedOn { get; set; }

    }

    public abstract class Entity<TId> : IEntity<TId>
    {
        public DateTime? CreatedOn { 
            get => field?.ToLocalTime(); 
            init => field = DateTime.UtcNow; 
        }
        public DateTime? UpdatedOn { 
            get => field?.ToLocalTime();
            set => field = value?.ToUniversalTime();
        }

        public TId? Id { get; protected set; }
    }
}
