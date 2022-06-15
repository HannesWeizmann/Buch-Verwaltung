using System.Collections.Generic;

namespace BuchDatenbank
{
    public interface IBuchRepository
    {
        void AktualisiereBuecher(int id, string titel, string autor);
        void FuegeBuecherEin(string titel, string autor);
        List<BuchDTO> HoleAlleBuecher();
    }
}