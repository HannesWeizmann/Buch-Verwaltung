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

        public BuchOrmRepository(DatenbankKontext kontext)
        {
            _kontext = kontext;
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
    }
}
