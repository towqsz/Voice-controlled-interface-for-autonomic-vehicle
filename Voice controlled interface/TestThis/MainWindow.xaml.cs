using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.ComponentModel;
using System.Windows.Threading;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using Microsoft.Maps.MapControl.WPF;
using System.Net;
using System.IO;
using System.Diagnostics;





namespace TestThis
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        
        DispatcherTimer timer, timerBlinker;
        Game game;
        SpeechRecognizer speechRecognizer;
        SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
        List<KeyValuePair<string, int>> valueList = new List<KeyValuePair<string, int>>();
        private ViewModels.MainWindowModel viewModel;
        private System.Diagnostics.Stopwatch stopwatch = new Stopwatch();
        private long lastUpdateMilliSeconds;
        private double score = 0;
        private OxyPlotModel plotModel;
        public double Score { get { return score; } set { score = value; this.OnPropertyChanged("Score"); } }
        private double controlsOpacityDisabled = 0.4;
        private double controlsOpacityEnabled = 1;
        private double _max;
        public double przebieg = 240121.2;
        public double Max
        {
            get { return _max; }
            set { _max = value; this.OnPropertyChanged("Max"); }
            
        }

        private double _vBlinker;
        public double vBlinker
        {
            get { return _vBlinker; }
            set { _vBlinker = value; this.OnPropertyChanged("vBlinker"); }

        }

        private double _fuelLevel;
        public double fuelLevel
        {
            get { return _fuelLevel; }
            set { _fuelLevel = value; this.OnPropertyChanged("fuelLevel"); }

        }

        private double _fuelLevelLower;
        public double fuelLevelLower
        {
            get { return _fuelLevelLower; }
            set { _fuelLevelLower = value; this.OnPropertyChanged("fuelLevelLower"); }

        }

        private double _tempLevel;
        public double tempLevel
        {
            get { return _tempLevel; }
            set { _tempLevel = value; this.OnPropertyChanged("tempLevel"); }

        }

        private double _tempLevelUpper;
        public double tempLevelUpper
        {
            get { return _tempLevelUpper; }
            set { _tempLevelUpper = value; this.OnPropertyChanged("tempLevelUpper"); }

        }



        public MainWindow()
        {
            vBlinker = controlsOpacityDisabled;
            tempLevelUpper = 100;
            tempLevel = 10;
            InitializeComponent();
            myGauge1.DataContext = this;
            _18_png.DataContext = this;
            myGauge3_fuel.DataContext = this;
            myGauge4_temp.DataContext = this;
            myMap.Focus();
            plotModel = new OxyPlotModel();
            speechRecognizer = new SpeechRecognizer();
            this.DataContext = plotModel;

            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
            

            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                 
                this.timeText.Text = DateToString() + DateTime.Now.ToString(" dd ") + DateTime.Now.ToString("yyyy \n HH:mm");
            }, this.Dispatcher);

            viewModel = new ViewModels.MainWindowModel();
            DataContext = viewModel;

            CompositionTarget.Rendering += CompositionTargetRendering;
            stopwatch.Start();

            InitializeComponent();

        }


        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            game = new Game(0);
            this.myGauge2.DataContext = game;
            //Start the timer
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(4500);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            
            timerBlinker = new DispatcherTimer();
            timerBlinker.Interval = TimeSpan.FromMilliseconds(1000);
            timerBlinker.Tick += new EventHandler(timerBlinker_Tick);
            timerBlinker.Start();

            tempText.Text = scrollBar.Value.ToString() + " °C";
            przebiegText.Text = przebieg.ToString() + " km";
        }




        private void CompositionTargetRendering(object sender, EventArgs e)
        {
            if (stopwatch.ElapsedMilliseconds > lastUpdateMilliSeconds + 5000)
            {
                viewModel.UpdateModel();
                Plot1.RefreshPlot(true);
                lastUpdateMilliSeconds = stopwatch.ElapsedMilliseconds;
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            //Update random scores
            Random r = new Random();
            game.Score = r.Next(0, 4);


        }

        void timerBlinker_Tick(object sender, EventArgs e)
        {
            if (ChckBx4.IsChecked == true)
            {
                if (vBlinker == controlsOpacityEnabled)
                {
                    vBlinker = controlsOpacityDisabled;
                    PropertyChanged(this, new PropertyChangedEventArgs("vBlinker"));
                }
                else
                {
                    vBlinker = controlsOpacityEnabled;
                    PropertyChanged(this, new PropertyChangedEventArgs("vBlinker"));
                }


            }

            viewModel.sendValue(sliderFuelUsage.Value);
            
            
            
            

        }

        


        public string DateToString()
        {
            if (DateTime.Now.ToString("MM") == "01")
                return "January";
            if (DateTime.Now.ToString("MM") == "02")
                return "February";
            if (DateTime.Now.ToString("MM") == "03")
                return "March";
            if (DateTime.Now.ToString("MM") == "04")
                return "April";
            if (DateTime.Now.ToString("MM") == "05")
                return "May";
            if (DateTime.Now.ToString("MM") == "06")
                return "August";
            if (DateTime.Now.ToString("MM") == "07")
                return "June";
            if (DateTime.Now.ToString("MM") == "08")
                return "July";
            if (DateTime.Now.ToString("MM") == "09")
                return "September";
            if (DateTime.Now.ToString("MM") == "10")
                return "October";
            if (DateTime.Now.ToString("MM") == "11")
                return "November";
            else
                return "December";




        }


        

        

        private void ChckBx1_Checked(object sender, RoutedEventArgs e)
        {
            if (ChckBx1.IsChecked == true)
            {
                _2_png.Opacity = controlsOpacityEnabled;
            }
            else
            {
                _2_png.Opacity = controlsOpacityDisabled;
            }
        }

        private void ChckBx2_Checked(object sender, RoutedEventArgs e)
        {
            if (ChckBx2.IsChecked == true)
            {
                _3_png.Opacity = controlsOpacityEnabled;
            }
            else
            {
                _3_png.Opacity = controlsOpacityDisabled;
            }
        }

        private void ChckBx3_Checked(object sender, RoutedEventArgs e)
        {
            if (ChckBx3.IsChecked == true)
            {
                _4_png.Opacity = controlsOpacityEnabled;
            }
            else
            {
                _4_png.Opacity = controlsOpacityDisabled;
            }
        }

        private void ChckBx4_Checked(object sender, RoutedEventArgs e)
        {
            if (ChckBx4.IsChecked == true)
                vBlinker = controlsOpacityEnabled;
            else
                vBlinker = controlsOpacityDisabled;
        }

        private void ChckBx5_Checked(object sender, RoutedEventArgs e)
        {
            if (ChckBx5.IsChecked == true)
            {
                _6_png.Opacity = controlsOpacityEnabled;
            }
            else
            {
                _6_png.Opacity = controlsOpacityDisabled;
            }
        }

        private void ChckBx6_Checked(object sender, RoutedEventArgs e)
        {
            if (ChckBx6.IsChecked == true)
            {
                _7_png.Opacity = controlsOpacityEnabled;
            }
            else
            {
                _7_png.Opacity = controlsOpacityDisabled;
            }
        }

        private void ChckBx7_Checked(object sender, RoutedEventArgs e)
        {
            if (ChckBx7.IsChecked == true)
            {
                _8_png.Opacity = controlsOpacityEnabled;
            }
            else
            {
                _8_png.Opacity = controlsOpacityDisabled;
            }
        }

        private void ChckBx8_Checked(object sender, RoutedEventArgs e)
        {
            if (ChckBx8.IsChecked == true)
            {
                _9_png.Opacity = controlsOpacityEnabled;
            }
            else
            {
                _9_png.Opacity = controlsOpacityDisabled;
            }
        }

        private void ChckBx9_Checked(object sender, RoutedEventArgs e)
        {
            if (ChckBx9.IsChecked == true)
            {
                _10_png.Opacity = controlsOpacityEnabled;
            }
            else
            {
                _10_png.Opacity = controlsOpacityDisabled;
            }
        }

        private void ChckBx10_Checked(object sender, RoutedEventArgs e)
        {
            if (ChckBx10.IsChecked == true)
            {
                _11_png.Opacity = controlsOpacityEnabled;
            }
            else
            {
                _11_png.Opacity = controlsOpacityDisabled;
            }
        }

        private void ChckBx11_Checked(object sender, RoutedEventArgs e)
        {
            if (ChckBx11.IsChecked == true)
            {
                _12_png.Opacity = controlsOpacityEnabled;
            }
            else
            {
                _12_png.Opacity = controlsOpacityDisabled;
            }
        }

        private void ChckBx12_Checked(object sender, RoutedEventArgs e)
        {
            if (ChckBx12.IsChecked == true)
            {
                _13_png.Opacity = controlsOpacityEnabled;
            }
            else
            {
                _13_png.Opacity = controlsOpacityDisabled;
            }
        }

        private void ChckBx13_Checked(object sender, RoutedEventArgs e)
        {
            if (ChckBx13.IsChecked == true)
            {
                _14_png.Opacity = controlsOpacityEnabled;
            }
            else
            {
                _14_png.Opacity = controlsOpacityDisabled;
            }
        }

        private void ChckBx14_Checked(object sender, RoutedEventArgs e)
        {
            if (ChckBx14.IsChecked == true)
            {
                _15_png.Opacity = controlsOpacityEnabled;
            }
            else
            {
                _15_png.Opacity = controlsOpacityDisabled;
            }
        }

        private void ChckBx15_Checked(object sender, RoutedEventArgs e)
        {
            if (ChckBx15.IsChecked == true)
            {
                _16_png.Opacity = controlsOpacityEnabled;
            }
            else
            {
                _16_png.Opacity = controlsOpacityDisabled;
            }
        }

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        private void scrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tempText.Text = scrollBar.Value.ToString() + " °C";
        }

        private void przebiegbutton_Click(object sender, RoutedEventArgs e)
        {
            przebieg += 0.1;
            przebiegText.Text = przebieg.ToString() + " km";
        }

       

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

        private void sliderFuel_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            

            fuelLevel = sliderFuel.Value;
            fuelLevelLower = fuelLevel - 5;
            if (fuelLevelLower < 0)
            {
                fuelLevelLower = 0;
                _1_png.Opacity = controlsOpacityEnabled;
            }
            else
            {
                _1_png.Opacity = controlsOpacityDisabled;
            }
            PropertyChanged(this, new PropertyChangedEventArgs("fuelLevel"));

        }

        private void sliderTemp_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           

            tempLevel = sliderTemp.Value;
            tempLevelUpper = 100;
            if (tempLevel > tempLevelUpper)
            {
                tempLevelUpper=tempLevel;
                _6_png.Opacity = controlsOpacityEnabled;
            }
            else
            {
                _6_png.Opacity = controlsOpacityDisabled;
                tempLevelUpper = 100;
            }
            PropertyChanged(this, new PropertyChangedEventArgs("TempLevel"));

        }

        #endregion


        private void Button_Location_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GetMyLocation();
            }
            catch (SystemException err)
            {
                string errMsg = "Unable to get your location: " + err.Message.ToString();
                MessageBox.Show(errMsg);
            }
        }

        private string GetPublicIpAddress()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://ifconfig.me");

            request.UserAgent = "curl"; 

            string publicIPAddress;

            request.Method = "GET";
            using (WebResponse response = request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    publicIPAddress = reader.ReadToEnd();
                }
            }

            return publicIPAddress.Replace("\n", "");
        }

        private void GetMyLocation()
        {
            string _urlResponse = "";
            string _ipinfodb_apikey = "_ipinfodb_apikey";
            string _mypublicipaddress = GetPublicIpAddress();
            string _urlRequest = "http://api.ipinfodb.com/v3/ip-city/?key=" + _ipinfodb_apikey + "&" + _mypublicipaddress;

            var request = (HttpWebRequest)WebRequest.Create(_urlRequest);

            request.UserAgent = "curl"; 

            request.Method = "GET";
            using (WebResponse response = request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    _urlResponse = reader.ReadToEnd();
                }
            }

            string[] _myGeocodeInfo = _urlResponse.Split(';');

            Location myLoc = new Location(Convert.ToDouble(_myGeocodeInfo[8]), Convert.ToDouble(_myGeocodeInfo[9]));
            myMap.SetView(myLoc, Convert.ToDouble(14), Convert.ToDouble(0));

            Pushpin myPin = new Pushpin();
            MapLayer.SetPosition(myPin, myLoc);
            myMap.Children.Add(myPin);

            System.Windows.Controls.Label label = new System.Windows.Controls.Label();
            label.Content = "Here I AM!";
            label.Foreground = new SolidColorBrush(Colors.DarkBlue);
            label.Background = new SolidColorBrush(Colors.WhiteSmoke);
            label.FontSize = 30;
            MapLayer.SetPosition(label, myLoc);
            myMap.Children.Add(label);
        }

        private void Button_Zoom_Minus(object sender, RoutedEventArgs e)
        {
            myMap.ZoomLevel -= 1;
        }

        private void sliderFuelUsage_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
            fuelUsageTextBox.Text = Convert.ToInt16(sliderFuelUsage.Value).ToString() + " " +" [l/100km]";
            
        }

        private void btnLocation_Click(object sender, RoutedEventArgs e)
        {
           
            try 
            {
                GetMyLocation();
                speechSynthesizer.Speak("Location loaded.");
            }
            catch
            {
                speechSynthesizer.Speak("Unable to load location.");
            };


            txtSpeech.Text = "Get Location!" + "\n" + txtSpeech.Text;

        }

        private void btnAutoPilot_Click(object sender, RoutedEventArgs e)
        {
            speechSynthesizer.Speak("Auto pilot activated");
            _10_png.Opacity = controlsOpacityEnabled;
            txtSpeech.Text = "Auto Pilot Activated!" + "\n" + txtSpeech.Text;

        }

        private void btnAutoPilotDct_Click(object sender, RoutedEventArgs e)
        {
            speechSynthesizer.Speak("Auto pilot deactivated");
            _10_png.Opacity = controlsOpacityDisabled;
            txtSpeech.Text = "Auto Pilot Deactivated!" + "\n" + txtSpeech.Text;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            

            
            if(Plot1.Visibility == Visibility.Hidden)
            {
               Plot1.Visibility = Visibility.Visible;
            }
            else
            {
                Plot1.Visibility = Visibility.Hidden;
                
            }
            

        }

        private void Button_Zoom_Plus(object sender, RoutedEventArgs e)
        {
            myMap.ZoomLevel += 1;
        }
    
}





    public class Game : INotifyPropertyChanged
    {
        private double score;

        public double Score
        {
            get { return score; }
            set
            {
                score = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Score"));
                }
            }
        }


        public Game(double scr)
        {
            this.Score = scr;
        }




        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion


    }


    public class OxyPlotModel : INotifyPropertyChanged
    {

        private OxyPlot.PlotModel plotModel;
        public OxyPlot.PlotModel PlotModel
        {
            get
            {
                return plotModel;
            }
            set
            {
                plotModel = value; OnPropertyChanged("PlotModel");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    


}
