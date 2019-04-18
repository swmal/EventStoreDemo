using EventStoreDemo.Domain.Car.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Car.CommandHandlers
{
    public class StartDrivingCommandHandler : CarCommandHandlerBase
    {
        public StartDrivingCommandHandler(StartDrivingCommand command) : base(command)
        {
            _command = command;
        }

        public StartDrivingCommandHandler(StartDrivingCommand command, Car aggregateRoot) : base(command, aggregateRoot)
        {
            _command = command;
        }

        private readonly StartDrivingCommand _command;
        protected override void ExecuteCommand(Car aggregateRoot)
        {
            aggregateRoot.StartDriving(_command.DrivingStartedAt, _command.Driver);
        }
    }
}
