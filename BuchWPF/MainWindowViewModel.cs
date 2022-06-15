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

            
            VerschiebenKommando = new RelayCommand(
                parameter => LoescheBuch(parameter),
                parameter => FuegeBuchwiederein(parameter),
                parameter => KannBuchLoeschen(parameter)
            );
            
        }

        public ICommand VerschiebenKommando { get; private set; }

        private void LoescheBuch(object? buch) 
        {
            if (buch == null) return;
            _modell.LoescheBuch((Buch)buch);
            Buecher.Remove((Buch)buch);
        }
        
        private bool KannBuchLoeschen(object? buch)
        {
            return buch != null;
        }

        private void FuegeBuchwiederein(object? buch)
        {
            _modell.FuegeBuchwiederein((Buch)buch);
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
