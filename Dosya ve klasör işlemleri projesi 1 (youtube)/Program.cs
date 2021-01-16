using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace Dosya_ve_klasör_işlemleri_projesi_1__youtube_
{
    class Program
    {
        static void Main(string[] args)
        {   Basadön:
            Console.WriteLine("1-Yeni öğrenci kaydı");
            Console.WriteLine("2-Öğrenci Bilgilerini güncelleme");
            Console.WriteLine("3-Öğrenci kaydı silme");
            Console.WriteLine("4-Öğrenci sınıf değişikliği");
            Console.WriteLine("5-Çıkış");

            Console.WriteLine("Seçim yapınız [1,2,3,4,5]");
            string seçim = Console.ReadLine();
            string Ad,Sınıf,ogreno,sınıfyolu, ogrencinoyolu;
            switch (seçim)
            {
                case "1":
                    yeniden:
                    Console.WriteLine("kayıt olunacak Öğrencinin sınıfını giriniz:");
                    Sınıf = Console.ReadLine();
                    Console.WriteLine("kayıt olunacak Öğrenci no giriniz:");
                    ogreno = Console.ReadLine();
                    sınıfyolu = @"c:\okul\" + Sınıf;
                    ogrencinoyolu=@"c:\okul\"+Sınıf + "\\" + ogreno;
                    if (System.IO.Directory.Exists(sınıfyolu) == true && System.IO.Directory.Exists(ogrencinoyolu) == false) 
                    {
                        System.IO.Directory.CreateDirectory(ogrencinoyolu);
                        string dosyaadı =ogreno + ".txt";
                        string hedefsınıfyolu = System.IO.Path.Combine(ogrencinoyolu, dosyaadı);
                        System.IO.File.Create(hedefsınıfyolu).Close();
                            
                        Console.WriteLine("{0}Numaralı Öğrenciye ait dosya oluşmuştur.",ogreno);
                        Console.WriteLine("Öğrenci Adını giriniz:");
                        Ad = Console.ReadLine();
                        Console.WriteLine("Öğrencinin Soyadını giriniz:");
                        string soyad = Console.ReadLine();
                        Console.WriteLine("Öğrencinin Cinsiyetini giriniz:");
                        string cinsiyet = Console.ReadLine();
                        Console.WriteLine("Öğrenci telefon numarasını giriniz:");
                        string telno = Console.ReadLine();
                        Console.WriteLine("Öğrencini Adresini giriniz:");
                        string adres = Console.ReadLine();

                        string[] dizi = { "Öğrenci adı:" + Ad, "Öğrenci Soyadı:" + soyad, "Öğrenci cinsiyeti:" + cinsiyet, "Öğrenci Telefon numarası:" + telno, "Öğrenci adresi:" + adres };
                        System.IO.File.WriteAllLines(@"c:\okul\" + Sınıf + "\\" + ogreno + "\\" + ogreno + ".txt", dizi);
                        Console.WriteLine("Öğrenci Bilgileriniz başarıyla kaydedilmiştit.");
                        goto yeniden;
                        
                    }
                    if (System.IO.Directory.Exists(sınıfyolu)==false)
                    {
                        Console.Clear();
                        Console.WriteLine("{0}Bu sınıf bulunamadı", Sınıf);
                        goto yeniden;
                    }
                    if (System.IO.Directory.Exists(ogrencinoyolu)==true)
                    {
                        Console.Clear();
                        Console.WriteLine("{1}Sınıfında {0}Numaralı öğrenci zaten kayıtlı!", ogreno,Sınıf);
                        goto yeniden;
                    }
                    break;

                case "2":
                    Console.WriteLine("Öğrenci no giriniz:");
                    ogreno = Console.ReadLine();
                    System.IO.DirectoryInfo klasörbilgisi = new System.IO.DirectoryInfo("c:\\okul");
                    System.IO.FileInfo[] dosyalar = klasörbilgisi.GetFiles(ogreno + ".txt", System.IO.SearchOption.AllDirectories);
                    int adet = dosyalar.Count();

                    if (adet>0)
                    {
                        string öğrencidosyayolu = dosyalar[0].DirectoryName;
                        string öğrencidosyaadı = ogreno + ".txt";
                        string hedefdosyayolu = System.IO.Path.Combine(öğrencidosyayolu, öğrencidosyaadı);
                        string[] öğrencibilgileri = System.IO.File.ReadAllLines(hedefdosyayolu);
                        foreach (string satırlar in öğrencibilgileri)
                        {
                            Console.WriteLine(satırlar);
                        }
                    
                güncelle:
                    Console.WriteLine("1-Telefon no");
                    Console.WriteLine("2-Adres");
                    Console.WriteLine("Hangi Bilgi güncellenecektir");
                    string guncellememenusu = Console.ReadLine();
                        if (guncellememenusu == "1")
                        {
                            Console.WriteLine("Yeni bir telefon no giriniz:");
                            öğrencibilgileri[3] = "Öğrenci Telefon numarası:" + Console.ReadLine();
                            System.IO.File.WriteAllLines(hedefdosyayolu, öğrencibilgileri);
                            Console.WriteLine("Öğrencinin telefonu güncellenmiştir.");
                            foreach (string güncelleme in öğrencibilgileri)
                            {
                                Console.WriteLine(güncelleme);
                            }
                        tekrar:
                            Console.WriteLine("Başka bilgi güncellenecekmi(e veya h cevap veriniz):");
                            string karar = Console.ReadLine();
                            if (karar == "e")
                            {
                                goto güncelle;
                            }
                            if (karar == "h")
                            {
                                Console.WriteLine("İşleminiz tamamlanmıltır.");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Yanlış birgiriş yaptınız tekrar deneyiniz.");
                                goto tekrar;
                            }
                        }
                        if (guncellememenusu=="2")
                        {
                            Console.WriteLine("Yeni adres bilgisi giriniz:");
                            
                            öğrencibilgileri[4] = "Öğrenci adresi:"+ Console.ReadLine();
                            System.IO.File.WriteAllLines(hedefdosyayolu, öğrencibilgileri);
                            Console.WriteLine("Öğrenci adres bilgileriniz güncellenmiştir");
                            foreach (string satırlar in öğrencibilgileri)
                            {
                                Console.WriteLine(satırlar);
                            }
                        baş:
                            Console.WriteLine("Başka biri işlem yapmak istiyormusunuz(e veya h veriniz ):");
                            string karar2 = Console.ReadLine();
                           if (karar2=="e")
                            {
                                goto güncelle;
                            }
                            else if (karar2=="h")
                            {
                                Console.WriteLine(" güncelleme İşleminiz tamamlanmıştır.");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Yanlış giriş yaptınız!");
                                goto baş;
                            }

                        }
                    }
                    break;
                case "3":
                    Console.WriteLine("Öğrenci no giriniz:");
                    ogreno = Console.ReadLine();
                    System.IO.DirectoryInfo silinecekklasörbilgisi = new System.IO.DirectoryInfo("c:\\okul");
                    System.IO.FileInfo[] dosyalar1 = silinecekklasörbilgisi.GetFiles(ogreno + ".txt", System.IO.SearchOption.AllDirectories);//System.IO.SearchOption.AllDirectories alt klasörlerde aransınmı yı kontrolediyor.
                    int bulunandosyaadedi = dosyalar1.Count();//dizinin elemansayısı count=miktar.
                    if (bulunandosyaadedi>0)
                    {
                        string silinecekklasöyolu = dosyalar1[0].DirectoryName;
                        Console.WriteLine(silinecekklasöyolu);
                        string[] klasördizisi = silinecekklasöyolu.Split('\\');
                        Dön:
                        Console.WriteLine("{0} sınıfındaki {1} numaralı öğrenciyi silmek istiyormusunuz(e veya h ):",klasördizisi[2],ogreno);
                        string silmeonay = Console.ReadLine().ToUpper();
                        if (silmeonay=="E")
                        {
                            System.IO.Directory.Delete(silinecekklasöyolu,true);//dzin doluysa true ekle
                            Console.WriteLine("{0} sınıfındaki {1} numaralı öğrenci silinmiştir", klasördizisi[2], ogreno);
                            goto Basadön;
                           
                        }
                        else if (silmeonay=="H")
                        {
                            Console.Clear();
                            Console.WriteLine("Silme işlemi iptal edilmiştir .");
                            goto Basadön;

                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Hatalı giriş yaptınız.");
                            goto Dön;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Okulda {0} Numaralı öğrenci kaydı yotur. ", ogreno);
                        goto Basadön;

                    }



                    break;
                case "4":
                    Console.WriteLine("Öğrenci No giriniz:");
                    ogreno = Console.ReadLine();
                    System.IO.DirectoryInfo taşınacakklasörbilgisi = new System.IO.DirectoryInfo("c:\\okul");
                    System.IO.FileInfo[] bulunandosyalar = taşınacakklasörbilgisi.GetFiles(ogreno+".txt",System.IO.SearchOption.AllDirectories);
                    int dosyadedi = bulunandosyalar.Count();
                    if (dosyadedi>0)
                    {
                        string taşınacakklasöryolu = bulunandosyalar[0].DirectoryName;
                        string[] klasörler = taşınacakklasöryolu.Split('\\');
                        //foreach (string yazdırma in klasörler)
                        //{
                        //    Console.WriteLine(yazdırma);//Kaçıncı eleman olduğunu bulmak için
                        //}
                        Console.WriteLine("{0} sınıfındaki {1} numaralı öğrenci hangi sınıfa taşınacaktır:",klasörler[2],ogreno);
                        string klasöradı = Console.ReadLine();
                        if (System.IO.Directory.Exists("c:\\okul"+"\\"+ klasöradı)==true)
                        {
                            string hedefklasöryolu = @"c:\okul" + "\\" + klasöradı + "\\" + ogreno;
                            System.IO.Directory.Move(taşınacakklasöryolu, hedefklasöryolu);
                            Console.Clear();
                            Console.WriteLine("{0}sınıfındaki {1} numaralı öğrenci {2}sınıfına taşıma işlemi gerçekleşmiştir.",klasörler[2],ogreno,klasöradı);
                            goto Basadön;

                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Girdiğniz {0}sınıfı okulumuzda bulunmamaktadır.", klasöradı);
                            goto Basadön;
                        }

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("{0} numaralı öğrenci okulumuzda kayıtlıdeğildir.", ogreno);
                        goto Basadön;
                    }
                    break;
                case "5":
                    Environment.Exit(0);


                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Yanlış seçim yaptınız.");
                    goto Basadön;
                    break;








            }


            Console.ReadKey();
        }
    }
}
