using System.Threading.Tasks;
using Mmu.Cg.WpfUI.Areas.AutoMapper.CreateProfile.Commands;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;
using Mmu.Mlh.WpfExtensions.Areas.ViewExtensions.Components.CommandBars.ViewData;

namespace Mmu.Cg.WpfUI.Areas.AutoMapper.CreateProfile
{
    public class CreateProfileViewModel : ViewModelBase, IMainNavigationViewModel, IViewModelWithHeading, IInitializableViewModel
    {
        private readonly CreateProfileCommandsContainer _commandsContainer;
        private string _currentText;
        public CommandsViewData Commands => _commandsContainer.Commands;

        public string CurrentText
        {
            get => _currentText;
            set
            {
                _currentText = value;
                OnPropertyChanged();
            }
        }

        public string HeadingText { get; } = "Create AutoMapper Profile";
        public string NavigationDescription { get; } = "Create Profile";
        public int NavigationSequence { get; } = 1;

        public CreateProfileViewModel(CreateProfileCommandsContainer commandsContainer)
        {
            _commandsContainer = commandsContainer;
        }

        public Task InitializeAsync()
        {
            return _commandsContainer.InitializeAsync(this);
        }
    }
}