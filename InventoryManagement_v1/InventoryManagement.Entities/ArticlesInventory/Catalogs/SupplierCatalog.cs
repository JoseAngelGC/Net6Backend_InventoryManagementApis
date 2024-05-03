using InventoryManagement.Entities.ArticlesInventory.Bases;
using InventoryManagement.Entities.ArticlesInventory.Store;

namespace InventoryManagement.Entities.ArticlesInventory.Catalogs
{
    public partial class SupplierCatalog : CatalogBaseEntity
    {
        public SupplierCatalog()
        {
            ArticleSuppliers = new HashSet<ArticleSupplier>();
        }


        public string? CompanyName { get; set; }
        public string? CompanyEmail { get; set; }
        public string? Telephone { get; set; }
        public string? PhisicalAddress { get; set; }


        public virtual ICollection<ArticleSupplier> ArticleSuppliers { get; set; }
    }
}
