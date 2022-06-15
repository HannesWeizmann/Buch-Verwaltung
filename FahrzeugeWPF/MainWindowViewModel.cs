using Fahrzeuge;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Input;

namespace FahrzeugeWPF
{
    class MainWindowViewModel : AbstractViewModelBase
    {
        private readonly FahrzeugeModell _modell;
        private string _mainWindowTitle = "Fahrzeuge";
        private Timer _timer = new Timer()
        {
            Interval = 1000
        };

        public MainWindowViewModel(FahrzeugeModell modell)
        {
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
            _modell = modell;
            InitialisiereDasViewModell();

            LoeschenKommando = new RelayCommand(
                parameter => LoescheFahrzeug(parameter),
                parameter => KannFahrzeugLoeschen(parameter)
            );

            LeerenKommando = new RelayCommand(
                x => LeereListe(),
                x => true
            );
        }

        public ICommand LoeschenKommando { get; private set; }
        public ICommand LeerenKommando { get; private set; }

        private void LoescheFahrzeug(object? fahrzeug) 
        {
            if (fahrzeug == null) return;
            _modell.LoescheFahrzeug((Fahrzeug)fahrzeug);
            Fahrzeuge.Remove((Fahrzeug)fahrzeug);
        }
        private bool KannFahrzeugLoeschen(object? fahrzeug)
        {
            return fahrzeug != null;
        }

        private async void LeereListe()
        {
            await Task.Run(() =>
            {
                Application.Current.Dispatcher.Invoke(() => Fahrzeuge.Clear());
            });
        }

        public string MainWindowTitle
        {
            get => _mainWindowTitle;
            set
            {
                _mainWindowTitle = value;
                NotifyPropertyChanged();
            }
        }

        private void _timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            MainWindowTitle = $"Fahrzeuge {DateTime.Now.ToLongTimeString()}";
        }

        public async void InitialisiereDasViewModell()
        {
            var fahrzeuge = await _modell.LadeAlleFahrzeuge();
            foreach(var fahrzeug in fahrzeuge)
            {
                Fahrzeuge.Add(fahrzeug);
            }
        }

        public ObservableCollection<Fahrzeug> Fahrzeuge { get; } = new();
    }
}
