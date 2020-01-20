using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Text;
using Windows.UI.Xaml.Controls;
using System.Diagnostics;


namespace Chapter_10
{
    public class JournalEntry
    {
        private RichEditBox _richEditBox;
        private string YMFullPath;
        private string YMFolder;
        public string EntryHeader { get; }
        

        public JournalEntry(RichEditBox richEditBox, string YMFullPath, 
            string YMFolder, 
            string EntryHeader)
        {
            _richEditBox = richEditBox;
            this.YMFullPath = YMFullPath;
            this.YMFolder = YMFolder;
            this.EntryHeader = EntryHeader;
        }

        public async void Save()
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;


            if (!Directory.Exists(Path.Combine(YMFullPath, YMFolder)))
            {
                await storageFolder.CreateFolderAsync(YMFolder);
            }

            StorageFolder subStorage = await storageFolder.GetFolderAsync(YMFolder);
            StorageFile sampleFile =
                await subStorage.CreateFileAsync(
                    "FirstRichEdit.rtf",
                    CreationCollisionOption.ReplaceExisting);

            IRandomAccessStream documentStream =
                await sampleFile.OpenAsync(FileAccessMode.ReadWrite);
            _richEditBox.Document.SaveToStream(TextGetOptions.FormatRtf, documentStream);
            documentStream.Dispose();
        }

      
    }
}
