using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TotalWarStats.Business.Interfaces;
using TotalWarStats.Business.Services;
using TotalWarStats.Model.Entities;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TotalWarStats.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MatchHistoryView : Page
    {
        public ObservableCollection<Match> Matches;

        private IMatchService _matchService;

        public MatchHistoryView()
        {
            this.InitializeComponent();
            InitializeView();
        }

        private void InitializeView()
        {
            _matchService = new MatchService();
            Matches = new ObservableCollection<Match>();
            UpdateMatches();
        }

        private async void UpdateMatches()
        {
            Matches.Clear();
            IList<Match> matches = await _matchService.GetAllMatchesAsync();
            matches = matches.OrderByDescending(m => m.Date).ToList();
            
            foreach(Match match in matches)
            {
                Matches.Add(match);
            }
        }
    }
}
