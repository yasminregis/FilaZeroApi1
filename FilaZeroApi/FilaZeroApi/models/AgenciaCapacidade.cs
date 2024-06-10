namespace FilaZeroApi.models
{
    public class AgenciaCapacidade
    {
        public AgenciaCapacidade(Guid id, Guid agenciaId, string HorarioFechamento, string HorarioAbertura, int lotacao, int quantidadeFichas)
        {
            this.id = id;
            this.agenciaId = agenciaId;
            this.HorarioFechamento  = HorarioFechamento;
            this.HorarioAbertura = HorarioAbertura;
            this.lotacao = lotacao;
            this.quantidadeFichas = quantidadeFichas;
        }

        public Guid id { get; set; }
        public Guid agenciaId { get; set; }
        public string HorarioFechamento { get; set; }
        public string HorarioAbertura { get; set; }

        public int lotacao { get; set; }
        public int quantidadeFichas { get; set; }

    }
}
