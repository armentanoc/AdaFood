using AdaFood.Models;

namespace AdaFood.Repositorio
{
    public class EntregadorRepository : IEntregadorRepository
    {
        public List<Entregador> listaEntregadores = new List<Entregador>();
        private static int ContadorId = 1;

        public EntregadorRepository()
        {
            listaEntregadores.Add(new Entregador() { Id = ContadorId++, Nome = "Fernando", CPF = "43276498701"});
            listaEntregadores.Add(new Entregador() { Id = ContadorId++, Nome = "Roberta", CPF = "45683206302" });
        }
        public void Add(EntregadorRequest entregadorRequest)
        {
            var entregador = new Entregador() { Id = ContadorId++, Nome = entregadorRequest.Nome, CPF = entregadorRequest.CPF };
            listaEntregadores.Add(entregador);
        }

        public Entregador? GetByCPF(string cpf)
        {
            return listaEntregadores.FirstOrDefault(entregador => entregador.CPF == cpf);
        }
    }
}
