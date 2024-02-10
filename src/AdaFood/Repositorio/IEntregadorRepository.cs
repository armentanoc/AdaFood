using AdaFood.Models;

namespace AdaFood.Repositorio
{
    public interface IEntregadorRepository
    {
        public void Add(EntregadorRequest entregador);

        public Entregador GetByCPF(string cpf);

    }
}
