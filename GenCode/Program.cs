namespace GenCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string srcPath = "C:\\Users\\AsRock\\source\\repos\\CRM\\src";
            ControllerGenerator.GenerateController<Store>(srcPath);
            ControllerGenerator.GenerateController<Order>(srcPath);
            ControllerGenerator.GenerateController<OrderHistory>(srcPath);
            ControllerGenerator.GenerateController<RefundRequest>(srcPath);


            //DtoGenerator.GenerateDtos<Store>(srcPath, "Store");
            //DtoGenerator.GenerateEntityClass<Store>(srcPath, "Store");
            //DbContextUpdater.AddEntityToDbContext<Store>(srcPath);
            //ServiceGenerator.GenerateServiceFiles<Store>(srcPath);
            //ServiceGenerator.UpdateConfigurationDependency<Store>(srcPath);
            //ServiceGenerator.UpdateAutoMapperProfile<Store>(srcPath);

            //DtoGenerator.GenerateDtos<Order>(srcPath, "Order");
            //DtoGenerator.GenerateEntityClass<Order>(srcPath, "Order");
            //DbContextUpdater.AddEntityToDbContext<Order>(srcPath);
            //ServiceGenerator.GenerateServiceFiles<Order>(srcPath);
            //ServiceGenerator.UpdateConfigurationDependency<Order>(srcPath);
            //ServiceGenerator.UpdateAutoMapperProfile<Order>(srcPath);

            //DtoGenerator.GenerateDtos<OrderHistory>(srcPath, "OrderHistory");
            //DtoGenerator.GenerateEntityClass<OrderHistory>(srcPath, "OrderHistory");
            //DbContextUpdater.AddEntityToDbContext<OrderHistory>(srcPath);
            //ServiceGenerator.GenerateServiceFiles<OrderHistory>(srcPath);
            //ServiceGenerator.UpdateConfigurationDependency<OrderHistory>(srcPath);
            //ServiceGenerator.UpdateAutoMapperProfile<OrderHistory>(srcPath);

            //DtoGenerator.GenerateDtos<RefundRequest>(srcPath, "RefundRequest");
            //DtoGenerator.GenerateEntityClass<RefundRequest>(srcPath, "RefundRequest");
            //DbContextUpdater.AddEntityToDbContext<RefundRequest>(srcPath);
            //ServiceGenerator.GenerateServiceFiles<RefundRequest>(srcPath);
            //ServiceGenerator.UpdateConfigurationDependency<RefundRequest>(srcPath);
            //ServiceGenerator.UpdateAutoMapperProfile<RefundRequest>(srcPath);


        }
    }
}
