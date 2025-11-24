using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DortIslem
{
    public partial class Form1 : Form
    {
        private bool isTrue = false;
        private int n = 10;
        private Random rnd = new Random();
        private string dosyaYolu;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dosyaYolu = Path.Combine(Path.GetTempPath(), "sayac.txt");

            if (!File.Exists(dosyaYolu))
            {
                File.WriteAllText(dosyaYolu, "0");
            }
            int sayi = 0;
            try
            {
                sayi = Convert.ToInt32(File.ReadAllText(dosyaYolu));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya okuma hatası: " + ex.Message);
                return;
            }
            try
            {
                File.WriteAllText(dosyaYolu, sayi.ToString());
                label14.Text = sayi.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya yazma hatası: " + ex.Message);
            }
            Rast(n);
        }

        private void Rast(int n)
        {
            label5.Text = rnd.Next(n).ToString();
            label6.Text = rnd.Next(n).ToString();

            if (radioButton2.Checked)
            {
                while (Convert.ToInt32(label5.Text) <= Convert.ToInt32(label6.Text))
                {
                    label5.Text = rnd.Next(n).ToString();
                    label6.Text = rnd.Next(n).ToString();
                }
            }

            if (radioButton4.Checked)
            {
                do
                {
                    label5.Text = rnd.Next(2, n).ToString();
                    label6.Text = rnd.Next(2, 10).ToString();
                } while (Convert.ToInt32(label5.Text) % Convert.ToInt32(label6.Text) != 0 || IsPrime((Convert.ToInt32(label5.Text))));
            }
        }

        private void calculate()
        {
            
            int counterTrue = 0;
            int counterFalse = 0;

            int sayi1 = Convert.ToInt32(label5.Text);
            int sayi2 = Convert.ToInt32(label6.Text);
            int kullaniciSonuc;

            if (!int.TryParse(textBox1.Text, out kullaniciSonuc))
            {
                MessageBox.Show("Lütfen geçerli bir sayı girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int dogruSonuc = 0;

            if (radioButton1.Checked)
                dogruSonuc = sayi1 + sayi2;
            else if (radioButton2.Checked)
                dogruSonuc = sayi1 - sayi2;
            else if (radioButton3.Checked)
                dogruSonuc = sayi1 * sayi2;
            else if (radioButton4.Checked && sayi2 != 0)
                dogruSonuc = sayi1 / sayi2;

            isTrue = (dogruSonuc == kullaniciSonuc);
            if (isTrue)
            {
                this.BackColor = Color.Lime;
                label9.Text = (Convert.ToInt32(label9.Text) + 1).ToString();
                int sayi = 0;
                try
                {
                    sayi = Convert.ToInt32(File.ReadAllText(dosyaYolu));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dosya okuma hatası: " + ex.Message);
                    return;
                }
                sayi++;
                try
                {
                    File.WriteAllText(dosyaYolu, sayi.ToString());
                    label14.Text = sayi.ToString();
                    if (Convert.ToInt32(label14.Text) >= 50)
                        MessageBox.Show("Musti 50TL kaandın gelince söyle verim");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dosya yazma hatası: " + ex.Message);
                }
            }
            else
            {
                this .BackColor = Color.Tomato;
                label10.Text = (Convert.ToInt32(label10.Text) + 1).ToString();
            }

            if (isTrue)
                Rast(n);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calculate();
            textBox1.Text = "";
        }

        
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            while (Convert.ToInt32(label6.Text) != 0 && ((Convert.ToInt32(label5.Text) % Convert.ToInt32(label6.Text) != 0)))
            {
                Rast(n);
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "1 Basamak")
                n = 10;
            else if (comboBox1.Text == "2 Basamak")
                n = 100;
            else if (comboBox1.Text == "3 Basamak")
                n = 1000;

            Rast(n);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Rast(n);
            textBox1.Text = "";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Rast(n);
            textBox1.Text = "";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Rast(n);
            textBox1.Text = "";
        }

        private void radioButton4_CheckedChanged_1(object sender, EventArgs e)
        {
            Rast(n);
            textBox1.Text = "";
        }
        public bool IsPrime(int num)
        {
            if (num < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                    return false;
            }

            return true;
        }
    }
}
