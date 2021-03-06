﻿using System;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Chapter_8
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private JournalEntry journalEntry;
        private int counter;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            EntriesListView.Items.Add("super");
            EntriesListView.Items.Add("extra");
            EntriesListView.Items.Add("maximum");
            EntriesListView.Items.Add("advanced");
            EntriesListView.Items.Add("efficient");

            EntriesListView.Items.Add("super");
            EntriesListView.Items.Add("extra");
            EntriesListView.Items.Add("maximum");
            EntriesListView.Items.Add("advanced");
            EntriesListView.Items.Add("efficient");
        }

        private void CreateNewEntryButton_Click(object sender, RoutedEventArgs e)
        {
            PivotItem pi = new PivotItem();

            var entryText = String.Format("Entry{0}", rootPivot.Items.Count + 1);
            pi.Header = entryText;
            RichEditBox reb = new RichEditBox();
            reb.HorizontalAlignment = HorizontalAlignment.Stretch;
            reb.VerticalAlignment = VerticalAlignment.Stretch;

            pi.Content = reb;

            pi.Loaded += PivotItem_Loaded;
            rootPivot.Items.Add(pi);
            rootPivot.SelectedIndex = rootPivot.Items.Count - 1;
        }

        private async void SaveEntryButton_Click(object sender, RoutedEventArgs e)
        {
            journalEntry.Save();
        }

        private void rootPivot_GotFocus(object sender, RoutedEventArgs e)
        {
            Pivot p = sender as Pivot;
            PivotItem pi = p.SelectedItem as PivotItem;
            RichEditBox_SetFocus(pi);
        }

        private void PivotItem_Loaded(object sender, RoutedEventArgs e)
        {
            PivotItem pi = sender as PivotItem;
            RichEditBox_SetFocus(pi);
        }

        private void RichEditBox_SetFocus(PivotItem pi)
        {
            RichEditBox reb = pi.Content as RichEditBox;
            reb.Focus(FocusState.Keyboard);
            journalEntry = new JournalEntry(reb);
        }
    }
}
