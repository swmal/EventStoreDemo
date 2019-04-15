using EventStoreDemo.Domain.CarRental.Commands;

namespace EventStoreDemo.Domain.CarRental.CommandHandlers
{
    public class AquireCarCommandHandler : CommandHandler<CarRental>
    {
       public AquireCarCommandHandler(AquireCarCommand command) : base(command)
        {
            _command = command;
        }

        public AquireCarCommandHandler(AquireCarCommand command, CarRental aggregateRoot) : base(command, aggregateRoot)
        {
            _command = command;
        }

        private readonly AquireCarCommand _command;

        protected override void ExecuteCommand(CarRental aggregateRoot)
        {
            aggregateRoot.AquireCar(_command.Registration, _command.Model, _command.Seller, _command.AquiredDate,_command.RegistrationDate, _command.Milage);
        }
    }
}
