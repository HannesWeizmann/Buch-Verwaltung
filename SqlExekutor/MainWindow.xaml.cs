using Microsoft.Win32;
using MySqlConnector;
using System;
using System.IO;
using System.Windows;

namespace SqlExekutor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Konstruktor mit Angabe des Connectionstrings
        public MainWindow()
        {
            InitializeComponent();
            ConnectionTextBox.Text = "Server=localhost;User ID=root;Password=root;";
        }

        //Button um SQL-Skript auszuwählen
        private void SelectScriptButton_Click(object sender, RoutedEventArgs e)
        {
            FileInfo? datei = SkriptDateiWaehlen();
            string dateiInhalt = DateiEinlesen(datei);
            ScriptTextBox.Text = dateiInhalt;
        }

        //Button um Skript auszuführen
        private void ExecuteScriptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FuehreSkriptAus(ScriptTextBox.Text, ConnectionTextBox.Text);
                MessageBox.Show("Skript erfolgreich ausgeführt.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Funktion, die im Dateisystem das SQL-Skript auswählen lässt
        private FileInfo? SkriptDateiWaehlen()
        {
            OpenFileDialog dateiDialog = new OpenFileDialog();
            dateiDialog.Filter = "SQL files (*.sql)|*.sql";
            if ((bool)dateiDialog.ShowDialog())
                return new FileInfo(dateiDialog.FileName);
            else
                return null;
        }

        //Funktion zum einlesen der Datei
        private string DateiEinlesen(FileInfo? datei)
        {
            if (datei == null)
                return string.Empty;
            else
                return File.ReadAllText(datei.FullName);
        }

        //Funktion mit der das Skript ausgeführt wird
        private void FuehreSkriptAus(string sqlScript, string connectionString)
        {
            using var datenbankVerbindung = new MySqlConnection(connectionString);
            datenbankVerbindung.Open();

            using var kommando = new MySqlCommand(sqlScript, datenbankVerbindung);
            kommando.ExecuteNonQuery();
        }
    }
}
