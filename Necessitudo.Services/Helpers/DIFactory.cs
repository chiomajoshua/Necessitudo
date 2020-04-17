using Autofac;
using Necessitudo.Contract;
using Necessitudo.Engine;
using Necessitudo.Services.Services;
using Necessitudo.Services.ViewModels;

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
			builder.RegisterInstance(new UserEngine()).As<IUserEngine>();
			#endregion

			#region DIServices
			builder.RegisterType<SecurityService>();
			builder.RegisterType<UserService>();
			#endregion

			#region DIViewModels
			builder.RegisterType<SecurityViewModel>();
			builder.RegisterType<UserViewModel>();
			#endregion

			Container = builder.Build();
		}


		public static T Resolve<T>()
		{
			if (Container == null)
			{
				Initialize();
			}
			return Container.Resolve<T>();
		}
	}
}