using System;
using System.Collections;

namespace CSLab02
{
    struct MatHang
    {
        public int MaMH;
        public string TenMH;
        public int SoLuong;
        public float DonGia;

        public MatHang(int MaMH, string TenMH, int SoLuong, float DonGia)
        {
            this.MaMH = MaMH;
            this.TenMH = TenMH;
            this.SoLuong = SoLuong;
            this.DonGia = DonGia;
        }

        public float ThanhTien()
        {
            return SoLuong * DonGia;
        }
    }

    class Program
    {
        static void ThemMatHang(Hashtable danhsach, MatHang m)
        {
            if (!danhsach.ContainsKey(m.MaMH))
            {
                danhsach.Add(m.MaMH, m);
            }
            else
            {
                Console.WriteLine("Loi: Ma mat hang nay da ton tai!");
            }
        }

        static bool TimMatHang(Hashtable danhsach, int MaMH)
        {
            return danhsach.ContainsKey(MaMH);
        }

        static void XoaMatHang(Hashtable danhsach, int MaMH)
        {
            if (danhsach.ContainsKey(MaMH))
            {
                danhsach.Remove(MaMH);
            }
        }

        static void XuatDanhSach(Hashtable danhsach)
        {
            Console.WriteLine("\n--- DANH SACH MAT HANG ---");
            Console.WriteLine("{0,-10} | {1,-20} | {2,-10} | {3,-10} | {4,-15}", "Ma MH", "Ten MH", "So Luong", "Don Gia", "Thanh Tien");

            foreach (DictionaryEntry item in danhsach)
            {
                MatHang m = (MatHang)item.Value;
                Console.WriteLine("{0,-10} | {1,-20} | {2,-10} | {3,-10} | {4,-15}",
                                  m.MaMH, m.TenMH, m.SoLuong, m.DonGia, m.ThanhTien());
            }
            Console.WriteLine("--------------------------");
        }

        static void Main(string[] args)
        {
            Hashtable danhSach = new Hashtable();
            string tiepTuc = "y";

            while (tiepTuc.ToLower() == "y")
            {
                Console.WriteLine("\nNhap thong tin mat hang:");
                Console.Write("Ma mat hang: ");
                int maMH = int.Parse(Console.ReadLine());

                Console.Write("Ten mat hang: ");
                string tenMH = Console.ReadLine();

                Console.Write("So luong: ");
                int soLuong = int.Parse(Console.ReadLine());

                Console.Write("Don gia: ");
                float donGia = float.Parse(Console.ReadLine());

                MatHang m = new MatHang(maMH, tenMH, soLuong, donGia);
                ThemMatHang(danhSach, m);

                Console.Write("Ban co muon tiep tuc nhap khong? (y/n): ");
                tiepTuc = Console.ReadLine();
            }

            XuatDanhSach(danhSach);

            Console.Write("\nNhap ma mat hang can tim va xoa: ");
            int maTimKiem = int.Parse(Console.ReadLine());

            if (TimMatHang(danhSach, maTimKiem))
            {
                Console.WriteLine($"Da tim thay mat hang co ma {maTimKiem}. Dang xoa...");
                XoaMatHang(danhSach, maTimKiem);

                Console.WriteLine("\nDanh sach sau khi xoa:");
                XuatDanhSach(danhSach);
            }
            else
            {
                Console.WriteLine($"Khong tim thay mat hang co ma {maTimKiem}.");
            }

            Console.ReadKey();
        }
    }
}