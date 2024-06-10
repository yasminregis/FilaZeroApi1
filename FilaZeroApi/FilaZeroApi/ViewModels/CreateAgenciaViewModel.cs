using FilaZeroApi.models;
using Flunt.Notifications;
using Flunt.Validations;

namespace FilaZeroApi.ViewModels
{
    public class CreateAgenciaViewModel: Notifiable<Notification>
    {


        public string cnpj { get; set; } = "";
        public string codigoAgencia { get; set; } = "";
        public string endereco { get; set; } = "";
        public string nomeBanco { get; set; } = "";
        public string nomeCompleto { get; set; } = "";
        public string senha { get; set; } = "";

        public Agencia MapTo()
        {
            var contract = new Contract<Notification>()
                               .Requires()
                               .IsNotNull(nomeBanco, "Informe um nome")
                               .IsGreaterThan(nomeBanco, 3, "O titulo deve conter mais de 3");
            AddNotifications(contract);
            //public record Agencia(Guid Id, string cnpj, string codigoAgencia, string endereco, string nomeBanco, string nomeCompleto, string senha);


            return new Agencia(Guid.NewGuid(), cnpj, codigoAgencia, endereco, nomeBanco, nomeCompleto, senha);

        }
    }
}
