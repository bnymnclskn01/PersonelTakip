using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MekaGelisim_PersonelTakip_WinForm.Sinif_Modulu
{
    public class Personel
    {
        private int _personelID;
        private string _tckn;
        private string _personelAd;
        private string _personelSoyad;
        private string _telefon;
        private string _departman;
        private string _durum;
        private string _iban;
        private double _SabitMaas;
        private string _girisTarih;
        private string _cikisTarih;
        private int _toplamRaporlu;
        private int _toplamUcretli;
        private int _ToplamUcretsiz;
        private double _toplamAlacak;
        private double _toplamBorc;


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
        #endregion
    }
}
