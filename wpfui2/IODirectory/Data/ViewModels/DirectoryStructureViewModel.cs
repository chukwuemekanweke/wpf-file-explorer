using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfui2.IODirectory.Data.ViewModels
{
    public class DirectoryStructureViewModel:BaseViewModel
    {
        //A list of all directories on the machine
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }
        public DirectoryStructureViewModel()
        {
            List<DirectoryItem> children =  DirectoryStructure.GetLogicalDrives();
            Items = new ObservableCollection<DirectoryItemViewModel>(children.Select(x => new DirectoryItemViewModel(x.FullPath, DirectoryItemType.Drive)));
        }
    }
}
