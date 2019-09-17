using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using wpfui2.IODirectory.Data;

namespace wpfui2.IODirectory
{
    public static class DirectoryStructure
    {

        public static List<DirectoryItem> GetLogicalDrives()
        {
            //Get all logical drives
            return  Directory.GetLogicalDrives().Select(x=> new DirectoryItem {
                FullPath = x, Type = DirectoryItemType.Drive
            }).ToList();           
        }

        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            List<DirectoryItem> items = new List<DirectoryItem>();


            #region Get Folders
            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                    items.AddRange(dirs.Select(x=> new DirectoryItem {
                        FullPath = x,
                        Type = DirectoryItemType.Folder
                    }));
            }
            catch (Exception ex)
            {

            }

         
            #endregion Get Folders

            #region Get Files
            List<string> files = new List<string>();

            try
            {
                var fls = Directory.GetFiles(fullPath);
                if (fls.Length > 0)
                    items.AddRange(fls.Select(x => new DirectoryItem
                    {
                        FullPath = x,
                        Type = DirectoryItemType.File
                    }));
            
            }
            catch (Exception ex)
            {

            }
            #endregion

            return items;
        }


        #region Helpers
        public static string GetFileFolderName(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return string.Empty;

            var normalizedPath = path.Replace('/', '\\');
            string[] fileOrFolderName = normalizedPath.Split('\\');
            return fileOrFolderName.LastOrDefault();
        }
        #endregion

    }
}
