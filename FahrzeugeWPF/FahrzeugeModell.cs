using FahrzeugDatenbank;
using Fahrzeuge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrzeugeWPF
{
    class FahrzeugeModell
    {
        private readonly IBuchRepository _repository;

        public FahrzeugeModell(IBuchRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Fahrzeug>> LadeAlleFahrzeuge()
        {
            List<BuchDTO>? fahrzeuge = await Task.Run(() => {
                return _repository.HoleAlleFahrzeuge();
            });
            var fahrzeugListe = KonvertiereFahrzeuge(fahrzeuge);
            return fahrzeugListe;
        }

        private IEnumerable<Fahrzeug> KonvertiereFahrzeuge(IEnumerable<BuchDTO> fahrzeuge)
        {
            List<Fahrzeug> fahrzeugListe = new();
            foreach (var fahrzeugDTO in fahrzeuge)
            {
                switch (fahrzeugDTO.Typ)
                {
                    case "Auto":
                        var auto = new Auto() { 
                            Id = fahrzeugDTO.Id,
                            Name = fahrzeugDTO.Name
                        };
                        fahrzeugListe.Add(auto);
                        break;
                    case "Motorrad":
                        var motorrad = new Motorrad()
                        {
                            Id = fahrzeugDTO.Id,
                            Name = fahrzeugDTO.Name
                        };
                        fahrzeugListe.Add(motorrad);
                        break;
                    case "Fahrrad":
                        var fahrrad = new Fahrrad()
                        {
                            Id = fahrzeugDTO.Id,
                            Name = fahrzeugDTO.Name
                        };
                        fahrzeugListe.Add(fahrrad);
                        break;
                }
            }
            return fahrzeugListe;
        }

        internal void LoescheFahrzeug(Fahrzeug fahrzeug)
        {
            _repository.LoescheFahrzeug(fahrzeug.Id);
        }
    }
}
