using System;
using System.Collections.Generic;
using System.Linq;
using SistemParkir.Models;
using SistemParkir.Services;

namespace SistemParkir
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Selamat datang di Sistem Parkir!");

            Console.Write("Masukkan jumlah lot parkir: ");
            int totalLot = int.Parse(Console.ReadLine());
            var parkir = new Parkir(totalLot);

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Check-in Kendaraan");
                Console.WriteLine("2. Check-out Kendaraan");
                Console.WriteLine("3. Laporan Lot Terisi");
                Console.WriteLine("4. Laporan Lot Tersedia");
                Console.WriteLine("5. Laporan Ganjil/Genap");
                Console.WriteLine("6. Laporan Jenis Kendaraan");
                Console.WriteLine("7. Laporan Warna Kendaraan");
                Console.WriteLine("8. Keluar");

                Console.Write("\nPilih opsi: ");
                var pilihan = Console.ReadLine();

                switch (pilihan)
                {
                    case "1":
                        Console.Write("Nomor Polisi: ");
                        string nomorPolisi = Console.ReadLine();
                        Console.Write("Jenis Kendaraan (Mobil/Motor): ");
                        string jenis = Console.ReadLine();
                        Console.Write("Warna: ");
                        string warna = Console.ReadLine();

                        if (parkir.CheckInKendaraan(new Kendaraan(nomorPolisi, jenis, warna)))
                            Console.WriteLine("Kendaraan berhasil check-in.");
                        else
                            Console.WriteLine("Parkir penuh atau jenis kendaraan tidak valid.");
                        break;

                    case "2":
                        Console.Write("Nomor Polisi: ");
                        nomorPolisi = Console.ReadLine();

                        if (parkir.CheckOutKendaraan(nomorPolisi))
                            Console.WriteLine("Kendaraan berhasil check-out.");
                        else
                            Console.WriteLine("Kendaraan tidak ditemukan.");
                        break;

                    case "3":
                        Console.WriteLine($"Lot terisi: {parkir.LaporanLotTerisi()}");
                        break;

                    case "4":
                        Console.WriteLine($"Lot tersedia: {parkir.LaporanLotTersedia()}");
                        break;

                    case "5":
                        var (ganjil, genap) = parkir.LaporanNomorPolisiGanjilGenap();
                        Console.WriteLine($"Ganjil: {ganjil}, Genap: {genap}");
                        break;

                    case "6":
                        var (mobil, motor) = parkir.LaporanJenisKendaraan();
                        Console.WriteLine($"Mobil: {mobil}, Motor: {motor}");
                        break;

                    case "7":
                        var warnaLaporan = parkir.LaporanWarnaKendaraan();
                        foreach (var warnaItem in warnaLaporan)
                            Console.WriteLine($"{warnaItem.Key}: {warnaItem.Value}");
                        break;

                    case "8":
                        Console.WriteLine("Terima kasih telah menggunakan sistem parkir.");
                        return;

                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }
            }
        }
    }
}
