using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TotalWarStats.Business.Interfaces;
using TotalWarStats.Business.Services;
using TotalWarStats.Model.Entities;
using TotalWarStats.Model.Utils;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TotalWarStats.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MatchView : Page
    {

        public IList<string> MainFactionList { get; set; }

        public ObservableCollection<Matchup> Matchups { get; set; }
        public string MatchupsAsString { get; set; }

        public double WinRate { get; set; }

        public IList<Match> Matches { get; set; }

        public string PlayerFaction { get; set; }
        public string OpponentFaction { get; set; }

        private IMatchService _matchService;

        public MatchView()
        {
            this.InitializeComponent();
            InitializeView();
        }

        private void InitializeView()
        {
            _matchService = new MatchService();
            MainFactionList = GameFactionsConstants.Warhammer2;
            Matchups = new ObservableCollection<Matchup>();
            AddEventHandlers();
            UpdateWinrate();
            UpdateMatchups();
            ShowContentDialog("Matchups", Matchups.Count + "", "Ok");
        }

        private void AddEventHandlers()
        {
            WinButton.Click += WinButton_Click;
            LostButton.Click += LostButton_Click;
            MatchupListView.ItemClick += MatchupListView_ItemClick;
        }

        private void MatchupListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Matchup selectedMatchup = e.ClickedItem as Matchup;
            ShowContentDialog(selectedMatchup.GetMatchup(), selectedMatchup.ToString(), "Ok");
        }

        private void LostButton_Click(object sender, RoutedEventArgs e)
        {
            HandleNewMatchUpdate(false);
        }

        private void WinButton_Click(object sender, RoutedEventArgs e)
        {
            HandleNewMatchUpdate(true);
        }

        private void HandleNewMatchUpdate(bool playerHasWon)
        {
            if (FactionPlayerComboBox.SelectedIndex == -1 || FactionOpponentComboBox.SelectedIndex == -1)
            {
                ShowContentDialog("No faction selected", "Please go back and make sure both factions are selected", "Ok");
                return;
            }

            GetFactions();
            AddMatch(playerHasWon);
            UpdateWinrate(); 
            UpdateMatchups();

        }

        private void UpdateMatchups()
        {
            Matchups.Clear();

            foreach(string playerFaction in MainFactionList)
            {

                foreach(string opponentFaction in MainFactionList)
                {
                    CalculateMatchup(playerFaction, opponentFaction);
                }
            }
        }

        private async void CalculateMatchup(string playerFaction, string opponentFaction)
        {

            IList<Match> matches = await _matchService.GetAllMatchesAsync();
            IList<Match> wins = null;

            matches = matches.Where(m => m.PlayerFaction.ToUpper().Equals(playerFaction.ToUpper()) && m.OpponentFaction.ToUpper().Equals(opponentFaction.ToUpper())).ToList();
            wins = matches.Where(m => m.HasWon).ToList();
            
            AddMatchup(playerFaction, opponentFaction, wins.Count, matches.Count);
        }

        private void AddMatchup(string playerFaction, string opponentFaction, int wins, int totalGamesPlayed)
        {
            Matchup matchup = new Matchup()
            {
                PlayerFaction = playerFaction,
                OpponentFaction = opponentFaction,
                MatchesWon = wins,
                MatchesLost = totalGamesPlayed - wins,
                Winrate = Math.Round((double)wins / totalGamesPlayed, 2)
            };

            Matchups.Add(matchup);
        }

        private async void UpdateWinrate()
        {
            IList<Match> matches = await _matchService.GetAllMatchesAsync();
            double matchesWon = matches.Where(m => m.HasWon == true).Count();
            double totalMatchesPlayed = matches.Count;

            WinrateTextBlock.Text = Math.Round(matchesWon / totalMatchesPlayed, 2) + "%";
        }

        private void GetFactions()
        {
            PlayerFaction = FactionPlayerComboBox.SelectedItem.ToString();
            OpponentFaction = FactionOpponentComboBox.SelectedItem.ToString();
        }

        private async void AddMatch(bool isWinner)
        {
            Match match = new Match
            {
                MatchId = Guid.NewGuid().ToString(),
                PlayerFaction = PlayerFaction,
                OpponentFaction = OpponentFaction,
                HasWon = isWinner,
                Date = DateTime.Now
            };

            await _matchService.AddMatchAsync(match);
        }

        private async void ShowContentDialog(string title, string content, string closeButtonText)
        {
            ContentDialog noFactionSelectedDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = closeButtonText
            };

            ContentDialogResult result = await noFactionSelectedDialog.ShowAsync();
            return;
        }
    }
}
