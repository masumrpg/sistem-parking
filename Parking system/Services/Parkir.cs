using SistemParkir.Models;

namespace SistemParkir.Services;

public class Parkir
    {
        private readonly List<Lot> _lots;

        public Parkir(int totalLot)
        {
            _lots = Enumerable.Range(1, totalLot).Select(i => new Lot(i)).ToList();
        }

        public bool CheckInKendaraan(Kendaraan kendaraan)
        {
            var lotKosong = _lots.FirstOrDefault(lot => !lot.IsOccupied);
            if (lotKosong == null || (kendaraan.JenisKendaraan != "Mobil" && kendaraan.JenisKendaraan != "Motor"))
                return false;

            return lotKosong.CheckIn(kendaraan);
        }

        public bool CheckOutKendaraan(string nomorPolisi)
        {
            var lotTerisi = _lots.FirstOrDefault(lot => lot.IsOccupied && lot.KendaraanParkir.NomorPolisi == nomorPolisi);
            return lotTerisi?.CheckOut() ?? false;
        }

        public int LaporanLotTerisi() => _lots.Count(lot => lot.IsOccupied);

        public int LaporanLotTersedia() => _lots.Count(lot => !lot.IsOccupied);

        public (int ganjil, int genap) LaporanNomorPolisiGanjilGenap()
        {
            int ganjil = 0, genap = 0;

            foreach (var lot in _lots.Where(lot => lot.IsOccupied))
            {
                var nomorPolisi = lot.KendaraanParkir.NomorPolisi;

                var angka = string.Concat(nomorPolisi.Where(char.IsDigit)); // Gabungkan semua digit
                if (int.TryParse(angka, out int nomorAkhir)) // Parse angka dari nomor polisi
                {
                    if (nomorAkhir % 2 == 0)
                        genap++;
                    else
                        ganjil++;
                }
            }

            return (ganjil, genap);
        }


        public (int mobil, int motor) LaporanJenisKendaraan()
        {
            int mobil = _lots.Count(lot => lot.IsOccupied && lot.KendaraanParkir.JenisKendaraan == "Mobil");
            int motor = _lots.Count(lot => lot.IsOccupied && lot.KendaraanParkir.JenisKendaraan == "Motor");
            return (mobil, motor);
        }

        public Dictionary<string, int> LaporanWarnaKendaraan()
        {
            return _lots
                .Where(lot => lot.IsOccupied)
                .GroupBy(lot => lot.KendaraanParkir.Warna)
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }