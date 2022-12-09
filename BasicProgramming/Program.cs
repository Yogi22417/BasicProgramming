namespace BasicProgramming;

class Program
{
    static string[] barang = { "Kursi Belajar", "Meja Belajar", "Kasur Anak", "Lampu Belajar" };
    static int[] harga = { 500000, 700000, 850000, 250000 };
    static int[] nomorbarang = {};
    static int[] jumlah = {};
    public static void Main(String[] args)
    {
        BerandaMenu();
    }

    static void BerandaMenu()
    {
        Boolean ulang = false;
            Console.WriteLine("Selamat Datang Di RukoPedia");
            Console.WriteLine("1. Lihat Katalog Barang");
            Console.WriteLine("2. Pesan Barang");
            Console.WriteLine("3. Keranjang");
            Console.WriteLine("4. Bersihkan Keranjang");
            Console.WriteLine("5. Checkout");
            Console.WriteLine("6. Keluar Aplikasi");
            Console.Write("Masukkan Pilihan : ");
            int pilih = Convert.ToInt32(Console.ReadLine());
            switch (pilih)
            {
                case 1:
                    Katalog();
                    break;
                case 2:
                    Beli();
                    break;
                case 3:
                    Keranjang();
                    BerandaMenu();
                    break;
                case 4:
                    Bersihkan();
                    break;
                case 5:
                    Checkout();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("-----------------");
                    Console.WriteLine("Pilihan Tidak Ada");
                BerandaMenu();
                    break;
            }
    }
    static void ListBarang()
    {
        Console.Clear();
        int no = 1;
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("|No | Nama Barang\t| Harga\t  |");
        Console.WriteLine("-----------------------------------");
        for (int i = 0; i < barang.Length; i++)
        {
            Console.WriteLine("|" + no++ + "  | " + barang[i] + "\t| " + harga[i] + "  |");
        }
        Console.WriteLine("-----------------------------------------");
    }
    static void Katalog()
    {
        ListBarang();
        Boolean ulang = false;
        do
        {
            Console.Write("Apakah Ingin Lanjut Untuk Membeli Barang ? ? y/n : ");
            string lanjut = Console.ReadLine().ToLower();
            switch (lanjut)
            {
                case "y":
                    Beli();
                    break;
                case "n":
                    BerandaMenu();
                    break;
                default:
                    Katalog();
                    break;
            }
        } while(ulang == true);
    }

    static void Beli()
    {
        Console.Clear();
        Boolean ulang = false;
        ListBarang();
        Console.Write("Ingin Membeli Nomor Berapa ? : ");
        int pilih_barang = Convert.ToInt32(Console.ReadLine())-1;
        Console.Write("Ingin Membeli Berapa Pcs ? : ");
        int pilih_jumlah = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("-----------------------");
        Console.WriteLine("Pembelian : ");
        Console.WriteLine("-----------------------");
        Console.WriteLine("Nama Barang \t= " + barang[pilih_barang]);
        Console.WriteLine("Harga Barang \t= " + harga[pilih_barang]);
        Console.WriteLine("Total Harga \t= " + jumlah_harga(harga[pilih_barang], pilih_jumlah));
        Console.WriteLine("-----------------------");
        Console.WriteLine("Apakah Pembelian Sudah Benar ? y/n");
        string lanjut = Console.ReadLine().ToLower();
        switch (lanjut)
            {
            case "y":
                nomorbarang = nomorbarang.Append(pilih_barang).ToArray();
                jumlah = jumlah.Append(pilih_jumlah).ToArray();
                Console.WriteLine("Apakah Ingin Membeli Barang Baru ? y/n");
                string beli_ulang = Console.ReadLine().ToLower();
                if (beli_ulang == "y")
                {
                    Beli();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Pembelian Sudah Selesai");
                    Console.WriteLine("-----------------------");
                    BerandaMenu();
                }
                break;
            case "n":
                Beli();
                break;
            default:
                Beli();
                break;
        }
    }

