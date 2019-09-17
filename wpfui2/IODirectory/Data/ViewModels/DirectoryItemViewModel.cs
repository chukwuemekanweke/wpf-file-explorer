using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace wpfui2.IODirectory.Data.ViewModels
{

    /// <summary>
    /// View Model For Each Directory Item
    /// </summary>
    public class DirectoryItemViewModel : BaseViewModel
    {


        #region Commands
        public ICommand ExpandCommand { get; set; }
        #endregion

        public DirectoryItemViewModel(string fullPath, DirectoryItemType directoryItemType)
        {
            ExpandCommand = new RelayCommand(Expand);
            FullPath = fullPath;
            Type = directoryItemType;

            Collapse();
        }


        #region Properties
        public DirectoryItemType Type { get; set; }
        public string FullPath { get; set; }
        public string Name => Type == DirectoryItemType.Drive ? FullPath :
                                                                DirectoryStructure.GetFileFolderName(FullPath);
        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }
        public bool CanExpand => Type != DirectoryItemType.File;
        public bool IsExpanded
        {

            get => Children?.Count(x => x != null) > 0;
            set
            {
                //if UI tells us to expand....
                if (value)
                {
                    Expand();
                }
                else
                {
                    Collapse();
                }
            }

        }
        #endregion 

        /// <summary>
        /// Removes all children from list
        /// </summary>
        private void Collapse()
        {
            Children = new ObservableCollection<DirectoryItemViewModel>();

            if (Type != DirectoryItemType.File)
            {
                Children.Add(null);
            }
        }

        private void Expand()
        {
            if (Type == DirectoryItemType.File)
            {
                return;
            }

            Children = new ObservableCollection<DirectoryItemViewModel>(DirectoryStructure.GetDirectoryContents(FullPath).Select(x => new DirectoryItemViewModel(x.FullPath, x.Type)));
        }
    }
}
