using InventoryManagement.Entities.ArticlesInventory.Bases;
using InventoryManagement.Entities.ArticlesInventory.Inputs;

namespace InventoryManagement.Entities.ArticlesInventory.Catalogs
{
    public partial class InputTypeCatalog : CatalogBaseEntity
    {
        public InputTypeCatalog()
        {
            InputOrders = new HashSet<InputOrder>();
        }


        public string? InputTypeName { get; set; }


        public virtual ICollection<InputOrder> InputOrders { get; set; }
    }
}
