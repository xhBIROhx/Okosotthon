using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class Termosztat : OkosEszkoz
    {
        public double JelenlegiHomerseklet { get; private set; }
        public double CelHomerseklet { get; private set; }

        public Termosztat(string azonosito, string nev, double celHomerseklet)
        : base(azonosito, nev)
        {
            this.CelHomerseklet = celHomerseklet;
            this.JelenlegiHomerseklet = 21.0;
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            if (parancs.StartsWith("BEALLIT_HOMERSEKLET:"))
            {
                string[] parts = parancs.Split(":");
                if (parts.Length == 2 && double.TryParse(parts[1], out double ujCelHomerseklet))
                {
                    this.CelHomerseklet = ujCelHomerseklet;
                }
            }
        }

        public override string AllapotJelentes()
        {
            return $"Jelenlegi hőmérséklet: {JelenlegiHomerseklet} °C, célhőmérséklet: {CelHomerseklet} °C";
        }

        protected override bool OnTesztFuttatasa()
        {
            return this.CelHomerseklet >= 5.0 && this.CelHomerseklet <= 35.0;
        }

    }
}
