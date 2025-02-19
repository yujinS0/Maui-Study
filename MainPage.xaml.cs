﻿namespace MyMauiApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void OnNavigateToDigitsPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(DigitsPage));
        }

        private async void OnNavigateToOmokGamePage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(OmokGamePage));
        }
    }

}
