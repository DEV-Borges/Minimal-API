using System.Numerics;
using Minimal.Infraestrutura.Db;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;

namespace MinimalApi.Dominio.Servicos;
public class VeiculoServico : IVeiculoServico
{
private readonly DbContexto _contexto;

    public VeiculoServico(DbContexto db){
        _contexto = db;
    }

    public void Apagar(Veiculo veiculo)
    {
        _contexto.Veiculos.Remove(veiculo);
        _contexto.SaveChanges();
    }

    public void Atualizar(Veiculo veiculo)
    {
        _contexto.Veiculos.Update(veiculo);
        _contexto.SaveChanges();        
    }

    public Veiculo? BuscaPorId(int id)
    {
        return _contexto.Veiculos.Where(v=> v.Id == id).FirstOrDefault();

    }

    public void Incluir(Veiculo veiculo)
    {
        _contexto.Veiculos.Add(veiculo);
        _contexto.SaveChanges();
    }

    public List<Veiculo> Todos(int pagina, string nome = null, string Marca = null)
    {
        var query = _contexto.Veiculos.AsQueryable();
        if  (!string.IsNullOrEmpty(nome)){
            query = query.Where(v => v.Nome.ToLower().Contains(nome));
        }

        int itensPorPagina = 10;

        query = query.Skip((pagina - 1 ) * itensPorPagina).Take(itensPorPagina);

        return query.ToList();
    }
}
