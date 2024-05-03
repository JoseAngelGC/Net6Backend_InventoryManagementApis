using InventoryManagement.Entities.ArticlesInventory.Bases;

namespace InventoryManagement.Entities.ArticlesInventory.Catalogs
{
    public partial class ArticleBrandCatalog : CatalogBaseEntity
    {
        public ArticleBrandCatalog()
        {
            Articles = new HashSet<Article>();
        }


        public string? BrandName { get; set; }


        public virtual ICollection<Article> Articles { get; set; }
    }
}
