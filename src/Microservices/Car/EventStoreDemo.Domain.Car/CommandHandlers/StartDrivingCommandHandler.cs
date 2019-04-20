using EventStoreDemo.Domain.Car.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Car.CommandHandlers
{
    public class StartDrivingCommandHandler : CarCommandHandlerBase<StartDrivingCommand>
    {
        public StartDrivingCommandHandler(StartDrivingCommand command) : base(command)
        {
        }

        public StartDrivingCommandHandler(StartDrivingCommand command, Car aggregate) : base(command, aggregate)
        {
        }

        protected override void ExecuteCommand(Car aggregateRoot, StartDrivingCommand command)
        {
            aggregateRoot.StartDriving(command.DrivingStartedAt, command.Driver);
        }
    }
}
