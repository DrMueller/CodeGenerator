using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using Mmu.Cg.WpfUI.Areas.AutoMapper.CreateProfile.Services;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.Components.CommandBars.ViewData;

namespace Mmu.Cg.WpfUI.Areas.AutoMapper.CreateProfile.Commands
{
    public class CreateProfileCommandsContainer : IViewModelCommandContainer<CreateProfileViewModel>
    {
        private readonly IProfileFactory _profileFactory;
        private CreateProfileViewModel _context;

        public CommandsViewData Commands => new CommandsViewData(
            new List<ViewModelCommand>
            {
                CreateProfileCommand
            });

        private ViewModelCommand CreateProfileCommand => new ViewModelCommand(
            "Create!",
            new RelayCommand(
                () =>
                {
                    var profile = _profileFactory.CreateProfile(_context.CurrentText);
                    _context.CurrentText = profile;
                    Clipboard.SetText(profile);
                },
                () => !string.IsNullOrEmpty(_context.CurrentText)));

        public CreateProfileCommandsContainer(IProfileFactory profileFactory)
        {
            _profileFactory = profileFactory;
        }

        public Task InitializeAsync(CreateProfileViewModel context)
        {
            _context = context;
            return Task.CompletedTask;
        }
    }
}