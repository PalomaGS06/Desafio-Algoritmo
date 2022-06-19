﻿using System;
using System.Text.RegularExpressions;
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
            bool valida_dados;
            string nome, sexo, categoria, classificacao, riscos, recomendacao, tentativa;

            do
            {             

                    Titulo();

                    //inserindo dados dentro de variáveis:
                    Console.WriteLine($"» Seja Bem Vindo(a)! «".PadLeft(71, ' '));
                    Console.WriteLine($"Aperte qualquer tecla para começar!  \n\n".PadLeft(82, ' '));

                    Rodape();

                    Console.ReadKey();

                    Console.Clear();
                do
                {

                    Titulo();

                    Console.Write(" \nPara gerarmos seu Diagnóstico Prévio, preencha seus dados abaixo: \n\n");


                    //Nome
                    Console.Write("\n Digite seu nome completo: ");
                    nome = Console.ReadLine();

                    while (string.IsNullOrWhiteSpace(nome))
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine("\n  Nome vazio! Por favor, digite de novo:");
                        Console.ResetColor();
                        nome = Console.ReadLine();

                    }

                    Regex letra = new Regex(@"[A-Z,a-z]");
                    if (!letra.IsMatch(nome))
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine("\n  Nome inexistente! Por favor, insira novamente:");
                        Console.ResetColor();
                        Console.ReadLine();
                    }


                    //Sexo
                    Console.Write("\n Digite seu sexo (M para masculino e F para feminino): ");
                    sexo = Console.ReadLine();

                    while ( sexo.ToUpper() != "F" && sexo.ToUpper() != "M")
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine("\n  Dado inválido! por favor, tente novamente:");
                        Console.ResetColor();
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
                    valida_dados= int.TryParse(Console.ReadLine(), out idade);

                    while (valida_dados == false || idade <= 0 || idade > 150)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine("\n  Idade inválida! Por favor, tente novamente:");
                        Console.ResetColor();
                        valida_dados = int.TryParse(Console.ReadLine(), out idade); 
                    }


                    //Altura
                    Console.Write("\n Digite sua altura, em metros: ");
                    valida_dados = double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out altura);

                    while (valida_dados == false || altura <= 0 || altura >= 2.7)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine("\n  Altura inválida! Por favor, tente novamente:");
                        Console.ResetColor();
                        valida_dados = double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out altura);
                    }

                    //Peso
                    Console.Write("\n Digite seu peso, em Kg: ");
                    valida_dados = double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out peso);



                    while (valida_dados == false|| peso <= 0 || peso >= 700)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine("\n  Peso inválido! Por favor, tente novamente:");
                        Console.ResetColor();
                        valida_dados = double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out peso);
                    }

                    Console.WriteLine("\n\n");

                    Rodape();

                    Console.WriteLine(" ");

                    Console.Write("\t» Deseja confirmar seus dados? Digite 'S' para ver ser resultado ou 'N' para preencher de novo: « \n\n ");
                    tentativa = Console.ReadLine();

                    Console.Clear();

                    while (tentativa.ToUpper() != "S" && tentativa.ToUpper() != "N")
                    {
                        Console.Write("  ");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine("\n   Escolha inválida. Por favor, digite 'S' para avançar ou 'N' para preencher novamente: ");
                        Console.ResetColor();
                        tentativa = Console.ReadLine();
                    }

                } while (tentativa.ToUpper() == "N");
                    
                    Console.Clear();


                //Funções sendo chamadas e atribuídas por variáveis:              

                categoria = Categoria(idade);

                imc = IMC(peso, altura);

                classificacao = Classificacao(imc);

                riscos = Riscos(imc);

                recomendacao = Recomendacao(imc);

                Rodape();

                Console.Clear();

                Titulo();

                Console.Write($" Nome:  {nome}\n ");
                Console.Write($"Sexo:  {sexo}\n ");
                Console.Write($"Idade:  {idade}\n ");
                Console.Write($"Altura:  {Math.Round(altura, 2)} m\n ");
                Console.Write($"Peso:  {Math.Round(peso, 2)} Kg\n ");
                Console.Write($"Categoria:  {categoria}\n\n\n ");                
                Console.Write($"IMC Desejável:  entre 20 a 24\n\n ");
                Console.Write($"Resultado IMC:  {Math.Round(imc, 1)}\n\n ");

                Console.Write($"Classificação IMC:  ");
                Classificacao_Cor(classificacao);
                Console.ResetColor();

                Console.WriteLine("\n");
                Console.Write($" Riscos:  {riscos}\n\n ");
                Console.Write($"Recomendação Inicial:  {recomendacao}\n\n\n ");

                    
                Rodape();

                Console.WriteLine(" ");

                Console.Write("\t» Deseja realizar o Diagnóstico Prévio outra vez? Digite 'S' para confirmar ou 'N' para finalizar: « \n\n ");                         
                tentativa = Console.ReadLine();
                
                Console.Clear();
           
              while (tentativa.ToUpper() != "S" && tentativa.ToUpper() != "N")
                {
                    Console.Write("  ");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("\n   Escolha inválida. Por favor, digite 'S' para confirmar ou 'N' para finalizar o programa: ");
                    Console.ResetColor();
                    tentativa = Console.ReadLine();
                 }
                  
            }
            while (tentativa.ToUpper() == "S");

                Console.Clear();

                if (tentativa.ToUpper() == "N")
                {
                    Titulo();

                    Console.Write("  » Agradecemos a sua preferência! Take Care! «\n\n".PadLeft(85 , ' '));

                    Rodape();
                }
        }

        static string Categoria(int idade)
        {
            string category = null;

            if (idade < 12) { category = "Infantil"; }
            if (idade >= 12 && idade <= 20) { category = "Juvenil"; }
            if (idade >= 21 && idade <= 65) { category = "Adulto"; }
            if (idade > 65) { category = "Idoso"; }
           
            return category;    
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

            else if (imc >= 20 && imc <= 24)
            {              
                rating = "Peso Normal";               
            }


            else if (imc >= 25 && imc <= 29)
            {          
                rating = "Excesso de Peso";             
            }


            else if(imc >= 30 && imc <= 35)
            {               
                rating = "Obesidade";           
            }

            else if(imc > 35)
            {             
                rating = "Super Obesidade";              
            }
     
            return rating;
                       
            
        }

        static void Classificacao_Cor(string rating)
        {
            if (rating == "Abaixo do Peso Ideal")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Abaixo do Peso Ideal");
                Console.ResetColor();
            }

            if (rating == "Peso Normal")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Peso Normal");
                Console.ResetColor();
            }

            if (rating == "Excesso de Peso")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Excesso de Peso");
                Console.ResetColor();
            }

            if (rating == "Obesidade")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Obesidade");
                Console.ResetColor();
            }

            if (rating == "Super Obesidade")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Super Obesidade");
                Console.ResetColor();
            }

        }

        static string Riscos (double imc)
        {
            string effect = null;

           if (imc < 20)
            {
              effect = "Muitas complicações de saúde como doenças pulmonares e \n" +
                     " cardiovasculares podem estar associadas ao baixo peso.";    
            }

            else if (imc >= 20 && imc <= 24)
            {         
                effect = "Seu peso está ideal para suas referências.";
            }

            else if (imc >= 25 && imc <= 29)
            {             
                effect = "Aumento de peso apresenta risco moderado para outras doenças\n" +
                         " crônicas e cardiovasculares.";      
            }

            else if (imc >= 30 && imc <= 35)
            {       
                effect = "Quem tem obesidade vai estar mais exposto a doenças graves e ao\n" +
                         " risco de mortalidade.";      
            }

            else if (imc > 35)
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

            else if (imc >= 20 && imc <= 24)
            {     
                advice = "Mantenha uma dieta saudável e faça seus exames periódicos.";
            }

            else if (imc >= 25 && imc <= 29)
            {     
                advice = "Adote um tratamento baseado em dieta balanceada, exercício físico\n" +
                               " e medicação. A ajuda de um profissional pode ser interessante.";
            }

            else if (imc >= 30 && imc <= 35)
            {     
                advice = "Adote uma dieta alimentar rigorosa, com o acompanhamento de um\n" +
                               " nutricionista e um médico especialista(endócrino).";
            }

            else if (imc > 35)
            { 
                advice = "Procure com urgência o acompanhamento de um nutricionista para\n" +
                               " realizar reeducação alimentar, um psicólogo e um médico" +
                               " especialista(endócrino).";
            }

            return advice;
        }

        static void Titulo()
        {

            for (int x = 0; x < Console.WindowWidth/2; x++)
            {
                 Console.Write("<>");
            }

            Console.WriteLine("  ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($" DIAGNÓSTICO PRÉVIO - IMC\n".PadLeft( 73 , ' '));

            Console.ResetColor();

            Console.Write($"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n".PadLeft(76, ' '));

        }
        
        static void Rodape()
        {
            for (int z = 0; z < Console.WindowWidth/2; z++)
            {
                Console.Write("<>");
            }

            Console.WriteLine("  ");

        }

    }
}
