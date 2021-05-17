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
    public class Personel
    {
        #region Private Properties
        private int _personelID;
        private string _tckn;
        private string _personelAd;
        private string _personelSoyad;
        private string _telefon;
        private string _departman;
        private string _adres;
        private string _durum;
        private string _iban;
        private double _sabitMaas;
        private string _girisTarih;
        private string _cikisTarih;
        private int _toplamRaporlu;
        private int _toplamUcretli;
        private int _ToplamUcretsiz;
        private double _toplamAlacak;
        private double _toplamBorc;
        #endregion
        #region Properties
        public int PersonelID
        {
            get { return _personelID; }
            set { _personelID = value; }
        }
        public string TCKN
        {
            get { return _tckn; }
            set { _tckn = value; }
        }
        public string Adres
        {
            get { return _adres; }
            set { _adres = value; }
        }
        public string PersonelAd
        {
            get { return _personelAd; }
            set { _personelAd = value; }
        }
        public string PersonelSoyad
        {
            get { return _personelSoyad; }
            set { _personelSoyad = value; }
        }
        public string Telefon
        {
            get { return _telefon; }
            set { _telefon = value; }
        }
        public string Departman
        {
            get { return _departman; }
            set { _departman = value; }
        }
        public string Durum
        {
            get { return _durum; }
            set { _durum = value; }
        }
        public string Iban
        {
            get { return _iban; }
            set { _iban = value; }
        }
        public double SabitMaas
        {
            get { return _sabitMaas ; }
            set { _sabitMaas = value; }
        }
        public string GirisTarihi
        {
            get { return _girisTarih; }
            set { _girisTarih = value; }
        }
        public string CikisTarihi
        {
            get { return _cikisTarih; }
            set { _cikisTarih = value; }
        }
        public int ToplamRaporlu
        {
            get { return _toplamRaporlu; }
            set { _toplamRaporlu = value; }
        }
        public int ToplamUcretli
        {
            get { return _toplamUcretli; }
            set { _toplamUcretli = value; }
        }
        public int ToplamUcretsiz
        {
            get { return _ToplamUcretsiz; }
            set { _ToplamUcretsiz = value; }
        }
        public double ToplamAlacak
        {
            get { return _toplamAlacak; }
            set { _toplamAlacak = value; }
        }
        public double ToplamBorc
        {
            get { return _toplamBorc; }
            set { _toplamBorc = value; }
        }
        #endregion
        #region Personel Sql Sorgular
        SqlConnection conn = new SqlConnection(Genel.connStr);
        public bool PersonelEkle(Personel p)
        {
            bool sonuc = false;
            SqlCommand cmd = new SqlCommand("insert into Tbl_Personel(TCKN,PersonelAdi,PersonelSoyadi,Telefon,Adres,Departman,Durum,IBAN,SabitMaas,GirisTarihi,CikisTarihi,GunlukMesai,ToplamRaporlu,ToplamUcretli,ToplamUcretsiz,ToplamAlacak,ToplamBorc) values(@TCKN,@PersonelAdi,@PersonelSoyadi,@Telefon,@Adres,@Departman,@Durum,@IBAN,@SabitMaas,@GirisTarihi,@CikisTarihi,@GunlukMesai,@ToplamRaporlu,@ToplamUcretli,@ToplamUcretsiz,@ToplamAlacak,@ToplamBorc)", conn);
            cmd.Parameters.Add("@TCKN", SqlDbType.VarChar).Value = p._tckn;
            cmd.Parameters.Add("@PersonelAdi", SqlDbType.VarChar).Value = p._personelAd;
            cmd.Parameters.Add("@PersonelSoyadi", SqlDbType.VarChar).Value = p._personelSoyad;
            cmd.Parameters.Add("@Telefon", SqlDbType.VarChar).Value = p._telefon;
            cmd.Parameters.Add("@Adres", SqlDbType.VarChar).Value = p._adres;
            cmd.Parameters.Add("@Departman", SqlDbType.VarChar).Value = p._departman;
            cmd.Parameters.Add("@Durum", SqlDbType.VarChar).Value = p._durum;
            cmd.Parameters.Add("@IBAN", SqlDbType.VarChar).Value = p._iban;
            cmd.Parameters.Add("@SabitMaas", SqlDbType.Money).Value = p._sabitMaas;
            cmd.Parameters.Add("@GirisTarihi", SqlDbType.DateTime).Value = p._girisTarih;
            cmd.Parameters.Add("@GirisTarihi", SqlDbType.DateTime).Value = Convert.ToDateTime("31:12.2199 00:00:00.000");
            if (conn.State==ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally{conn.Close(); }
            return sonuc;
        }
        public bool PersonelGuncelleWithLeft(Personel p)
        {
            bool Sonuc = false;
            SqlCommand cmd = new SqlCommand("Update Tbl_Personel set TCKN=@TCKN, PersonelAdi=@PersonelAdi, PersonelSoyadi=@PersonelSoyadi,Telefon=@Telefon,Adres=@Adres,Departman=@Departman,Durum=@Durum,IBAN=@IBAN,SabitMaas=@SabitMaas,GirisTarihi=@GirisTarihi,CikisTarihi=@CikisTarihi, where ID=@ID", conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = p._personelID;
            cmd.Parameters.Add("@TCKN", SqlDbType.VarChar).Value = p._tckn;
            cmd.Parameters.Add("@PersonelAdi", SqlDbType.VarChar).Value = p._personelAd;
            cmd.Parameters.Add("@PersonelSoyadi", SqlDbType.VarChar).Value = p._personelSoyad;
            cmd.Parameters.Add("@Telefon", SqlDbType.VarChar).Value = p._telefon;
            cmd.Parameters.Add("@Adres", SqlDbType.VarChar).Value = p._adres;
            cmd.Parameters.Add("@Departman", SqlDbType.VarChar).Value = p._departman;
            cmd.Parameters.Add("@Durum", SqlDbType.VarChar).Value = p._durum;
            cmd.Parameters.Add("@IBAN", SqlDbType.VarChar).Value = p._iban;
            cmd.Parameters.Add("@SabitMaas", SqlDbType.Money).Value = p._sabitMaas;
            cmd.Parameters.Add("@GirisTarihi", SqlDbType.DateTime).Value = Convert.ToDateTime(p._girisTarih);
            cmd.Parameters.Add("@CikisTarihi", SqlDbType.DateTime).Value = Convert.ToDateTime(p._cikisTarih);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
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
        public bool PersonelGuncelleWithoutLeft(Personel p)
        {
            bool Sonuc = false;
            SqlCommand cmd = new SqlCommand("Update Tbl_Personel set TCKN=@TCKN, PersonelAdi=@PersonelAdi, PersonelSoyadi=@PersonelSoyadi,Telefon=@Telefon,Adres=@Adres,Departman=@Departman,Durum=@Durum,IBAN=@IBAN,SabitMaas=@SabitMaas,GirisTarihi=@GirisTarihi,CikisTarihi=@CikisTarihi, where ID=@ID", conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = p._personelID;
            cmd.Parameters.Add("@TCKN", SqlDbType.VarChar).Value = p._tckn;
            cmd.Parameters.Add("@PersonelAdi", SqlDbType.VarChar).Value = p._personelAd;
            cmd.Parameters.Add("@PersonelSoyadi", SqlDbType.VarChar).Value = p._personelSoyad;
            cmd.Parameters.Add("@Telefon", SqlDbType.VarChar).Value = p._telefon;
            cmd.Parameters.Add("@Adres", SqlDbType.VarChar).Value = p._adres;
            cmd.Parameters.Add("@Departman", SqlDbType.VarChar).Value = p._departman;
            cmd.Parameters.Add("@Durum", SqlDbType.VarChar).Value = p._durum;
            cmd.Parameters.Add("@IBAN", SqlDbType.VarChar).Value = p._iban;
            cmd.Parameters.Add("@SabitMaas", SqlDbType.Money).Value = p._sabitMaas;
            cmd.Parameters.Add("@GirisTarihi", SqlDbType.DateTime).Value = Convert.ToDateTime(p._girisTarih);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
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
        public bool PersonelKontrol(string TCKN)
        {
            bool varMi = false;
            SqlCommand cmd = new SqlCommand("Select * From Tbl_Personel where TCKN=@TCKN", conn);
            cmd.Parameters.Add("@TCKN", SqlDbType.VarChar).Value = TCKN;
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
                varMi = true;
            dr.Close();
            conn.Close();
            return varMi;
        }
        public bool PersonelKontrol(string ID,string TCKN)
        {
            bool Varmi = false;
            SqlCommand cmd = new SqlCommand("SELECT * FROM Tbl_Personel where ID != @ID and TCKN=@TCKN",conn);
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;
            cmd.Parameters.Add("@TCKN", SqlDbType.VarChar).Value = TCKN;
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
                Varmi = true;
            dr.Close();
            conn.Close();
            return Varmi;
        }
        public void PersonelleriGetir(ListView liste)
        {
            liste.Items.Clear();
            SqlCommand cmd = new SqlCommand("SELECT ID,TCKN,PersonelAdi,PersonelSoyadi,Telefon,Adres,Departman,Durum from Tbl_Personel where Silindi=0", conn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
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
                    liste.Items[i].SubItems.Add(dr[7].ToString());
                    i++;
                }
            }
            dr.Close();
            conn.Close();
        }
        public void PersonelleriGetirForIzin(ListView liste)
        {
            liste.Items.Clear();
            SqlCommand cmd = new SqlCommand("Select ID,PersonelAdi,PersonelSoyadi,Telefon,Adres,ToplamRaporlu,ToplamUcretli,ToplamUcretsiz from Personel where Silindi=0", conn);
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
                    liste.Items[i].SubItems.Add(dr[7].ToString());
                    i++;
                }
            }
            dr.Close();
            conn.Close();
        }
        public void PersonelleriGetirForMesai(ListView liste)
        {
            liste.Items.Clear();
            SqlCommand cmd = new SqlCommand("SELECT ID,TCKN,PersonelAdi,PersonelSoyadi,Telefon,Adres,Departman,Durum from Tbl_Personel where Silindi=0", conn);
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                int i = 0;
                while (dr.Read())
                {
                    liste.Items.Add(dr[0].ToString());
                    liste.Items[i].SubItems.Add(dr[2].ToString());
                    liste.Items[i].SubItems.Add(dr[3].ToString());
                    liste.Items[i].SubItems.Add(dr[4].ToString());
                    liste.Items[i].SubItems.Add(dr[5].ToString());
                    i++;
                }
            }
            dr.Close();
            conn.Close();
        }
        public void PersonelleriGetir(int ID, Personel p)
        {
            SqlCommand cmd = new SqlCommand("Select TCKN,PersonelAdi,PersonelSoyadi,Telefon,Adres,Departman,Durum,CikisTarihi,GirisTarihi,IBAN,SabitMaas,ToplamRaporlu,ToplamUcretli,ToplamUcretsiz from Tbl_Personel where ID=@ID and Silindi=0", conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                p.TCKN = dr[0].ToString();
                p.PersonelAd = dr[1].ToString();
                p.PersonelSoyad = dr[2].ToString();
                p.Telefon = dr[3].ToString();
                p.Adres = dr[4].ToString();
                p.Departman = dr[5].ToString();
                p.Durum = dr[6].ToString();
                p.CikisTarihi = Convert.ToDateTime(dr[7].ToString()).ToShortDateString(); //tarih formatı GG.AA.YYYY
                p.GirisTarihi= Convert.ToDateTime(dr[8].ToString()).ToShortDateString(); //tarih formatı GG.AA.YYYY
                p.Iban = dr[9].ToString();
                p.ToplamRaporlu = Convert.ToInt32(dr[10]);
                p.ToplamUcretli= Convert.ToInt32(dr[11]);
                p.ToplamUcretsiz= Convert.ToInt32(dr[12]);
            }
            dr.Close();
            conn.Close();
        }
        public void PersonelleriGetirByArama(string ID, string TCKN, string Adi, string Soyadi,string Telefon, string Adres, string Departman, ListView liste)
        {
            liste.Items.Clear();
            SqlCommand cmd = new SqlCommand("Select ID, TCKN, PersonelAdi, PersonelSoyadi, Telefon, Adres, Departman, Durum from Personel where Silindi=0 and ID like @ID +'%' and TCKN like @TCKN + '%' and PersonelAdi like @Adi +'%' and PersonelSoyadi like @Soyadi +'%' and Telefon like @Telefon + '%' and Adres like @Adres + '%' and Departman like @Departman +'%'", conn);
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;
            cmd.Parameters.Add("@TCKN", SqlDbType.VarChar).Value = TCKN;
            cmd.Parameters.Add("@Adi", SqlDbType.VarChar).Value = Adi;
            cmd.Parameters.Add("@Soyadi", SqlDbType.VarChar).Value = Soyadi;
            cmd.Parameters.Add("@Telefon", SqlDbType.VarChar).Value = Telefon;
            cmd.Parameters.Add("@Adres", SqlDbType.VarChar).Value = Adres;
            cmd.Parameters.Add("@Departman", SqlDbType.VarChar).Value = Departman;
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
                    liste.Items[i].SubItems.Add(dr[7].ToString());
                    i++;
                }
            }
        }
        public void PersonelleriGetirByIzinArama(string Adi,string Soyadi, ListView liste)
        {
            liste.Items.Clear();
            SqlCommand cmd = new SqlCommand("Select ID, PersonelAdi, PersonelSoyadi, Telefon, Adres, Toplam Raporlu, Toplam Ucretli, ToplamUcretsiz from Tbl_Personel where Silindi=0 and PersonelAdi like @Adi +'%' and PersonelSoyadi like @Soyadi +'%'", conn);
            cmd.Parameters.Add("@Adi", SqlDbType.VarChar).Value = Adi;
            cmd.Parameters.Add("@Soyadi", SqlDbType.VarChar).Value = Soyadi;
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
                    liste.Items[i].SubItems.Add(dr[7].ToString());
                    i++;
                }
            }
            dr.Close();
            conn.Close();
        }
        public bool PersonelSil(int ID)
        {
            bool Sonuc = false;
            SqlCommand cmd = new SqlCommand("Update Tbl_Personel set Silindi=1 where ID=@ID", conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
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
        public bool IzinGunSayisiEkle(int ID, string IzinTipi, int Gun)
        {
            bool Sonuc = false;

            return Sonuc;
        }

        #endregion

        /*

         bir veri eklemek istediğinizde
        1 veya 0 döndürür
        Eğer 1 dönerse veri eklenir güncellenir silinir veri getirilir  veri tabanından executeNonQuery 1 - 0 SqlException Bunu görmek için sqlException hatası patlatıyoruz.
         */
    }
}
