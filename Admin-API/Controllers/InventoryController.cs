using Business.Abstractions;
using Common.DTO.Inventory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService inventoryService;

        #region Constructor
        public InventoryController(IInventoryService invService)
        {
            inventoryService = invService;
        }
        #endregion


        #region Action Methods

        [HttpGet]
        [ActionName("GetInventories")]
        public async Task<IActionResult> GetInventories()
        {
            var result = await inventoryService.GetInventories();
            return Ok(result);
        }

        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> AddInventory(AddInventoryRequestDto requestDto)
        {

            var result = await inventoryService.AddInventory(requestDto);
            return Ok(result);
        }

        [HttpPut]
        [ActionName("Modify")]
        public async Task<IActionResult> ModifyInventory(ModilfyInventoryRequestDto requestDto)
        {
            var result = await inventoryService.ModifyInventory(requestDto);
            return Ok(result);
        }

        [HttpDelete]
        [ActionName("Delete")]
        public async Task<IActionResult> RemoveInventory(RemoveInventoryRequestDto requestDto)
        {

            var result = await inventoryService.RemoveInventory(requestDto);
             return Ok(result);
        }


        #endregion
    }
}
