using BuchDatenbank;
using Buecher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuchWPF
{
    class BuecherModell
    {
        private readonly IBuchRepository _repository;

        public BuecherModell(IBuchRepository repository)
        {
            _repository = repository;
        }

        //Funktionen für Tabelle aktuelle Bücher
        //Es werden alle Bücher geholt und dann eine Buchliste erstellt
        public async Task<IEnumerable<Buch>> LadeAlleBuecher()
        {
            List<BuchDTO>? buecher = await Task.Run(() => {
                return _repository.HoleAlleBuecher();
            });
            var buchListe = erstelleBuchliste(buecher);
            return buchListe;
        }
        
        private IEnumerable<Buch> erstelleBuchliste(IEnumerable<BuchDTO> buecher)
        {
            List<Buch> buchListe = new();
            foreach (var buchDTO in buecher)
            {
                var buch = new Buch()
                {   
                    Id = buchDTO.Id,
                    titel = buchDTO.titel,
                    autor = buchDTO.autor
                };
                buchListe.Add(buch);
            }
            return buchListe;
        }

        //Funktionen für Tabelle archivierte Bücher
        public async Task<IEnumerable<Buch>> LadeAlleBuecher2()
        {
            List<Buch2DTO>? buecher = await Task.Run(() => {
                return _repository.HoleAlleBuecher2();
            });
            var buchListe2 = erstelleBuchliste2(buecher);
            return buchListe2;
        }


        private IEnumerable<Buch> erstelleBuchliste2(IEnumerable<Buch2DTO> buecher)
        {
            List<Buch> buchListe2 = new();
            foreach (var buchDTO in buecher)
            {
                var buch = new Buch()
                {
                    Id = buchDTO.Id,
                    titel = buchDTO.titel,
                    autor = buchDTO.autor
                };
                buchListe2.Add(buch);
            }
            return buchListe2;
        }

        //Loesche und FuegeWiederEin-Funktionen zum Verschieben der Bücher
        internal void LoescheBuch(Buch buch)
        {
            _repository.LoescheBuch(buch.Id);
        }

        internal void LoescheBuch2(Buch buch)
        {
            _repository.LoescheBuch2(buch.Id);
        }

        internal void FuegeBuchWiederEin(Buch buch)
        {
            _repository.FuegeBuchWiederEin(buch.Id);
        }

        internal void FuegeBuchWiederEin2(Buch buch)
        {
            _repository.FuegeBuchWiederEin2(buch.Id);
        }

        //Testpush
    }
}
