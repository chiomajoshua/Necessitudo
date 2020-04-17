using Autofac;
using Necessitudo.Contract;
using Necessitudo.Engine;
using Necessitudo.Services.Services;
using Necessitudo.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Necessitudo.Services.Helpers
{
    public class DIFactory
    {
		public static IContainer Container { get; set; }
		public static bool ReIssueTokenOnError = true;


		public static void Initialize()
		{
			var builder = new ContainerBuilder();

			#region DIEngines
			builder.RegisterInstance(new SecurityEngine()).As<ISecurityEngine>();
			#endregion

			#region DIServices
			builder.RegisterType<SecurityService>();
			#endregion

			#region DIViewModels
			builder.RegisterType<SecurityViewModel>();
			#endregion

			Container = builder.Build();
		}


		public static T Resolve<T>()
		{
			if (DIFactory.Container == null)
			{
				Initialize();
			}
			return DIFactory.Container.Resolve<T>();
		}
	}
}
