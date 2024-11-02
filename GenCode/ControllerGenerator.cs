using System.IO;
using System.Text;
namespace GenCode;
public class ControllerGenerator
{

    public static void GenerateController<T>( string directoryPath)
    {
        var entityName = typeof(T).Name;
        directoryPath = Path.Combine(directoryPath, "BASE.ApiGateway", "Controllers", "Admin" );
        var sb = new StringBuilder();

        sb.AppendLine("using BASE.CORE;");
        sb.AppendLine("using Microsoft.AspNetCore.Mvc;");
        sb.AppendLine("using Microsoft.AspNetCore.Authorization;");
        sb.AppendLine("using System.Threading.Tasks;");
        sb.AppendLine("using BASE.CORE.Settings;");
        sb.AppendLine("using Microsoft.Extensions.Caching.Memory;");
        sb.AppendLine("using BASE.ApiGateway.Controllers.BaseController;");
        sb.AppendLine("using BASE.ApiGateway.Service.Worker;");
        sb.AppendLine("using BASE.CORE.FileService;");
        sb.AppendLine("using BASE.Services.Interfaces;");
        sb.AppendLine("using BASE.Infrastructure.Interface;");
        sb.AppendLine($"using BASE.Model.{entityName};");
        sb.AppendLine($"using BASE.Entity;");
        sb.AppendLine();
        sb.AppendLine($"namespace BASE.ApiGateway.Controllers.Admin");
        sb.AppendLine("{");
        sb.AppendLine($"    [Route(\"api/admin/[controller]\")]");
        sb.AppendLine($"    [ApiController]");
        sb.AppendLine($"    [Authorize]");
        sb.AppendLine($"    public class {entityName}Controller : GenericController<long, {entityName}, View{entityName}Dto, View{entityName}Dto, Create{entityName}Dto, Update{entityName}Dto, Filter{entityName}Dto>");
        sb.AppendLine("    {");
        sb.AppendLine("        readonly AppSettings _appSettings;");
        sb.AppendLine("        private readonly IMemoryCache _memoryCache;");
        sb.AppendLine($"        private readonly I{entityName}Service _{entityName.ToLower()}Service;");
        sb.AppendLine("        // Inject other services as needed");
        sb.AppendLine();
        sb.AppendLine($"        public {entityName}Controller(AppSettings appSettings, IMemoryCache memoryCache,ILogHistoryService logHistoryService, I{entityName}Service {entityName.ToLower()}Service, IWorkerService workerService, IFileService fileService, IDocumentUploadService documentUploadService) :");
        sb.AppendLine($"            base({entityName.ToLower()}Service, logHistoryService, workerService, fileService, documentUploadService)");
        sb.AppendLine("        {");
        sb.AppendLine("            _appSettings = appSettings;");
        sb.AppendLine("            _memoryCache = memoryCache;");
        sb.AppendLine($"            _{entityName.ToLower()}Service = {entityName.ToLower()}Service;");
        sb.AppendLine("        }");
        sb.AppendLine();
        sb.AppendLine("        [HttpGet(\"GetAll\")]");
        sb.AppendLine($"        public override async Task<ActionResult<IPagedList<View{entityName}Dto>>> GetAll([FromQuery] Filter{entityName}Dto filter)");
        sb.AppendLine("        {");
        sb.AppendLine("            return await base.GetAll(filter);");
        sb.AppendLine("        }");
        sb.AppendLine();
        sb.AppendLine("        [HttpPost(\"Create\")]");
        sb.AppendLine($"        public override async Task<ActionResult> Create([FromBody] Create{entityName}Dto request)");
        sb.AppendLine("        {");
        sb.AppendLine("            return await base.Create(request);");
        sb.AppendLine("        }");
        sb.AppendLine("        [HttpPut(\"Update\")]");
        sb.AppendLine($"        public override async Task<ActionResult> Update([FromBody] Update{entityName}Dto request)");
        sb.AppendLine("        {");
        sb.AppendLine("            return await base.Update(request);");
        sb.AppendLine("        }");
        sb.AppendLine();
        sb.AppendLine("        [HttpDelete(\"Delete/{id}\")]");
        sb.AppendLine($"        public override async Task<ActionResult> Delete(long id)");
        sb.AppendLine("        {");
        sb.AppendLine("            return await base.Delete(id);");
        sb.AppendLine("        }");
        sb.AppendLine("    }");
        sb.AppendLine("}");

        // Ghi vào file
        File.WriteAllText(Path.Combine(directoryPath, $"{entityName}Controller.cs"), sb.ToString());
    }
}
