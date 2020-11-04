using Microsoft.VisualBasic;
using Refit;
using System;
using System.Threading.Tasks;

namespace ConsultCEP
{
    class Program
    {
        static async Task Main(string[] args) //Requisições assíncronas para aguardar todo o tempo necessário da requisição
        {
            Console.WriteLine("\t█▀▀ █▀█ █▄░█ █▀ █░█ █░░ ▀█▀   █▀▀ █▀▀ █▀█\n" +
                              "\t█▄▄ █▄█ █░▀█ ▄█ █▄█ █▄▄ ░█░   █▄▄ ██▄ █▀");

            int continuar = 1;
            while (continuar == 1)
            {
                try
                {
                    var cepClient = RestService.For<ICepApiService>("https://viacep.com.br/");
                    Console.WriteLine("\nInforme o seu CEP: ");
                    string cepInformado = Console.ReadLine();
                    Console.WriteLine("Realizando consulta...");

                    var address = await cepClient.GetAddressAsync(cepInformado);

                    Console.WriteLine($"\nCEP: {address.Cep}\nRua: {address.Logradouro}\nBairro: {address.Bairro}\nCidade: {address.Localidade}\nUF: {address.UF}");
                }
                catch (Exception e)
                {

                    Console.WriteLine($"Erro na requisição {e.Message}");
                }

                Console.WriteLine("\nGostaria de pesquisar outro CEP? [1]Sim [2]Não");
                continuar = int.Parse(Console.ReadLine());
            }
        }
    }
}
