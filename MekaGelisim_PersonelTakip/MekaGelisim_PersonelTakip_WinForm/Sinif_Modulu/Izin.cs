using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MekaGelisim_PersonelTakip_WinForm.Sinif_Modulu
{
    public class Izin
    {
        #region Private Properties
        private int _izinID;
        private int _personelID;
        private string _izinTipi;
        private double _izinGunSayisi;
        private string _izinBaslangic;
        private string _izinBitis;
        #endregion
        #region Public Properties
        public int IzinID
        {
            get { return _izinID; }
            set { _izinID = value; }
        }
        public int PersonelID
        {
            get { return _personelID; }
            set { _personelID = value; }
        }
        public string IzinTipi
        {
            get { return _izinTipi; }
            set { _izinTipi = value; }
        }
        public double IzinGunSayisi
        {
            get { return _izinGunSayisi; }
            set { _izinGunSayisi = value; }
        }
        public string IzinBaslangic
        {
            get { return _izinBaslangic; }
            set { _izinBaslangic = value; }
        }
        public string IzinBitis
        {
            get { return _izinBitis; }
            set { _izinBitis = value; }
        }
        #endregion
        #region Connection
        SqlConnection conn = new SqlConnection(Genel.connStr);
        #endregion
        #region SQL SORGULAR
        public void IzinlerGetir(int ID, ListView liste)
        {
            liste.Items.Clear();
            SqlCommand cmd = new SqlCommand("Select ID,PersonelAdi,PersonelSoyadi,İzinTipi,İzinGunSayisi,İzinBaslangic,İzinBitis from Tbl_Personel p inner join Tbl_IzinHareketleri ih on p.ID=ih.PersonelID where ih.PersonelID=@ID and ih.Silindi=0", conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            if (conn.State==ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                int i = 0;
                while (dr.Read())
                {
                    liste.Items.Add(dr[0].ToString());
                    liste.Items[i].SubItems.Add(dr[1].ToString());
                    liste.Items[i].SubItems.Add(dr[2].ToString());
                    liste.Items[i].SubItems.Add(dr[3].ToString());
                    liste.Items[i].SubItems.Add(dr[4].ToString());
                    liste.Items[i].SubItems.Add(dr[5].ToString());
                    liste.Items[i].SubItems.Add(dr[6].ToString());
                    i++;
                }
            }
            dr.Close();
            conn.Close();
        }
        public void IzinlerGetir(ListView liste)
        {
            liste.Items.Clear();
            SqlCommand cmd = new SqlCommand("Select ID,PersonelAdi,PersonelSoyadi,İzinTipi,İzinGunSayisi,İzinBaslangic,İzinBitis from Tbl_IzinHareketleri ih inner join Tbl_Personel p on ih.PersonelID=@p.ID ih.Silindi=0", conn);
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                int i = 0;
                while (dr.Read())
                {
                    liste.Items.Add(dr[0].ToString());
                    liste.Items[i].SubItems.Add(dr[1].ToString());
                    liste.Items[i].SubItems.Add(dr[2].ToString());
                    liste.Items[i].SubItems.Add(dr[3].ToString());
                    liste.Items[i].SubItems.Add(dr[4].ToString());
                    liste.Items[i].SubItems.Add(dr[5].ToString());
                    liste.Items[i].SubItems.Add(dr[6].ToString());
                    i++;
                }
            }
            dr.Close();
            conn.Close();
        }
        public int IzinIDOlustur()
        {
            int ID = 0;
            SqlCommand cmd = new SqlCommand("Select max(ID) from Tbl_IzinHareketleri", conn);
            if (cmd.ExecuteScalar().ToString() == "")
                ID = 1;
            else
            {
                ID = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            }
            return ID;
        }
        public bool IzinKontrol(int ID, string Baslangic, string Bitis)
        {
            bool Varmi = false;
            SqlCommand cmd = new SqlCommand("Select * From Tbl_IzinHareketleri where PersonelID=@ID and IzinBaslangic=@Baslangic and IzinBitis=@Bitis", conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            cmd.Parameters.Add("@Baslangic", SqlDbType.VarChar).Value = Baslangic;
            cmd.Parameters.Add("@Bitis", SqlDbType.VarChar).Value = Bitis;
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
                Varmi = true;
            dr.Close();
            conn.Close();
            return Varmi;
        }
        public bool IzinKontrol(int ID, string IzinTipi , string Baslangic, string Bitis)
        {
            bool Varmi = false;
            SqlCommand cmd = new SqlCommand("Select * From Tbl_IzinHareketleri where PersonelID=@ID and IzinTipi=@Tipi and IzinBaslangic=@Baslangic and IzinBitis=@Bitis", conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            cmd.Parameters.Add("@Tipi", SqlDbType.VarChar).Value = IzinTipi;
            cmd.Parameters.Add("@Baslangic", SqlDbType.VarChar).Value = Baslangic;
            cmd.Parameters.Add("@Bitis", SqlDbType.VarChar).Value = Bitis;
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
                Varmi = true;
            dr.Close();
            conn.Close();
            return Varmi;
        }
        public bool IzinSil(int ID)
        {
            bool Sonuc = false;
            SqlCommand cmd = new SqlCommand("Update Tbl_IzinHareketleri set Silindi=1 where ID=@ID", conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return Sonuc;
        }
        #endregion
    }
}
