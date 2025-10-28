namespace calc
{
    public partial class MainPage : ContentPage
    {
        double kwota = 0;
        int oprocentowanie = 0;


        public MainPage()
        {
            InitializeComponent();
        }

      
        private void OnButtonClicked(object? sender, EventArgs e)
        {
            kwota = double.Parse(kwotaRachunku.Text);
            double wynik = kwota + (kwota * oprocentowanie / 100);
            napiwekLabel.Text = "Napiwek : " + (kwota * oprocentowanie / 100)+ " zł";
            wynikLabel.Text = "Do zapłaty : " + wynik + " zł";
        }

        private void OnSliderValueChanged(object? sender, EventArgs e)
        {
          Slider slider = (Slider)sender;
            oprocentowanie = (int)slider.Value;
            
        }
        private void OnResetClicked(object? sender, EventArgs e)
        {
            kwotaRachunku.Text = "";
            napiwekLabel.Text = "";
            wynikLabel.Text = "";
            procentNapiwku.Value = 15;
        }
    }
}
