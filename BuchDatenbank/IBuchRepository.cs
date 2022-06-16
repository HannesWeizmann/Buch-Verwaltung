using System.Collections.Generic;

namespace BuchDatenbank
{
    public interface IBuchRepository
    {
        void AktualisiereBuecher(int id, string titel, string autor);
        void FuegeBuecherEin(string titel, string autor);
        List<BuchDTO> HoleAlleBuecher();
        List<Buch2DTO> HoleAlleBuecher2();

        //Je zwei Funktionen zum löschen und einfügen in linker und rechter Tabelle
        void LoescheBuch(int id);
        void LoescheBuch2(int id);
        void FuegeBuchWiederEin(int id);
        void FuegeBuchWiederEin2(int id);

    }
}