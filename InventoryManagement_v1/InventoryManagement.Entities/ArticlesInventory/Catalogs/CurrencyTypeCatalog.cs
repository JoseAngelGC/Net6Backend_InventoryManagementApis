using InventoryManagement.Entities.ArticlesInventory.Bases;
using InventoryManagement.Entities.ArticlesInventory.Inputs;
using InventoryManagement.Entities.ArticlesInventory.Outputs;
using InventoryManagement.Entities.ArticlesInventory.Store;

namespace InventoryManagement.Entities.ArticlesInventory.Catalogs
{
    public partial class CurrencyTypeCatalog : CatalogBaseEntity
    {
        public CurrencyTypeCatalog()
        {
            ArticleInputs = new HashSet<ArticleInput>();
            ArticleStores = new HashSet<ArticleStore>();
            InputOrders = new HashSet<InputOrder>();
            OutputOrders = new HashSet<OutputOrder>();
        }


        public string? CurrencyTypeName { get; set; }


        public virtual ICollection<ArticleInput> ArticleInputs { get; set; }
        public virtual ICollection<ArticleStore> ArticleStores { get; set; }
        public virtual ICollection<InputOrder> InputOrders { get; set; }
        public virtual ICollection<OutputOrder> OutputOrders { get; set; }
    }
}
