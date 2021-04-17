namespace XCommerce
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Npgsql;
    using Servicios.Interface.Rubros;
    using Servicios.Implementacion.Rubros;
    using Servicios.Interface.ListaPrecios;
    using Servicios.Implementacion.ListaPrecios;
    using Servicios.Interface.Iva;
    using Servicios.Implementacion.Iva;
    using Servicios.Interface.Articulos;
    using Servicios.Implementacion.Articulo;
    using Servicios.Interface.Provincias;
    using Servicios.Implementacion.Provincias;
    using Servicios.Interface.Localidad;
    using Servicios.Implementacion.Localidad;
    using Servicios.Interface.Comprobante;
    using Servicios.Implementacion.Comprobante;
    using Servicios.Interface.DetalleComprobante;
    using Servicios.Implementacion.DetalleComprobante;
    using Servicios.Interface.Persona;
    using Servicios.Implementacion.Persona;
    using Servicios.Interface.Usuario;
    using Servicios.Implementacion.Usuario;
    using Servicios.Interface.Configuracion;
    using Servicios.Implementacion.Configuracion;
    using Servicios.Interface.Caja;
    using Servicios.Implementacion.Caja;
    using Servicios.Interface.Marca;
    using Servicios.Implementacion.Marca;
    using Rotativa;
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var conexion = new NpgsqlConnection("Server=localhost; User Id=postgres;Password=panchito; DataBase=SistemaVentas");
            services.AddSingleton(conexion);

            services.AddTransient<IRubroServicio, RubroServicio>();
            services.AddTransient<IListaPrecioServicio, ListaPrecioServicio>();
            services.AddTransient<IIvaServicio, IvaServicio>();
            services.AddTransient<IArticuloServicio, ArticuloServicio>();
            services.AddTransient<IProvinciaServicio, ProvinciaServicio>();
            services.AddTransient<IClienteServicio, ClienteServicio>();
            services.AddTransient<ILocalidadServicio, LocalidadServicio>();
            services.AddTransient<IComprobanteServicio, ComprobanteServicio>();
            services.AddTransient<IDetalleComprobanteServicio, DetalleComprobanteServicio>();
            services.AddTransient<IPersonaServicio, PersonaServicio>();
            services.AddTransient<IEmpleadoServicio, EmpeadoServicio>();
            services.AddTransient<IUsuarioServicio, UsuarioServicio>();
            services.AddTransient<IConfiguracionServicio, ConfiguracionServicio>();
            services.AddTransient<ICajaServicio, CajaServicio>();
            services.AddTransient<IArticuloServicio, ArticuloServicio>();
            services.AddTransient<IMarcaServicio, MarcaServicio>();
            
            services.AddControllersWithViews();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            Rotativa.AspNetCore.RotativaConfiguration.Setup(env.WebRootPath, "../Rotativa");
        }
    }
}
