using System;
using System.IO;
using System.Text;
namespace GenCode;
public class ServiceGenerator
{
    public static void UpdateConfigurationDependency<T>(string rootPath)
    {
        string entityName = typeof(T).Name;
        //C:\Users\AsRock\source\repos\CRM\src\IFAMILY.ApiGateway\Configuration\AutoMapperProfile.cs
        string filePath = Path.Combine(rootPath, "IFAMILY.ApiGateway", "Configuration", "ConfigurationDependency.cs");

        var lines = File.ReadAllLines(filePath);
        const int insertLine = 61; // Dòng 61 để chèn dịch vụ

        // Đoạn cần thêm
        string serviceCode = $"            services.AddScoped<I{entityName}Service, {entityName}Service>();";

        // Kiểm tra xem dòng đã tồn tại chưa
        if (Array.Exists(lines, line => line.Trim() == serviceCode.Trim()))
        {
            Console.WriteLine("Service code đã tồn tại.");
            return; // Nếu đã tồn tại, không thêm nữa
        }

        // Chèn dòng mới vào
        var newLines = new string[lines.Length + 1];
        for (int i = 0; i < lines.Length; i++)
        {
            newLines[i] = lines[i];
            if (i == insertLine - 1) // Chèn sau dòng 61 (chỉ số 60)
            {
                newLines[i + 1] = serviceCode;
                Array.Copy(lines, i + 1, newLines, i + 2, lines.Length - (i + 1));
                break;
            }
        }

        // Ghi lại nội dung đã cập nhật vào tệp
        File.WriteAllLines(filePath, newLines);
        Console.WriteLine("Đã thêm service code.");
    }

    public static void UpdateAutoMapperProfile<T>(string rootPath)
    {
        string entityName = typeof(T).Name;
        string filePath = Path.Combine(rootPath, "IFAMILY.ApiGateway", "Configuration", "AutoMapperProfile.cs");

        var lines = File.ReadAllLines(filePath);
        const int insertLine = 25; // Dòng 25 để chèn đoạn CreateMap

        // Đoạn cần thêm
        string mappingCode = $"            CreateMap<Create{entityName}Dto, {entityName}>().ReverseMap();\n" +
                             $"            CreateMap<Update{entityName}Dto, {entityName}>().ReverseMap();\n" +
                             $"            CreateMap<View{entityName}Dto, {entityName}>().ReverseMap();\n" +
                             $"            CreateMap<{entityName}, View{entityName}Dto>();";

        // Kiểm tra xem đoạn mã đã tồn tại chưa
        if (Array.Exists(lines, line => line.Trim() == mappingCode.Trim()))
        {
            Console.WriteLine("Mapping code đã tồn tại.");
            return; // Nếu đã tồn tại, không thêm nữa
        }

        // Chèn đoạn mã vào
        var newLines = new string[lines.Length + 1];
        for (int i = 0; i < lines.Length; i++)
        {
            newLines[i] = lines[i];
            if (i == insertLine - 1) // Chèn sau dòng 25 (chỉ số 24)
            {
                newLines[i + 1] = mappingCode;
                Array.Copy(lines, i + 1, newLines, i + 2, lines.Length - (i + 1));
                break;
            }
        }

        // Ghi lại nội dung đã cập nhật vào tệp
        File.WriteAllLines(filePath, newLines);
        Console.WriteLine("Đã thêm mapping code.");
    }

    public static void GenerateServiceFiles<T>(string rootPath)
    {
        string entityName =  typeof(T).Name;
        string implementsDirectory = Path.Combine(rootPath,"IFAMILY.Services", "Implements", "Services");
        string interfacesDirectory = Path.Combine(rootPath,"IFAMILY.Services", "Interfaces", "Services");

        // Tạo thư mục nếu chưa tồn tại
        Directory.CreateDirectory(implementsDirectory);
        Directory.CreateDirectory(interfacesDirectory);

        // Tạo file ICategoryService.cs
        GenerateInterfaceFile(entityName, interfacesDirectory);

        // Tạo file CategoryService.cs
        GenerateImplementationFile(entityName, implementsDirectory);
    }

