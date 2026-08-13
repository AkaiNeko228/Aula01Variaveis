using System.Diagnostics.Contracts;
using System;
 
 // commit, algo que ja sabia

namespace Aula01Projeto
{
    public class Program
    {
        static void Main(string[] args){
         //concatenarPalavras();
         //CalcularMedia();
         //CalcularTabuada();
         //VerficarAulaEtec();
         Console.WriteLine("Digite um número para escolher o menu a baixo:");
         Console.WriteLine("1 - Concatenar Palavras");
         Console.WriteLine("2 - Calcular Média");
         Console.WriteLine("3 - Calcular Tabuada");
         Console.WriteLine("4 - Verificar Aula Etec");
         int opcao = int.Parse(Console.ReadLine());
      
         switch (opcao){
            case 1:
                concatenarPalavras();
                break;
            case 2:
                CalcularMedia();
                break;
            case 3:
                CalcularTabuada();
                break;
            case 4:
                VerficarAulaEtec();
                break;
            default:
                Console.WriteLine("Opção inválida");
                break;
         }
        } 

        public static void VerficarAulaEtec(){
            Console.WriteLine("Dia da semana:");
         DateTime data = DateTime.Parse(Console.ReadLine());
         if(data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday){
            Console.WriteLine("Não tem aula, final de semana, nao pode");
         } else {
                Console.WriteLine("Tem aula");
         }
        
        }
        public static void CalcularTabuada(){
            Console.WriteLine("Digite um número para calcular a tabuada:");
            int numero = int.Parse(Console.ReadLine());
            int contador = 0;

            while (contador <= 10){
                string mensagem  = string.Format("{0} x {1} = {2}", numero, contador, numero * contador);
                Console.WriteLine(mensagem);
                contador++;
            }
            //for (int i = 1; i <= 10; i++){
              //  Console.WriteLine($"{numero} x {i} = {numero * i}");
            //}
        }


        public static void CalcularMedia(){
            Console.WriteLine("Digite a primeira nota:");
            decimal nota1 = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Digite a segunda nota:");
            decimal nota2 = decimal.Parse(Console.ReadLine());
            decimal media = (nota1 + nota2) / 2;
            Console.WriteLine($"A média do aluno é: {media}");
            if (media > 7){
                Console.WriteLine("Aprovado");
            } else if (media <7 && media >= 4){
                Console.WriteLine("Recuperação");

            }else {
                Console.WriteLine("Reprovado");
            }
        }
        

        public static void concatenarPalavras(){  
            // -------------------------------------------------- //
            Console.WriteLine("Digite o seu nome:");
            String nome = Console.ReadLine(); 
            Console.WriteLine($"Seu nome tem {nome.Length} caracteres.");
            Console.ReadKey();
            // -------------------------------------------------- //
            Console.WriteLine("Digite a data de nascimento:");
            DateTime dtNascimento = DateTime.Parse (Console.ReadLine()); 
            int qtdDiasVividos = DateTime.Now.Subtract(dtNascimento).Days;
            Console.WriteLine("O dias vividios ate hoje são:" +qtdDiasVividos);
            Console.ReadKey();
            // -------------------------------------------------- //
            string frase1 = $"então... {nome}, hoje é {DateTime.Now}...";
            // -------------------------------------------------- //
            Console.WriteLine(frase1);
            Console.WriteLine("Me conte... quanto esta valendo o Dollar em Reais??");
            decimal valorDolarReais = decimal.Parse(Console.ReadLine());
            // -------------------------------------------------- //
            string frase2 = string.Format("então hoje é {0:dd/MM/yyyy}, e o dolar esta custando {1:C2}", DateTime.Now, valorDolarReais);
            Console.WriteLine(frase2);
            // -------------------------------------------------- //
            string cabecalho = string.Format("{0:dddd}, {0:dd}, de {0:MMMM} de {0:yyyy} - {0:HH:mm:ss}", DateTime.Now);
            Console.WriteLine(cabecalho);
            // -------------------------------------------------- //
        }
    }
}
