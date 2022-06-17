using System;
using System.Threading;
using System.Globalization;

namespace DiagnosticoPrevio_IMC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // inserindo/declarando as variáveis. Algumas são iniciadas com valor nulo. 
            double altura, peso, imc;
            int idade;
            string nome, sexo, categoria = null, classificacao = null, riscos = null, recomendacao = null, tentativa, enter;

            do {

                        //inserindo dados dentro de variáveis:
                 Console.WriteLine(" \t Seja Bem Vindo(a)! Aperte a tecla ENTER para começar! \n ");
                 enter = Console.ReadLine();

                 Console.Write( " Para gerarmos seu Diagnóstico Prévio, preencha seus dados abaixo: \n"); 


                    //Nome
                Console.Write("\n Digite seu nome completo: ");
                nome = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(nome))
                {
                    Console.Write("Nome inexistente! Por favor, insira novamente: ");
                    nome = Console.ReadLine();
                }

                    //Sexo
                Console.Write("\n Digite seu sexo (M para masculino e F para feminino): ");
                sexo = Console.ReadLine();

            while (sexo.ToUpper() != "F" && sexo.ToUpper() != "M")

            {
                Console.Clear();

                Console.Write("Dado inválido! por favor, tente novamente: ");
                sexo = Console.ReadLine();

            }

            if (sexo.ToUpper() == "F")
            {
                sexo = "Feminino";
            }
            else if (sexo.ToUpper() == "M")
            {
                sexo = "Masculino";
            }

                    //Idade
                Console.Write("\n Digite sua idade: ");
                idade = int.Parse(Console.ReadLine());

            while (idade <= 0)
            {
                Console.Clear();

                Console.Write("Idade inválida! Por favor, tente novamente: ");
                idade = int.Parse(Console.ReadLine());
            }
            
           
                    //Altura
                Console.Write("\n Digite sua altura, em metros(e utilize vírgula (,) para separar as medidas): ");
                altura = double.Parse(Console.ReadLine().Replace(".", ",").ToString());
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt");

            while (altura <= 0 || altura >= 4.0)
            {
                Console.Clear();

                Console.Write("Altura inválida! Por favor, tente novamente: ");
                altura = double.Parse(Console.ReadLine().Replace(".", ",").ToString());
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt");
            }

                    //Peso
                Console.Write("\n Digite seu peso, em Kg(e utilize vírgula (,) para separar o valor do peso): ");
                peso = double.Parse(Console.ReadLine().Replace(".", ",").ToString());
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt");

           while (peso <= 0 || peso >= 300)
            {
                Console.Clear();

                Console.Write("Peso inválido! Por favor, tente novamente: ");
                peso = double.Parse(Console.ReadLine().Replace(".", ",").ToString());
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt");
            }
            
                    //Categoria
            if (idade < 12) { categoria = "Infantil"; }
            if (idade >= 12 && idade <= 20) { categoria = "Juvenil"; }
            if (idade >= 21 && idade <= 65) { categoria = "Adulto"; }
            if (idade > 65) { categoria = "Idoso"; }


                //Funções sendo chamadas e atribuídas por variáveis:

                    imc = IMC(peso, altura);

                    classificacao = Classificacao(imc);

                    riscos = Riscos(imc);

                    recomendacao = Recomendacao(imc);
               
    
       
            Console.Clear();

            Console.WriteLine("\n\t DIAGNÓSTICO PRÉVIO\n\n ");

            Console.WriteLine($" Nome:  {nome}\n " +
                              $"Sexo:  {sexo}\n " +
                              $"Idade:  {idade}\n " +
                              $"Altura:  {Math.Round(altura, 2)} m\n " +
                              $"Peso:  {Math.Round(peso, 2)} Kg\n " +
                              $"Categoria:  {categoria}\n\n\n " +
                              $"IMC Desejável:  entre 20 a 24\n\n " +
                              $"Resultado IMC:  {Math.Round(imc,1)}\n\n " +
                              $"Classificação IMC:  {classificacao}\n\n " +
                              $"Riscos:  {riscos}\n\n " +
                              $"Recomendação Inicial:  {recomendacao}\n\n\n ");


            Console.WriteLine("Deseja realizar o Diagnóstico Prévio outra vez? Digite 'S' para confirmar ou 'N' para finalizar: ");
            tentativa = Console.ReadLine();
                
            Console.Clear();
          }
            while (tentativa.ToUpper() == "S");
            

        }

        static double IMC (double peso, double altura)
        {
            double imc;
            imc = (peso / Math.Pow(altura, 2));

            return imc;

        }

        static string Classificacao (double imc)
        {
            string rating = null;

            if (imc < 20)
            {
                rating = "Abaixo do Peso Ideal";
            }

            if (imc >= 20 && imc <= 24)
            {
                rating = "Peso Normal";
            }

            if (imc >= 25 && imc <= 29)
            {
               rating = "Excesso de Peso";
            }

            if (imc >= 30 && imc <= 35)
            {
                rating = "Obesidade";
            }
            if (imc > 35)
            {
              rating = "Super Obesidade";

            }

            return rating;
        } 


        static string Riscos (double imc)
        {
            string effect = null;


            if (imc < 20)
            {
              effect = "Muitas complicações de saúde como doenças pulmonares e \n" +
                     " cardiovasculares podem estar associadas ao baixo peso.";    
            }

            if (imc >= 20 && imc <= 24)
            {         
                effect = "Seu peso está ideal para suas referências.";
            }

            if (imc >= 25 && imc <= 29)
            {             
                effect = "Aumento de peso apresenta risco moderado para outras doenças\n" +
                         " crônicas e cardiovasculares.";      
            }

            if (imc >= 30 && imc <= 35)
            {       
                effect = "Quem tem obesidade vai estar mais exposto a doenças graves e ao\n" +
                         " risco de mortalidade.";      
            }

            if (imc > 35)
            {    
                effect = "O obeso mórbido vive menos, tem alto risco de mortalidade geral\n" +
                         " por diversas causas.";           
            }

            return effect;

        }


        static string Recomendacao (double imc)
        {

            string advice = null;

            if (imc < 20)
            {     
                advice = "Inclua carboidratos simples em sua dieta, além de proteínas -\n" +
                               " indispensáveis para ganho de massa magra. Procure um profissional.";
            }

            if (imc >= 20 && imc <= 24)
            {     
                advice = "Mantenha uma dieta saudável e faça seus exames periódicos.";
            }

            if (imc >= 25 && imc <= 29)
            {     
                advice = "Adote um tratamento baseado em dieta balanceada, exercício físico\n" +
                               " e medicação. A ajuda de um profissional pode ser interessante.";
            }

            if (imc >= 30 && imc <= 35)
            {     
                advice = "Adote uma dieta alimentar rigorosa, com o acompanhamento de um\n" +
                               " nutricionista e um médico especialista(endócrino).";
            }

            if (imc > 35)
            { 
                advice = "Procure com urgência o acompanhamento de um nutricionista para\n" +
                               " realizar reeducação alimentar, um psicólogo e um médico" +
                               " especialista(endócrino).";
            }

            return advice;
        }



    }
}
