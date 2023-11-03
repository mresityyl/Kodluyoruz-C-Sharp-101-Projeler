using System.Collections.Generic;

namespace Kodluyoruz_Console_ToDo_Uygulaması_Proje2
{
    internal class Board
    {
        public List<Kart> TodoKartlar { get; } = new List<Kart>();
        public List<Kart> InProgressKartlar { get; } = new List<Kart>();
        public List<Kart> DoneKartlar { get; } = new List<Kart>();
    }
}
