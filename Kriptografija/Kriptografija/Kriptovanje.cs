using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Kriptografija
{
    enum Kriptografija { TEKST, SIFRA }
    enum Pomeranje { Levo, Desno }

    class KriptoPoruka
    {

        string poruka;
        Kriptografija tip = Kriptografija.TEKST;

        public KriptoPoruka(string poruka)
        {
            this.poruka = poruka;
        }

        public bool UnesiNoviTekstPoruke(string novaPoruka)
        {
            if (tip.Equals(Kriptografija.TEKST))
            {
                poruka = novaPoruka;
                return true;
            }
            return false;
        }

        public void IspisiPorukuITip(Label l)
        {
            l.Text+=(tip+": "+poruka+"\n");
        }

        public void KriptoDekripto()
        {

            if (tip.Equals(Kriptografija.TEKST))
            {
                tip = Kriptografija.SIFRA;
                IzvrsiAgoritam(Pomeranje.Desno);
            }
            else if (tip.Equals(Kriptografija.SIFRA))
            {
                tip = Kriptografija.TEKST;
                IzvrsiAgoritam(Pomeranje.Levo);
            }

        }

        void IzvrsiAgoritam(Pomeranje pomeranje)
        {
            char[] porukaChar = poruka.ToCharArray();
            int velicinaPoruke = porukaChar.Length;
            for (int i = 0; i < velicinaPoruke; i++)
            {
                char elem = porukaChar[i];
                if (char.IsDigit(elem))
                {
                    porukaChar[i] = ZameniBroj(elem);
                }
                else if (char.IsLetter(elem))
                {
                    porukaChar[i] = ZameniSlova(elem, velicinaPoruke, pomeranje);
                }
                else if (char.IsWhiteSpace(elem))
                {
                    porukaChar[i] = '!';
                }
                else if (elem.Equals('!'))
                {
                    porukaChar[i] = ' ';
                }
            }

            poruka = new string(porukaChar);

        }

        char ZameniSlova(char slovo, int brojKaraktera, Pomeranje pomeranje)
        {
            if (char.IsUpper(slovo))
            {
                // velika slova su izmedju 65 i 90
                return PomeriSlovo(slovo, brojKaraktera, pomeranje, 'A', 'Z');
            }
            else if (char.IsLower(slovo))
            {
                // mala slova su izmedju 97 i 122
                return PomeriSlovo(slovo, brojKaraktera, pomeranje, 'a', 'z');
            }
            return slovo;
        }

        char PomeriSlovo(char slovo, int zaKolikoSePomeraKarakter, Pomeranje pomeranje, int donjaGranica, int gornjaGranica)
        {
            int brojSlovaAbecede = 26;
            if (pomeranje.Equals(Pomeranje.Desno))
            {
                int pozicijaSlova = zaKolikoSePomeraKarakter + slovo;
                while (pozicijaSlova > gornjaGranica)
                {
                    pozicijaSlova = pozicijaSlova - brojSlovaAbecede;
                }
                return Convert.ToChar(pozicijaSlova);
            }
            else // pomeranje u levo
            {
                int pozicijaSlova = slovo - zaKolikoSePomeraKarakter;
                while (pozicijaSlova < donjaGranica)
                {
                    pozicijaSlova = pozicijaSlova + brojSlovaAbecede;
                }
                return Convert.ToChar(pozicijaSlova);
            }
        }

        char ZameniBroj(char broj)
        {
            //algoritam za menjanje slova je u ogledalu u odnosu na broj 5
            //ako imamo broj 9 treba da dobijemo 1...
            //najjednostavnije je od 10 oduzeti trenutni broj i dobijemo trazeni broj
            // ovo vazi za sve brojeve osim 0, 0 treba da ostane 0
            if (broj != 0)
            {
                int rezultat = 10 - int.Parse(broj.ToString());
                return char.Parse(rezultat.ToString());
            }
            return broj;
        }
    }
}
