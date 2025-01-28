using Minimal.DTOs;
using MinimalApi.Dominio.Entidades;

namespace MinimalApi.Dominio.Interfaces;

public interface iAdministradorServico
{
    Administrador login(LoginDTO loginDTO);
}