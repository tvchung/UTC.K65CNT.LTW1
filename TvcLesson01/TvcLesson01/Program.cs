namespace TvcLesson01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tvc Lesson01");
            string choice;
            List<Student> students = new List<Student>()
            {
                new Student { masv = "SV001", hoTen = "Nguyen Van A", ngaySinh = new DateTime(2000, 1, 1), gioiTinh = true, email = "nguyenvana@example.com", soDienThoai = "0123456789", nganhHoc = "CNTT", diemTrungBinh = 8.5f, trangThai = true } ,
                new Student { masv = "SV002", hoTen = "Tran Thi B", ngaySinh = new DateTime(2001, 2, 2), gioiTinh = false, email = "Chungtrinhj@gmaii.com", soDienThoai = "0987654321", nganhHoc = "Kinh te", diemTrungBinh = 7.2f, trangThai = true }
            };
            do
            {
                // menu
                ChucNang();
                Console.Write("Nhập lựa chọn của bạn: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Nhập thông tin sinh viên
                        ThemSinhVien(students);
                        break;
                    case "2":
                        // Hiển thị thông tin sinh viên
                        HienThiSinhVien(students);
                        break;
                    case "14":
                        Console.WriteLine("Thoát chương trình.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }

            } while (choice != "14");

        }


        static void ChucNang()
        {
            Console.WriteLine("==== MENU ====");
            Console.WriteLine("1. Nhập thông tin sinh viên");
            Console.WriteLine("2. Hiển thị thông tin sinh viên");
            Console.WriteLine("3. Tìm sinh viên theo mã");
            Console.WriteLine("4. Tìm gần đúng theo tên");
            Console.WriteLine("5. Cập nhật thông tin sinh viên");
            Console.WriteLine("6. Xóa sinh viên theo mã");
            Console.WriteLine("7. Sắp xếp theo họ tên");
            Console.WriteLine("8. Sắp xếp theo điểm trung bình");
            Console.WriteLine("9. Hiển thị sinh viên có điểm từ 8 trở lên.");
            Console.WriteLine("10. Hiển thị sinh viên có điểm cao nhất.");
            Console.WriteLine("11. Hiển thị sinh viên có điểm cao nhất.");
            Console.WriteLine("12. Thống kê sinh viên theo ngành.");
            Console.WriteLine("13. Thống kê sinh viên theo trạng thái.");
            Console.WriteLine("14. Thoát");
        }

        // Thêm sinh viên
        static void ThemSinhVien(List<Student> students)
        {
            Student student = new Student();
            Console.Write("Nhập mã sinh viên: ");
            student.masv = Console.ReadLine();
            Console.Write("Nhập họ tên: ");
            student.hoTen = Console.ReadLine();
            Console.Write("Nhập ngày sinh (dd/MM/yyyy): ");
            student.ngaySinh = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.Write("Nhập giới tính (true/false): ");
            student.gioiTinh = bool.Parse(Console.ReadLine());
            Console.Write("Nhập email: ");
            student.email = Console.ReadLine();
            Console.Write("Nhập số điện thoại: ");
            student.soDienThoai = Console.ReadLine();
            Console.Write("Nhập ngành học: ");
            student.nganhHoc = Console.ReadLine();
            Console.Write("Nhập điểm trung bình: ");
            student.diemTrungBinh = float.Parse(Console.ReadLine());
            Console.Write("Nhập trạng thái (true/false): ");
            student.trangThai = bool.Parse(Console.ReadLine());
            students.Add(student);
        }
        // Hiển thị thông tin sinh viên
        static void HienThiSinhVien(List<Student> students)
        {
            Console.WriteLine("Danh sách sinh viên:");
            foreach (var student in students)
            {
                Console.WriteLine($"Mã SV: {student.masv}, Họ tên: {student.hoTen}, Ngày sinh: {student.ngaySinh.ToString("dd/MM/yyyy")}, Giới tính: {(student.gioiTinh ? "Nam" : "Nữ")}, Email: {student.email}, SĐT: {student.soDienThoai}, Ngành học: {student.nganhHoc}, Điểm TB: {student.diemTrungBinh}, Trạng thái: {(student.trangThai ? "Đang học" : "Nghỉ học")}");
            }
        }
    }
}
