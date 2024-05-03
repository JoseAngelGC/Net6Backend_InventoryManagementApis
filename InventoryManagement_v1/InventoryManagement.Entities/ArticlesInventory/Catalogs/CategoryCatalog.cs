using InventoryManagement.Entities.ArticlesInventory.Bases;

namespace InventoryManagement.Entities.ArticlesInventory.Catalogs
{
    public partial class CategoryCatalog : CatalogBaseEntity
    {
        public CategoryCatalog()
        {
            Articles = new HashSet<Article>();
        }


        public string? CategoryName { get; set; }


        public virtual ICollection<Article> Articles { get; set; }
    }
}