    private static void GenerateInterfaceFile(string entityName, string directoryPath)
    {
        string interfaceName = $"I{entityName}Service.cs";
        var sb = new StringBuilder();

        sb.AppendLine("using System;");
        sb.AppendLine($"using IFAMILY.Model;"); // Giả sử có các DTO trong IFAMILY.Model
        sb.AppendLine($"using IFAMILY.Services;"); // Thêm namespace cho IBaseService
        sb.AppendLine($"using IFAMILY.Entity;");
        sb.AppendLine($"using IFAMILY.Services.BaseServices;");
        sb.AppendLine($"using IFAMILY.Model.{entityName};");

        sb.AppendLine($"namespace IFAMILY.Services.Interfaces");
        sb.AppendLine("{");
        sb.AppendLine($"    public interface I{entityName}Service : IBaseService<long, {entityName}, View{entityName}Dto, View{entityName}Dto, Create{entityName}Dto, Update{entityName}Dto, Filter{entityName}Dto>");
        sb.AppendLine("    {");
        sb.AppendLine("    }");
        sb.AppendLine("}");

        File.WriteAllText(Path.Combine(directoryPath, interfaceName), sb.ToString());
    }

    private static void GenerateImplementationFile(string entityName, string directoryPath)
    {
        string className = $"{entityName}Service.cs";
        var sb = new StringBuilder();

        sb.AppendLine("using AutoMapper;");
        sb.AppendLine("using IFAMILY.CORE.Extensions;");
        sb.AppendLine("using IFAMILY.Data.Repository;");
        sb.AppendLine("using IFAMILY.Entity.IdentityAccess;");
        sb.AppendLine("using IFAMILY.Services.BaseServices;");
        sb.AppendLine("using Microsoft.AspNetCore.Http;");
        sb.AppendLine("using Microsoft.AspNetCore.Identity;");
        sb.AppendLine("using Microsoft.Extensions.Logging;");
        sb.AppendLine("using System;");
        sb.AppendLine("using IFAMILY.Entity;");
        sb.AppendLine("using System.Linq;");
        sb.AppendLine($"using IFAMILY.Model.{entityName};");
        sb.AppendLine("using IFAMILY.Services.Interfaces;");
        sb.AppendLine("using System.Threading.Tasks;");
        sb.AppendLine();
        sb.AppendLine($"namespace IFAMILY.Services.Implements");
        sb.AppendLine("{");
        sb.AppendLine($"    public class {entityName}Service : BaseService<long, {entityName}, View{entityName}Dto, View{entityName}Dto, Create{entityName}Dto, Update{entityName}Dto, Filter{entityName}Dto>, I{entityName}Service");
        sb.AppendLine("    {");
        sb.AppendLine($"        public {entityName}Service(IRepository<{entityName}, long> repository,");
        sb.AppendLine($"            IMapper mapper, ILogger<{entityName}Service> logger,");
        sb.AppendLine("            IUnitOfWork unitOfWork,");
        sb.AppendLine("            IHttpContextAccessor httpContextAccessor,");
        sb.AppendLine("            UserManager<User> userManager)");
        sb.AppendLine("            : base(repository, mapper, logger, unitOfWork, httpContextAccessor, userManager)");
        sb.AppendLine("        {");
        sb.AppendLine("        }");
        sb.AppendLine();
        sb.AppendLine($"        public override async Task<IQueryable<{entityName}>> QueryFilter()");
        sb.AppendLine("        {");
        sb.AppendLine($"            var query = _repository.GetAll();");
        sb.AppendLine();
        sb.AppendLine("            return query;");
        sb.AppendLine("        }");
        sb.AppendLine();
        sb.AppendLine($"        public override async Task<IQueryable<{entityName}>> QueryFilter(Filter{entityName}Dto filter)");
        sb.AppendLine("        {");
        sb.AppendLine($"            if (!filter.IsDelete.HasValue)");
        sb.AppendLine("            {");
        sb.AppendLine($"                filter.IsDelete = false;");
        sb.AppendLine("            }");
        sb.AppendLine();
        sb.AppendLine($"            var query = _repository.GetAll()");
        sb.AppendLine($"                .WhereIf(filter.IsDelete.HasValue, x => x.IsDelete == filter.IsDelete)");
        sb.AppendLine($"                .Where(x => !x.IsDelete);");
        sb.AppendLine();
        sb.AppendLine($"            if (string.IsNullOrEmpty(filter.Sorting))");
        sb.AppendLine($"                filter.Sorting = \"ModifiedDate Desc\";");
        sb.AppendLine($"            query = query.Sort(filter.Sorting);");
        sb.AppendLine();
        sb.AppendLine("            return await Task.FromResult(query);");
        sb.AppendLine("        }");
        sb.AppendLine("    }");
        sb.AppendLine("}");

        File.WriteAllText(Path.Combine(directoryPath, className), sb.ToString());
    }
}
