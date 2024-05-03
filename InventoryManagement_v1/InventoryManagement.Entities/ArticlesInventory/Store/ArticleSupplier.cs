using InventoryManagement.Entities.ArticlesInventory.Catalogs;

namespace InventoryManagement.Entities.ArticlesInventory.Store
{
    public partial class ArticleSupplier
    {
        public ArticleSupplier()
        {
            ArticleStores = new HashSet<ArticleStore>();
        }

        public Guid ControlCode { get; set; }
        public Guid ArticleCode { get; set; }
        public Guid ProductTypeCode { get; set; }
        public Guid SupplierCode { get; set; }
        public bool? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Article ArticleCodeNavigation { get; set; } = null!;
        public virtual ProductTypeCatalog ProductTypeCodeNavigation { get; set; } = null!;
        public virtual SupplierCatalog SupplierCodeNavigation { get; set; } = null!;
        public virtual ICollection<ArticleStore> ArticleStores { get; set; }
    }
}
