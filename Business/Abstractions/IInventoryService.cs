
using Common.DTO.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstractions
{
    public interface IInventoryService
    {
        Task<String> AddInventory(AddInventoryRequestDto RequestDto);
        Task<String> RemoveInventory(RemoveInventoryRequestDto inventory);
        Task<GetInventoriesResponseDto> GetInventories();
        Task<String> ModifyInventory(ModilfyInventoryRequestDto inventory);
    }
}
