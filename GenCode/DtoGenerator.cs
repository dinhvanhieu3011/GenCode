using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
namespace GenCode;
public class DtoGenerator
{
    public static void GenerateEntityClass<T>(string srcPath, string entityName)
    {

        string className = $"{entityName}.cs";
        string filePath = Path.Combine(srcPath, "IFAMILY.Entity","Entity" ,className);

        var sb = new StringBuilder();

        sb.AppendLine("using System;");
        sb.AppendLine("using IFAMILY.Entity;"); // Giả sử BaseFullAuditedEntity được định nghĩa ở đây
        sb.AppendLine();
        sb.AppendLine($"namespace IFAMILY.Entity");
        sb.AppendLine("{");
        sb.AppendLine($"    public class {entityName} : BaseFullAuditedEntity<long>");
        sb.AppendLine("    {");

        // Lấy thông tin thuộc tính từ entity
        foreach (var prop in typeof(T).GetProperties())
        {
            string typeName = GetSimpleTypeName(prop.PropertyType);
            sb.AppendLine($"        public {typeName} {prop.Name} {{ get; set; }}");
        }

        sb.AppendLine("    }");
        sb.AppendLine("}");


        // Tạo thư mục nếu chưa tồn tại
        //Directory.CreateDirectory(directoryPath);

        // Ghi nội dung vào tệp
        File.WriteAllText(filePath, sb.ToString());
    }

    public static void GenerateDtos<T>( string srcPath,string entityName)
    {
        string baseNamespace = "IFAMILY.Model";
        string directoryPath = Path.Combine(srcPath, "IFAMILY.Model", entityName);

        // Tạo thư mục nếu chưa tồn tại
        Directory.CreateDirectory(directoryPath);

        // Tạo các DTO
        GenerateCreateDto<T>(directoryPath, baseNamespace);
        GenerateUpdateDto<T>(directoryPath, baseNamespace);
        GenerateFilterDto<T>(directoryPath, baseNamespace);
        GenerateViewDto<T>(directoryPath, baseNamespace);
    }

    private static void GenerateCreateDto<T>(string directoryPath, string baseNamespace)
    {
        var className = $"Create{typeof(T).Name}Dto";
        var sb = new StringBuilder();

        sb.AppendLine($"using System;");
        sb.AppendLine($"using IFAMILY.Model.BaseModels;");
        sb.AppendLine();
        sb.AppendLine($"namespace {baseNamespace}.{typeof(T).Name}");
        sb.AppendLine("{");
        sb.AppendLine($"    public class {className} : BaseCreateDto");
        sb.AppendLine("    {");

        foreach (var prop in typeof(T).GetProperties())
        {
            string typeName = GetSimpleTypeName(prop.PropertyType);
            sb.AppendLine($"        public {typeName} {prop.Name} {{ get; set; }}");
        }

        sb.AppendLine("    }");
        sb.AppendLine("}");

        File.WriteAllText(Path.Combine(directoryPath, $"{className}.cs"), sb.ToString());
    }

    private static void GenerateUpdateDto<T>(string directoryPath, string baseNamespace)
    {
        var className = $"Update{typeof(T).Name}Dto";
        var sb = new StringBuilder();

        sb.AppendLine($"using System;");
        sb.AppendLine($"using IFAMILY.Model.BaseModels;");
        sb.AppendLine();
        sb.AppendLine($"namespace {baseNamespace}.{typeof(T).Name}");
        sb.AppendLine("{");
        sb.AppendLine($"    public class {className} : EntityDto<long>");
        sb.AppendLine("    {");

        foreach (var prop in typeof(T).GetProperties())
        {
            string typeName = GetSimpleTypeName(prop.PropertyType);
            sb.AppendLine($"        public {typeName} {prop.Name} {{ get; set; }}");
        }

        sb.AppendLine("    }");
        sb.AppendLine("}");

        File.WriteAllText(Path.Combine(directoryPath, $"{className}.cs"), sb.ToString());
    }

    private static void GenerateFilterDto<T>(string directoryPath, string baseNamespace)
    {
        var className = $"Filter{typeof(T).Name}Dto";
        var sb = new StringBuilder();

        sb.AppendLine($"using {baseNamespace};");
        sb.AppendLine();
        sb.AppendLine($"namespace {baseNamespace}.{typeof(T).Name}");
        sb.AppendLine("{");
        sb.AppendLine($"    public class {className} : PagedAndSortResultRequestDto");
        sb.AppendLine("    {");
        sb.AppendLine("        // Thêm các thuộc tính lọc ở đây");
        sb.AppendLine("    }");
        sb.AppendLine("}");

        File.WriteAllText(Path.Combine(directoryPath, $"{className}.cs"), sb.ToString());
    }

    private static void GenerateViewDto<T>(string directoryPath, string baseNamespace)
    {
        var className = $"View{typeof(T).Name}Dto";
        var sb = new StringBuilder();

        sb.AppendLine($"using System;");
        sb.AppendLine($"using IFAMILY.Model.BaseModels;");
        sb.AppendLine();
        sb.AppendLine($"namespace {baseNamespace}.{typeof(T).Name}");
        sb.AppendLine("{");
        sb.AppendLine($"    public class {className} : FullAuditedEntityDto<long>");
        sb.AppendLine("    {");

        foreach (var prop in typeof(T).GetProperties())
        {
            string typeName = GetSimpleTypeName(prop.PropertyType);
            sb.AppendLine($"        public {typeName} {prop.Name} {{ get; set; }}");
        }

        sb.AppendLine("    }");
        sb.AppendLine("}");

        File.WriteAllText(Path.Combine(directoryPath, $"{className}.cs"), sb.ToString());
    }

    private static string GetSimpleTypeName(Type type)
    {
        if (type == typeof(string)) return "string";
        if (type == typeof(int)) return "int";
        if (type == typeof(long)) return "long";
        if (type == typeof(double)) return "double";
        if (type == typeof(bool)) return "bool";
        // Thêm các kiểu khác nếu cần

        return type.Name; // Đối với các kiểu phức tạp hoặc không xác định
    }
}
