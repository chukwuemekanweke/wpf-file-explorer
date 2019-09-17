using wpfui2.IODirectory.Data;

namespace wpfui2.IODirectory
{
    public class DirectoryItem
    {
        public DirectoryItemType Type { get; set; }
        public string FullPath { get; set; }
        public string Name => Type == DirectoryItemType.Drive ? FullPath :
                                                                DirectoryStructure.GetFileFolderName(FullPath);
    }
}
