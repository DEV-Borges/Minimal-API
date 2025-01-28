using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidades;

namespace Minimal.Infraestrutura.Db;

public class DbContexto : DbContext
{
    private readonly IConfiguration _configuracaoAppSettings;
    public DbContexto (IConfiguration configuracaoAppSettings){
        _configuracaoAppSettings = configuracaoAppSettings;
    }
    public DbSet <Administrador> Administradores {get; set;} = default!;
    public DbSet <Veiculo> Veiculos {get; set;} = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>().HasData(
            new Administrador{
                Id = 1,
                Email = "Admin@gmail.com.br",
                Senha = "123456",
                Perfil = "Adm"
            }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        if (!optionsBuilder.IsConfigured){
            var StringConexao = _configuracaoAppSettings.GetConnectionString("mysql")?.ToString();

            if (!string.IsNullOrEmpty(StringConexao)){

                optionsBuilder.UseMySql(StringConexao
                , ServerVersion.AutoDetect(StringConexao));
            }
        }
    
    }

}

