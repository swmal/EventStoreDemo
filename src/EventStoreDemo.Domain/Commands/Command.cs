using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain
{
    public class Command<T>
        where T : AggregateRoot, new()
    {
    }
}
