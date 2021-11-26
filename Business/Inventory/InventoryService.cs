using Common.DTO.Inventory;
using Business.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.InventoryDataService;
using Common.Constants;

namespace Services.Inventory
{
    public class InventoryService : IInventoryService
    {
        #region Constructor

        private readonly IInventoryDataService inventoryDataService;

        public InventoryService(IInventoryDataService invDataService)
        {
            inventoryDataService = invDataService;
        }

        #endregion

        #region Service methods

        public async Task<String> AddInventory(AddInventoryRequestDto RequestDto)
        {
            var isValid = ValidatdateItem(RequestDto);
           
            if (isValid)
            {
                var isAdded = await inventoryDataService.AddInventory(RequestDto);
                if (isAdded) return ValidationMsg.AddSuccessMessage;
                else return ValidationMsg.AddValidationMessage;
            }
            return ValidationMsg.AddValidationMessage;
        }

        public async Task<GetInventoriesResponseDto> GetInventories()
        {
            return await inventoryDataService.GetInventories();
        }

        public async Task<String> ModifyInventory(ModilfyInventoryRequestDto inventory)
        {
            var isUpdated = await inventoryDataService.ModifyInventory(inventory);
            if (isUpdated) return ValidationMsg.ModifySuccessMessage;
            else return ValidationMsg.ModifyErrorMessage;
        }

        public async Task<String> RemoveInventory(RemoveInventoryRequestDto inventory)
        {
            var isDeleted = await inventoryDataService.RemoveInventory(inventory);
            if (isDeleted) return ValidationMsg.DeleteSuccessMessage;
            else return ValidationMsg.DeleteErrorMessage;
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestDto"></param>
        /// <returns></returns>
        private bool ValidatdateItem(AddInventoryRequestDto requestDto)
        {
            if(requestDto != null && requestDto.InventoryData != null
                && !String.IsNullOrWhiteSpace(requestDto.InventoryData.Name)
                && requestDto.InventoryData.Price>0
                && !String.IsNullOrWhiteSpace(requestDto.InventoryData.InventoryCode))
                return true;
            else
                return false;
        }

        #endregion
    }
}
