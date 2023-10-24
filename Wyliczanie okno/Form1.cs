using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wyliczanie_okno
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Włączenie programu
        private void Program_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            // Wprowadzenie danych
            int pełna_siła1 = 0;
            int pełna_siła2 = 0;

            int straty1 = 0;
            int straty2 = 0;

            int[] punkty_zbiór1 = { 0, 0, 0, 0, 0, 0 };
            int[] punkty_zbiór2 = { 0, 0, 0, 0, 0, 0 };

            int[] antypunkty_zbiór1 = { 0, 0, 0, 0, 0, 0 };
            int[] antypunkty_zbiór2 = { 0, 0, 0, 0, 0, 0 };

            int punkty_suma1 = 0;
            int punkty_suma2 = 0;

            // Wprowadzenie danych na temat wojsk z programu
            // Ilość wojsk atakującego
            int[] pułki1 = new int[] { (int)Convert.ToDouble(Liczba1A.Text), (int)Convert.ToDouble(Liczba2A.Text), (int)Convert.ToDouble(Liczba3A.Text), (int)Convert.ToDouble(Liczba4A.Text), (int)Convert.ToDouble(Liczba5A.Text), (int)Convert.ToDouble(Liczba6A.Text)};
            //Ilość wojsk obronnych
            int[] pułki2 = new int[] { (int)Convert.ToDouble(Liczba1B.Text), (int)Convert.ToDouble(Liczba2B.Text), (int)Convert.ToDouble(Liczba3B.Text), (int)Convert.ToDouble(Liczba4B.Text), (int)Convert.ToDouble(Liczba6B.Text), (int)Convert.ToDouble(Liczba6B.Text)};

            // Siła wojsk atakujących
            int[] siła_pułku1 = new int[] { (int)Convert.ToDouble(Sila1A.Text), (int)Convert.ToDouble(Sila2A.Text), (int)Convert.ToDouble(Sila3A.Text), (int)Convert.ToDouble(Sila4A.Text), (int)Convert.ToDouble(Sila5A.Text), (int)Convert.ToDouble(Sila6A.Text)};
            // Siła wojsk obronnych
            int[] siła_pułku2 = new int[] { (int)Convert.ToDouble(Sila1B.Text), (int)Convert.ToDouble(Sila2B.Text), (int)Convert.ToDouble(Sila3B.Text), (int)Convert.ToDouble(Sila4B.Text), (int)Convert.ToDouble(Sila5B.Text), (int)Convert.ToDouble(Sila6B.Text)};

            // Ilość bonusu dla wszystkich sił atakujących
            int bonus1 = (int)Convert.ToDouble(BonusA.Text);
            // Ilość bonusu dla wszystkich sił obronnych
            int bonus2 = (int)Convert.ToDouble(BonusB.Text);

            // Ilość bonusu dla konkretnych oddziałów atakujących
            int[] bonusy_wojsk1 = new int[] { (int)Convert.ToDouble(Bonus1A.Text), (int)Convert.ToDouble(Bonus2A.Text), (int)Convert.ToDouble(Bonus3A.Text), (int)Convert.ToDouble(Bonus4A.Text), (int)Convert.ToDouble(Bonus5A.Text), (int)Convert.ToDouble(Bonus6A.Text)};
            // Ilość bonusu dla konkretnych oddziałów obronnych
            int[] bonusy_wojsk2 = new int[] { (int)Convert.ToDouble(Bonus1B.Text), (int)Convert.ToDouble(Bonus2B.Text), (int)Convert.ToDouble(Bonus3B.Text), (int)Convert.ToDouble(Bonus4B.Text), (int)Convert.ToDouble(Bonus5B.Text), (int)Convert.ToDouble(Bonus6B.Text)};

            // Mnożnik strat atakujących
            int mnożnik_strat1 = (int)Convert.ToDouble(MnogStratA.Text);
            // Mnożnik strat obronnych
            int mnożnik_strat2 = (int)Convert.ToDouble(MnogStratB.Text);

            // Zakres rzutu
            // Minimum
            int min_rzut = (int)Convert.ToDouble(RzutMin.Text);
            // Maksimum
            int max_rzut = (int)Convert.ToDouble(RzutMax.Text);

            // Wynik wymagany do porażki
            int wynik_porazka = (int)Convert.ToDouble(RzutPorazka.Text);
            // Wynik wymagany do sukcesu
            int wynik_sukces = (int)Convert.ToDouble(RzutSukces.Text);
            // Wynik wymagany do sukcesu krytycznego
            int wynik_super = (int)Convert.ToDouble(RzutSuper.Text);

            // Wyliczenie ataku atakującego
            for (int i = 0; i < pułki1.Length; i++)
            {
                for (int y = 0; y < pułki1[i]; y++)
                {
                    int rzut = rnd.Next(min_rzut, max_rzut);
                    if (rzut + bonus1 + bonusy_wojsk1[i] > wynik_sukces)
                    {
                        punkty_suma1 = punkty_suma1 + 1;
                        punkty_zbiór1[i] = punkty_zbiór1[i] + 1;
                        if (rzut + bonus1 >= wynik_super)
                        {
                            punkty_suma1 = punkty_suma1 + 1;
                            punkty_zbiór1[i] = punkty_zbiór1[i] + 1;
                        }
                    }
                    if (rzut <= wynik_porazka)
                    {
                        antypunkty_zbiór1[i] = antypunkty_zbiór1[i] + 1;
                    }
                }

            }

            // Wyliczenie ataku obrońcy
            for (int i = 0; i < pułki2.Length; i++)
            { 
                for (int y = 0; y < pułki2[i]; y++)
                {
                    int rzut = rnd.Next(min_rzut, max_rzut);
                    if (rzut + bonus2 + bonusy_wojsk2[i]> wynik_sukces)
                    {
                        punkty_suma2 = punkty_suma2 + 1;
                        punkty_zbiór2[i] = punkty_zbiór2[i] + 1;
                        if (rzut + bonus2 >= wynik_super)
                        {
                            punkty_suma2 = punkty_suma2 + 1;
                            punkty_zbiór2[i] = punkty_zbiór2[i] + 1;
                        }
                    }
                    if (rzut <= wynik_porazka)
                    {
                        antypunkty_zbiór2[i] = antypunkty_zbiór2[i] + 1;
                    }
                }

            }

            // Wyliczenie porażek atakującego
            int antypunktyA = 0;
            for (int i = 0; i < antypunkty_zbiór1.Length; i++)
            {
                antypunktyA = antypunktyA + antypunkty_zbiór1[i];
            }
            punkty_suma1 = punkty_suma1;

            // Wyliczenie porażek obrońcy
            int antypunktyB = 0;
            for (int i = 0; i < antypunkty_zbiór2.Length; i++)
            {
                antypunktyB = antypunktyB + antypunkty_zbiór2[i];
            }
            punkty_suma2 = punkty_suma2;

            // Liczenie strat atakującego
            for (int i = 0; i < pułki1.Length; i++)
            {
                straty2 = straty2 + ((punkty_zbiór1[i] * siła_pułku1[i]) * mnożnik_strat2) + (antypunkty_zbiór2[i] * siła_pułku2[i] * mnożnik_strat2);
            }
            // Liczenie strat obrońcy
            for (int i = 0; i < pułki2.Length; i++)
            {
                straty1 = straty1 + ((punkty_zbiór2[i] * siła_pułku2[i]) * mnożnik_strat1) + (antypunkty_zbiór1[i] * siła_pułku1[i] * mnożnik_strat1);
            }

            // Pokazanie zwycięscy
            Wygrany.Items.Clear();
            if (punkty_suma1>punkty_suma2)
            {
                Wygrany.Items.Add("Atakujący");
            }
            else 
            {
                Wygrany.Items.Add("Obrońca");
            }

            // Pokazanie strat
            StratyA.Items.Clear();
            StratyB.Items.Clear();
            StratyA.Items.Add(straty1);
            StratyB.Items.Add(straty2);

            // Pokazanie punktów zwycięskich atakującego
            Win1A.Items.Clear();
            Win2A.Items.Clear();
            Win3A.Items.Clear();
            Win4A.Items.Clear();
            Win5A.Items.Clear();
            Win6A.Items.Clear();
            Win1A.Items.Add(punkty_zbiór1[0]);
            Win2A.Items.Add(punkty_zbiór1[1]);
            Win3A.Items.Add(punkty_zbiór1[2]);
            Win4A.Items.Add(punkty_zbiór1[3]);
            Win5A.Items.Add(punkty_zbiór1[4]);
            Win6A.Items.Add(punkty_zbiór1[5]);

            // Pokazanie punktów zwycięskich obrońcy
            Win1B.Items.Clear();
            Win2B.Items.Clear();
            Win3B.Items.Clear();
            Win4B.Items.Clear();
            Win5B.Items.Clear();
            Win6B.Items.Clear();
            Win1B.Items.Add(punkty_zbiór2[0]);
            Win2B.Items.Add(punkty_zbiór2[1]);
            Win3B.Items.Add(punkty_zbiór2[2]);
            Win4B.Items.Add(punkty_zbiór2[3]);
            Win5B.Items.Add(punkty_zbiór2[4]);
            Win6B.Items.Add(punkty_zbiór2[5]);

            // Pokazanie punktów porażki atakującego
            Lose1A.Items.Clear();
            Lose2A.Items.Clear();
            Lose3A.Items.Clear();
            Lose4A.Items.Clear();
            Lose5A.Items.Clear();
            Lose6A.Items.Clear();
            Lose1A.Items.Add(antypunkty_zbiór1[0]);
            Lose2A.Items.Add(antypunkty_zbiór1[1]);
            Lose3A.Items.Add(antypunkty_zbiór1[2]);
            Lose4A.Items.Add(antypunkty_zbiór1[3]);
            Lose5A.Items.Add(antypunkty_zbiór1[4]);
            Lose6A.Items.Add(antypunkty_zbiór1[5]);

            // Pokazanie punktów porażki obrońcy
            Lose1B.Items.Clear();
            Lose2B.Items.Clear();
            Lose3B.Items.Clear();
            Lose4B.Items.Clear();
            Lose5B.Items.Clear();
            Lose6B.Items.Clear();
            Lose1B.Items.Add(antypunkty_zbiór2[0]);
            Lose2B.Items.Add(antypunkty_zbiór2[1]);
            Lose3B.Items.Add(antypunkty_zbiór2[2]);
            Lose4B.Items.Add(antypunkty_zbiór2[3]);
            Lose5B.Items.Add(antypunkty_zbiór2[4]);
            Lose6B.Items.Add(antypunkty_zbiór2[5]);
        }


    }
}
