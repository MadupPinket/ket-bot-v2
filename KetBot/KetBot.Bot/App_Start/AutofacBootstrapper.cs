using Autofac;
using KetBot.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace KetBot.Bot
{
    public static class AutofacBootstrapper
    {
        public static void Initialise()
        {
            //var builder = new ContainerBuilder();
            //BuildContainer(builder);
        }

        static void BuildContainer(ContainerBuilder builder)
        {
            //then the base repo types
            builder.RegisterInstance(new KetbotMongoRepository()).As<IKetbotMongoRepository>();
            builder.RegisterType<MessagesController>();

            var container = builder.Build();
        }
    }
}