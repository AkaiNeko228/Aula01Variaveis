using System;
using System.Globalization;

namespace Aula01Projeto
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite um número para escolher uma opção:");
            Console.WriteLine("1 - Concatenar palavras");
            Console.WriteLine("2 - Calcular média");
            Console.WriteLine("3 - Calcular tabuada");
            Console.WriteLine("4 - Verificar aula Etec");
            Console.WriteLine("5 - Detalhar data");
            Console.WriteLine("6 - Calcular desconto do INSS");

            int opcao = LerInteiro("Opção: ");

            switch (opcao)
            {
                case 1:
                    ConcatenarPalavras();
                    break;
                case 2:
                    CalcularMedia();
                    break;
                case 3:
                    CalcularTabuada();
                    break;
                case 4:
                    VerificarAulaEtec();
                    break;
                case 5:
                    DetalharData();
                    break;
                case 6:
                    CalcularDescontoINSS();
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }

        private static int LerInteiro(string mensagem)
        {
            int valor;
            do
            {
                Console.Write(mensagem);
            } while (!int.TryParse(Console.ReadLine(), out valor));

            return valor;
        }

        private static decimal LerDecimal(string mensagem)
        {
            decimal valor;
            do
            {
                Console.Write(mensagem);
            } while (!decimal.TryParse(Console.ReadLine(), NumberStyles.Number,
                CultureInfo.CurrentCulture, out valor));

            return valor;
        }

        private static DateTime LerData(string mensagem)
        {
            DateTime data;
            do
            {
                Console.Write(mensagem);
            } while (!DateTime.TryParse(Console.ReadLine(), out data));

            return data;
        }

        
        public static void VerificarAulaEtec()
        {
            DateTime data = LerData("Digite uma data: ");

            if (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday)
                Console.WriteLine("Não tem aula: é final de semana.");
            else
                Console.WriteLine("Tem aula.");
        }

        public static void CalcularTabuada()
        {
            int numero = LerInteiro("Digite um número para calcular a tabuada: ");

            for (int contador = 0; contador <= 10; contador++)
            {
                Console.WriteLine($"{numero} x {contador} = {numero * contador}");
            }
        }


        public static void CalcularMedia()
        {
            decimal nota1 = LerDecimal("Digite a primeira nota: ");
            decimal nota2 = LerDecimal("Digite a segunda nota: ");
            decimal media = (nota1 + nota2) / 2;
            Console.WriteLine($"A média do aluno é: {media:N2}");

            if (media >= 7)
                Console.WriteLine("Aprovado");
            else if (media >= 4)
                Console.WriteLine("Recuperação");
            else
                Console.WriteLine("Reprovado");
        }
        

        public static void ConcatenarPalavras()
        {
            // -------------------------------------------------- //
            Console.WriteLine("Digite o seu nome:");
            string nome = Console.ReadLine() ?? string.Empty;
            Console.WriteLine($"Seu nome tem {nome.Length} caracteres.");
            Console.ReadKey();
            // -------------------------------------------------- //
            Console.WriteLine("Digite a data de nascimento:");
            DateTime dtNascimento = LerData("Digite a data de nascimento: ");
            int qtdDiasVividos = (DateTime.Now - dtNascimento).Days;
            Console.WriteLine($"Os dias vividos até hoje são: {qtdDiasVividos}");
            // -------------------------------------------------- //
            string frase1 = $"então... {nome}, hoje é {DateTime.Now}...";
            // -------------------------------------------------- //
            Console.WriteLine(frase1);
            Console.WriteLine("Me conte... quanto esta valendo o Dollar em Reais??");
            decimal valorDolarReais = LerDecimal("Cotação do dólar em reais: ");
            // -------------------------------------------------- //
            string frase2 = string.Format("então hoje é {0:dd/MM/yyyy}, e o dolar esta custando {1:C2}", DateTime.Now, valorDolarReais);
            Console.WriteLine(frase2);
            // -------------------------------------------------- //
            string cabecalho = string.Format("{0:dddd}, {0:dd}, de {0:MMMM} de {0:yyyy} - {0:HH:mm:ss}", DateTime.Now);
            Console.WriteLine(cabecalho);
            // -------------------------------------------------- //
        }

        public static void DetalharData(){
            Console.WriteLine("Digite uma data (dd/mm/aaaa):");
            DateTime data = LerData("Digite uma data (dd/mm/aaaa): ");

            string diaSemana = data.ToString("dddd");
            string mesExtenso = data.ToString("MMMM");

            Console.WriteLine($"O dia da semana é: {diaSemana}");
            Console.WriteLine($"O mês por extenso é: {mesExtenso}");

            if (data.DayOfWeek == DayOfWeek.Sunday){
                DateTime agora = DateTime.Now;
                Console.WriteLine($"Essa data cai num domingo! Agora são {agora:HH:mm}");
            }
        }

        public static void CalcularDescontoINSS(){
            Console.WriteLine("Digite o valor do salário:");
            decimal salario = LerDecimal("Digite o valor do salário: ");

            if (salario < 0)
            {
                Console.WriteLine("O salário não pode ser negativo.");
                return;
            }

            
            decimal faixa1Min = 0.00m,    faixa1Max = 1621.00m, aliquota1 = 0.075m;
            decimal faixa2Min = 1621.01m, faixa2Max = 2902.84m, aliquota2 = 0.09m;
            decimal faixa3Min = 2902.85m, faixa3Max = 4354.27m, aliquota3 = 0.12m;
            decimal faixa4Min = 4354.28m, faixa4Max = 8475.55m, aliquota4 = 0.14m;

            decimal descontoFaixa1 = 0m;
            decimal descontoFaixa2 = 0m;
            decimal descontoFaixa3 = 0m;
            decimal descontoFaixa4 = 0m;

            if (salario > faixa1Min){
                decimal baseCalculo1 = Math.Min(salario, faixa1Max) - faixa1Min;
                descontoFaixa1 = baseCalculo1 * aliquota1;
            }

            if (salario > faixa2Min){
                decimal baseCalculo2 = Math.Min(salario, faixa2Max) - faixa2Min;
                descontoFaixa2 = baseCalculo2 * aliquota2;
            }

            if (salario > faixa3Min){
                decimal baseCalculo3 = Math.Min(salario, faixa3Max) - faixa3Min;
                descontoFaixa3 = baseCalculo3 * aliquota3;
            }

            if (salario > faixa4Min){
                
                decimal baseCalculo4 = Math.Min(salario, faixa4Max) - faixa4Min;
                descontoFaixa4 = baseCalculo4 * aliquota4;
            }

            decimal totalINSS = descontoFaixa1 + descontoFaixa2 + descontoFaixa3 + descontoFaixa4;
            decimal salarioComDesconto = salario - totalINSS;

            Console.WriteLine($"O valor do desconto de INSS é: {totalINSS:C2}");
            Console.WriteLine($"O salário com o desconto do INSS é: {salarioComDesconto:C2}");
        }
    }
}
