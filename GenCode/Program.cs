namespace GenCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string srcPath = "C:\\Users\\AsRock\\source\\repos\\CRM\\src";
            //ControllerGenerator.GenerateController<Store>(srcPath);
            //ControllerGenerator.GenerateController<Order>(srcPath);
            //ControllerGenerator.GenerateController<OrderHistory>(srcPath);
            //ControllerGenerator.GenerateController<RefundRequest>(srcPath);


            DtoGenerator.GenerateDtos<Field>(srcPath, "Field");
            DtoGenerator.GenerateEntityClass<Field>(srcPath, "Field");
            DbContextUpdater.AddEntityToDbContext<Field>(srcPath);
            ServiceGenerator.GenerateServiceFiles<Field>(srcPath);
            ServiceGenerator.UpdateConfigurationDependency<Field>(srcPath);
            ServiceGenerator.UpdateAutoMapperProfile<Field>(srcPath);

            DtoGenerator.GenerateDtos<Platform>(srcPath, "Platform");
            DtoGenerator.GenerateEntityClass<Platform>(srcPath, "Platform");
            DbContextUpdater.AddEntityToDbContext<Platform>(srcPath);
            ServiceGenerator.GenerateServiceFiles<Platform>(srcPath);
            ServiceGenerator.UpdateConfigurationDependency<Platform>(srcPath);
            ServiceGenerator.UpdateAutoMapperProfile<Platform>(srcPath);

            DtoGenerator.GenerateDtos<Video>(srcPath, "Video");
            DtoGenerator.GenerateEntityClass<Video>(srcPath, "Video");
            DbContextUpdater.AddEntityToDbContext<Video>(srcPath);
            ServiceGenerator.GenerateServiceFiles<Video>(srcPath);
            ServiceGenerator.UpdateConfigurationDependency<Video>(srcPath);
            ServiceGenerator.UpdateAutoMapperProfile<Video>(srcPath);

            DtoGenerator.GenerateDtos<OrderStatus>(srcPath, "OrderStatus");
            DtoGenerator.GenerateEntityClass<OrderStatus>(srcPath, "OrderStatus");
            DbContextUpdater.AddEntityToDbContext<OrderStatus>(srcPath);
            ServiceGenerator.GenerateServiceFiles<OrderStatus>(srcPath);
            ServiceGenerator.UpdateConfigurationDependency<OrderStatus>(srcPath);
            ServiceGenerator.UpdateAutoMapperProfile<OrderStatus>(srcPath);

            DtoGenerator.GenerateDtos<OrderState>(srcPath, "OrderState");
            DtoGenerator.GenerateEntityClass<OrderState>(srcPath, "OrderState");
            DbContextUpdater.AddEntityToDbContext<OrderState>(srcPath);
            ServiceGenerator.GenerateServiceFiles<OrderState>(srcPath);
            ServiceGenerator.UpdateConfigurationDependency<OrderState>(srcPath);
            ServiceGenerator.UpdateAutoMapperProfile<OrderState>(srcPath);
            
        }
    }
}
