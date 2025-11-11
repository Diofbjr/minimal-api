using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using minimal_api.Dominio.Interfaces;
using test.Mocks;
using System.Linq;

namespace minimal_api
{
    public class Setup
    {
        public const string PORT = "5001";
        public static TestContext testContext = default!;
        public static WebApplicationFactory<Program> http = default!;
        public static HttpClient client = default!;

        public static void ClassInit(TestContext testContext)
        {
            Setup.testContext = testContext;

            Setup.http = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.UseSetting("https_port", Setup.PORT)
                            .UseEnvironment("Testing");

                    builder.ConfigureServices(services =>
                    {
                        var administradorServico = services.SingleOrDefault(
                            d => d.ServiceType == typeof(IAdministradorServico));
                        if (administradorServico != null) services.Remove(administradorServico);

                        var veiculoServico = services.SingleOrDefault(
                            d => d.ServiceType == typeof(IVeiculoServico));
                        if (veiculoServico != null) services.Remove(veiculoServico);

                        services.AddScoped<IAdministradorServico, AdministradorServicoMock>();
                        services.AddScoped<IVeiculoServico, VeiculoServicoMock>();
                    });
                });

            Setup.client = Setup.http.CreateClient();
        }

        public static void ClassCleanup()
        {
            Setup.http.Dispose();
        }
    }
}
