using System;
using System.Collections.Generic;
using TotalWarStats.Business.Interfaces;
using TotalWarStats.Business.Services;
using TotalWarStats.Model.Entities;
using TotalWarStats.Model.Utils;
using TotalWarStats.Views;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TotalWarStats
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public sealed partial class MainPage : Page
    {
        private string _currentFrame;

        public MainPage()
        {
            this.InitializeComponent();
            InitializeView();
        }

        private void InitializeView()
        {
            NavigationView.ItemInvoked += NavigationView_ItemInvoked;
            contentFrame.Navigate(typeof(MatchView));
            _currentFrame = NavigationViewItemConstants.Match;
        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.InvokedItem.Equals(_currentFrame)) return;
            if (args.IsSettingsInvoked) contentFrame.Navigate(typeof(SettingsView));
            if (args.InvokedItem.Equals(NavigationViewItemConstants.Match)) contentFrame.Navigate(typeof(MatchView));
            if (args.InvokedItem.Equals(NavigationViewItemConstants.Matchups)) contentFrame.Navigate(typeof(MatchupsView));
            if (args.InvokedItem.Equals(NavigationViewItemConstants.MatchHistory)) contentFrame.Navigate(typeof(MatchHistoryView));

            _currentFrame = args.InvokedItem.ToString();
        }
    }
}
