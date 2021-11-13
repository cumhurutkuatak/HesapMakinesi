using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace hesapmakinesi1
{
    public partial class Form1 : Form
    {
        


        int simgecontur = 0; // eşittire ikiden fazla basınca hatayı önlemek amaçlı değişken
        string simgeoperator = "";
        bool giris_degeri = false;
        double sayi1 = 0;// ekleme yaptığım değişken çift işlemler ilk sayıyı bu global değişkende saklıyorum
        double hafiza = 0; // m+ m- mr için hafıza değişkeni
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            formu_ortala(); // form hangi ekranda açılırsa açılsın ortalansın
            kapabutton.Enabled = true;
            acbutton.Enabled = false;
            acbutton.Hide(); // program ilk açıldığında aç butonu gözükmesin
        }
        private void kapabutton_Click(object sender, EventArgs e) // kapa butonuna bastıgında tum butonların pasif olması için
        {
            acbutton.Show();
            kapabutton.Hide();
            acbutton.Enabled = true;

            gecmislabel.Text = "";
            sayi1 = 0;
            hafiza = 0;

            eksiartibutton.Enabled = false;
            gostergetextbox.Text = "";
            btn_mr.Enabled = false;
            btn_meksi.Enabled = false;
            btn_marti.Enabled = false;
            btn_exit.Enabled = false;
            ButtonCE.Enabled = false;
            faktoriyelbutton.Enabled = false;
            modbutton.Enabled = false;
            btn_e.Enabled = false;
            kapabutton.Enabled = false;
            ButtonC.Enabled = false;
            backspacebutton.Enabled = false;
            yuzdebutton.Enabled = false;
            bolbutton.Enabled = false;
            pisayisi.Enabled = false;
            logaritmabutton.Enabled = false;
            karekok.Enabled = false;
            rakam0button.Enabled = false;
            rakam1button.Enabled = false;
            rakam2button.Enabled = false;
            rakam3button.Enabled = false;
            rakam4button.Enabled = false;
            rakam5button.Enabled = false;
            rakam6button.Enabled = false;
            rakam7button.Enabled = false;
            rakam8button.Enabled = false;
            rakam9button.Enabled = false;
            virgulbutton.Enabled = false;
            esittirbuton.Enabled = false;
            artibutton.Enabled = false;
            eksibutton.Enabled = false;
            carpbutton.Enabled = false;
            sinusbutton.Enabled = false;
            CosinusButton.Enabled = false;
            TanjantButton.Enabled = false;
            lnButton.Enabled = false;
            KareAlmaButton.Enabled = false;
        }

        private void acbutton_Click(object sender, EventArgs e) // ac butonuna bastıgında tum butonların pasif olması için
        {
            acbutton.Hide();
            kapabutton.Show();
            acbutton.Enabled = false;

            eksiartibutton.Enabled = true;
            gostergetextbox.Text = "0";
            btn_mr.Enabled = true;
            btn_meksi.Enabled = true;
            btn_marti.Enabled = true;
            btn_exit.Enabled = true;
            ButtonCE.Enabled = true;
            faktoriyelbutton.Enabled = true;
            modbutton.Enabled = true;
            btn_e.Enabled = true;
            kapabutton.Enabled = true;
            ButtonC.Enabled = true;
            backspacebutton.Enabled = true;
            yuzdebutton.Enabled = true;
            bolbutton.Enabled = true;
            pisayisi.Enabled = true;
            logaritmabutton.Enabled = true;
            karekok.Enabled = true;
            rakam0button.Enabled = true;
            rakam1button.Enabled = true;
            rakam2button.Enabled = true;
            rakam3button.Enabled = true;
            rakam4button.Enabled = true;
            rakam5button.Enabled = true;
            rakam6button.Enabled = true;
            rakam7button.Enabled = true;
            rakam8button.Enabled = true;
            rakam9button.Enabled = true;
            virgulbutton.Enabled = true;
            esittirbuton.Enabled = true;
            artibutton.Enabled = true;
            eksibutton.Enabled = true;
            carpbutton.Enabled = true;
            sinusbutton.Enabled = true;
            CosinusButton.Enabled = true;
            TanjantButton.Enabled = true;
            lnButton.Enabled = true;
            KareAlmaButton.Enabled = true;
        }
        private void esittirbuton_Click(object sender, EventArgs e)
        {

            simgecontur += 1; // esittire 2 kere basıldıgında hatayı onlemesi icin

            if (simgecontur <= 2)
            {
                esit_muamele();
            }
        }
        private void OrtakButton_Click(object sender, EventArgs e)
        {

            simgecontur = 0;

            if ((gostergetextbox.Text.Length == 1 && gostergetextbox.Text == ","))
            {
                gostergetextbox.Text = "0,";
            }



            if ((gostergetextbox.Text == "0") || (giris_degeri))
                gostergetextbox.Text = "";

            giris_degeri = false;


            Button num = (Button)sender;
            if (num.Text == ",")
            {
                if (!gostergetextbox.Text.Contains(","))
                    gostergetextbox.Text = gostergetextbox.Text + num.Text;
            }
            else
                gostergetextbox.Text = gostergetextbox.Text + num.Text;

        }
        private void eksiartibutton_Click(object sender, EventArgs e)
        {
            simgeoperator = "";
            gostergetextbox.Text = System.Convert.ToString(-1 * double.Parse(gostergetextbox.Text));
        }
        private void ButtonC_Click(object sender, EventArgs e) // hafıza dahil tüm her şeyi siler
        {
            gostergetextbox.Text = "0";
            gecmislabel.Text = "";
            sayi1 = 0;
            hafiza = 0;
        }

        private void ButtonCE_Click(object sender, EventArgs e) // textboxu siler ekranı temizler 
        {
            gostergetextbox.Text = "0";
            gecmislabel.Text = "";
        }

        private void backspacebutton_Click(object sender, EventArgs e) //backspace geri alma butonu
        {
            if (gostergetextbox.Text.Length > 0) // eğer sıfırdan büyükse 
            {
                gostergetextbox.Text = gostergetextbox.Text.Remove(gostergetextbox.Text.Length - 1, 1); // başlangıç indeksi -1 miktar da 1 birer birer azalsın
                if (gostergetextbox.Text.Length == 0) // karakter sayısı 0 a eşit olduğunda
                {
                    gostergetextbox.Text = "0"; // en sonunda tüm rakamları geri alınca textboxta 0 olsun diye
                }
            }
        }



        private void KareAlmaButton_Click(object sender, EventArgs e)
        {
            
            simgeoperator = "Kare";
            cifttus_kontrolu();
        }
       private void karekok_Click(object sender, EventArgs e)
        {
             
            simgeoperator = "√";
            cifttus_kontrolu();
        }
       private void TanjantButton_Click(object sender, EventArgs e) 
        {
            simgeoperator = "Tan";
            cifttus_kontrolu();
        }
       private void CosinusButton_Click(object sender, EventArgs e) 
        {
            simgeoperator = "Cos";
            cifttus_kontrolu();
        }
       private void sinusbutton_Click(object sender, EventArgs e) 
        {
            simgeoperator = "Sin";
            cifttus_kontrolu();
        }
        private void logaritmabutton_Click(object sender, EventArgs e)
        {
           
            simgeoperator = "log";
            cifttus_kontrolu();
        }

        private void pisayisi_Click(object sender, EventArgs e)
        {
            simgeoperator = "PI";
            islem_yap((Math.PI), simgeoperator);
                     
        }    
        private void btn_e_Click(object sender, EventArgs e)
        {
            simgeoperator = "e";
            islem_yap((Math.E), simgeoperator);
        }

        private void lnButton_Click(object sender, EventArgs e)
        {
            
            if (sayi1 != 0) { esit_muamele(); }// ikinci kez bastığında eşite basmiş kabul edilecek
            simgeoperator = "ln";
            cifttus_kontrolu();
        }
        private void yuzdebutton_Click(object sender, EventArgs e) 
        {
            
            if (sayi1 != 0) { esit_muamele(); }// ikinci kez bastığında eşite basmiş kabul edilecek   
            simgeoperator = "%";
            cifttus_kontrolu();
        }
        private void faktoriyelbutton_Click(object sender, EventArgs e) 
        {
           
            if (sayi1 != 0) { esit_muamele(); }// ikinci kez bastığında eşite basmiş kabul edilecek    
            simgeoperator = "!";
            cifttus_kontrolu();
        }
        private void artibutton_Click(object sender, EventArgs e)
        {   
            if (sayi1 != 0) { esit_muamele(); } // ikinci kez bastığında eşite basmiş kabul edilecek
            simgeoperator = "+";
            cifttus_kontrolu();               
        }
        private void eksibutton_Click(object sender, EventArgs e)
        {   
            if (sayi1 != 0) { esit_muamele(); }// ikinci kez bastığında eşite basmiş kabul edilecek  
            simgeoperator = "-";
            cifttus_kontrolu();
        }

        private void carpbutton_Click(object sender, EventArgs e)
        {  
            if (sayi1 != 0) { esit_muamele(); }// ikinci kez bastığında eşite basmiş kabul edilecek   
            simgeoperator = "*";
            cifttus_kontrolu();
        }

        private void bolbutton_Click(object sender, EventArgs e)
        {  
            if (sayi1 != 0) { esit_muamele(); }// ikinci kez bastığında eşite basmiş kabul edilecek
            simgeoperator = "/";
            cifttus_kontrolu();
        }

        private void modbutton_Click(object sender, EventArgs e)
        {

            if (sayi1 != 0) { esit_muamele(); }// ikinci kez bastığında eşite basmiş kabul edilecek 
            simgeoperator = "mod";
            cifttus_kontrolu();
        }

        private void btn_marti_Click(object sender, EventArgs e) // hafızaya sayi almak icin
        {
            if (gostergetextbox.Text != "") //textboxda değer varsa hafızaya al boşsa alma 
            {
                hafiza = hafiza + double.Parse(gostergetextbox.Text);
            }

        }
        private void btn_meksi_Click(object sender, EventArgs e) // hafızadaki sayıyı silmek için
        {
            if (gostergetextbox.Text != "")
            {
                hafiza = hafiza - double.Parse(gostergetextbox.Text);
            }
        }

        private void btn_mr_Click(object sender, EventArgs e) // hafızadaki sayıyı goster 
        {
            gostergetextbox.Text = System.Convert.ToString(hafiza);

        }

        private void btn_exit_Click(object sender, EventArgs e) // programdan çıkış yapmak için close butonu
        {
            DialogResult msx = MessageBox.Show("Çıkacak Misiniz?", "Çıkış Uyarısı!", MessageBoxButtons.YesNo);

            if (msx == DialogResult.Yes)
            {
                System.Environment.Exit(0);
            }
        }


        private void islem_yap(double gelensayi, string islem, double sonsayi = 0)
        {
            gecmislabel.Text = "";

         

            switch (islem)
            {
                case "Kare":
                    gecmislabel.Text = islem + "(" + System.Convert.ToString(gelensayi) + ")" + "=" + System.Convert.ToString(Math.Pow(gelensayi,2));
                    gostergetextbox.Text = System.Convert.ToString(Math.Pow(gelensayi, 2));
                    break;

                case "√":
                    gecmislabel.Text = islem + "(" + System.Convert.ToString(gelensayi) + ")" + "=" + System.Convert.ToString(Math.Sqrt(gelensayi));
                    gostergetextbox.Text = System.Convert.ToString(Math.Sqrt(gelensayi));
                    break;

                case "Tan":
                    gecmislabel.Text = islem + "(" + System.Convert.ToString(gelensayi) + ")" + "=" + System.Convert.ToString(Math.Tan(gelensayi));
                    gostergetextbox.Text = System.Convert.ToString(Math.Tan(gelensayi));
                    break;

                case "Cos":
                    gecmislabel.Text = islem + "(" + System.Convert.ToString(gelensayi) + ")" + "=" + System.Convert.ToString(Math.Cos(gelensayi));
                    gostergetextbox.Text = System.Convert.ToString(Math.Cos(gelensayi));
                    break;

                case "Sin":
                    gecmislabel.Text = islem + "(" + System.Convert.ToString(gelensayi) + ")" + "=" + System.Convert.ToString(Math.Sin(gelensayi));
                    gostergetextbox.Text = System.Convert.ToString(Math.Sin(gelensayi));
                    break;

                case "log":
                    gecmislabel.Text = islem + "(" + System.Convert.ToString(gelensayi) + ")" + "=" + System.Convert.ToString(Math.Log10(gelensayi));
                    gostergetextbox.Text = System.Convert.ToString(Math.Log10(gelensayi));
                    break;

                case "ln":
                    gecmislabel.Text = islem + "(" + System.Convert.ToString(gelensayi) + ")" + "=" + System.Convert.ToString(Math.Log(gelensayi));
                    gostergetextbox.Text = System.Convert.ToString(Math.Log(gelensayi));
                    break;

                case "PI":
                    gecmislabel.Text = islem + "(" + System.Convert.ToString(gelensayi) + ")" + "=" + System.Convert.ToString(Math.PI);
                    gostergetextbox.Text = System.Convert.ToString(Math.PI);
                    break;

                case "e":
                    gecmislabel.Text = islem + "(" + System.Convert.ToString(gelensayi) + ")" + "=" + System.Convert.ToString(Math.E);
                    gostergetextbox.Text = System.Convert.ToString(Math.E);
                    break;


                case "%":
                    gecmislabel.Text = islem + "(" + System.Convert.ToString(gelensayi) + ")" + "=" + System.Convert.ToString(gelensayi / 100);
                    gostergetextbox.Text = System.Convert.ToString(gelensayi / 100);
                    break;

                case "!":
                    gecmislabel.Text = "n(" + System.Convert.ToString(gelensayi) + ")" + islem + "=" + System.Convert.ToString(faktoryel(gelensayi));
                    gostergetextbox.Text = System.Convert.ToString(faktoryel(gelensayi)); //Sayımızı faktoryel fonksiyonuna göndererek hesaplıyoruz
                    break;



                case "mod":

                    if (sonsayi == 0)
                    {                         
                        ciftislemler(gelensayi, 0, simgeoperator);
                        
                    }
                    else
                    {                        
                        gecmislabel.Text = System.Convert.ToString(gelensayi) + " " + islem + " "+System.Convert.ToString(sonsayi)+"="+ System.Convert.ToString(gelensayi % sonsayi); 
                        gostergetextbox.Text = System.Convert.ToString(gelensayi % sonsayi);
                        sayi1 = 0;   
                    }  
                    break;


                case "+":

                    if (sonsayi == 0)
                    {
                        ciftislemler(gelensayi, 0, simgeoperator);

                    }
                    else
                    {
                        gecmislabel.Text = System.Convert.ToString(gelensayi) + " " + islem + " " + System.Convert.ToString(sonsayi) + "=" + System.Convert.ToString(String.Format("{0:0.##}", (gelensayi) + (sonsayi)));
                        gostergetextbox.Text = System.Convert.ToString((gelensayi) + (sonsayi));
                       
                        

                    }
                    break;


                case "-":

                    if (sonsayi == 0)
                    {
                        ciftislemler(gelensayi, 0, simgeoperator);

                    }
                    else
                    {
                        gecmislabel.Text = System.Convert.ToString(gelensayi) + " " + islem + " " + System.Convert.ToString(sonsayi) + "=" + System.Convert.ToString(gelensayi- sonsayi);
                        gostergetextbox.Text = System.Convert.ToString(gelensayi - sonsayi);
                       
                    }
                    break;

                case "*":

                    if (sonsayi == 0)
                    {
                        ciftislemler(gelensayi, 0, simgeoperator);

                    }
                    else
                    {
                        gecmislabel.Text = System.Convert.ToString(gelensayi) + " " + islem + " " + System.Convert.ToString(sonsayi) + "=" + System.Convert.ToString(gelensayi * sonsayi); 
                        gostergetextbox.Text = System.Convert.ToString(gelensayi * sonsayi);
                      
                    }
                    break;

                case "/":

                    if (sonsayi == 0)
                    {
                        ciftislemler(gelensayi, 0, simgeoperator);

                    }
                    else
                    {
                        gecmislabel.Text = System.Convert.ToString(gelensayi) + " " + islem + " " + System.Convert.ToString(sonsayi) +"="+ System.Convert.ToString(gelensayi / sonsayi); 
                        gostergetextbox.Text = System.Convert.ToString(gelensayi / sonsayi);
                        
                    }
                    break;


            }
        }
        private void esit_muamele()
        // diğer operatörler ikinci kez basılırsa eşit kabul etmek için 
        {
            try
            {
                if (sayi1 != 0 && double.Parse(gostergetextbox.Text) != 0 && gostergetextbox.TextLength > 0)
                {
                    ciftislemler(sayi1, double.Parse(gostergetextbox.Text), "=");
                }
            }

            catch
            {

            }
        }





        // textboxta sıfır değeri yoksa islemyap fonksiyonu çalışsın
        public void cifttus_kontrolu()
        {
            try
            {
                if (double.Parse(gostergetextbox.Text) != 0)
                {
                    islem_yap((double.Parse(gostergetextbox.Text)), simgeoperator);
                }
            }
            catch
            {

            }
        }

        //faktoriyel için kendini tekrarlayan iç içe recursive fonsiyon
        public double faktoryel(double number)
        {
            if (number == 1)
                return 1;
            else if (number == 0)
                return 1;
            else
                return number * faktoryel(number - 1); 
        }

        public void ciftislemler(double sayi_1,double sayi_2,string islem) // iki sayı arasında işlem yapmak için aşağıdaki fonksiyon yazıldı
        {

            if (islem !="=")
            { //ilk rakamdan sonra operator simgesine basılmışsa burayı çalıştır
                sayi1 = double.Parse(gostergetextbox.Text);
                gecmislabel.Text = System.Convert.ToString(sayi1) + " " + islem + " ";
                gostergetextbox.Text = "";
            }
            else
            {
                // ikinci rakam girilmiş ve eşittir basılmışsa git işlem yap     
                islem_yap(sayi1, simgeoperator, double.Parse(gostergetextbox.Text));
                sayi1 = 0;
            }            
        }

        private void formu_ortala() // program her açıldığında ekranın ortasında açılması için 
        {
            int genislik, yukseklik, bizim_en, bizim_yuk;
            genislik = Screen.PrimaryScreen.Bounds.Width; //bilgisayarın ekran çözünürlüğünün genişliğini alıyoruz
            yukseklik = Screen.PrimaryScreen.Bounds.Height;//bilgisayarın ekran çözünürlüğünün yüksekliğini alıyoruz
            bizim_en = 639; // değerler
            bizim_yuk = 480; // değerler 

            this.Location = new Point((int)((genislik - bizim_en) / 2), (int)((yukseklik - bizim_yuk) / 2));
            this.Size = new Size((int)((bizim_en)), (int)(bizim_yuk));
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void gostergetextbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
