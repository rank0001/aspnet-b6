using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystem.Data
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
