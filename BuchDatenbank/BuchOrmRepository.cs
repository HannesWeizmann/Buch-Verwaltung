using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuchDatenbank
{
    public class BuchOrmRepository : IBuchRepository
    {
        private readonly DatenbankKontext _kontext;
        private readonly DatenbankKontext _kontext2;

        public BuchOrmRepository(DatenbankKontext kontext, DatenbankKontext kontext2)
        {
            _kontext = kontext;
            _kontext2 = kontext2;
        }


        /* vielleicht dann verschieben und dann aktualisieren*/
        public void AktualisiereBuecher(int id, string titel, string autor)
        {
            BuchDTO buch = _kontext.Buecher.Find(id);
            buch.titel = titel;
            buch.autor = autor;
            _kontext.SaveChanges();
        }
        
        public void FuegeBuecherEin(string titel, string autor)
        {
            BuchDTO buch = new BuchDTO
            {
                titel = titel,
                autor = autor
            };
            _ = _kontext.Buecher.Add(buch);
            _ = _kontext.SaveChanges();

        }

        public List<BuchDTO> HoleAlleBuecher()
        {
            return _kontext.Buecher.ToList();
        }

        public void AktualisiereBuecher2(int id, string titel, string autor)
        {
            Buch2DTO buch = _kontext2.Buecher2.Find(id);
            buch.titel = titel;
            buch.autor = autor;
            _kontext.SaveChanges();
        }

        public void FuegeBuecherEin2(string titel, string autor)
        {
            Buch2DTO buch = new Buch2DTO
            {
                titel = titel,
                autor = autor
            };
            _ = _kontext2.Buecher2.Add(buch);
            _ = _kontext2.SaveChanges();

        }
        public List<Buch2DTO> HoleAlleBuecher2()
        {
            return _kontext2.Buecher2.ToList();
        }

        public void LoescheBuch(int id)
        {
            BuchDTO buch = _kontext.Buecher.Find(id);
            _kontext.Buecher.Remove(buch);
            _kontext.SaveChanges();
        }

        public void FuegeBuchwiederein(int id)
        {
            BuchDTO buch = _kontext.Buecher.Find(id);
            _kontext.Buecher.Add(buch);
            _kontext.SaveChanges();
        }
    }
}
