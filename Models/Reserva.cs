using DesafioProjetoHospedagem.Models.Exceptions;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {

        private const int QuantidadeDiasReservadosDesconto = 10;
        private const decimal PorcentagemDesconto = 0.1M;

        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (IsListaHospedesVazia(hospedes))
                throw new EmptyListException("Lista de hóspedes não pode ser vazia!");

            int quantidadeHospedes = hospedes.Count;

            if (IsCapacidadeSuiteMaiorNumeroHospedes(quantidadeHospedes))
                Hospedes = hospedes;
            else
                throw new GuestCapacityExceededException("Capacidade da suíte é menor do que o número de hóspedes!");
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (IsValorDesconto())
            {

                decimal valorDesconto = valor * PorcentagemDesconto;
                valor -= valorDesconto;
            }

            return valor;
        }

        private bool IsCapacidadeSuiteMaiorNumeroHospedes(int quantidadeHospedes)
        {
            return Suite.Capacidade >= quantidadeHospedes;
        }

        private bool IsListaHospedesVazia(List<Pessoa> hospedes)
        {
            return hospedes == null || hospedes.Count == 0;
        }

        private bool IsValorDesconto()
        {
            return DiasReservados >= QuantidadeDiasReservadosDesconto;
        }
    }
}