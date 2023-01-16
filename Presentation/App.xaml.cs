using Domain;
using Domain.Repository;
using Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Windows;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Assembly applicationAssembly = typeof(Application.Dummy).Assembly;
            var provider = AppServiceProvider.Instance;
            provider.ServiceCollection
                .AddDbContext<AppDbContext>()
                //.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
                .AddMediatR(applicationAssembly)
                .AddSingleton<IUnitOfWork, UnitOfWork>();

            provider.GetService<AppDbContext>().Migrate();
        }
    }
}
