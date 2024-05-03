using InventoryManagement.Entities.ArticlesInventory.Bases;
using InventoryManagement.Entities.ArticlesInventory.Store;

namespace InventoryManagement.Entities.ArticlesInventory.Catalogs
{
    public partial class UbicationCatalog : CatalogBaseEntity
    {
        public UbicationCatalog()
        {
            ArticleStores = new HashSet<ArticleStore>();
        }


        public string? UbicationName { get; set; }


        public virtual ICollection<ArticleStore> ArticleStores { get; set; }
    }
}
