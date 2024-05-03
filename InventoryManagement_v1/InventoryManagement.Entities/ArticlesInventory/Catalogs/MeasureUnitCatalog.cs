using InventoryManagement.Entities.ArticlesInventory.Bases;
using InventoryManagement.Entities.ArticlesInventory.Inputs;
using InventoryManagement.Entities.ArticlesInventory.Outputs;
using InventoryManagement.Entities.ArticlesInventory.Store;

namespace InventoryManagement.Entities.ArticlesInventory.Catalogs
{
    public partial class MeasureUnitCatalog : CatalogBaseEntity
    {
        public MeasureUnitCatalog()
        {
            ArticleInputs = new HashSet<ArticleInput>();
            ArticleOutputs = new HashSet<ArticleOutput>();
            ArticleStores = new HashSet<ArticleStore>();
        }


        public string? MeasureUnitName { get; set; }
        public string? Acronym { get; set; }


        public virtual ICollection<ArticleInput> ArticleInputs { get; set; }
        public virtual ICollection<ArticleOutput> ArticleOutputs { get; set; }
        public virtual ICollection<ArticleStore> ArticleStores { get; set; }
    }
}
