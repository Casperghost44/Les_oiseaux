namespace Les_oiseaux.Web.Middlewares
{
    public static class DependacyInjection
    {
        public static IServiceCollection AddMiddlewares(
           this IServiceCollection services)
        {
            services.AddScoped<ExceptionMiddleware>();
            services.AddScoped<TransactionMiddleware>();

            return services;
        }

        public static IApplicationBuilder UseCustomMiddleware(
            this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMiddleware<TransactionMiddleware>();

            return app;
        }


    }
}
