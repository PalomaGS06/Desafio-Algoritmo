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
            string nome, sexo, categoria = null, classificacao = null, riscos = null, recomendacao = null, tentativa;

            //inserindo dados dentro de variáveis:
                Console.Write(" \t\n Seja bem vindo(a)! Para ver seus resultados do diagnóstico prévio,\n" +
                               " primeiramente, preenche seus dados abaixo: \n");

                    //Nome
                Console.Write("\n Digite seu nome completo: ");
                nome = Console.ReadLine();

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

                Console.Write("Peso inválido ! Por favor, tente novamente: ");
                peso = double.Parse(Console.ReadLine().Replace(".", ",").ToString());
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt");
            }
            
                    //Categoria
            if (idade < 12) { categoria = "Infantil"; }
            if (idade >= 12 && idade <= 20) { categoria = "Juvenil"; }
            if (idade >= 21 && idade <= 65) { categoria = "Adulto"; }
            if (idade > 65) { categoria = "Idoso"; }


                    //Cálculo IMC
            imc = (peso /Math.Pow(altura,2));

            //Riscos, Recomendação inicial e Classificação
            if (imc < 20)
            {
                classificacao = "Abaixo do Peso Ideal";

                riscos = "Muitas complicações de saúde como doenças pulmonares e \n" +
                     " cardiovasculares podem estar associadas ao baixo peso.";

                recomendacao = "Inclua carboidratos simples em sua dieta, além de proteínas -\n" +
                               " indispensáveis para ganho de massa magra. Procure um profissional.";
            }
            if (imc >= 20 && imc <= 24)
            {
                classificacao = "Peso Normal";

                riscos = "Seu peso está ideal para suas referências.";

                recomendacao = "Mantenha uma dieta saudável e faça seus exames periódicos.";
            }
            if (imc >= 25 && imc <= 29)
            {
                classificacao = "Excesso de Peso";

                riscos = "Aumento de peso apresenta risco moderado para outras doenças\n" +
                         " crônicas e cardiovasculares.";

                recomendacao = "Adote um tratamento baseado em dieta balanceada, exercício físico\n" +
                               " e medicação. A ajuda de um profissional pode ser interessante.";
            }
            if (imc >= 30 && imc <= 35)
            {
                classificacao = "Obesidade";

                riscos = "Quem tem obesidade vai estar mais exposto a doenças graves e ao\n" +
                         " risco de mortalidade.";

                recomendacao = "Adote uma dieta alimentar rigorosa, com o acompanhamento de um\n" +
                               " nutricionista e um médico especialista(endócrino).";
            }
            if (imc > 35)
            {
                classificacao = "Super Obesidade";

                riscos = "O obeso mórbido vive menos, tem alto risco de mortalidade geral\n" +
                         " por diversas causas.";

                recomendacao = "Procure com urgência o acompanhamento de um nutricionista para\n" +
                               " realizar reeducação alimentar, um psicólogo e um médico" +
                               " especialista(endócrino).";

            }
       
            Console.Clear();

            Console.WriteLine("\n\t DIAGNÓSTICO PRÉVIO\n\n ");

            Console.WriteLine($" Nome:  {nome}\n " +
                              $"Sexo:  {sexo}\n " +
                              $"Idade:  {idade}\n " +
                              $"Altura:  {Math.Round(altura, 2)}\n " +
                              $"Peso:  {Math.Round(peso, 2)}\n " +
                              $"Categoria:  {categoria}\n\n\n " +
                              $"IMC Desejável:  entre 20 a 24\n\n " +
                              $"Resultado IMC:  {Math.Round(imc,1)} - {classificacao} " +
                              $"Riscos:  {riscos}\n\n " +
                              $"Recomendação Inicial:  {recomendacao}\n\n\n");


            Console.WriteLine("Deseja realizar o Diagnóstico Prévio outra vez? Digite 'S' para confirmar ou 'N' para finalizar: ");
            tentativa = Console.ReadLine();
            while(tentativa.ToUpper() == "S")
            {
                Console.Clear();
            }
        }
    }
}
