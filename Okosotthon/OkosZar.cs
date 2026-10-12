using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class OkosZar: OkosEszkoz
    {
        private string pinKod;
        public bool ZartE { get; private set; }

        public OkosZar(string azonosito, string nev, string pinKod)
        : base(azonosito, nev)
        {
            this.pinKod = pinKod;
            this.ZartE = true;
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            if (parancs.StartsWith("NYITAS:"))
            {
                string[] parts = parancs.Split(":");
                if (parts.Length == 2)
                {
                    string megadottPinKod = parts[1];
                    if (megadottPinKod == this.pinKod)
                    {
                        this.ZartE = false;
                    }
                }
            }
            else if (parancs == "ZARAS")
            {
                this.ZartE = true;
            }
        }


        public override string AllapotJelentes()
        {
            return ZartE ? "ZÁRVA" : "NYITVA";
        }

        protected override bool OnTesztFuttatasa()
        {
            return true;
        }

        public override void GyariBeallitasokVisszaallitasa()
        {
            base.GyariBeallitasokVisszaallitasa();
            this.pinKod = "0000";
            this.ZartE = true;
        }
    }
}
