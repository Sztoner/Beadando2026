namespace Backend.Models
{
    public class ProjektAlkatreszGet
    {
        public int ProjektId { get; set; }
        public string ProjektNev { get; set; }
        public int AlkatreszId { get; set; }
        public string AlkatreszNev { get; set; }
        public int Darabszam { get; set; }
        public int HianyDb { get; set; }
    }
}
