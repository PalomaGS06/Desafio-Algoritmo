    //Algoritmo gerador de um Diagnóstico Prévio baseado em IMC para um programa de emagrecimento saudável

    //Bibliotecas importadas abaixo:
using System;
using System.Text.RegularExpressions; //A função Regex é chamada através dessa biblioteca
using System.Globalization; //A função Cultureinfo é chamada através dessa biblioteca


namespace DiagnosticoPrevio_IMC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Inserindo e declarando as variáveis, sendo elas de tipos double, inteiro, booleano e string
            double altura, peso, imc; //A variável imc é responsável por calcular o IMC através das variáveis altura e peso
            int idade;
            bool valida_dados; //Variável utilizada para a validação de dados do tipo numérico
            string nome, sexo, categoria, classificacao, riscos, recomendacao, tentativa; //A variável tentativa permite de o usuário escolher prosseguir ou retornar, através de um loop

            do //Loop inicial que permite o usuário de escolher entre realizar novamente o Diagnóstico Prévio ou finalizá-lo
            {             

                    Titulo(); //Chamada da função Titulo para exibir o cabeçalho como introdução
                       
                    //Informações iniciais do programa
                    Console.WriteLine($"» Seja Bem Vindo(a)! «".PadLeft(71, ' ')); //Função que centraliza o texto.
                                                                                   //Como parâmetros, ela recebe um inteiro de 32 bits (para ajustar a posição desejada) e um char 
                    Console.WriteLine($"Aperte qualquer tecla para começar!  \n\n".PadLeft(82, ' '));

                    Rodape(); //Chamada da função Rodape criado por linhas/símbolos como referência de acabamento

                    Console.ReadKey(); //Função que fixa o valor digitado

                    Console.Clear(); //Limpa a tela

                do //Loop utilizado para perguntar ao usuário se o mesmo deseja confirmar os dados digitados ou preenché-los novamente
                {

                    Titulo(); //Chama a função Titulo

                    Console.Write(" \nPara gerarmos seu Diagnóstico Prévio, preencha seus dados abaixo: \n\n"); //Pede para o usuario preencher os dados


                    //Recebe o nome digitado
                    Console.Write("\n Digite seu nome completo: ");
                    nome = Console.ReadLine(); //Armazena o que o usuário digitar, na variável nome

                    while (string.IsNullOrWhiteSpace(nome)) //Função que não aceita espaço em branco no nome em que o usuario digitar
                                                         //Enquanto um espaço sem letras é digitado, o programa exibe uma informação de Nome vazio 
                    {
                        //Abaixo, informação de erro exibida com cor preta e cor de fundo branca
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine("\n  Nome vazio! Por favor, digite de novo:");
                        Console.ResetColor(); //A cor estabelecida acima é resetada, retornando a cor padrão
                        nome = Console.ReadLine(); //Pede para o usuário digitar o nome novamente
                    }
                    
                        //Função que permite como entrada, um valor especificado como argumento dentro do parâmetro
                        //No caso abaixo, os valores específicos que podem entrar são somente letras de A a Z, maiúsculas e minúsculas
                        Regex letra = new Regex(@"[A-Z a-z]");
                    while (!letra.IsMatch(nome)) //Sobrecarga IsMatch determina se o valor de caracteres especificados é válido
                                                  //Se caso for negativo, é exibida uma mensagem de erro para o usuário
                    {
                         Console.ForegroundColor = ConsoleColor.Black;
                         Console.BackgroundColor = ConsoleColor.White;
                         Console.WriteLine("\n  Nome inexistente! Por favor, insira novamente:"); //Mensagem de erro caso o usuário digitar um número ou caractere
                         Console.ResetColor();
                         nome = Console.ReadLine(); //Permite o usuário digitar um valor válido no nome
                    }
                   
                    //Sexo a ser inserido pelo usuário
                    Console.Write("\n Digite seu sexo (M para masculino e F para feminino): ");
                    sexo = Console.ReadLine(); //Guarda o dado digitado na variável sexo e exibe posteriormente qual o gênero que o usuário digitou
                    
                    //Enquanto o usuário não digitar nem F e nem M, exibirá uma mensagem de erro pedindo para o mesmo tentar novamente
                    while ( sexo.ToUpper() != "F" && sexo.ToUpper() != "M") //Função que converte letras minúsculas (digitadas) para maiúsculas
                                                                            //Essa função faz com que aceite tanto letras minúsculas quanto maiúsculas
                                                                            //digitadas pelo usuário
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine("\n  Dado inválido! por favor, tente novamente:");
                        Console.ResetColor();
                        sexo = Console.ReadLine(); //Permite o usuário digitar um valor válido

                    }
                    //Se for digitado F ou M, a variável sexo recebe Feminino ou Masculino e é exibido como resultado posteriormente
                    if (sexo.ToUpper() == "F")
                    {
                        sexo = "Feminino";
                    }
                    else if (sexo.ToUpper() == "M")
                    {
                        sexo = "Masculino";
                    }

                    //Recebe a idade, como inteiro, a ser digitada
                    Console.Write("\n Digite sua idade: ");
                    valida_dados= int.TryParse(Console.ReadLine(), out idade); //Tenta converter o valor para inteiro, armazenando na variável idade
                                                                               //Faz a validação, caso for true, atribui na variável valida_dados

                    //Enquanto a validação for falsa e a idade menor ou igual a zero ou maior que 150, é exibida uma mensagem de erro
                    while (valida_dados == false || idade <= 0 || idade > 150)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine("\n  Idade inválida! Por favor, tente novamente:");
                        Console.ResetColor();
                        valida_dados = int.TryParse(Console.ReadLine(), out idade); //Permite o usuário digitar o valor novamente
                    }


                    //Altura a ser inserida pelo usuário, de tipo double
                    Console.Write("\n Digite sua altura, em metros: ");
                    //Abaixo, a função Replace() permite que o char vírgula seja substituído pelo char ponto e vice versa, para a quebra decimal
                    //A enumeração NumberStyles permite caracteres do tipo número que são passados dentro do TryParse
                    // A função de cultura serve para aceitar qualquer tipo de separador decimal (, ou .) independentemente do idioma do computador
                    valida_dados = double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out altura);

                    //Limites e validação para a altura através do loop while
                    while (valida_dados == false || altura <= 0 || altura >= 2.7)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine("\n  Altura inválida! Por favor, tente novamente:");
                        Console.ResetColor();
                        //Permite ao usuário digitar novamente a altura, separando as casas decimais tanto com vírgula como com ponto
                        valida_dados = double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out altura);
                    }

                    //Recebe o peso informado pelo usuário
                    Console.Write("\n Digite seu peso, em Kg: ");
                    valida_dados = double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out peso);


                    //Limites e validação para o peso através do loop while
                    while (valida_dados == false|| peso <= 0 || peso >= 700)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine("\n  Peso inválido! Por favor, tente novamente:"); //Mensagem de erro
                        Console.ResetColor();
                        valida_dados = double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out peso);
                    }

                    Console.WriteLine("\n\n"); //Quebra de linha

                    Rodape(); //Chama a função Rodape como preenchimento final

                    Console.WriteLine(" "); //Pula de linha. Acrescenta uma linha em branco

                    Console.Write("\t» Deseja confirmar seus dados? Digite 'S' para ver ser resultado ou 'N' para preencher de novo: « \n\n ");
                    tentativa = Console.ReadLine(); //variável que vai receber a letra informada pelo usuário

                    Console.Clear(); //Limpa a tela

                    //Loop para validação de dados
                    while (tentativa.ToUpper() != "S" && tentativa.ToUpper() != "N") //Loop para caso o usuário digitar letras diferentes das
                                                                                     //correspondidas acima, exibirá uma mensagem de erro
                    {
                        Console.Write("  ");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine("\n   Escolha inválida. Por favor, digite 'S' para avançar ou 'N' para preencher novamente: ");
                        Console.ResetColor();
                        tentativa = Console.ReadLine();
                       
                    }

                } while (tentativa.ToUpper() == "N"); //Caso o usuário escolher N, o laço de repetição Do While voltará na primeira informação
                                                      //de preenchimento (digitar o nome)
                                                      //Caso o usuário digitar S, o programa avança, e exibirá os resultados do Diagnóstico Prévio
                    
                    Console.Clear(); //Limpa a tela


                //Funções sendo chamadas e atribuídas por variáveis:          

                categoria = Categoria(idade);

                imc = IMC(peso, altura);

                classificacao = Classificacao(imc);

                riscos = Riscos(imc);

                recomendacao = Recomendacao(imc);

                Rodape(); 

                Console.Clear();

                Titulo();

                //Os dados digitados são imprimidos na tela e os resultados gerados
                Console.Write($" Nome:  {nome}\n ");
                Console.Write($"Sexo:  {sexo}\n ");
                Console.Write($"Idade:  {idade}\n ");
                Console.Write($"Altura:  {Math.Round(altura, 2)} m\n "); //Função que arredonda valores depois da vírgula
                Console.Write($"Peso:  {Math.Round(peso, 2)} Kg\n ");
                Console.Write($"Categoria:  {categoria}\n\n\n ");                
                Console.Write($"IMC Desejável:  entre 20 a 24\n\n ");
                Console.Write($"Resultado IMC:  {Math.Round(imc, 1)}\n\n ");

                Console.Write($"Classificação IMC:  "); 
                Classificacao_Cor(classificacao); //Função de cor que carrega como parâmetro, a variável classificação na qual está atribuída pela função 'Classificação'                                                  
                Console.ResetColor(); //Cor definida dentro da função Classificacao_cor é resetada(restaura as cores padrão do terminal)

                Console.WriteLine("\n");
                Console.Write($" Riscos:  {riscos}\n\n ");
                Console.Write($"Recomendação Inicial:  {recomendacao}\n\n\n ");

                    
                Rodape();

                Console.WriteLine(" ");

                Console.Write("\t» Deseja realizar o Diagnóstico Prévio outra vez? Digite 'S' para confirmar ou 'N' para finalizar: « \n\n ");                         
                tentativa = Console.ReadLine();
                
                Console.Clear();
           
              while (tentativa.ToUpper() != "S" && tentativa.ToUpper() != "N") //Validação para caso o usuário não digitar as letras S ou N
                                                                               //Se for digitada uma letra diferente da correspondente acima, o console
                                                                               //exibirá uma mensagem de erro
                {
                    Console.Write("  ");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("\n   Escolha inválida. Por favor, digite 'S' para confirmar ou 'N' para finalizar o programa: ");
                    Console.ResetColor();
                    tentativa = Console.ReadLine(); //Permitir que o usuário digite outra letra
                    Console.Clear();
                }

            }
            while (tentativa.ToUpper() == "S"); //Se for digitada a letra S, o programa reiniciará para um novo diagnóstico

                Console.Clear();

                if (tentativa.ToUpper() == "N") //Se for digitada a letra N, o console exibirá uma informação de agradecimento e o programa é encerrado
                {
                    Titulo();

                    Console.Write("  » Agradecemos a sua preferência! Take Care! «\n\n".PadLeft(85 , ' ')); //Informação centralizada

                    Rodape();
                }
        }

        /// <summary>
        /// Função que determina a categoria através da idade digitada pelo usuário 
        /// </summary>
        /// <param name="idade"></param>
        /// <returns>Retorna a categoria compatível ao usuário</returns>
        static string Categoria(int idade)
        {
            string category = null; //variável iniciada como nula
            //Categorias correspondentes às idades definidas, através de uma estrutura condicional
            if (idade < 12) { category = "Infantil"; }
            if (idade >= 12 && idade < 21) { category = "Juvenil"; }
            if (idade >= 21 && idade <= 65) { category = "Adulto"; }
            if (idade > 65) { category = "Idoso"; }
           
            return category;    
        }

        /// <summary>
        /// Função que calcula o imc através de sua fórmula 
        /// </summary>
        /// Abaixo, parâmetros que, a partir do valor recebido pelo usuário, são utilizados para o cálculo do imc
        /// <param name="peso"></param> 
        /// <param name="altura"></param>
        /// <returns>Retorna o resultado do imc calculado</returns>
        static double IMC (double peso, double altura)
        {
            double imc;
            imc = (peso / Math.Pow(altura, 2)); //Função de exponenciação/Potência, no qual calcula a base e o expoente: Math.Pow(base, expoente)

            return imc;

        }

        /// <summary>
        /// Função que classifica qual categoria de peso o usuário está enquadrado
        /// </summary>
        /// <param name="imc"></param>
        /// <returns>Retorna a classificação correspondente</returns>
        static string Classificacao (double imc)
        {
            string rating = null;

            // Dependendo de qual for o resultado do imc do usuário, é exibida a classificação que ele se encontra                     
            if (imc < 20)
            {
                rating = "Abaixo do Peso Ideal";
            } 

            else if (imc >= 20 && imc < 25)
            {              
                rating = "Peso Normal";               
            }


            else if (imc >= 25 && imc < 30)
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

        /// <summary>
        /// Função que exibe cada tipo de classificação com uma cor correspondente a uma intensidade de risco
        /// </summary>
        /// <param name="rating"></param>
        static void Classificacao_Cor(string rating)
        {
            //Caso a classificação for abaixo do peso, a mensagem é exibida na cor ciano
            if (rating == "Abaixo do Peso Ideal")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Abaixo do Peso Ideal");
                Console.ResetColor();
            }
            //Caso a classificação for igual ao peso normal, a mensagem é exibida na cor verde
            if (rating == "Peso Normal")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Peso Normal");
                Console.ResetColor();
            }
            //Caso a classificação for acima do peso, a mensagem é exibida na cor azul
            if (rating == "Excesso de Peso")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Excesso de Peso");
                Console.ResetColor();
            }
            //Caso a classificação for como obeso, a mensagem é exibida na cor amarela
            if (rating == "Obesidade")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Obesidade");
                Console.ResetColor();
            }
            //Caso a classificação for superior à obesidade, a mensagem é exibida na cor vermelha
            if (rating == "Super Obesidade")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Super Obesidade");
                Console.ResetColor();
            }

        }

        /// <summary>
        /// Função que representa os riscos de acordo com o resultado do imc
        /// </summary>
        /// <param name="imc"></param>
        /// <returns>Retorna o risco estimado</returns>
        static string Riscos (double imc)
        {
            string effect = null;

           //um valor de texto do tipo string é atribuído à variavel effect dependendo da condição do resultado do imc 
           if (imc < 20)
            {
              effect = "Muitas complicações de saúde como doenças pulmonares e \n" +
                     " cardiovasculares podem estar associadas ao baixo peso.";    
            }

            else if (imc >= 20 && imc < 25)
            {         
                effect = "Seu peso está ideal para suas referências.";
            }

            else if (imc >= 25 && imc < 30)
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

        /// <summary>
        /// Função que apresenta a recomendação adequada para o usuário a partir do resultado de seu imc
        /// </summary>
        /// <param name="imc"></param>
        /// <returns>Retorna a recomendação estimada</returns>
        static string Recomendacao (double imc)
        {

            string advice = null;

            //O texto é atribuído à variavel effect dependendo de uma condição do resultado do imc do usuário
            if (imc < 20)
            {     
                advice = "Inclua carboidratos simples em sua dieta, além de proteínas \n" +
                               " indispensáveis para ganho de massa magra. Procure um profissional.";
            }

            else if (imc >= 20 && imc < 25)
            {     
                advice = "Mantenha uma dieta saudável e faça seus exames periódicos.";
            }

            else if (imc >= 25 && imc < 30)
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

        /// <summary>
        /// Função que representa o cabeçalho para ser exibido no console
        /// </summary>
        static void Titulo()
        {

            for (int x = 0; x < Console.WindowWidth/2; x++) //Através do loop for, a variável x é menor do que o tamanho da tela dividida por 2
                                                            //Sendo distribuída no lado esquerdo e direito da tela
            {
                 Console.Write("<>"); //Linhas de símbolos são impressas, sendo repetidas até metade da tela do console
            }

            Console.WriteLine("  ");

            //Título centralizado na coloração magenta
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($" DIAGNÓSTICO PRÉVIO - IMC\n".PadLeft( 73 , ' '));
            Console.ResetColor();

            //Linhas centralizadas sublinhando o título
            Console.Write($"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n".PadLeft(76, ' '));

        }
        
        /// <summary>
        /// Função que serve como uma margem de rodapé 
        /// </summary>
        static void Rodape()
        {
            for (int z = 0; z < Console.WindowWidth/2; z++)
            {
                Console.Write("<>"); //Através de um loop, as linhas impressas são mostradas repetidamente até a metade da tela como limite
            }

            Console.WriteLine("  ");

        }

    }
}
