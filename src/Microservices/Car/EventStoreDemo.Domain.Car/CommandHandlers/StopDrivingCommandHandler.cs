using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Car.CommandHandlers
{
    public class StopDrivingCommandHandler : CarCommandHandlerBase<StopDrivingCommand>
    {
        public StopDrivingCommandHandler(StopDrivingCommand command) : base(command)
        {
        }

        public StopDrivingCommandHandler(StopDrivingCommand command, Car aggregate) : base(command, aggregate)
        {
        }

        protected override void ExecuteCommand(Car aggregateRoot, StopDrivingCommand command)
        {
            aggregateRoot.StopDriving(command.DrivingStoppedAt, command.Driver, command.DistanceDriven);
        }
    }
}
