using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreGiris.Services
{
    // bu servis, bize bir adet rastgele seçilmiş rakam sağlar.
    public class LuckyNumberService
    {
        // ilk oluşturulurken kullanılıp bidaha bidaha oluşturulmaması
        private readonly static Random rnd = new Random();
        //viewbag lı
        private static LuckyNumberService lns = new LuckyNumberService();
                                        //dışarıdan ayarlanamasın
        public int LuckyNumber { get; private set; }
       
        public LuckyNumberService()
        {

            LuckyNumber = rnd.Next(10);
        }
    }
}
