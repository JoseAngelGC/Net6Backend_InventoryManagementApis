using InventoryManagement.Entities.ArticlesInventory.Bases;
using InventoryManagement.Entities.ArticlesInventory.Store;

namespace InventoryManagement.Entities.ArticlesInventory.Catalogs
{
    public partial class Article : CatalogBaseEntity
    {
        public Article()
        {
            ArticleSuppliers = new HashSet<ArticleSupplier>();
        }


        public string? ArticleName { get; set; }
        public string? ShortDescription { get; set; }
        public Guid CategoryCode { get; set; }
        public Guid SubCategoryCode { get; set; }
        public Guid ArticleBrandCode { get; set; }


        public virtual ArticleBrandCatalog ArticleBrandCodeNavigation { get; set; } = null!;
        public virtual CategoryCatalog CategoryCodeNavigation { get; set; } = null!;
        public virtual SubCategoryCatalog SubCategoryCodeNavigation { get; set; } = null!;
        public virtual ICollection<ArticleSupplier> ArticleSuppliers { get; set; }
    }
}
