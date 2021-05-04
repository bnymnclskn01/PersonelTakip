using MekaGelisim_PersonelTakip_WinForm.Sinif_Modulu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MekaGelisim_PersonelTakip_WinForm.Giris_Modulu
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        public static bool Sonuc = false;
        SqlConnection conn = new SqlConnection(Genel.connStr);
        private void btn_GirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select Username, UserPassword from Tbl_Admin", conn);
            if (conn.State == ConnectionState.Closed) 
            {
                conn.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            bool Adi = false;
            while (dr.Read())
            {
                if (txtKulAdi.Text.Trim() == dr["Username"].ToString() && txtSifre.Text.Trim() == dr["UserPassword"].ToString())
                {
                    Sonuc = true;
                }
                else if (txtKulAdi.Text.Trim() == dr["Username"].ToString() && txtSifre.Text.Trim() == dr["UserPassword"].ToString())
                {
                    Adi = true;
                }
            }
            dr.Close();
            conn.Close();
            if (Sonuc)
            {
                MessageBox.Show("Başarılı Giriş Yaptınız", "Başarılı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Anasayfa_Modulu.Anasayfa a1 = new Anasayfa_Modulu.Anasayfa();
                a1.Show();
                this.Hide();
            }
            else if (Adi == true && Sonuc == false)
            {
                MessageBox.Show("Yanlış Giriş Yaptınız", "Yanlış Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Yanlış Giriş Yaptınız", "Yanlış Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
