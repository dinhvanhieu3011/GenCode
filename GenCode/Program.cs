namespace GenCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string srcPath = "E:\\Learn\\ifamily\\src";
            //ControllerGenerator.GenerateController<Store>(srcPath);
            //ControllerGenerator.GenerateController<Order>(srcPath);
            //ControllerGenerator.GenerateController<OrderHistory>(srcPath);
            //ControllerGenerator.GenerateController<RefundRequest>(srcPath);


            DtoGenerator.GenerateDtos<UserInfo>(srcPath, "UserInfo");
            //DtoGenerator.GenerateEntityClass<UserInfo>(srcPath, "UserInfo");
            DbContextUpdater.AddEntityToDbContext<UserInfo>(srcPath);
            ServiceGenerator.GenerateServiceFiles<UserInfo>(srcPath);
            ServiceGenerator.UpdateConfigurationDependency<UserInfo>(srcPath);
            ServiceGenerator.UpdateAutoMapperProfile<UserInfo>(srcPath);

            //DtoGenerator.GenerateDtos<Platform>(srcPath, "Platform");
            //DtoGenerator.GenerateEntityClass<Platform>(srcPath, "Platform");
            //DbContextUpdater.AddEntityToDbContext<Platform>(srcPath);
            //ServiceGenerator.GenerateServiceFiles<Platform>(srcPath);
            //ServiceGenerator.UpdateConfigurationDependency<Platform>(srcPath);
            //ServiceGenerator.UpdateAutoMapperProfile<Platform>(srcPath);

            //DtoGenerator.GenerateDtos<Video>(srcPath, "Video");
            //DtoGenerator.GenerateEntityClass<Video>(srcPath, "Video");
            //DbContextUpdater.AddEntityToDbContext<Video>(srcPath);
            //ServiceGenerator.GenerateServiceFiles<Video>(srcPath);
            //ServiceGenerator.UpdateConfigurationDependency<Video>(srcPath);
            //ServiceGenerator.UpdateAutoMapperProfile<Video>(srcPath);

            //DtoGenerator.GenerateDtos<OrderStatus>(srcPath, "OrderStatus");
            //DtoGenerator.GenerateEntityClass<OrderStatus>(srcPath, "OrderStatus");
            //DbContextUpdater.AddEntityToDbContext<OrderStatus>(srcPath);
            //ServiceGenerator.GenerateServiceFiles<OrderStatus>(srcPath);
            //ServiceGenerator.UpdateConfigurationDependency<OrderStatus>(srcPath);
            //ServiceGenerator.UpdateAutoMapperProfile<OrderStatus>(srcPath);

            //DtoGenerator.GenerateDtos<OrderState>(srcPath, "OrderState");
            //DtoGenerator.GenerateEntityClass<OrderState>(srcPath, "OrderState");
            //DbContextUpdater.AddEntityToDbContext<OrderState>(srcPath);
            //ServiceGenerator.GenerateServiceFiles<OrderState>(srcPath);
            //ServiceGenerator.UpdateConfigurationDependency<OrderState>(srcPath);
            //ServiceGenerator.UpdateAutoMapperProfile<OrderState>(srcPath);
            
        }
    }
}
