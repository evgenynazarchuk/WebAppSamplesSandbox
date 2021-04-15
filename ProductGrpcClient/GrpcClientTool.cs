using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ProductGrpcClient
{
    class GrpcClientTool : IDisposable
    {
        private Grpc.Net.Client.GrpcChannel _channel;
        private object _service;

        public GrpcClientTool(Type serviceType, string address)
        {
            this._channel = Grpc.Net.Client.GrpcChannel.ForAddress(address);
            this._service = Activator.CreateInstance(type: serviceType, args: _channel);
        }

        public TResponse Request<TResponse, TRequest>(string methodName, TRequest requestBody)
            where TRequest : class, new()
            where TResponse : class, new()
        {
            var method = this._service.GetType().GetMethods().Where(x => x.Name == methodName).ToList();
            var options = new Grpc.Core.CallOptions();

            DateTime startDateTime = DateTime.Now;
            var response = method[1].Invoke(this._service, new object[] { requestBody, options });
            DateTime endDateTime = DateTime.Now;

            Console.WriteLine($"{startDateTime.ToString("O")}\t{endDateTime.ToString("O")}\t{endDateTime.Subtract(startDateTime)}");

            return response as TResponse;
        }

        public void Request<TResponse, TRequest>(string methodName, TRequest requestBody, out TResponse responseBody)
            where TRequest : class, new()
            where TResponse : class, new()
        {
            responseBody = this.Request<TResponse, TRequest>(methodName, requestBody);
        }

        public void Request<TRequest>(string methodName, TRequest requestBody)
            where TRequest : class, new()
        {
            this.Request<object, TRequest>(methodName, requestBody);
        }

        public void Dispose()
        {
            this._channel.Dispose();
        }
    }
}
