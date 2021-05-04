using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MekaGelisim_PersonelTakip_WinForm.Sinif_Modulu
{
    public class Genel
    {
        public static bool izinAcikmi = false; // Her zaman Kapalı Olabilir Ana Dağıcı Ben isem
        public static bool mesaiAcikmi = false; // Her zaman Kapalı Olabilir Ana Dağıcı Ben isem
        public static bool personelAcikmi = false;
        public static bool maasAcikmi = false;  // Her zaman Kapalı Olabilir Ana Dağıcı Ben isem
        public static bool primAcikmi = false; // Her zaman Kapalı Olabilir Ana Dağıcı Ben isem
        //Data Source=DESKTOP-C39NLVL\\MEKASERVER;Initial Catalog=PersonelTakip;Integrated Security=true"
        public static string connStr = "Data Source=DESKTOP-C39NLVL\\MEKASERVER;initial catalog=PersonelTakip;integrated security=True;";
    }
}
