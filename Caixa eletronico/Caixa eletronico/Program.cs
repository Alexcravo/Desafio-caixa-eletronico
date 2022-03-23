using System;
using System.Collections.Generic;

namespace Caixa_eletronico
{
    class Programa
    {
        static void Main(string[] args)
        {
            //Lista para salvar as ações do usuario do tipo String
            List<string> listExtrato = new List<string>();

            //String extrato definido como null como padrão
            string extrato = null;

            //Decimal saldo definido como 0 como padrão
            decimal saldo = 0;

            //Decimal saque definido como 0 como padrão
            decimal saque = 0;

            Console.WriteLine("Qual é seu nome?");
            
            //Pego o nome do Usuario e dou boas vindas
            string nome = Console.ReadLine();
            Console.WriteLine($"Olá {nome}, seja bem vindo ao caixa do Cravo Bank");

            //Chamo as opçoes novamente para o usuario
            Opcoes();

            //Metodo Opcoes
            void Opcoes() 
            {
                //Exibo para o usuario as opções
                Console.WriteLine("\n Digite 1 para Consultar saldo \n Digite 2 para Sacar o dinheiro \n Digite 3 para Depositar o dinheiro \n Digite 4 para Extrato da conta \n Digite 5 para Finalizar operação");
                
                //Pego o valor da opção que o usuario digitou
                string opcao = Console.ReadLine();

                //Limpa o console
                Console.Clear();

                //Chamo o metodo ValidateOpcao passando a opção que o usuario digitou
                ValidateOpcao(opcao);
            }

            //Metodo ValidateOpcao espera receber uma string 
            void ValidateOpcao(string opcoes) 
            {
                //Valido usando switch case para verificar qual foi a opção que o usuario digitou até a achar o metodo que corresponde
                switch (opcoes)
                {
                    case "1":
                        ConsultarSaldo(saldo);
                        break;
                    case "2":
                        Sacar();
                        break;
                    case "3":
                        Depositar();
                        break;
                    case "4":
                        Extrato();
                        break;
                    case "5":
                        Sair();
                        break;
                }
            }

            //Metodo ConsultarSaldo espera receber um decimal
            void ConsultarSaldo(decimal saldo)
            {
                //Exibe o saldo atual
                Console.WriteLine($"Seu saldo atualmente é de R${saldo}");

                //Chamo as opçoes novamente para o usuario
                Opcoes();
            }

            //Metodo Sacar
            void Sacar()
            {
                Console.WriteLine("Qual o valor do saque ?");

                //Converto o valor digitado para decimal
                saque = Convert.ToDecimal(Console.ReadLine());

                //Verifico se o Valor do saque for maior que o saldo me retorna saldo indiponivel e exibe a opção novamente
                if (saque > saldo )
                {
                    Console.WriteLine("Saldo indisponivel");
                    Opcoes();
                }

                //Atualizo o valor do saldo fazendo a subtração do saldo - saque
                saldo = (saldo - saque);
                Console.WriteLine("Saque realizado");

                //Adiciono o valor do saque novo com a data para a lista de extrato
                extrato = $"Saque de R${saque}, Data:{DateTime.Now}";
                listExtrato.Add(extrato);

                //Chamo as opçoes novamente para o usuario
                Opcoes();
            }


            //Metodo Depositar
            void Depositar()
            {
                Console.WriteLine("Qual o valor deseja depositar ?");

                //Converto o valor digitado para decimal
                var saldoNovo = Convert.ToDecimal(Console.ReadLine());

                //exibi o valor recebido Concatenado
                Console.WriteLine($"Deposito de R${saldoNovo} Efetudo com sucesso");

                //Somo o valor novo digitado com o valor antigo do saldo
                saldo = saldoNovo + saldo;

                //Adiciono o valor do saldo novo com a data para a lista de extrato
                extrato = $"Deposito de R${saldoNovo}, Data:{DateTime.Now}";
                listExtrato.Add(extrato);

                //Chamo as opçoes novamente para o usuario
                Opcoes();
            }


            //Metodo Extrato
            void Extrato()
            {
                //Pego itens da lista de extrato e exibo um de cada vez usando foreach
                foreach (var item in listExtrato)
                {
                    Console.WriteLine($"Transações realizadas {item}");
                }

                //Chamo as opçoes novamente para o usuario
                Opcoes();
            }

            //Metodo Sair
            void Sair()
            {
                Console.WriteLine($"Obrigado {nome}, por utilizar nossos serviços !");
            }
        }
    }
}