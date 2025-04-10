using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Jenis karyawan (Tetap/Kontrak/Magang): ");
        string jenisKaryawan = Console.ReadLine().ToLower();

        Console.Write("Nama karyawan: ");
        string nama = Console.ReadLine();

        Console.Write("ID karyawan: ");
        string id = Console.ReadLine();

        Console.Write("Gaji pokok: ");
        double gajiPokok = Convert.ToDouble(Console.ReadLine());

        Karyawan karyawan; 

        if (jenisKaryawan == "tetap")
        {
            karyawan = new KaryawanTetap(nama, id, gajiPokok);
        }
        else if (jenisKaryawan == "kontrak")
        {
            karyawan = new KaryawanKontrak(nama, id, gajiPokok);
        }
        else if (jenisKaryawan == "magang")
        {
            karyawan = new KaryawanMagang(nama, id, gajiPokok);
        }
        else
        {
            Console.WriteLine("Jenis karyawan tidak valid.");
            return;
        }

        
        double gajiAkhir = karyawan.HitungGaji();
        Console.WriteLine($"Gaji akhir {nama} ({jenisKaryawan}): Rp {gajiAkhir:N2}");
    }
}

class Karyawan
{
    private string Nama { get; set; }
    private string ID { get; set; }
    private double GajiPokok { get; set; }

    public Karyawan(string nama, string id, double gajiPokok)
    {
        Nama = nama;
        ID = id;
        GajiPokok = gajiPokok;
    }

    public virtual double HitungGaji()
    {
        return GajiPokok;
    }
}

class KaryawanTetap : Karyawan
{
    private double BonusTetap = 50000;

    public KaryawanTetap(string nama, string id, double gajiPokok) : base(nama, id, gajiPokok)
    {
    }

    public override double HitungGaji()
    {
        return base.HitungGaji() + BonusTetap;
    }
}

class KaryawanKontrak : Karyawan
{
    private double PotonganKontrak = 200000;

    public KaryawanKontrak(string nama, string id, double gajiPokok) : base(nama, id, gajiPokok)
    {
    }

    public override double HitungGaji()
    {
        return base.HitungGaji() - PotonganKontrak;
    }
}

class KaryawanMagang : Karyawan
{
    public KaryawanMagang(string nama, string id, double gajiPokok) : base(nama, id, gajiPokok)
    {
    }

    public override double HitungGaji()
    {
        return base.HitungGaji();
    }
}
