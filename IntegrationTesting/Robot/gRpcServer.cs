using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using App2D;

namespace IntegrationTesting.Robot
{
    class GRpcServer
    {
        const int Port = 50051;
        Server server = new Server
        {
            Services = { Robot2dApp.BindService(new VisionImpl()) },
            Ports = { new ServerPort("127.0.0.1", Port, ServerCredentials.Insecure) }
        };

        public GRpcServer()
        {
        }

        public void ServerStart()
        {
            server.Start();
            Console.WriteLine("Greeter server listening on port " + Port);
            Console.WriteLine("Press any key to stop the server...");            
        }

        public void ServerStop()
        {
            server.ShutdownAsync().Wait();
        }
    }
}
