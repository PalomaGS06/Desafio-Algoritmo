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
            string nome, sexo, categoria = null, classificacao = null, riscos = null, recomendacao = null;

            //inserindo dados dentro de variáveis:
                Console.Write(" \nSeja bem vindo(a)! Para ver seus resultados do diagnóstico prévio,\n" +
                               "primeiramente, preenche seus dados abaixo: \n");

                    //Nome
                Console.Write("\n Digite seu nome completo: ");
                nome = Console.ReadLine();

                    //Sexo
                Console.Write("\n Digite seu sexo (M para masculino e F para feminino): ");
                sexo = Console.ReadLine();

            while (sexo.ToUpper() != "F" && sexo.ToUpper() != "M")

            {
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
                Console.Write("Idade inválida! Por favor, tente novamente: ");
                idade = int.Parse(Console.ReadLine());
            }
            
           
                    //Altura
                Console.Write("\n Digite sua altura (em metros): ");
                altura = double.Parse(Console.ReadLine().Replace(".", ",").ToString());
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt");

            while (altura <= 0 || altura >= 4.0)
            {
                Console.Write("altura inválida! Por favor, tente novamente: ");
                altura = double.Parse(Console.ReadLine().Replace(".", ",").ToString());
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt");
            }

                    //Peso
                Console.Write("\n Digite seu peso (Kg): ");
                peso = double.Parse(Console.ReadLine().Replace(".", ",").ToString());
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt");

           while (peso <= 0 || peso >= 300)
            {
                Console.Write("peso inválido ! Por favor, tente novamente: ");
                peso = double.Parse(Console.ReadLine().Replace(".", ",").ToString());
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt");
            }
            
                    //Categoria
            if (idade < 12) { categoria = "Infantil"; }
            if (idade >= 12 && idade <= 20) { categoria = "Juvenil"; }
            if (idade >= 21 && idade <= 65) { categoria = "Adulto"; }
            if (idade > 65) { categoria = "Idoso"; }

        }
    }
}
