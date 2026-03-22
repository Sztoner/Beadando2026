namespace Backend.Models
{
    public class Projekt
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public string Helyszin { get; set; }
        public string Megrendelo { get; set; }
        public string Leiras { get; set; }
        public string Statusz { get; set; }
        public int Munkaido { get; set; }
        public int Munkadij { get; set; }
        public int Ar { get; set; }
    }
}
