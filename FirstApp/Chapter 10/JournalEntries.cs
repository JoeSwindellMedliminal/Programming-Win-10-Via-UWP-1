﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_10
{
    public class JournalEntries : List<JournalEntry>
    {
        public JournalEntry currentJournalEntry { get; private set; }
        public void GetSelectedEntry(string EntryHeader)
        {
            foreach (JournalEntry je in this)
            {
                if (je.EntryHeader == EntryHeader)
                {
                    currentJournalEntry = je;
                    return;
                }
            }
            currentJournalEntry= null;

        }
    }
}
