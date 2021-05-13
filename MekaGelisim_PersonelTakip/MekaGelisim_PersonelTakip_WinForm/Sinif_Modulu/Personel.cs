using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private string _adres
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
        public bool PersonelTamSil(int ID)
        {
            bool Sonuc = false;
            SqlCommand cmd = new SqlCommand("Delete From Tbl_Personel where ID=@ID", conn);
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
        #endregion

        /*

         bir veri eklemek istediğinizde
        1 veya 0 döndürür
        Eğer 1 dönerse veri eklenir güncellenir silinir veri getirilir  veri tabanından executeNonQuery 1 - 0 SqlException Bunu görmek için sqlException hatası patlatıyoruz.
         */
    }
}
