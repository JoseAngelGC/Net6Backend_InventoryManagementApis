using InventoryManagement.Entities.ArticlesInventory.Bases;
using InventoryManagement.Entities.ArticlesInventory.Store;

namespace InventoryManagement.Entities.ArticlesInventory.Catalogs
{
    public partial class ProductTypeCatalog : CatalogBaseEntity
    {
        public ProductTypeCatalog()
        {
            ArticleSuppliers = new HashSet<ArticleSupplier>();
        }


        public string? ProductTypeName { get; set; }


        public virtual ICollection<ArticleSupplier> ArticleSuppliers { get; set; }
    }
}
