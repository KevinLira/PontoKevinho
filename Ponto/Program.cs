using System;
using Ponto.Entity;
using Ponto.Helper;

namespace Ponto
{
    class Program
    {
        static void Main(string[] args)
        {

            var kevin = new Funcionario
            {
                Nome = "Kevin Lira",
                CartaoPonto = new CartaoPonto
                {
                    Batidas = new BatidasFactory().GetList()
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
                    TotalResumido(kevin);
                    break;

                case "2":
                default:
                    TotalResumido(kevin, true);
                    break;

                case "3":
                    VisualizarEntradasESaidasRaw(kevin.CartaoPonto);
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

        private static void VisualizarEntradasESaidasRaw(CartaoPonto kevin)
        {
            Console.WriteLine("*******************************************************");
            foreach (var item in kevin.Batidas)
            {
                Console.WriteLine($"Dia: {item.DataEntrada.Date} Entrada: {item.DataEntrada.ToShortTimeString()} Saída: {item.DataSaida.ToShortTimeString()}     ");
            }
            Console.WriteLine("*******************************************************");

        }

        private static TimeSpan CalcularSaldoHoras(CartaoPonto kevinCartaoPonto, bool exibeDetalhe)
        {
            var saldo = new TimeSpan();
            var diaDescontadoAjustadoNoArrayGambiarristico = new TimeSpan().Add(TimeSpan.FromHours(-8).Add(TimeSpan.FromMinutes(-59)));
            var marretaDesconto = new TimeSpan().Add(TimeSpan.FromHours(-8));


            foreach (var item in kevinCartaoPonto.Batidas)
            {
                var diff = (item.DataSaida - item.DataEntrada);

                var timeSpan = diff.Add(TimeSpan.FromHours(-9));

                if (timeSpan > new TimeSpan(0, 10, 0) || timeSpan < new TimeSpan(0, -10, 0))
                {
                    if (timeSpan == diaDescontadoAjustadoNoArrayGambiarristico)
                    {
                        timeSpan = marretaDesconto;// Se for uma Falta ou uma emenda, Desconta 8 horas para compensação
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

        public static void TotalResumido(Funcionario kevin, bool exibeDetalhe = false)
        {
            kevin.CartaoPonto.SaldoHoras = CalcularSaldoHoras(kevin.CartaoPonto,exibeDetalhe);
            Console.WriteLine("*******************************************************");
            Console.WriteLine("*                                                     *");
            Console.WriteLine($"* Nome: {kevin.Nome}                                    *");
            Console.WriteLine($"* Total de Horas: {kevin.CartaoPonto.SaldoHoras}                            *");
            Console.WriteLine("*                                                     *");
            Console.WriteLine("*******************************************************");

        }
    }
}
