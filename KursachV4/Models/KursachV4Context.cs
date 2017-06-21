using System.Data.Entity;

namespace KursachV4.Models
{
    public class KursachV4Context : DbContext
    {
        // В этот файл можно добавить пользовательский код. Изменения не будут перезаписаны.
        // 
        // Если требуется, чтобы платформа Entity Framework автоматически удаляла и формировала заново базу данных
        // при каждой смене схемы модели, добавьте следующий
        // код к методу Application_Start в файле Global.asax.
        // Примечание: в этом случае при каждой смене модели ваша база данных будет удалена и создана заново.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<KursachV4.Models.KursachV4Context>());

        public KursachV4Context() : base("name=KursachV4Context")
        {
        }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Scrap> Scraps { get; set; }

        public DbSet<Arraiving> Arraivings { get; set; }

        public DbSet<Provider> Providers { get; set; }

        public DbSet<Consumption> Consumptions { get; set; }

        public DbSet<Receiver> Receivers { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<VIPProvider> VIPProviders { get; set; }

        public DbSet<DetailsOfArraivedMetal> DetailsOfArraivedMetal { get; set; }
    }
}
