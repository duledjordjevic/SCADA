using CommonLibrary;
using CommonLibrary.ConsoleTools;
using RTU.ServiceReference;
using System;
using System.Threading;

namespace RTU
{
    public class RTDClientAdapter
    {
        private readonly RealTimeDriverServiceClient RTDClient;

        private Device device;

        public RTDClientAdapter(RealTimeDriverServiceClient rtdClient)
        {
            RTDClient = rtdClient;
        }

        public void Register()
        {
            var registered = false;

            while (!registered)
            {
                device = new Device { Address = ConsoleReader.ReadString("RTU address", "") };
                registered = RTDClient.RegisterRTU(device.Address);
            }
        }

        public void Configure()
        {
            device.Min = ConsoleReader.ReadDouble("min value", "");
            device.Max = ConsoleReader.ReadDoubleGreaterThan(device.Min, "max value", "");
            device.Rate = ConsoleReader.ReadPositiveInteger("rate in seconds", "");
        }

        public void SendData()
        {
            var random = new Random();
            while (true)
            {
                var value = random.NextDouble() * (device.Max - device.Min) + device.Min;

                string message = $"{value}";

                SignatureProvider.CreateAsmKeys();
                var signature = SignatureProvider.SignMessage(message);
                SignatureProvider.ExportPublicKey();

                RTDClient.SendData(device.Address, message, signature);

                Thread.Sleep(device.Rate * 1000);
            }
        }

    }
}
