using Buecher;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Input;

namespace BuchWPF
{
    class MainWindowViewModel : AbstractViewModelBase
    {
        private readonly BuecherModell _modell;
        private string _mainWindowTitle = "Buch-Verwaltung";
    
        public MainWindowViewModel(BuecherModell modell)
        {
            _modell = modell;
            InitialisiereDasViewModell();

            //Verschiebenkommando für Tabelle aktuelle Bücher
            VerschiebenKommando = new RelayCommand(
                parameter => FuegeBuchWiederEin(parameter),
                parameter => LoescheBuch(parameter),
                parameter => KannBuchLoeschen(parameter)
            );

            //Verschiebenkommando für Tabelle archivierte Bücher
            VerschiebenKommando2 = new RelayCommand(
                parameter => FuegeBuchWiederEin2(parameter),
                parameter => LoescheBuch2(parameter),
                parameter => KannBuchLoeschen(parameter)
            );

        }

        public ICommand VerschiebenKommando { get; private set; }
        public ICommand VerschiebenKommando2 { get; private set; }

        private void LoescheBuch(object? buch) 
        {
            if (buch == null) return;
            _modell.LoescheBuch((Buch)buch);
            Buecher.Remove((Buch)buch);
        }

        private void LoescheBuch2(object? buch)
        {
            if (buch == null) return;
            _modell.LoescheBuch2((Buch)buch);
            Buecher2.Remove((Buch)buch);
        }

        private bool KannBuchLoeschen(object? buch)
        {
            return buch != null;
        }

        //FuegeBuchWiederEin fügt das in der linken Tabelle gelöschte in die rechte Tabelle ein und FuegeBuchWiederEin2 andersherum
        private void FuegeBuchWiederEin(object? buch)
        {
            _modell.FuegeBuchWiederEin((Buch)buch);
            Buecher2.Add((Buch)buch);
        }

        private void FuegeBuchWiederEin2(object? buch)
        {
            _modell.FuegeBuchWiederEin((Buch)buch);
            Buecher.Add((Buch)buch);
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

        //Laden beider Buchliste in die Tabellen
        public async void InitialisiereDasViewModell()
        {
            var buecher = await _modell.LadeAlleBuecher();
            var buecher2 = await _modell.LadeAlleBuecher2();
            foreach (var buch in buecher)
            {
                Buecher.Add(buch);
            }
            foreach (var buch in buecher2)
            {
                Buecher2.Add(buch);
            }
        }

        public ObservableCollection<Buch> Buecher { get; } = new();
        public ObservableCollection<Buch> Buecher2 { get; } = new();
    }
}
