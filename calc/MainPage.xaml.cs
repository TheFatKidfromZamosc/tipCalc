namespace calc
{
 
    public partial class MainPage : ContentPage
    {
        double kwota = 0;
        int oprocentowanie = 15;
        int lastTipPercentage = 15;
        int selectedCurrencyIndex = 0;
        public MainPage()
        {
            InitializeComponent();
        }

        private void WyswietlWynik(object sender, EventArgs e)
        {
            OnButtonClicked(sender, e);
        }

        private void OnButtonClicked(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(kwotaRachunku.Text))
            {
                DisplayAlert("Błąd", "Proszę wpisać kwotę rachunku.", "OK");
                return;
            } 
            kwota = double.Parse(kwotaRachunku.Text);
            if (kwota < 0)
            {
                DisplayAlert("Błąd", "Kwota rachunku nie może być ujemna.", "OK");
                return;
            }

            double wynik = kwota + (kwota * oprocentowanie / 100);
            if (selectedCurrencyIndex == 0)
            {
                napiwekLabel.Text = "Napiwek : " + (kwota * oprocentowanie / 100) + " zł";
                wynikLabel.Text = "Do zapłaty : " + wynik.ToString("F2") + " zł";
            }
            else if (selectedCurrencyIndex == 1)
            {
                napiwekLabel.Text = "Napiwek : " + (kwota * oprocentowanie / 100) + " $";
                wynikLabel.Text = "Do zapłaty : " + wynik.ToString("F2") + " $";
            }
            else if (selectedCurrencyIndex == 2)
            {
                napiwekLabel.Text = "Napiwek : " + (kwota * oprocentowanie / 100) + " €";
                wynikLabel.Text = "Do zapłaty : " + wynik.ToString("F2") + " €";
            }
            else if (selectedCurrencyIndex == 3)
            {
                napiwekLabel.Text = "Napiwek : " + (kwota * oprocentowanie / 100) + " £";
                wynikLabel.Text = "Do zapłaty : " + wynik.ToString("F2") + " £";
            }
        }

        public string getKwotaRachunkuText(object sender, EventArgs e)
        {
            return kwotaRachunku.Text;
        }

        private void OnSliderValueChanged(object? sender, EventArgs e)
        {
          Slider slider = (Slider)sender;
            oprocentowanie = (int)slider.Value;
        /*    if (!string.IsNullOrEmpty(getKwotaRachunkuText(sender, e)))
            {
                WyswietlWynik(sender,e);
            } */

        }
        private void OnResetClicked(object? sender, EventArgs e)
        {
           lastTipPercentage = oprocentowanie;
            kwotaRachunku.Text = "";
            napiwekLabel.Text = "";
            wynikLabel.Text = "";
            procentNapiwku.Value = lastTipPercentage;
            rodzajWaluty.SelectedIndex = 0;
            DisplayAlert("Reset", "Wszystkie pola zostały zresetowane.", "OK");
        }

        private void OnPickerIndexChanged(object? sender, EventArgs e)
        {
            selectedCurrencyIndex = rodzajWaluty.SelectedIndex;
        }

    }
}
