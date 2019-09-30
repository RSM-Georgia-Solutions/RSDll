using Autofac;
using RevenueServices.Inrerfaces;

namespace RevenueServices
{
    public static class ContainerConfig
    {
        public static IContainer Cofigrure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<RsClient>().As<IRsClient>();

            return builder.Build();
        }
    }
}
