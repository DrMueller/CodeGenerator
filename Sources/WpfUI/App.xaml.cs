using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Models;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.Mlh.WpfExtensions.Areas.Initialization;

namespace Mmu.Cg.WpfUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            var appIcon = WpfUI.Properties.Resources.M;
            var assemblyParameters = AssemblyParameters.CreateFromAssembly(typeof(App).Assembly);

            var appConfig = ApplicationConfiguration.CreateFromIcon("Code Generator", appIcon);
            await BootstrapService.StartUpAsync(assemblyParameters, appConfig, Maybe.CreateNone<Action>());
        }
    }
}
