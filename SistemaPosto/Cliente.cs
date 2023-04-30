using System;

namespace SistemaPosto
{
    class Cliente : Posto
    {
        private string Nome;
        private string Telefone;
        private string Endereco;
        public string Cpf;
        public double Saldo = 300;
        public double Divida = 0.0;
        public bool Disponivel = true;

        public string TipoVeiculo;
        public string CorVeiculo;
        public string PlacaVeiculo;
        
       

        public static int RegistrarUsuario(Cliente[] clientes, string nome, string telefone, string endereco, string cpf, string tipoveiculo, string corveiculo, string placaveiculo)
        {
            try
            {
                Cliente cliente = new Cliente { Nome = nome, Telefone = telefone, Endereco = endereco, Cpf = cpf, Saldo = 300, TipoVeiculo = tipoveiculo, CorVeiculo = corveiculo, PlacaVeiculo = placaveiculo,Disponivel = true, Divida = 0.0 };
                foreach (var ValidarInformacoes in clientes)
                {
                    if (ValidarInformacoes != null && ValidarInformacoes.Cpf == cpf)
                    {
                        Console.WriteLine("Usuários não podem ter o mesmo CPF!");
                        Console.ReadKey();
                        Console.Clear();
                        return 0;
                    }
                    if (tipoveiculo != "carro" && tipoveiculo != "moto" && tipoveiculo != "bicicleta" && tipoveiculo != "caminhao")
                    {
                        throw new Exception(" digite um tipo de veiculo disponivel: ");
                    }

                    if (ValidarInformacoes != null && ValidarInformacoes.PlacaVeiculo == placaveiculo)
                    {
                        Console.WriteLine("Usuários não podem ter a mesma placa de veículo!");
                        Console.ReadKey();
                        Console.Clear();
                        return 0;
                    }
                }
                var novo_usuario = new Cliente { Nome = nome, Telefone = telefone, Endereco = endereco, Cpf = cpf, Saldo = 300, TipoVeiculo = tipoveiculo, CorVeiculo = corveiculo, PlacaVeiculo = placaveiculo, Disponivel = true, Divida = 0.0 };
                clientes[Array.IndexOf(clientes, null)] = novo_usuario;
                Console.WriteLine("Usuário cadastrado com sucesso");
                Console.ReadKey();
                Console.Clear();
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro, veiculo invalido, digite um " + ex.Message);
                Console.ReadKey();
                Console.Clear();
                return 0;
            }
        }
        public static int ProcurarUsuario(Cliente[] clientes, string cpf)
        {
            int cont = 0;
            foreach (var procurar in clientes)
            {
                if (procurar != null && procurar.Cpf == cpf)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Usuario encontrado!");
                    Console.WriteLine("Nome: " + procurar.Nome);
                    Console.WriteLine("Endereço: " + procurar.Endereco);
                    Console.WriteLine("telefone: " + procurar.Telefone);
                    Console.WriteLine("Cpf: " + procurar.Cpf);
                    Console.WriteLine("Saldo: " + procurar.Saldo);
                    Console.WriteLine("Tipo de veiculo: " + procurar.TipoVeiculo);
                    Console.WriteLine("Cor do veiculo: " + procurar.CorVeiculo);
                    Console.WriteLine("Placa do veiculo: " + procurar.PlacaVeiculo);
                    if (procurar.Disponivel == true)
                    {
                        Console.WriteLine("Sem dividas.");
                    }
                    else
                    {
                        Console.WriteLine("Divida pendente.");
                    }
                    Console.ReadKey();
                    Console.Clear();
                    cont++;
                }
            }

                if (cont > 0)
                {
                    return 1;
                }

                else
                {
                    Console.WriteLine("Usuario não encontrado!");
                    Console.ReadKey();
                    Console.Clear();
                    return 0;
                }

            }
        public static int Depositar(Cliente[] clientes, string cpf)
        {
               foreach (var procurar in clientes)
            {
                if (procurar != null && procurar.Cpf == cpf)
                {
                    Console.WriteLine("Usuario conectado, seu saldo atual é: " + procurar.Saldo);
                    Console.Write("digite a quatidade de dinheiro que deseja depositar: ");
                    int Deposito = int.Parse(Console.ReadLine());
                    procurar.Saldo = (procurar.Saldo + Deposito);
                    Console.WriteLine("Deposito realizado com sucesso seu novo saldo é: " + procurar.Saldo);
                    Console.ReadKey();
                    Console.Clear();
                    return 1;
                }
            }
            return 0;
        }
    }
}
