﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Text;
using Windows.UI.Xaml.Controls;

namespace Chapter_8
{
    class JournalEntry
    {
        private RichEditBox _richEditBox;

        public JournalEntry(RichEditBox richEditBox)
        {
            _richEditBox = richEditBox;
        }

        public async void Save()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync("FirstRichEdit.rtf", Windows.Storage.CreationCollisionOption.ReplaceExisting);

            IRandomAccessStream documentStream = await sampleFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
            _richEditBox.Document.SaveToStream(Windows.UI.Text.TextGetOptions.FormatRtf, documentStream);
            documentStream.Dispose();
        }
    }
}
