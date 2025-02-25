using System;
using System.Collections.Generic;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        // Construtor padrão
        public Reserva() { }

        // Construtor com número de dias reservados
        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        // Método para cadastrar hóspedes
        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verifica se a capacidade da suíte é suficiente para o número de hóspedes
            if (Suite != null && hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                // Lança uma exceção caso a capacidade seja insuficiente
                throw new Exception("A quantidade de hóspedes excede a capacidade da suíte.");
            }
        }

        // Método para cadastrar a suíte
        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        // Método para obter a quantidade de hóspedes
        public int ObterQuantidadeHospedes()
        {
            return Hospedes?.Count ?? 0; // Retorna o número de hóspedes ou 0 caso não haja hóspedes cadastrados
        }

        // Método para calcular o valor da diária
        public decimal CalcularValorDiaria()
        {
            if (Suite == null)
            {
                throw new Exception("Nenhuma suíte foi cadastrada.");
            }

            // Calcula o valor total das diárias
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Aplica desconto de 10% se os dias reservados forem 10 ou mais
            if (DiasReservados >= 10)
            {
                valor *= 0.9m; // Aplica o desconto de 10%
            }

            return valor;
        }
    }

}
