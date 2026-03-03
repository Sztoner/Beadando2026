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
        public int id;
        public string nev;
        public int ar;
        public int maxdb; //max elhelyezheto dbszam egy rekeszben

        public Alkatresz()
        {
            id = 0;
            nev = string.Empty;
            ar = 0;
            maxdb = 0;
        }
    }

    public class Alkalmazott //alkalmazott adatai
    {
        public string nev;
        public string passwd;
        public string szerep; //raktaros, raktarvezeto, szakember
        //ide majd a tobbi tulajdonsaga

        public Alkalmazott()
        {
            nev = string.Empty;
            passwd = string.Empty;
            szerep = string.Empty;
        }
    }

    public class TaroltAlkatresz //Raktarban tarolt alkatreszek adatai
    {
        public int id; //alkatresz_id
        public Vector3 rekesz; //rekeszID
        public int db; //dbszam

        public TaroltAlkatresz()
        {
            id = 0;
            rekesz = new Vector3(0,0,0);
            db = 0;
        }

        public TaroltAlkatresz(int id ,Vector3 pos, int q)
        {
            this.id = id;
            rekesz = pos;
            db = q;
        }
    }
}
