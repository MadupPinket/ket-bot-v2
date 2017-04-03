using Autofac;
using Autofac.Integration.WebApi;
using KetBot.Bot.Dialogs;
using KetBot.Data.Repositories;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Builder.Internals.Fibers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace KetBot.Bot
{
    public static class AutofacBootstrapper
    {
        public static void Initialise()
        {
            var builder = new ContainerBuilder();
            BuildContainer(builder);
        }

        static void BuildContainer(ContainerBuilder builder)
        {
            //builder.RegisterType<KetbotMongoRepository>().As<IKetbotMongoRepository>();
            //builder.RegisterType<MongoClient>().AsSelf().UsingConstructor()
            builder.RegisterType<KetbotMongoRepository>().Keyed<IKetbotMongoRepository>(FiberModule.Key_DoNotSerialize).AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<KetbotLuisDialog>().As<IDialog<object>>().InstancePerDependency();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            builder.RegisterModule(new DialogModule());

            builder.RegisterModule(new ReflectionSurrogateModule());

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}