using EventStoreDemo.Domain.EventHandlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain
{
    public abstract class CommandHandler<T>
        where T : AggregateRoot, new()
    {
        public CommandHandler(Command<T> command)
        {
            _root = new T();
        }

        public CommandHandler(Command<T> command, T aggregateRoot)
        {
            _root = aggregateRoot;
        }

        private readonly T _root;
        protected abstract void ExecuteCommand(T aggregateRoot);
        public void Execute()
        {
            ExecuteCommand(_root);
            foreach(var evt in _root.DomainEvents)
            {
                DomainEventHandlers.Publish(evt);
            }
        }
    }
}
