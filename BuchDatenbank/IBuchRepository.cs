using System.Collections.Generic;

namespace BuchDatenbank
{
    public interface IBuchRepository
    {
        void AktualisiereBuecher(int id, string titel, string autor);
        void AktualisiereBuecher2(int id, string titel, string autor);
        void FuegeBuecherEin(string titel, string autor);
        void FuegeBuecherEin2(string titel, string autor);
        List<BuchDTO> HoleAlleBuecher();
        List<Buch2DTO> HoleAlleBuecher2();

        //Zwei Funktionen zum löschen in linker und rechter Tabelle
        void LoescheBuch(int id);
        void LoescheBuch2(int id);

    }
}