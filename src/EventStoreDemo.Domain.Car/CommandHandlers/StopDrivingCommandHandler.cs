using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Car.CommandHandlers
{
    public class StopDrivingCommandHandler : CommandHandler<Car>
    {
        public StopDrivingCommandHandler(StopDrivingCommand command) : base(command, new DomainEventHandlerResolver())
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
