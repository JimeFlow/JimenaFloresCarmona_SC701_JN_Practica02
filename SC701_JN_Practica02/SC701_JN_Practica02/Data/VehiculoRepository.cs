using System.Data;
using Dapper;
using SC701_JN_Practica02.Models;

namespace SC701_JN_Practica02.Data
{
    public class VehiculoRepository
    {
        private readonly DBContextDapper _db;
        public VehiculoRepository(DBContextDapper db) => _db = db;

        public async Task<int> CreateAsync(VehiculoModel model)
        {
            using var conn = _db.CreateConnection();
            var p = new DynamicParameters();
            p.Add("@Marca", model.Marca);
            p.Add("@Modelo", model.Modelo);
            p.Add("@Color", model.Color);
            p.Add("@Precio", model.Precio);
            p.Add("@VendedorCedula", model.VendedorCedula);
            return await conn.ExecuteAsync("sp_InsertVehiculo", p, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<dynamic>> GetAllWithVendedorAsync()
        {
            using var conn = _db.CreateConnection();
            return await conn.QueryAsync("sp_ListVehiculos", commandType: CommandType.StoredProcedure);
        }
    }
}