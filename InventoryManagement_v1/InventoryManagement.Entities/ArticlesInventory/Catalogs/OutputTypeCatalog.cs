using InventoryManagement.Entities.ArticlesInventory.Bases;
using InventoryManagement.Entities.ArticlesInventory.Outputs;

namespace InventoryManagement.Entities.ArticlesInventory.Catalogs
{
    public partial class OutputTypeCatalog : CatalogBaseEntity
    {
        public OutputTypeCatalog()
        {
            OutputOrders = new HashSet<OutputOrder>();
        }


        public string? OutputTypeName { get; set; }


        public virtual ICollection<OutputOrder> OutputOrders { get; set; }
    }
}
