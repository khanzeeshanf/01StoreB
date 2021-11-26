using System;

namespace Models
{
    /// <summary>
    /// Represent Inventory
    /// </summary>
    public class Inventory
    {
        /// <summary>
        /// Name of Item
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// Item Description
        /// </summary>
        public String Description { get; set; }
        /// <summary>
        /// Price of Item
        /// </summary>
        public Double Price { get; set; }
        /// <summary>
        /// Qty of Item
        /// </summary>
        public int Qty { get; set; }
        /// <summary>
        /// Uniq code for each Item
        /// </summary>
        public String InventoryCode { get; set; }
    }
}