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

        public abstract IDomainEventHandlerResolver EventHandlerResolver { get; }

        protected CommandHandler<T> Handler { get; private set; }

        public CommandHandler(Command<T> command, T aggregateRoot)
        {
            _root = aggregateRoot;
        }

        private readonly T _root;
        protected abstract void ExecuteCommand(T aggregateRoot);

        protected virtual void OnCommandExecuted(T aggregateRoot) { }
        public void Execute()
        {
            ExecuteCommand(_root);
            foreach(var evt in _root.DomainEvents)
            {
                var handler = EventHandlerResolver.ResolveHandler(evt.GetType());
                handler.HandleEvent(evt);
            }
            OnCommandExecuted(_root);
        }
    }
}
