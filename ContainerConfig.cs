﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueServices.Inrerfaces
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