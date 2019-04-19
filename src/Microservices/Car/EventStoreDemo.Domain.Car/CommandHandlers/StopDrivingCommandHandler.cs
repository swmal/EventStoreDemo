using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Car.CommandHandlers
{
    public class StopDrivingCommandHandler : CarCommandHandlerBase
    {
        public StopDrivingCommandHandler(StopDrivingCommand command) : base(command)
        {
            _command = command;
        }

        public StopDrivingCommandHandler(StopDrivingCommand command, Car aggregateRoot) : base(command, aggregateRoot)
        {
            _command = command;
        }

        private readonly StopDrivingCommand _command;
        protected override void ExecuteCommand(Car aggregateRoot)
        {
            aggregateRoot.StopDriving(_command.DrivingStoppedAt, _command.Driver, _command.DistanceDriven);
        }
    }
}
