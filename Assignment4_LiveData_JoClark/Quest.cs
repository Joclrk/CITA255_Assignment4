using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Assignment4_LiveData_JoClark
{
    internal class Quest
    {
        public string Title { get; set; }
        public string Giver { get; set; }
        public int Reward { get; set; }
        public ObservableCollection<Quest> Quests {get;} = new ObservableCollection<Quest>();
    }
}
