
namespace Kodluyoruz_Console_ToDo_Uygulaması_Proje2
{
    internal class Kart
    {
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public int AtananKisiID { get; set; }
        public KartBuyuklukleri Buyukluk { get; set; }
        public string Line { get; set; } = "TODO"; // "TODO" default

        public Kart(string baslik, string icerik, KartBuyuklukleri buyukluk, int atananKisiID)
        {
            Baslik = baslik;
            Icerik = icerik;
            Buyukluk = buyukluk;
            AtananKisiID = atananKisiID;
        }
    }

    public enum KartBuyuklukleri
    {
        XS = 1,
        S,
        M,
        L,
        XL
    }
}
