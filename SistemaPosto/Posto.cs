using System;
using System.Data;
using System.Diagnostics.Eventing.Reader;

namespace SistemaPosto
{
    abstract class  Posto
    {

        protected static int Combustivel(Cliente[] clientes,string cpf)
        { 
            Console.Clear();
            double CombusivelEscolhido = 0.0;
            foreach (var verificar in clientes)
            {
                if (verificar != null && verificar.Cpf == cpf && verificar.Disponivel == true)
                {
                    Console.WriteLine("---Usuario conectado---");
                    Console.WriteLine("");
                    if (verificar.TipoVeiculo == "carro")
                    {
                        Console.WriteLine("1-Para abstecer seu carro com gasolina R$5,70");
                        Console.WriteLine("2-Para abstecer seu carro com gasolina aditivada R$5,90");
                        Console.WriteLine("3-Para abstecer seu carro com etanaol R$3,90");
                        Console.WriteLine("4-Para abstecer seu carro com diesel R$7,00");
                        Console.Write("Escolha:");
                        int opc = int.Parse(Console.ReadLine());
                        if (opc == 1)
                        {
                            CombusivelEscolhido = 5.70;
                        }
                        if (opc == 2)
                        {
                            CombusivelEscolhido = 5.90;
                        }
                        if (opc == 3)
                        {
                            CombusivelEscolhido = 3.90;
                        }
                        if (opc == 4)
                        {
                            CombusivelEscolhido = 7.00;
                        }
                    }

                    else if (verificar.TipoVeiculo == "moto")
                    {
                        Console.WriteLine("1-Para abstecer sua moto com gasolina R$5,70");
                        Console.WriteLine("2-Para abstecer sua moto com gasolina aditivada R$5,90");
                        Console.WriteLine("3-Para abstecer sua moto com etanaol R$3,90");
                        Console.Write("Escolha:");
                        int opc = int.Parse(Console.ReadLine());
                        if (opc == 1)
                        {
                            CombusivelEscolhido = 5.70;
                        }
                        if (opc == 2)
                        {
                            CombusivelEscolhido = 5.90;
                        }
                        if (opc == 3)
                        {
                            CombusivelEscolhido = 3.90;
                        }
                    }

                    else if (verificar.TipoVeiculo == "caminhao")
                    {
                        Console.WriteLine("1-Para abastecer seu carro com diesel R$7,00");
                        Console.WriteLine("2-Para abastecer seu carro com diesel aditivada R8,90");
                        Console.Write("Escolha:");
                        int opc = int.Parse(Console.ReadLine());
                        if (opc == 1)
                        {
                            CombusivelEscolhido = 7.00;
                        }
                        if (opc == 2)
                        {
                            CombusivelEscolhido = 8.90;
                        }
                    }

                    else if (verificar.TipoVeiculo == "bicicleta")
                    {
                        Console.WriteLine("Não tem combustivel para bicicleta.");
                        CombusivelEscolhido = 10.00;
                    }

                    double PrecoTotal = 0.0;
                    Console.Write("Digite os litros de combustivel q vc vai querer:");
                    int LitrosCombustivel = int.Parse(Console.ReadLine());
                    Console.WriteLine("Seu saldo atual é:" + verificar.Saldo);
                    PrecoTotal = (CombusivelEscolhido * LitrosCombustivel);
                   
                    if (verificar.Saldo >= PrecoTotal)
                    {
                        verificar.Saldo = (verificar.Saldo - PrecoTotal);
                        Console.WriteLine("Pagamneto realizado com sucesso!");
                        Console.WriteLine("Seu saldo depois da compra é: " + verificar.Saldo);
                        verificar.Disponivel = true;
                        Console.ReadLine();
                        Console.Clear();
                        return 1;
                    }

                    else
                    {
                        Console.WriteLine("Saldo não suficiente!");
                        Console.WriteLine("Seu veiculo ficará impedido de usar os seviços do posto ate que voce quite as dividas.");
                        verificar.Divida = PrecoTotal;
                        verificar.Disponivel = false;
                        Console.ReadKey();
                        Console.Clear();
                        return 0;
                    }
                }
            }
            Console.WriteLine("Usuario não encontrado! / Cobrança pendende!");
            Console.ReadKey();
            Console.Clear();
            return 0;
        }
        protected static int Estacionamento(Cliente[] clientes, string cpf)
        {
            Console.Clear();
            double PrecoHora = 0.0;
            foreach (var verificar in clientes)
            {
                if (verificar != null && verificar.Cpf== cpf && verificar.Disponivel == true)
                {
                    Console.WriteLine("Usuario conectado, o tipod e seu veiculo é:" + verificar.TipoVeiculo);
                    if (verificar.TipoVeiculo == "carro")
                    {
                        Console.WriteLine("Preco para carros por hora é de R$5,00");
                        PrecoHora = 5.00;
                    }

                    else if (verificar.TipoVeiculo == "moto")
                    {
                        Console.WriteLine("Preço para motos por hora é de R$3,00");
                        PrecoHora = 3.00;
                    }

                    else if (verificar.TipoVeiculo == "bicicleta")
                    {
                        Console.WriteLine("Preço para bicicleta por hora é de R$1,50");
                        PrecoHora = 1.50;
                    }

                    else if (verificar.TipoVeiculo == "caminhao")
                    {
                        Console.WriteLine("Preço para caminhao por hora é de R$10,00");
                        PrecoHora = 10.00;
                    }

                    Console.Write("Digite a quantidade de horas q deseja permanecer com seu veiculo:");
                    int TempoTotal = int.Parse(Console.ReadLine());
                    double PrecoTotal = (PrecoHora * TempoTotal);
                    Console.WriteLine("Preço do estacionamento: " + PrecoTotal);
                    Console.WriteLine("Seu saldo atual é de: " + verificar.Saldo);

                    if (verificar.Saldo >= PrecoTotal)
                    {
                        verificar.Saldo = (verificar.Saldo - PrecoTotal);
                        Console.WriteLine("Pagamento realizado com sucesso, seu novo saldo é: " + verificar.Saldo);
                        verificar.Disponivel = true;
                        Console.ReadKey();
                        Console.Clear();
                        return 1;
                    }
                    else
                    {
                        Console.WriteLine("Saldo isuficiente pra o pagamento, seu saldo atual é " + verificar.Saldo + " e o preço do esatcionamento foi: " + PrecoTotal);
                        Console.WriteLine("Seu veiculo ficará impedido de usar os seviços do posto ate que voce quite as dividas.");
                        verificar.Divida = PrecoTotal;
                        verificar.Disponivel = false;
                        Console.ReadKey();
                        Console.Clear();
                        return 0;
                    }
                }
            }
            Console.WriteLine("Usuario não encontrado");
            Console.ReadKey();
            Console.Clear();
            return 0;
        }
        protected static int Lavagem(Cliente[] clientes, string cpf)
        {
            Console.Clear();
            double PreçoLavagem = 0.0;
            foreach (var verificar in clientes)
            {
                if (verificar != null && verificar.Cpf == cpf && verificar.Disponivel == true)
                {
                    Console.WriteLine("usuario conectado");
                    if (verificar.TipoVeiculo == "carro")
                    {
                        Console.WriteLine("Preco para carros por hora é de R$40,00");
                        PreçoLavagem = 40.00;
                    }

                    else if (verificar.TipoVeiculo == "moto")
                    {
                        Console.WriteLine("Preço para motos por hora é de R$25,00");
                        PreçoLavagem = 25.00;
                    }

                    else if (verificar.TipoVeiculo == "bicicleta")
                    {
                        Console.WriteLine("Preço para bicicleta por hora é de R$10,00");
                        PreçoLavagem = 10.00;
                    }

                    else if (verificar.TipoVeiculo == "caminhao")
                    {
                        Console.WriteLine("Preço para caminhao por hora é de R$100,00");
                        PreçoLavagem = 100.00;
                    }

                    if (verificar.Saldo >= PreçoLavagem)
                    {
                        verificar.Saldo = (verificar.Saldo - PreçoLavagem);
                        Console.WriteLine("Pagamento realizado com sucesso, seu novo saldo é: " + verificar.Saldo);
                        verificar.Disponivel = true;
                        Console.ReadKey();
                        Console.Clear();
                        return 1;
                    }
                    else
                    {
                        Console.WriteLine("Saldo isuficiente pra o pagamento, seu saldo atual é " + verificar.Saldo + " e o preço do esatcionamento foi: " + PreçoLavagem);
                        Console.WriteLine("Seu veiculo ficará impedido de usar os seviços do posto ate que voce quite as dividas.");
                        verificar.Divida = PreçoLavagem;
                        verificar.Disponivel = false;
                        Console.ReadKey();
                        Console.Clear();
                        return 0;
                    }
                   
                }
             }
            return 0;
        }
        protected static void PagarDivida(Cliente[] clientes, string cpf)
        {
            foreach (var verificar in clientes)
            {
                if (verificar != null && verificar.Cpf == cpf && !verificar.Disponivel)
                {
                    Console.WriteLine("Usuário conectado. Saldo disponivel: " + verificar.Saldo + " o valor de sua divida é:" + verificar.Divida);
                    Console.Write("Digite o valor que deseja pagar: ");
                    double valorPagamento = double.Parse(Console.ReadLine());

                    if (valorPagamento >= verificar.Divida && verificar.Saldo >= valorPagamento)
                    {
                        verificar.Saldo -= valorPagamento;
                        verificar.Disponivel = true; 
                        Console.WriteLine("Dívida quitada. Seu veículo está desbloqueado. Seu novo saldo é: " + verificar.Saldo );
                        verificar.Disponivel = true;
                    }

                    else
                    {
                        Console.Write("Saldo nao suficiente, 1- se quiser depositar dinheiro na conta, 2 - se quiser sair");
                        int opc = int.Parse(Console.ReadLine());

                        if (opc == 1)
                        {
                            Console.Write("Digite o Cpf do usuario:");
                            string CPF = Console.ReadLine();
                            Cliente cliente = new Cliente();
                            Cliente.Depositar(clientes, cpf);
                        }
                        else if (opc ==2 )
                        {
                            return;
                        }
                    }

                    Console.ReadLine();
                    Console.Clear();
                    return;
                }
            }

            Console.WriteLine("Usuário não encontrado ou não possui dívida pendente.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}