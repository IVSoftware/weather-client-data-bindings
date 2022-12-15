using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace weather_client
{
    public partial class MainForm : Form
    {
        public MainForm() => InitializeComponent();
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            checkBoxRun.CheckedChanged += onRunCheckedChanged;
            richTextBox.DataBindings.Add(new Binding(
                propertyName: nameof(RichTextBox.Text),
                dataSource: _weatherClient,
                dataMember: nameof(WeatherClient.Temperature),
                true,
                nullValue: 0,
                formatString: "F2",
                dataSourceUpdateMode: DataSourceUpdateMode.OnPropertyChanged
            ));
            richTextBox.DataBindings.Add(new Binding(
                propertyName: nameof(RichTextBox.ForeColor),
                dataSource: _weatherClient,
                dataMember: nameof(WeatherClient.Color),
                false,
                dataSourceUpdateMode: DataSourceUpdateMode.OnPropertyChanged
            ));
            progressBarTemperature.DataBindings.Add(new Binding(
                propertyName: nameof(ProgressBar.Value),
                dataSource: _weatherClient,
                dataMember: nameof(WeatherClient.Temperature),
                false,
                dataSourceUpdateMode: DataSourceUpdateMode.OnPropertyChanged
            ));
            progressBarTemperature.DataBindings.Add(new Binding(
                propertyName: nameof(ProgressBar.ForeColor),
                dataSource: _weatherClient,
                dataMember: nameof(WeatherClient.Color),
                false,
                dataSourceUpdateMode: DataSourceUpdateMode.OnPropertyChanged
            ));
        }
        private async void onRunCheckedChanged(object? sender, EventArgs e)
        {
            if (checkBoxRun.Checked)
            {
                while (true)
                {
                    if (!checkBoxRun.Checked) return;
                    await _weatherClient.UpdateWeatherAsync();
                    if (!checkBoxRun.Checked) return;
                    await Task.Delay(TimeSpan.FromSeconds(2));
                }
            }
        }
        private readonly WeatherClient _weatherClient = new WeatherClient();
    }
    class WeatherClient : INotifyPropertyChanged
    {
        double _temperature = 0;
        public double Temperature
        {
            get => _temperature;
            set
            {
                if (!Equals(_temperature, value))
                {
                    _temperature = value;
                    OnPropertyChanged();
                }
            }
        }
        Color _color = Color.Black;
        public Color Color
        {
            get => _color;
            set
            {
                if (!Equals(_color, value))
                {
                    _color = value;
                    OnPropertyChanged();
                }
            }
        }
        internal async Task UpdateWeatherAsync()
        {
            await Task.Delay(250); // Simulate API query
            Temperature = _rando.NextDouble() * 100;
        }
        Random _rando = new Random(2);
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            switch (propertyName)
            {
                case nameof(Temperature):
                    if (Temperature < 32)
                    {
                        Color = Color.Blue;
                    }
                    else if (Temperature > 75)
                    {
                        Color = Color.Red;
                    }
                    else Color = Color.Green;
                    break;
            }
        }
    }
    class VerticalProgressBar : ProgressBar
    {
        public VerticalProgressBar() => SetWindowTheme(Handle, string.Empty, string.Empty);
        protected override CreateParams CreateParams
        {
            get
            { 
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x04;
                return cp;
            }
        }
        [DllImport("uxtheme", ExactSpelling = true, CharSet = CharSet.Unicode)]
        public extern static Int32 SetWindowTheme(IntPtr hWnd,
                      String textSubAppName, String textSubIdList);
    }
}