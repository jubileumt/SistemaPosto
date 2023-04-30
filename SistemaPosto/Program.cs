using Microsoft.SqlServer.Server;
using System;

namespace SistemaPosto
{
    class Program : Cliente
    {
        static void Main(string[] args)
        {
            Cliente[] clientes = new Cliente[10];
            while (true)
            {
                Console.WriteLine("1-para fazer registro de usuario e seu carro.");
                Console.WriteLine("2-Para procurar usuario cadastrado.");
                Console.WriteLine("3-Para depositar dinheiro para um usuario.");
                Console.WriteLine("4-para fazer uso do Posto de combustivel.");
                Console.WriteLine("5-Para fazer uso do estacionamento do Posto.");
                Console.WriteLine("6-Para fazer uso da lavagem  do Posto.");
                Console.WriteLine("7-Para pagar dividas.");
                Console.Write("Escolha:");
                int opc = int.Parse(Console.ReadLine());

                if (opc == 1)
                {
                    Console.Write("Digite o nome do usuario:");
                    string nome = Console.ReadLine();
                    Console.Write("Digite o telefone do usuario:");
                    string telefone = Console.ReadLine();
                    Console.Write("Digite o endereço do usuario:");
                    string endereco = Console.ReadLine();
                    Console.Write("Digite o Cpf do usuario:");
                    string cpf = Console.ReadLine();
                    Console.Write("Tipo do veiculo, aceitamos carro,moto,bicicleta e caminhão:");
                    string tipocarro = Console.ReadLine();
                    Console.Write("Cor do  veiculo:");
                    string corcarro = Console.ReadLine();
                    Console.Write("Placa do veiculo:");
                    string placacarro = Console.ReadLine();
                    RegistrarUsuario(clientes, nome, telefone, endereco, cpf, tipocarro , corcarro ,placacarro);
                }

                if (opc == 2)
                {
                    Console.Write("Digite o Cpf do usuario:");
                    string cpf = Console.ReadLine();
                    ProcurarUsuario(clientes,cpf);
                }
                if (opc == 3)
                {
                    Console.Write("Digite o Cpf do usuario:");
                    string cpf = Console.ReadLine();
                    Depositar(clientes, cpf);
                }

                if (opc == 4)
                {
                    Console.Write("Digite o Cpf do usuario para fazer uso dos combustiveis disponveis:");
                    string cpf = Console.ReadLine();
                    Combustivel(clientes,cpf);
                    
                }

                if (opc == 5)
                {
                    Console.Write("Digite o Cpf de um usuario para usar o estacionamento:");
                   
                    string cpf = Console.ReadLine();
                    Estacionamento(clientes,cpf);
                   
                }

                if (opc ==  6)
                {
                    Console.Write("Digite o Cpf de um usuario para fazer usa da lavagem do posto:");
                    string cpf = Console.ReadLine();
                    Lavagem(clientes, cpf);
                }

                if (opc == 7)
                {
                    Console.Write("Digite o Cpf de um usuario para quitar divida:");
                    string cpf = Console.ReadLine();
                    PagarDivida(clientes, cpf);
                }
            }
        }
    }
}