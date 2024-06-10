namespace FilaZeroApi.models
{
   // public record Agencia(Guid Id, string nome);

    public record Agencia(Guid Id, string cnpj, string codigoAgencia, string endereco, string nomeBanco, string nomeCompleto, string senha);



}
