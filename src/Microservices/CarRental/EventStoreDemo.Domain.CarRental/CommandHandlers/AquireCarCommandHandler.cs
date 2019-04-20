using EventStoreDemo.Domain.CarRental.Commands;

namespace EventStoreDemo.Domain.CarRental.CommandHandlers
{
    public class AquireCarCommandHandler : CarRentalCommandHandlerBase<AquireCarCommand>
    {
        public AquireCarCommandHandler(AquireCarCommand command) : base(command)
        {
        }

        public AquireCarCommandHandler(AquireCarCommand command, CarRental aggregateRoot) : base(command, aggregateRoot)
        {
        }

        // 
        protected override void ExecuteCommand(CarRental aggregateRoot, AquireCarCommand command)
        {
            aggregateRoot.AquireCar(command.Registration, command.Model, command.Seller, command.AquiredDate, command.RegistrationDate, command.Milage);
        }
    }
}
