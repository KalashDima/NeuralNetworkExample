using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using NeuralNetworkExample;

namespace NeuralNetworkWinForms
{
    public partial class NeuralNetworkDBSQL : DbContext
    {
        public NeuralNetworkDBSQL()
            : base("name=NeuralNetworkDBSQL")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<NeuralNetworkDBSQL>());
        }

        public virtual DbSet<TrainingData> TrainingData { get; set; }
        public virtual DbSet<NeuralNetworkModel> NeuralNetworkModels { get; set; }
        public virtual DbSet<LayerData> LayerData { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LayerData>()
                .HasRequired(ld => ld.NeuralNetworkModel)
                .WithMany(nnm => nnm.Layers)
                .HasForeignKey(ld => ld.NeuralNetworkModelId);
        }
    }
}