using System.Collections.Generic;

namespace Kodluyoruz_Console_ToDo_Uygulaması_Proje2
{
    internal class TakimUyeleri
    {
        public Dictionary<int, string> Uyeler { get; } = new Dictionary<int, string>();

        public TakimUyeleri()
        {
            Uyeler.Add(1, "Adem");
            Uyeler.Add(2, "Maden");
            Uyeler.Add(3, "Badem");
            Uyeler.Add(4, "Zaten");
            Uyeler.Add(5, "Matem");
        }
    }
}
