using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Assignment4_LiveData_JoClark
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Quest> Quest = [];
        string path = Path.Combine(FileSystem.AppDataDirectory, "quests.json");
        public MainPage()
        {
            InitializeComponent();
            QuestData.ItemsSource = Quest;
            if (!File.Exists(path))
            { 
                Quest NewQuest = new Quest
                { 
                    Title = "Test Quest",
                    Giver = "Giver Name",
                    Reward = 1000
                };
                Quest.Add(NewQuest);
                return;
            }
            else
            {
                var LoadQuest = JsonSerializer.Deserialize<List<Quest>>(File.ReadAllText(path));
                foreach (Quest quest in LoadQuest)
                {
                    Quest.Add(quest);
                }
            }
        }

        private void OnAddQuestClicked(object sender, EventArgs e)
        {
            int UserReward;
            bool Correct = int.TryParse(RewardEntry.Text, out UserReward);
            if (!Correct || UserReward <= 0)
            {
                RewardEntry.Placeholder = "Please enter a valid number greater than 0";
                RewardEntry.Text = string.Empty;
                return;
            }
            Quest NewQuest = new Quest
            {
                Title = TitleEntry.Text,
                Giver = GiverEntry.Text,
                Reward = UserReward 
            };

            Quest.Add(NewQuest);
            File.WriteAllText(path, JsonSerializer.Serialize(Quest));
        }

        private void OnRemoveQuestClicked(object sender, EventArgs e)
        {
            Quest.Remove((Quest)QuestData.SelectedItem);
            File.WriteAllText(path, JsonSerializer.Serialize(Quest));
        }
    }
}
