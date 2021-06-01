using Microsoft.EntityFrameworkCore;
using SafetyBP.Domain.Entities;
using SafetyBP.Domain.Models;
using SafetyBP.Domain.Models.Modules.ControlObjects;
using SafetyBP.Domain.Models.Modules.CorrectiveAction;
using SafetyBP.Persistance.EntityConfigurations;
using SafetyBP.Persistance.EntityConfigurations.Modules.CorrectiveAction;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SafetyBP.Persistance
{
    public class SafetyContext : DbContext
    {
        private readonly NLog.ILogger Logger = NLog.LogManager.GetCurrentClassLogger();

        private readonly string _DatabasePath;
        public DbSet<SafetyTask> Tasks { get; set; }
        public DbSet<SafetyTaskDetails> TaskDetails { get; set; }
        public DbSet<SafetyTaskCheckList> TaskDetailsCheckLists { get; set; }
        public DbSet<ControlObjectsHardware> Hardwares { get; set; }
        public DbSet<ControlObjectsSector> ControlObjectsSectors { get; set; }
        public DbSet<ControlObjectsSurvey> ControlObjectsSurveys { get; set; }
        public DbSet<ControlObjectsQuestion> ControlObjectsQuestions { get; set; }
        public DbSet<ControlObjectsCheckList> ControlObjectsCheckLists { get; set; }

        public DbSet<CorrectiveActionSector> CorrectiveActionSectors { get; set; }
        public DbSet<CorrectiveActionTopic> CorrectiveActionTopics { get; set; }
        public DbSet<CorrectiveActionTask> CorrectiveActionTasks { get; set; }



        public DbSet<SafetyCheckList> CheckLists { get; set; }
        public DbSet<SafetyCheckListDetail> CheckListDetails { get; set; }
        public DbSet<SafetyCheckListQuestion> CheckListQuestions { get; set; }
        public DbSet<SafetySector> Sectors { get; set; }
        public DbSet<SafetySpontaneousDiversion> SpontaneousDiversions { get; set; }
        public DbSet<OffLineRequest> OffLineRequests { get; set; }
        public DbSet<OffLineOperation> OffLineOperations { get; set; }

        public SafetyContext():this(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "safetybp2.db"))
        {
            
        }

        public SafetyContext(string database)
        {
            SQLitePCL.Batteries_V2.Init();
            _DatabasePath = database;

            if (!File.Exists(_DatabasePath))
            {
                var dbCreated = Database.EnsureCreated();
                if (!dbCreated)
                {
                    Logger.Info("DB Created");
                }
                else
                {
                    Logger.Info("DB Not Created");
                }
            }
        }

        public async Task DropDatabase() 
        {
            await Database.EnsureDeletedAsync();
        }

        public SafetyContext(DbContextOptions options) : base(options)
        {
            SQLitePCL.Batteries_V2.Init();
            _DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "safetybp2.db");
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_DatabasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ControlObjectsHardwareConfiguration());
            modelBuilder.ApplyConfiguration(new ControlObjectsSectorsConfiguration());
            modelBuilder.ApplyConfiguration(new ControlObjectsSurveyConfiguration());
            modelBuilder.ApplyConfiguration(new ControlObjectsQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new ControlObjectsCheckListConfiguration());
            modelBuilder.ApplyConfiguration(new ControlObjectsCheckListNegativeValueConfiguration());

            modelBuilder.ApplyConfiguration(new CorrectiveActionSectorConfiguration());
            modelBuilder.ApplyConfiguration(new CorrectiveActionTopicConfiguration());
            modelBuilder.ApplyConfiguration(new CorrectiveActionTaskConfiguration());            

            modelBuilder.ApplyConfiguration(new SafetyTaskConfiguration());
            modelBuilder.ApplyConfiguration(new SafetyTaskDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new SafetyTaskCheckListConfiguration());

            modelBuilder.ApplyConfiguration(new SafetyCheckListConfiguration());
            modelBuilder.ApplyConfiguration(new SafetyCheckListDetailConfiguration());
            modelBuilder.ApplyConfiguration(new SafetyCheckListQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new SafetyNegativeValueConfiguration());
            modelBuilder.ApplyConfiguration(new SafetySectorConfiguration());
            modelBuilder.ApplyConfiguration(new SafetySpontaneousDiversionConfiguration());

            modelBuilder.ApplyConfiguration(new OffLineRequestConfiguration());
            modelBuilder.ApplyConfiguration(new OffLineOperationConfiguration());
        }
    }
}
