using Admin.Controllers;
using Common.DTO.Inventory;
using Data.InventoryDataService;
using Microsoft.Extensions.Configuration;
using Moq;
using Services.Inventory;
using Xunit;

namespace AdminTest
{
    public class InventoryTest
    {
        [Fact]
        public void Test_GetInventories()
        {
            //Arrange
            var config = new Mock<IConfiguration>();
            var _ivnDataService = new InventoryDataService(config.Object);
            var _invServ = new InventoryService(_ivnDataService);
            var _InvContrl = new InventoryController(_invServ);
            //Act
            var result = _InvContrl.GetInventories();
            //Assert
            Assert.NotNull(result);

        }
        [Fact]
        public void Test_AddInventory()
        {
            //Arrange
            var req = new AddInventoryRequestDto();
            var config = new Mock<IConfiguration>();
            var _ivnDataService = new InventoryDataService(config.Object);
            var _invServ = new InventoryService(_ivnDataService);
            var _InvContrl = new InventoryController(_invServ);
            //Act
            var result = _InvContrl.AddInventory(req);
            //Assert
            Assert.NotNull(result);

        }
        [Fact]
        public void Test_ModifyInventory()
        {
            //Arrange
            var req = new ModilfyInventoryRequestDto();
            var config = new Mock<IConfiguration>();
            var _ivnDataService = new InventoryDataService(config.Object);
            var _invServ = new InventoryService(_ivnDataService);
            var _InvContrl = new InventoryController(_invServ);
            //Act
            var result = _InvContrl.ModifyInventory(req);
            //Assert
            Assert.NotNull(result);

        }
        [Fact]
        public void Test_RemoveInventory()
        {
            //Arrange
            var req = new RemoveInventoryRequestDto() { ItemID = 1 };
            var config = new Mock<IConfiguration>();
            var _ivnDataService = new InventoryDataService(config.Object);
            var _invServ = new InventoryService(_ivnDataService);
            var _InvContrl = new InventoryController(_invServ);
            //Act
            var result = _InvContrl.RemoveInventory(req);
            //Assert
            Assert.NotNull(result);

        }
    }
}
