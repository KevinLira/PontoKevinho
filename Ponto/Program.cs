using System;
using Ponto.Entity;
using Ponto.Helper;

namespace Ponto
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new BatidasFactory();
            var funcionario = new Funcionario
            {
                Nome = factory.GetNomeUsuario(), 
                CartaoPonto = new CartaoPonto
                {
                    Batidas = factory.GetList()
                }

            };

            Start:
            Console.Clear();
            Console.WriteLine("*******************************************************");
            Console.WriteLine("* Olá Lindão, por favor escolha entre uma das opções: *");
            Console.WriteLine("*                                                     *");
            Console.WriteLine("*  1 Para Relatorio Resumido                          *");
            Console.WriteLine("*  2 Para Relatorio Detalhado                         *");
            Console.WriteLine("*  3 Para Visualizar a lista de dias considerados     *");
            Console.WriteLine("*                                                     *");
            Console.WriteLine("*******************************************************");
            var num = Console.ReadLine();
            Console.Clear();
            switch (num)
            {   
                case "1":
                    ExibeTotal(funcionario);
                    break;

                case "2":
                default:
                    ExibeTotal(funcionario, true);
                    break;

                case "3":
                    VisualizarEntradasESaidasRaw(funcionario.CartaoPonto);
                    break;


            }
            Console.WriteLine("Pressione 1 para voltar ao menu, ou 2 para encerrar.");
            var item = Console.ReadLine();

            switch (item)
            {
                case "1":
                    goto Start;
                default:
                    goto End;
            }
            End:
            Console.Clear();
            Console.WriteLine("Obrigado.Pressione qualquer enter para encerrar.");
            Console.Read();

        }

        private static void VisualizarEntradasESaidasRaw(CartaoPonto cartao)
        {
            Console.WriteLine("*******************************************************");
            foreach (var item in cartao.Batidas)
            {
                Console.WriteLine($"Dia: {item.DataEntrada.Date} Entrada: {item.DataEntrada.ToShortTimeString()} Saída: {item.DataSaida.ToShortTimeString()}     ");
            }
            Console.WriteLine("*******************************************************");

        }

        private static TimeSpan CalcularSaldoHoras(CartaoPonto kevinCartaoPonto, bool exibeDetalhe)
        {
            var saldo = new TimeSpan();
            var diaDescontado = new TimeSpan().Add(TimeSpan.FromHours(-8).Add(TimeSpan.FromMinutes(-59)));
            var setDesconto = new TimeSpan().Add(TimeSpan.FromHours(-8));


            foreach (var item in kevinCartaoPonto.Batidas)
            {
                var diff = (item.DataSaida - item.DataEntrada);

                var timeSpan = diff.Add(TimeSpan.FromHours(-9));

                if (timeSpan > new TimeSpan(0, 10, 0) || timeSpan < new TimeSpan(0, -10, 0))
                {
                    if (timeSpan == diaDescontado)
                    {
                        timeSpan = setDesconto;// Se for uma Falta ou uma emenda, Desconta 8 horas para compensação
                    }
                    if (exibeDetalhe)
                    {
                        Console.WriteLine("*******************************************************");
                        Console.WriteLine($" Saldo de horas em: {item.DataEntrada.Date.ToShortDateString()} {timeSpan}     ");
                        Console.WriteLine("*******************************************************");

                    }

                    saldo += timeSpan;
                }


            }

            return saldo;
        }

        public static void ExibeTotal(Funcionario funcionario, bool exibeDetalhe = false)
        {
            funcionario.CartaoPonto.SaldoHoras = CalcularSaldoHoras(funcionario.CartaoPonto,exibeDetalhe);
            Console.WriteLine("*******************************************************");
            Console.WriteLine("");
            Console.WriteLine($" Nome: {funcionario.Nome}");
            Console.WriteLine($" Total de Horas: {funcionario.CartaoPonto.SaldoHoras}");
            Console.WriteLine("");
            Console.WriteLine("*******************************************************");

        }
    }
}
