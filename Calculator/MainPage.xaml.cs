using System;
using Microsoft.Maui.Controls;

namespace Calc
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
             
        }

        private void OnPercentClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            EntryResult.Text += button.Text;



        }
        private void Operatorbuttons(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            EntryResult.Text += button.Text;
        }
}
