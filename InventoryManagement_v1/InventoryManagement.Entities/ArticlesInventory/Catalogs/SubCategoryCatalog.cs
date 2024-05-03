using InventoryManagement.Entities.ArticlesInventory.Bases;

namespace InventoryManagement.Entities.ArticlesInventory.Catalogs
{
    public partial class SubCategoryCatalog : CatalogBaseEntity
    {
        public SubCategoryCatalog()
        {
            Articles = new HashSet<Article>();
        }


        public string? SubCategoryName { get; set; }


        public virtual ICollection<Article> Articles { get; set; }
    }
}
