using Minimal.DTOs;
using Minimal.Infraestrutura.Db;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;

namespace MinimalApi.Dominio.Servicos;


public class AdministradorServico : iAdministradorServico
{
private readonly DbContexto _contexto;

    public AdministradorServico(DbContexto db){
        _contexto = db;
    }

    public Administrador login(LoginDTO loginDTO)
    {
        var adm = _contexto.Administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();
        return adm;
    }
}

