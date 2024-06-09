using FilaZeroApi.models;
using Flunt.Notifications;
using Flunt.Validations;

namespace FilaZeroApi.ViewModels
{
    public class CreateAgenciaViewModel: Notifiable<Notification>
    {
        
        public string nome { get; set; }

        public Agencia MapTo()
        {
            var contract = new Contract<Notification>()
                               .Requires()
                               .IsNotNull(nome, "Informe um nome")
                               .IsGreaterThan(nome, 3, "O titulo deve conter mais de 3");
            AddNotifications(contract);

            return new Agencia(Guid.NewGuid(), nome);

        }
    }
}
