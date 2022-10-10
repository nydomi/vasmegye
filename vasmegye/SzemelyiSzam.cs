using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace vasmegye
{
    class SzemelyiSzam
    {
        readonly string szam;

        public string Szam => szam;

        public SzemelyiSzam(string szam){
            this.szam = szam;
        } 
    }
}
