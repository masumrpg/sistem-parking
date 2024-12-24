namespace SistemParkir.Models;

public class Kendaraan
{
    public string NomorPolisi { get; set; }
    public string JenisKendaraan { get; set; }  
    public string Warna { get; set; }
    public DateTime WaktuMasuk { get; set; }

    public Kendaraan(string nomorPolisi, string jenisKendaraan, string warna)
    {
        NomorPolisi = nomorPolisi;
        JenisKendaraan = jenisKendaraan;
        Warna = warna;
        WaktuMasuk = DateTime.Now;
    }
}