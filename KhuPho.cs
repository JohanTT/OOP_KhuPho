using System;
using System.Collections.Generic;

namespace OOPGap
{
    public class Nguoi
    {
        #region Nguoi Fields
        private string nHoTen;
        private DateTime nNgaySinh;
        private string nNoiSinh;
        private string nNgheNghiep;
        private string nDiaChi;
        #endregion

        #region Nguoi Constructor
        public Nguoi()
        {
            nHoTen = "null";
            nNgaySinh = new DateTime(2000, 1, 1);
            nNoiSinh = "null";
            nNgheNghiep = "null";
            nDiaChi = "null";
        }

        public Nguoi(string hoten, DateTime ngaysinh, string noisinh, string nghenghiep, string diachi)
        {
            nHoTen = hoten;
            nNgaySinh = ngaysinh;
            nNoiSinh = noisinh;
            nNgheNghiep = nghenghiep;
            nDiaChi = diachi;
        }
        #endregion

        #region get - set Nguoi 
        public string HoTen
        {
            get { return nHoTen; }
            set { nHoTen = value; }
        }
        public DateTime NgaySinh
        {
            get { return nNgaySinh; }
            set { nNgaySinh = value; }
        }
        public string NoiSinh
        {
            get { return nNoiSinh; }
            set { nNoiSinh = value; }
        }
        public string NgheNghiep
        {
            get { return nNgheNghiep; }
            set { nNgheNghiep = value; }
        }
        public string DiaChi
        {
            get { return nDiaChi; }
            set { nDiaChi = value; }
        }
        public int LayTuoi
        {
            get { return DateTime.Today.Year - NgaySinh.Year; }
            set { LayTuoi = value; }
        }
        #endregion

        #region Xuat Nguoi
        public virtual void Xuat()
        {
            Console.WriteLine("Ho ten: {0}\nNgay sinh: {1}\nNoi sinh: {2}\nNghe nghiep: {3}\nDia chi: {4}", 
                HoTen, NgaySinh.ToString("dd/MM/yyyy"), NoiSinh, NgheNghiep, DiaChi);
            Console.ReadKey();
        }
        #endregion

        #region Nhap Nguoi
        public virtual void Nhap()
        {
            Console.Write("Nhap ho ten: ");
            HoTen = Console.ReadLine();

            Console.Write("Nhap ngay sinh (MM/dd/yyyy): ");
            NgaySinh = DateTime.Parse(Console.ReadLine());

            Console.Write("Nhap noi sinh: ");
            NoiSinh = Console.ReadLine();

            Console.Write("Nhap nghe nghiep: ");
            NgheNghiep = Console.ReadLine();

            Console.Write("Nhap dia chi: ");
            DiaChi = Console.ReadLine();
        }
        #endregion
    }

    public class GiaDinh : Nguoi
    {
        #region GiaDinh Fields
        private int nSoLuong; // Lấy số lượng thành viên trong gia đình làm số lượng phần tử mảng
        public Nguoi[] Family;
        #endregion

        #region GiaDinh Constructor
        public GiaDinh()
        {
            nSoLuong = 0;
            Family = new Nguoi[nSoLuong];
        }
        public GiaDinh(int tv)
        {
            nSoLuong = tv;
            Family = new Nguoi[nSoLuong];
        }
        #endregion

        #region Get - Set GiaDinh
        public int SoLuong
        {
            get { return nSoLuong; }
            set { nSoLuong = value; }
        }

        public Nguoi this[int index]
        {
            get { return Family[index]; }
            set { Family[index] = value; }
        }
        #endregion

