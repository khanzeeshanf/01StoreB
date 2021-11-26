using Common.DTO.Inventory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.InventoryDataService
{
    public interface IInventoryDataService
    {
        Task<bool> AddInventory(AddInventoryRequestDto RequestDto);
        Task<bool> RemoveInventory(RemoveInventoryRequestDto inventory);
        Task<GetInventoriesResponseDto> GetInventories();
        Task<bool> ModifyInventory(ModilfyInventoryRequestDto inventory);
    }
}
