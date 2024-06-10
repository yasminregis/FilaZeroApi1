using FilaZeroApi.models;
using Flunt.Notifications;
using Flunt.Validations;

namespace FilaZeroApi.ViewModels
{
    public class CreateAgenciaCapacidadeViewModel : Notifiable<Notification>
    {
        public Guid id { get; set; } = Guid.Empty;
        public Guid agenciaId { get; set; } = Guid.Empty;
        public string HorarioFechamento { get; set; } = string.Empty;
        public string HorarioAbertura { get; set; } = string.Empty;

        public int lotacao { get; set; } = 0;
        public int quantidadeFichas { get; set; } = 0;

        public AgenciaCapacidade MapTo()
        {
            var contract = new Contract<Notification>();
                               


            AddNotifications(contract);

            return new AgenciaCapacidade(id == Guid.Empty? Guid.NewGuid(): id, agenciaId, HorarioFechamento, HorarioAbertura, lotacao, quantidadeFichas);
        }
    }
}
