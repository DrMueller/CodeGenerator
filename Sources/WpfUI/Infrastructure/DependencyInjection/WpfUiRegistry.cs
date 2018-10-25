using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;
using StructureMap;

namespace Mmu.Cg.WpfUI.Infrastructure.DependencyInjection
{
    public class WpfUiRegistry : Registry
    {
        public WpfUiRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType(typeof(WpfUiRegistry));
                    scanner.AddAllTypesOf<IViewModel>();
                    scanner.AddAllTypesOf(typeof(IViewModelCommandContainer<>));
                    scanner.WithDefaultConventions();
                });

            For<IViewModel>().Transient();
        }
    }
}