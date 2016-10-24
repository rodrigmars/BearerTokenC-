using MicroServiceWebApi;
using Microsoft.Owin.Hosting;
using System;

namespace SelfhostService
{
    public class ServiceHost
    {
        private string _baseAddress = "http://localhost:9000/";
        //WebApp;

        private IDisposable _server;

        public ServiceHost()
        {
            Console.WriteLine("ServiceHost constructed");
        }

        public void Start()
        {
            Console.WriteLine("ServiceHost started");

            _server = WebApp.Start<Startup>(url: _baseAddress);

            Console.WriteLine($"Server running at {_baseAddress}");
        }

        public void Shutdown()
        {
            Console.WriteLine("ServiceHost shutting down");
            //_server.Dispose();
        }

        public void Stop()
        {
            Console.WriteLine("Server shutting down");

            _server.Dispose();

            Console.WriteLine("ServiceHost stopped");
        }

    }
}