        // lay tuoi cao nhat va thap nhat
        public int CaoTuoiNhat()
        {
            int Tuoi = -1, vt = 0; // lấy vị trí người cao tuổi nhất trong gia đinh
            for (int i = 0; i < SoLuong; i++)
            {
                if (Family[i].LayTuoi > Tuoi)
                {
                    Tuoi = Family[i].LayTuoi;
                    vt = i;
                }
            }

            return Tuoi;
        }
        public int NhoTuoiNhat()
        {
            int Tuoi = 999, vt = 0; // lấy vị trí người nhỏ tuổi nhất trong gia đinh
            for (int i = 0; i < SoLuong; i++)
            {
                if (Family[i].LayTuoi < Tuoi)
                {
                    Tuoi = Family[i].LayTuoi;
                    vt = i;
                }
            }
            return Tuoi;
        }
        #region Xuat GiaDinh 
        public override void Xuat()
        {
            Console.WriteLine();
            Console.WriteLine("So luong thanh vien trong gia dinh: {0}", SoLuong);
            Console.WriteLine();
                        
            Console.WriteLine("Thong tin cua tung thanh vien: ");
            Console.WriteLine();
            for (int i = 0; i < SoLuong; i++)
            {
                Console.WriteLine("Nguoi {0}: \nHo ten: {1}\nNgay sinh: {2}\nNghe nghiep: {3}\n"
                    ,i + 1 , Family[i].HoTen, Family[i].NgaySinh.ToString("dd/MM/yyyy"), Family[i].NgheNghiep);
            }

            //Console.WriteLine(); khi ham tra ve vi tri
            //Console.WriteLine("Nguoi nho tuoi nhat: {0}, Tuoi: {1}", Family[CaoTuoiNhat()].HoTen, Family[CaoTuoiNhat()].LayTuoi);
            //Console.WriteLine("Nguoi cao tuoi nhat: {0}, Tuoi: {1}", Family[NhoTuoiNhat()].HoTen, Family[NhoTuoiNhat()].LayTuoi);

            //Console.WriteLine(); khi ham tra ve tuoi
            //Console.WriteLine("Nguoi nho tuoi nhat: {0}", CaoTuoiNhat());
            //Console.WriteLine("Nguoi cao tuoi nhat: {0}", NhoTuoiNhat());

            Console.ReadKey();
        }
        #endregion

        #region Nhap GiaDinh
        public override void Nhap()
        {
            for (int i = 0; i < SoLuong; i++)
            {
                Console.WriteLine("Nguoi thu {0}", i + 1);
                Nguoi tmp = new Nguoi();
                tmp.Nhap();
                Family[i] = tmp;
                Console.WriteLine();
            }
        }
        #endregion
    }

    public class KhuPho : GiaDinh
    {
        #region KhuPho Fields
        public GiaDinh[] Town;
        private int nTongGD; // tổng số lượng gia đình trong 1 khu phố
        #endregion

        #region KhuPho Constructor
        public KhuPho()
        {
            nTongGD = 0;
            Town = new GiaDinh[nTongGD];
        }

        public KhuPho(int tgd)
        {
            nTongGD = tgd;
            Town = new GiaDinh[nTongGD];
        }
        #endregion

        #region Get - Set KhuPho
        public int TongGD
        {
            get { return nTongGD; }
            set { nTongGD = value; }
        }

        public GiaDinh this[int index]
        {
            get { return Town[index]; }
            set { Town[index] = value; }
        }
        #endregion

        #region Nhap KhuPho
        public override void Nhap()
        {
            for (int i = 0; i < TongGD; i++)
            {
                Console.Write("So thanh vien cua gia dinh {0}: ", i + 1);
                int sl = int.Parse(Console.ReadLine());
                GiaDinh a = new GiaDinh(sl);
                a.Nhap();
                Town[i] = a;
            }
        }
        #endregion

        // lay nguoi cao tuoi nhat va thap tuoi nhat trong khu phu
        public int CaoNhat()
        {
            int Tuoi = -1;
            for (int i = 0; i < TongGD; i++)
            {
                if (Town[i].CaoTuoiNhat() > Tuoi)
                {
                    Tuoi = Town[i].CaoTuoiNhat();
                }
            }
            return Tuoi;
        }
        public int NhoNhat()
        {
            int Tuoi = 999; 
            for (int i = 0; i < TongGD; i++)
            {
                if (Town[i].NhoTuoiNhat() < Tuoi)
                {
                    Tuoi = Town[i].NhoTuoiNhat();
                }
            }
            return Tuoi;
        }

        #region Xuat KhuPho
        public override void Xuat()
        {
            Console.WriteLine("Khu pho co tong cong {0} ho gia dinh.", TongGD);
            Console.WriteLine();
            for (int i = 0; i < TongGD; i++)
            {
                Console.WriteLine("Gia dinh thu {0}:", i + 1);
                Town[i].Xuat();
            }
            Console.WriteLine("Tuoi nguoi gia nhat khu pho: {0}", CaoNhat());
            Console.WriteLine("Tuoi nguoi nho nhat khu pho: {0}", NhoNhat());
        }
        #endregion
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap so luong gia dinh trong khu pho: ");
            int sl = int.Parse(Console.ReadLine());

            KhuPho A = new KhuPho(sl);
            A.Nhap();
            A.Xuat();
        }
    }
}
