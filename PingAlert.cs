using System;

namespace FerramentaDePing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ferramenta de Ping");
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1. Ipconfig");
            Console.WriteLine("2. Ping");
            Console.WriteLine("3. Tracert");
            int escolha = Convert.ToInt32(Console.ReadLine());

            string enderecoIp;
            if (escolha == 1)
            {
                Ipconfig();
            }
            else if (escolha == 2)
            {
                Console.Write("Digite o endereço IP que você deseja pingar: ");
                enderecoIp = Console.ReadLine();
                Ping(enderecoIp);
            }
            else if (escolha == 3)
            {
                Console.Write("Digite o endereço IP que você deseja tracert: ");
                enderecoIp = Console.ReadLine();
                Tracert(enderecoIp);
            }
            else
            {
                Console.WriteLine("Escolha inválida. Saindo...");
            }
        }

        static void Ipconfig()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = "ipconfig";
            process.StartInfo.Arguments = "/all";
            process.Start();
        }

        static void Ping(string enderecoIp)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = "ping";
            process.StartInfo.Arguments = $"-c 1 {enderecoIp}";
            process.Start();
            if (process.WaitForExit(1000) && process.ExitCode == 0)
            {
                Console.WriteLine($"Ping para {enderecoIp} realizado com sucesso.");
            }
            else
            {
                Console.WriteLine($"Ping para {enderecoIp} falhou.");
            }
        }

        static void Tracert(string enderecoIp)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = "tracert";
            process.StartInfo.Arguments = enderecoIp;
            process.Start();
        }
    }
}