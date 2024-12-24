# Sistem Parkir

Sistem Parkir adalah aplikasi berbasis .NET untuk mengelola parkir kendaraan tanpa antarmuka pengguna (console-based). Aplikasi ini mendukung operasi check-in, check-out, dan laporan terkait lot parkir.

## Fitur Utama

1. **Check-In Kendaraan**
    - Mendukung kendaraan jenis **Mobil** dan **Motor**.
    - Mencatat informasi kendaraan (nomor polisi, warna, waktu masuk).
    - Menentukan lot parkir secara otomatis berdasarkan ketersediaan.

2. **Check-Out Kendaraan**
    - Membebaskan lot parkir yang sudah terisi.
    - Menghitung biaya parkir berdasarkan durasi parkir.

3. **Laporan**
    - **Jumlah lot terisi dan tersedia**.
    - **Jumlah kendaraan berdasarkan nomor polisi ganjil/genap**.
    - **Jumlah kendaraan berdasarkan jenis (Mobil/Motor)**.
    - **Jumlah kendaraan berdasarkan warna**.

4. **Validasi**
    - Memastikan hanya kendaraan yang valid dapat masuk.
    - Menampilkan pesan kesalahan jika parkir penuh atau data kendaraan tidak valid.