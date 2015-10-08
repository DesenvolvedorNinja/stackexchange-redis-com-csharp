using StackExchange.Redis;
using System;

namespace StackExchangeRedisDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //estabelecer a conexão com Redis
            using (ConnectionMultiplexer connectionRedis = ConnectionMultiplexer.Connect("localhost:13919,password=senhadoredis"))
            {
                //obter o database para envio de comandos ao Redis
                IDatabase clientRedis = connectionRedis.GetDatabase();
                //gravando uma chave
                clientRedis.StringSet("admin_sistema", "Desenvolvedor Ninja");
                //lendo uma chave
                Console.WriteLine(clientRedis.StringGet("admin_sistema"));
                //definindo 600 segundos como tempo de expiração
                clientRedis.KeyExpire("admin_sistema", TimeSpan.FromSeconds(600));
                //consultando o tempo de expiração da chave
                Console.WriteLine(clientRedis.KeyTimeToLive("admin_sistema"));
                //retirando o tempo de expiração da chave tornando-a permanente
                clientRedis.KeyPersist("admin_sistema");
                //apagando uma chave
                clientRedis.KeyDelete("admin_sistema");
                //fechando a conexão com o Redis
                connectionRedis.Close();
            }
        }
    }
}