    static void Keranjang()
    {
        Console.Clear();
        int no = 1;
        if (nomorbarang.Length != 0)
        {
            Console.WriteLine("Barang Yang Sudah Dibeli");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("| No | Nama Barang\t| Harga\t  | Jumlah\t| Total Harga\t|");
            Console.WriteLine("-----------------------------------------------------------------");
            for (int i = 0; i < nomorbarang.Length; i++)
            {
                Console.WriteLine("| " + no++ + "  | " + barang[nomorbarang[i]] + "\t| " + harga[nomorbarang[i]] + "  | " + jumlah[i] + "\t\t| " + jumlah_harga(harga[nomorbarang[i]], jumlah[i])+"\t|");
            }
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("|\t\t\t\t   Jumlah Total | " + sum(nomorbarang, jumlah) + "\t|");
            Console.WriteLine("-----------------------------------------------------------------");
        } else
        {
            Console.WriteLine("Anda Belum Membeli Barang Apapun");
            BerandaMenu();
        }
    }

    static void Bersihkan()
    {
        Console.WriteLine("Apakah Yakin Ingin Membersihkan Keranjang ? y/n");
        string lanjut = Console.ReadLine().ToLower();
        switch (lanjut)
        {
            case "y":
                Console.Clear();
                Console.WriteLine("Anda Sudah Menghapus Semua Pembelian Anda");
                nomorbarang = new int[] { };
                jumlah = new int[] { };
                BerandaMenu();
                break;
            case "n":
                Console.Clear();
                Console.WriteLine("Anda Tidak Jadi Menghapus Keranjang Anda");
                BerandaMenu();
                break;
            default:
                BerandaMenu();
                break;
        }
    }

    static void Checkout()
    {
        Keranjang();
        int total = sum(nomorbarang, jumlah);
        Console.Write("Masukkan Jumlah Uang : ");
        int bayar = Convert.ToInt32(Console.ReadLine());
        if (bayar >= total)
        {
            Console.Clear();
            Console.WriteLine("Berikut Adalah Receipt Kamu");
            Keranjang();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("| Total Belanja : " + total + "\t |");
            Console.WriteLine("| Jumlah Uang   : " + bayar + "\t |");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("| Uang Kembali  : " + (bayar - total) + "\t |");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Ingin Melanjutkan Ke Halaman Utama ? y/n");
            string menu = Console.ReadLine();
            switch (menu)
            {
                case "y":
                    nomorbarang = new int[] { };
                    jumlah = new int[] { };
                    BerandaMenu();
                    break;
                case "n":
                    Console.Clear();
                    Console.WriteLine("Terima Kasih Sudah Membeli Di RukoPedia");
                    Environment.Exit(0);
                    BerandaMenu();
                    break;
                default:
                    BerandaMenu();
                    break;
            }
        } else
        {
            Console.Clear();
            Console.WriteLine("Mohon Maaf Uang Yang Anda Inputkan Kurang");
            Console.WriteLine("Ingin Melanjutkan Pembayaran ? y/n");
            string lanjut = Console.ReadLine();
            switch (lanjut)
            {
                case "y":
                    Console.Clear();
                    Checkout();
                    break;
                case "n":
                    Console.Clear();
                    Console.WriteLine("Anda Tidak Jadi Checkout");
                    BerandaMenu();
                    break;
                default:
                    BerandaMenu();
                    break;
            }
        }
    }

    static int jumlah_harga(int harga, int pcs)
    {
        int jumlah_harga = harga * pcs;
        return jumlah_harga;
    }

    static int sum(int[] array, int[] array2)
    {
        int jumlah = 0;
        for (int i = 0; i < array.Length; i++)
        {
            int sjumlah = jumlah_harga(harga[array[i]], array2[i]);
            jumlah += sjumlah;
        }
        return jumlah;
    }
}