using Common.DTO.Inventory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Data.InventoryDataService
{
    public class InventoryDataService : IInventoryDataService
    {

        #region Declarations
        private readonly IConfiguration configuration;
        private readonly string DbConc;

        #region Queries

        private string GetInventoriesQry = "Select * From Inventory";
        private string AddItemQry = "Insert Into Inventory(Name,Description,Price,Qty,InventoryCode ) Values (@Name,@Description,@Price,@Qty,@InventoryCode)";
        private string ItemUpdatQry = "Update Inventory Set Name='{0}' ,Description='{1}',Qty={2},Price={3},InventoryCode='{4}' Where ID={5} ";
        private string DeleteItemQry = "Delete Inventory where Id={0}";

        #endregion

        #endregion

        #region Constructor

        public InventoryDataService(IConfiguration config)
        {
            configuration = config;
            DbConc =configuration["DbConnectionStrings"];
        }
        #endregion

        #region Service Methods

        public async Task<bool> AddInventory(AddInventoryRequestDto RequestDto)
        {
            using (SqlConnection conn = new SqlConnection(DbConc))
            {
                var res = await conn.ExecuteAsync(AddItemQry,RequestDto.InventoryData);
                return (res > 0) ? true: false;
            }
        }

        public async Task<GetInventoriesResponseDto> GetInventories()
        {
            var resp = new GetInventoriesResponseDto();
            IEnumerable<InventoryData> data;
            using(SqlConnection conn= new SqlConnection(DbConc))
            {
                data = await conn.QueryAsync<InventoryData>(GetInventoriesQry);
            }
            if(data != null)resp.Inventories = data.AsList();
            return resp;
        }

        public async Task<bool> ModifyInventory(ModilfyInventoryRequestDto inventory)
        {
            var item = inventory.InventoryData;
            var qry = string.Format(ItemUpdatQry, item.Name, item.Description, item.Qty, item.Price, item.InventoryCode,item.Id);
            using (SqlConnection conn = new SqlConnection(DbConc))
            {
                var res = await conn.ExecuteAsync(qry);
                return (res > 0) ? true : false;
            }
        }

        public async Task<bool> RemoveInventory(RemoveInventoryRequestDto inventory)
        {
            var qry = string.Format(DeleteItemQry,inventory.ItemID );

            using (SqlConnection conn = new SqlConnection(DbConc))
            {
                var res = await conn.ExecuteAsync(qry);
                return (res > 0) ? true : false;
            }
        }

        #endregion
    }
}
