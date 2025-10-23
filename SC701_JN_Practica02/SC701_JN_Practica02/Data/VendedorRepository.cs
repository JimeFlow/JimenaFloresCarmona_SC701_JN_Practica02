using System.Data;
using Dapper;
using SC701_JN_Practica02.Models;

namespace SC701_JN_Practica02.Data
{
    public class VendedorRepository
    {
        private readonly DBContextDapper _db;
        public VendedorRepository(DBContextDapper db) => _db = db;

        public async Task<int> CreateAsync(VendedorModel model)
        {
            using var conn = _db.CreateConnection();
            var p = new DynamicParameters();
            p.Add("@Cedula", model.Cedula);
            p.Add("@Nombre", model.Nombre);
            p.Add("@Correo", model.Correo);
            return await conn.ExecuteAsync("sp_InsertVendedor", p, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<VendedorModel>> GetAllAsync()
        {
            using var conn = _db.CreateConnection();
            return await conn.QueryAsync<VendedorModel>("sp_GetVendedores", commandType: CommandType.StoredProcedure);
        }

        public async Task<VendedorModel?> GetByCedulaAsync(string cedula)
        {
            using var conn = _db.CreateConnection();
            return (await conn.QueryAsync<VendedorModel>("SELECT Cedula, Nombre, Correo FROM Vendedores WHERE Cedula = @Cedula", new { Cedula = cedula })).FirstOrDefault();
        }
    }
}