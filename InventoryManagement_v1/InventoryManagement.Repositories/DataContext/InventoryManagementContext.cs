using InventoryManagement.Entities.ArticlesInventory.Catalogs;
using InventoryManagement.Entities.ArticlesInventory.Inputs;
using InventoryManagement.Entities.ArticlesInventory.Outputs;
using InventoryManagement.Entities.ArticlesInventory.Store;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Repositories.DataContext
{
    public partial class InventoryManagementContext : DbContext
    {
        public InventoryManagementContext()
        {
        }

        public InventoryManagementContext(DbContextOptions<InventoryManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; } = null!;
        public virtual DbSet<ArticleBrandCatalog> ArticleBrandCatalogs { get; set; } = null!;
        public virtual DbSet<ArticleInput> ArticleInputs { get; set; } = null!;
        public virtual DbSet<ArticleOutput> ArticleOutputs { get; set; } = null!;
        public virtual DbSet<ArticleStore> ArticleStores { get; set; } = null!;
        public virtual DbSet<ArticleSupplier> ArticleSuppliers { get; set; } = null!;
        public virtual DbSet<CategoryCatalog> CategoryCatalogs { get; set; } = null!;
        public virtual DbSet<CurrencyTypeCatalog> CurrencyTypeCatalogs { get; set; } = null!;
        public virtual DbSet<InputArticleMovement> InputArticleMovements { get; set; } = null!;
        public virtual DbSet<InputOrder> InputOrders { get; set; } = null!;
        public virtual DbSet<InputTypeCatalog> InputTypeCatalogs { get; set; } = null!;
        public virtual DbSet<MeasureUnitCatalog> MeasureUnitCatalogs { get; set; } = null!;
        public virtual DbSet<OutputOrder> OutputOrders { get; set; } = null!;
        public virtual DbSet<OutputTypeCatalog> OutputTypeCatalogs { get; set; } = null!;
        public virtual DbSet<ProductTypeCatalog> ProductTypeCatalogs { get; set; } = null!;
        public virtual DbSet<SubCategoryCatalog> SubCategoryCatalogs { get; set; } = null!;
        public virtual DbSet<SupplierCatalog> SupplierCatalogs { get; set; } = null!;
        public virtual DbSet<UbicationCatalog> UbicationCatalogs { get; set; } = null!;

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasKey(e => e.ControlCode)
                    .HasName("PK_ArticleControlCode");

                entity.ToTable("Article");

                entity.Property(e => e.ControlCode)
                    .HasColumnName("controlCode")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ArticleBrandCode).HasColumnName("articleBrandCode");

                entity.Property(e => e.ArticleName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("articleName");

                entity.Property(e => e.CategoryCode).HasColumnName("categoryCode");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("itemId");

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("shortDescription");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.SubCategoryCode).HasColumnName("subCategoryCode");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ArticleBrandCodeNavigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.ArticleBrandCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArticleBrandControlCode");

                entity.HasOne(d => d.CategoryCodeNavigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.CategoryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CategoryControlCode");

                entity.HasOne(d => d.SubCategoryCodeNavigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.SubCategoryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubCategoryControlCode");
            });

            modelBuilder.Entity<ArticleBrandCatalog>(entity =>
            {
                entity.HasKey(e => e.ControlCode)
                    .HasName("PK_ArticleBrandControlCode");

                entity.ToTable("ArticleBrandCatalog");

                entity.Property(e => e.ControlCode)
                    .HasColumnName("controlCode")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.BrandName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("brandName");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("itemId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ArticleInput>(entity =>
            {
                entity.HasKey(e => e.ControlCode)
                    .HasName("PK_ArticleInputCode");

                entity.ToTable("ArticleInput");

                entity.Property(e => e.ControlCode)
                    .HasColumnName("controlCode")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ArticleStoreCode).HasColumnName("articleStoreCode");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.InputCost)
                    .HasColumnType("decimal(12, 2)")
                    .HasColumnName("inputCost");

                entity.Property(e => e.InputCurrencyCode).HasColumnName("inputCurrencyCode");

                entity.Property(e => e.InputMeasureUnitCode).HasColumnName("inputMeasureUnitCode");

                entity.Property(e => e.InputOrderCode).HasColumnName("inputOrderCode");

                entity.Property(e => e.InputQuantity).HasColumnName("inputQuantity");

                entity.Property(e => e.InputUnitaryCost)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("inputUnitaryCost");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ArticleStoreCodeNavigation)
                    .WithMany(p => p.ArticleInputs)
                    .HasForeignKey(d => d.ArticleStoreCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArticleStoreCode");

                entity.HasOne(d => d.InputCurrencyCodeNavigation)
                    .WithMany(p => p.ArticleInputs)
                    .HasForeignKey(d => d.InputCurrencyCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CurrencyCtrCode");

                entity.HasOne(d => d.InputMeasureUnitCodeNavigation)
                    .WithMany(p => p.ArticleInputs)
                    .HasForeignKey(d => d.InputMeasureUnitCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InputMeasureUnitCode");

                entity.HasOne(d => d.InputOrderCodeNavigation)
                    .WithMany(p => p.ArticleInputs)
                    .HasForeignKey(d => d.InputOrderCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InputOrderCode");
            });

            modelBuilder.Entity<ArticleOutput>(entity =>
            {
                entity.HasKey(e => e.ControlCode)
                    .HasName("PK_ArticleOutputCode");

                entity.ToTable("ArticleOutput");

                entity.Property(e => e.ControlCode)
                    .HasColumnName("controlCode")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ArticleStoreCode).HasColumnName("articleStoreCode");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.OutputCost)
                    .HasColumnType("decimal(12, 2)")
                    .HasColumnName("outputCost");

                entity.Property(e => e.OutputMeasureUnitCode).HasColumnName("outputMeasureUnitCode");

                entity.Property(e => e.OutputOrderCode).HasColumnName("outputOrderCode");

                entity.Property(e => e.OutputQuantity).HasColumnName("outputQuantity");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ArticleStoreCodeNavigation)
                    .WithMany(p => p.ArticleOutputs)
                    .HasForeignKey(d => d.ArticleStoreCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArticleStoreControlCode");

                entity.HasOne(d => d.OutputMeasureUnitCodeNavigation)
                    .WithMany(p => p.ArticleOutputs)
                    .HasForeignKey(d => d.OutputMeasureUnitCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OutputMeasureUnitCode");

                entity.HasOne(d => d.OutputOrderCodeNavigation)
                    .WithMany(p => p.ArticleOutputs)
                    .HasForeignKey(d => d.OutputOrderCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OutputOrderCode");
            });

            modelBuilder.Entity<ArticleStore>(entity =>
            {
                entity.HasKey(e => e.ControlCode)
                    .HasName("PK_ArticleStoreControlCode");

                entity.ToTable("ArticleStore");

                entity.Property(e => e.ControlCode)
                    .HasColumnName("controlCode")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ArticleSupplierCode).HasColumnName("articleSupplierCode");

                entity.Property(e => e.BarCode).HasColumnName("barCode");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CurrencyCode).HasColumnName("currencyCode");

                entity.Property(e => e.CurrentStock).HasColumnName("currentStock");

                entity.Property(e => e.InputCompleted).HasColumnName("inputCompleted");

                entity.Property(e => e.InputStock).HasColumnName("inputStock");

                entity.Property(e => e.LastArticleStoreMovementCode).HasColumnName("lastArticleStoreMovementCode");

                entity.Property(e => e.Lote)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("lote");

                entity.Property(e => e.OutputStock).HasColumnName("outputStock");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.StockCost)
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("stockCost");

                entity.Property(e => e.StockMeasureUnitCode).HasColumnName("stockMeasureUnitCode");

                entity.Property(e => e.StockUnitaryPrice)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("stockUnitaryPrice");

                entity.Property(e => e.UbicationCode).HasColumnName("ubicationCode");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ArticleSupplierCodeNavigation)
                    .WithMany(p => p.ArticleStores)
                    .HasForeignKey(d => d.ArticleSupplierCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArticleSupplierControCode");

                entity.HasOne(d => d.CurrencyCodeNavigation)
                    .WithMany(p => p.ArticleStores)
                    .HasForeignKey(d => d.CurrencyCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CurrencyCtrlCode");

                entity.HasOne(d => d.StockMeasureUnitCodeNavigation)
                    .WithMany(p => p.ArticleStores)
                    .HasForeignKey(d => d.StockMeasureUnitCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StockMeasureUnitCode");

                entity.HasOne(d => d.UbicationCodeNavigation)
                    .WithMany(p => p.ArticleStores)
                    .HasForeignKey(d => d.UbicationCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UbicationControlCode");
            });

            modelBuilder.Entity<ArticleSupplier>(entity =>
            {
                entity.HasKey(e => e.ControlCode)
                    .HasName("PK_ArticleSupplierControlCode");

                entity.ToTable("ArticleSupplier");

                entity.Property(e => e.ControlCode)
                    .HasColumnName("controlCode")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ArticleCode).HasColumnName("articleCode");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ProductTypeCode).HasColumnName("productTypeCode");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.SupplierCode).HasColumnName("supplierCode");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ArticleCodeNavigation)
                    .WithMany(p => p.ArticleSuppliers)
                    .HasForeignKey(d => d.ArticleCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArticleControlCode");

                entity.HasOne(d => d.ProductTypeCodeNavigation)
                    .WithMany(p => p.ArticleSuppliers)
                    .HasForeignKey(d => d.ProductTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductTypeControlCode");

                entity.HasOne(d => d.SupplierCodeNavigation)
                    .WithMany(p => p.ArticleSuppliers)
                    .HasForeignKey(d => d.SupplierCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SupplierControlCode");
            });

            modelBuilder.Entity<CategoryCatalog>(entity =>
            {
                entity.HasKey(e => e.ControlCode)
                    .HasName("PK_CategoryControlCode");

                entity.ToTable("CategoryCatalog");

                entity.Property(e => e.ControlCode)
                    .HasColumnName("controlCode")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("categoryName");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("itemId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CurrencyTypeCatalog>(entity =>
            {
                entity.HasKey(e => e.ControlCode)
                    .HasName("PK_CurrencyTypeControlCode");

                entity.ToTable("CurrencyTypeCatalog");

                entity.Property(e => e.ControlCode)
                    .HasColumnName("controlCode")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CurrencyTypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("currencyTypeName");

                entity.Property(e => e.ItemId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("itemId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<InputArticleMovement>(entity =>
            {
                entity.HasKey(e => e.ControlCode)
                    .HasName("PK_InputArticleMovementControlCode");

                entity.ToTable("InputArticleMovement");

                entity.Property(e => e.ControlCode)
                    .HasColumnName("controlCode")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ArticleMovementCode).HasColumnName("articleMovementCode");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.MovementType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("movementType");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<InputOrder>(entity =>
            {
                entity.HasKey(e => e.ControlCode)
                    .HasName("PK_InputOrderControlCode");

                entity.ToTable("InputOrder");

                entity.Property(e => e.ControlCode)
                    .HasColumnName("controlCode")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ArticleQuantity).HasColumnName("articleQuantity");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CurrencyCode).HasColumnName("currencyCode");

                entity.Property(e => e.EntityCode)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("entityCode");

                entity.Property(e => e.EntityType)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("entityType");

                entity.Property(e => e.FolioNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("folioNumber");

                entity.Property(e => e.InputTypeCode).HasColumnName("inputTypeCode");

                entity.Property(e => e.SubtotalCost)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("subtotalCost");

                entity.Property(e => e.TotalCost)
                    .HasColumnType("decimal(12, 2)")
                    .HasColumnName("totalCost");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CurrencyCodeNavigation)
                    .WithMany(p => p.InputOrders)
                    .HasForeignKey(d => d.CurrencyCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CurrencyControlCode");

                entity.HasOne(d => d.InputTypeCodeNavigation)
                    .WithMany(p => p.InputOrders)
                    .HasForeignKey(d => d.InputTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InputTypeControlCode");
            });

            modelBuilder.Entity<InputTypeCatalog>(entity =>
            {
                entity.HasKey(e => e.ControlCode)
                    .HasName("PK_InputTypeControlCode");

                entity.ToTable("InputTypeCatalog");

                entity.Property(e => e.ControlCode)
                    .HasColumnName("controlCode")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.InputTypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("itemId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MeasureUnitCatalog>(entity =>
            {
                entity.HasKey(e => e.ControlCode)
                    .HasName("PK_MeasureUnitControlCode");

                entity.ToTable("MeasureUnitCatalog");

                entity.Property(e => e.ControlCode)
                    .HasColumnName("controlCode")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Acronym)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("acronym");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("itemId");

                entity.Property(e => e.MeasureUnitName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("measureUnitName");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<OutputOrder>(entity =>
            {
                entity.HasKey(e => e.ControlCode)
                    .HasName("PK_OutputOrderControlCode");

                entity.ToTable("OutputOrder");

                entity.Property(e => e.ControlCode)
                    .HasColumnName("controlCode")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ArticleQuantity).HasColumnName("articleQuantity");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CurrencyCode).HasColumnName("currencyCode");

                entity.Property(e => e.EntityCode)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("entityCode");

                entity.Property(e => e.EntityType)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("entityType");

                entity.Property(e => e.FolioNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("folioNumber");

                entity.Property(e => e.OutputTypeCode).HasColumnName("outputTypeCode");

                entity.Property(e => e.SubtotalCost)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("subtotalCost");

                entity.Property(e => e.TotalCost)
                    .HasColumnType("decimal(12, 2)")
                    .HasColumnName("totalCost");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CurrencyCodeNavigation)
                    .WithMany(p => p.OutputOrders)
                    .HasForeignKey(d => d.CurrencyCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CurrencyCode");

                entity.HasOne(d => d.OutputTypeCodeNavigation)
                    .WithMany(p => p.OutputOrders)
                    .HasForeignKey(d => d.OutputTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OutputTypeControlCode");
            });

            modelBuilder.Entity<OutputTypeCatalog>(entity =>
            {
                entity.HasKey(e => e.ControlCode)
                    .HasName("PK_OutputTypeControlCode");

                entity.ToTable("OutputTypeCatalog");

                entity.Property(e => e.ControlCode)
                    .HasColumnName("controlCode")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("itemId");

                entity.Property(e => e.OutputTypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProductTypeCatalog>(entity =>
            {
                entity.HasKey(e => e.ControlCode)
                    .HasName("PK_ProductTypeControlCode");

                entity.ToTable("ProductTypeCatalog");

                entity.Property(e => e.ControlCode)
                    .HasColumnName("controlCode")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("itemId");

                entity.Property(e => e.ProductTypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("productTypeName");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<SubCategoryCatalog>(entity =>
            {
                entity.HasKey(e => e.ControlCode)
                    .HasName("PK_SubCategoryControlCode");

                entity.ToTable("SubCategoryCatalog");

                entity.Property(e => e.ControlCode)
                    .HasColumnName("controlCode")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("itemId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.SubCategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("subCategoryName");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<SupplierCatalog>(entity =>
            {
                entity.HasKey(e => e.ControlCode)
                    .HasName("PK_SupplierControlCode");

                entity.ToTable("SupplierCatalog");

                entity.Property(e => e.ControlCode)
                    .HasColumnName("controlCode")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CompanyEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("companyEmail");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("companyName");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("itemId");

                entity.Property(e => e.PhisicalAddress)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("phisicalAddress");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Telephone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<UbicationCatalog>(entity =>
            {
                entity.HasKey(e => e.ControlCode)
                    .HasName("PK_UbicationControlCode");

                entity.ToTable("UbicationCatalog");

                entity.Property(e => e.ControlCode)
                    .HasColumnName("controlCode")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("itemId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UbicationName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ubicationName");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
