using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Kliens.Shared
{
    //Az adatbazisbol lekert adatok tarolasara hasznalt osztalyok
    public class Alkatresz //metainfo az alkatreszrol
    {
        public int Id {  get; set; }
        public string Nev { get; set; }
        public int Ar { get; set; }
        public int MaxDb { get; set; }//max elhelyezheto dbszam egy rekeszben
    }

    public class Alkalmazott //alkalmazott adatai
    {
        public string Nev { get; set; }
        public string Passwd { get; set; }
        public string Szerep { get; set; } //raktaros, raktarvezeto, szakember
        //ide majd a tobbi tulajdonsaga
    }

    public class TaroltAlkatresz //Raktarban tarolt alkatreszek adatai
    {
        public int Id { get; set; } //alkatresz_id
        public Vector3 Rekesz { get; set; } //rekeszID
        public int Db { get; set; } //dbszam

        public TaroltAlkatresz(int id ,Vector3 pos, int q)
        {
            this.Id = id;
            Rekesz = pos;
            Db = q;
        }
    }
}
