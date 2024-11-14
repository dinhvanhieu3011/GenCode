using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenCode
{
    public class DbContextUpdater
    {
        public static void AddEntityToDbContext<T>(string srcPath)
        {
            string filePath = Path.Combine(srcPath, "IFAMILY.Data", "Repository", "AppDbContext.cs");

            // Đọc nội dung tệp
            var lines = File.ReadAllLines(filePath);

            // Xác định vị trí để chèn dòng mới
            const int insertLine = 42;
            var entityName = typeof(T).Name;

            // Dòng cần thêm
            string newLine = $"    public DbSet<{entityName}> {entityName}s {{ get; set; }}";

            // Kiểm tra xem dòng đã tồn tại chưa
            if (Array.Exists(lines, line => line.Trim() == newLine))
            {
                Console.WriteLine($"Dòng đã tồn tại: {newLine}");
                return; // Nếu đã tồn tại, không thêm nữa
            }

            // Thêm dòng mới vào danh sách dòng
            var newLines = new string[lines.Length + 1];
            for (int i = 0; i < lines.Length; i++)
            {
                newLines[i] = lines[i];
                if (i == insertLine - 1) // Chèn sau dòng 42 (chỉ số 41)
                {
                    newLines[i + 1] = newLine;
                    Array.Copy(lines, i + 1, newLines, i + 2, lines.Length - (i + 1));
                    break;
                }
            }

            // Ghi lại nội dung đã cập nhật vào tệp
            File.WriteAllLines(filePath, newLines);
        }
    }
}
