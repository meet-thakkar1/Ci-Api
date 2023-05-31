using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CI_API.Models.Models;

namespace CI_API.Models.Data
{
    public partial class CiApiContext : DbContext
    {
        public CiApiContext()
        {
        }

        public CiApiContext(DbContextOptions<CiApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Banner> Banners { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<CmsPage> CmsPages { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<ContactU> ContactUs { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<FavouriteMission> FavouriteMissions { get; set; } = null!;
        public virtual DbSet<GoalMission> GoalMissions { get; set; } = null!;
        public virtual DbSet<Mission> Missions { get; set; } = null!;
        public virtual DbSet<MissionApplication> MissionApplications { get; set; } = null!;
        public virtual DbSet<MissionDocument> MissionDocuments { get; set; } = null!;
        public virtual DbSet<MissionInvite> MissionInvites { get; set; } = null!;
        public virtual DbSet<MissionMedium> MissionMedia { get; set; } = null!;
        public virtual DbSet<MissionRating> MissionRatings { get; set; } = null!;
        public virtual DbSet<MissionSkill> MissionSkills { get; set; } = null!;
        public virtual DbSet<MissionTheme> MissionThemes { get; set; } = null!;
        public virtual DbSet<PasswordReset> PasswordResets { get; set; } = null!;
        public virtual DbSet<Skill> Skills { get; set; } = null!;
        public virtual DbSet<Story> Stories { get; set; } = null!;
        public virtual DbSet<StoryInvite> StoryInvites { get; set; } = null!;
        public virtual DbSet<StoryMedium> StoryMedia { get; set; } = null!;
        public virtual DbSet<Timesheet> Timesheets { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserSkill> UserSkills { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=PCT42\\SQLSERVER2019;DataBase=Ci-Api;User ID=sa;Password=Tatva@123;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admin");

                entity.Property(e => e.AdminId).HasColumnName("admin_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.Email)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(225)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Banner>(entity =>
            {
                entity.ToTable("banner");

                entity.Property(e => e.BannerId).HasColumnName("banner_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.Image)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.SortOrder)
                    .HasColumnName("sort_order")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Text)
                    .HasColumnType("text")
                    .HasColumnName("text");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__city__country_id__32AB8735");
            });

            modelBuilder.Entity<CmsPage>(entity =>
            {
                entity.ToTable("cms_page");

                entity.Property(e => e.CmsPageId).HasColumnName("cms_page_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Slug)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("slug");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comment");

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.ApprovalStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("approval_status")
                    .HasDefaultValueSql("('PENDING')");

                entity.Property(e => e.Commenttext)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("commenttext");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.MissionId).HasColumnName("mission_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__comment__mission__3493CFA7");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__comment__user_id__339FAB6E");
            });

            modelBuilder.Entity<ContactU>(entity =>
            {
                entity.HasKey(e => e.ContactusId)
                    .HasName("PK__contact___226C46797D7E1124");

                entity.ToTable("contact_us");

                entity.Property(e => e.ContactusId).HasColumnName("contactus_id");

                entity.Property(e => e.ContactMessage).HasColumnName("contact_message");

                entity.Property(e => e.ContactSubject)
                    .HasMaxLength(300)
                    .HasColumnName("contact_subject");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ContactUs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__contact_u__user___3587F3E0");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.Iso)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("ISO");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<FavouriteMission>(entity =>
            {
                entity.ToTable("favourite_mission");

                entity.Property(e => e.FavouriteMissionId).HasColumnName("favourite_mission_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.MissionId).HasColumnName("mission_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.FavouriteMissions)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__favourite__missi__37703C52");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FavouriteMissions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__favourite__user___367C1819");
            });

            modelBuilder.Entity<GoalMission>(entity =>
            {
                entity.ToTable("goal_mission");

                entity.Property(e => e.GoalMissionId).HasColumnName("goal_mission_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.GoalObjectiveText)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("goal_objective_text");

                entity.Property(e => e.GoalValue).HasColumnName("goal_value");

                entity.Property(e => e.MissionId).HasColumnName("mission_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.GoalMissions)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__goal_miss__missi__3864608B");
            });

            modelBuilder.Entity<Mission>(entity =>
            {
                entity.ToTable("mission");

                entity.Property(e => e.MissionId).HasColumnName("mission_id");

                entity.Property(e => e.Availability)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("availability");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeadLine).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date");

                entity.Property(e => e.MissionType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("mission_type");

                entity.Property(e => e.OrganizationDetail)
                    .HasColumnType("text")
                    .HasColumnName("organization_detail");

                entity.Property(e => e.OrganizationName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("organization_name");

                entity.Property(e => e.Seatleft)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("seatleft");

                entity.Property(e => e.ShortDescription)
                    .HasColumnType("text")
                    .HasColumnName("short_description");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("start_date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.ThemeId).HasColumnName("theme_id");

                entity.Property(e => e.Title)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Missions)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mission__city_id__3B40CD36");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Missions)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mission__country__3A4CA8FD");

                entity.HasOne(d => d.Theme)
                    .WithMany(p => p.Missions)
                    .HasForeignKey(d => d.ThemeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mission__theme_i__395884C4");
            });

            modelBuilder.Entity<MissionApplication>(entity =>
            {
                entity.ToTable("mission_application");

                entity.Property(e => e.MissionApplicationId).HasColumnName("mission_application_id");

                entity.Property(e => e.AppliedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("applied_at");

                entity.Property(e => e.ApprovalStatus)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("approval_status")
                    .HasDefaultValueSql("('PENDING')");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.MissionId).HasColumnName("mission_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.MissionApplications)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mission_a__missi__3C34F16F");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MissionApplications)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mission_a__user___3D2915A8");
            });

            modelBuilder.Entity<MissionDocument>(entity =>
            {
                entity.ToTable("mission_document");

                entity.Property(e => e.MissionDocumentId).HasColumnName("mission_document_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.DocumentName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("document_name");

                entity.Property(e => e.DocumentPath)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("document_path");

                entity.Property(e => e.DocumentType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("document_type");

                entity.Property(e => e.MissionId).HasColumnName("mission_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.MissionDocuments)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mission_d__missi__3E1D39E1");
            });

            modelBuilder.Entity<MissionInvite>(entity =>
            {
                entity.ToTable("mission_invite");

                entity.Property(e => e.MissionInviteId).HasColumnName("mission_invite_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.FromUserId).HasColumnName("from_user_id");

                entity.Property(e => e.MissionId).HasColumnName("mission_id");

                entity.Property(e => e.ToUserId).HasColumnName("to_user_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.FromUser)
                    .WithMany(p => p.MissionInviteFromUsers)
                    .HasForeignKey(d => d.FromUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mission_i__from___40058253");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.MissionInvites)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mission_i__missi__3F115E1A");

                entity.HasOne(d => d.ToUser)
                    .WithMany(p => p.MissionInviteToUsers)
                    .HasForeignKey(d => d.ToUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mission_i__to_us__40F9A68C");
            });

            modelBuilder.Entity<MissionMedium>(entity =>
            {
                entity.HasKey(e => e.MissionMediaId)
                    .HasName("PK__mission___848A78E8DCAA9ED1");

                entity.ToTable("mission_media");

                entity.Property(e => e.MissionMediaId).HasColumnName("mission_media_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Default)
                    .HasColumnName("default")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.MediaName)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("media_name");

                entity.Property(e => e.MediaPath)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("media_path");

                entity.Property(e => e.MediaType)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("media_type");

                entity.Property(e => e.MissionId).HasColumnName("mission_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.MissionMedia)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mission_m__missi__41EDCAC5");
            });

            modelBuilder.Entity<MissionRating>(entity =>
            {
                entity.ToTable("mission_rating");

                entity.Property(e => e.MissionRatingId).HasColumnName("mission_rating_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.MissionId).HasColumnName("mission_id");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.MissionRatings)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mission_r__missi__43D61337");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MissionRatings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mission_r__user___42E1EEFE");
            });

            modelBuilder.Entity<MissionSkill>(entity =>
            {
                entity.ToTable("mission_skill");

                entity.Property(e => e.MissionSkillId).HasColumnName("mission_skill_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.MissionId).HasColumnName("mission_id");

                entity.Property(e => e.SkillId).HasColumnName("skill_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.MissionSkills)
                    .HasForeignKey(d => d.MissionId)
                    .HasConstraintName("FK__mission_s__missi__45BE5BA9");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.MissionSkills)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mission_s__skill__44CA3770");
            });

            modelBuilder.Entity<MissionTheme>(entity =>
            {
                entity.ToTable("mission_theme");

                entity.Property(e => e.MissionThemeId).HasColumnName("mission_theme_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<PasswordReset>(entity =>
            {
                entity.HasKey(e => e.Token)
                    .HasName("PK__password__CA90DA7B9C1FF5C0");

                entity.ToTable("password_reset");

                entity.Property(e => e.Token)
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasColumnName("token");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasColumnName("email");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("skill");

                entity.Property(e => e.SkillId).HasColumnName("skill_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.SkillName)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("skill_name");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Story>(entity =>
            {
                entity.ToTable("story");

                entity.Property(e => e.StoryId).HasColumnName("story_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.MissionId).HasColumnName("mission_id");

                entity.Property(e => e.PublishedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("published_at");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('DRAFT')");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.TotalViews).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.Stories)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__story__mission_i__47A6A41B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Stories)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__story__user_id__46B27FE2");
            });

            modelBuilder.Entity<StoryInvite>(entity =>
            {
                entity.ToTable("story_invite");

                entity.Property(e => e.StoryInviteId).HasColumnName("story_invite_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.FromUserId).HasColumnName("from_user_id");

                entity.Property(e => e.StoryId).HasColumnName("story_id");

                entity.Property(e => e.ToUserId).HasColumnName("to_user_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.FromUser)
                    .WithMany(p => p.StoryInviteFromUsers)
                    .HasForeignKey(d => d.FromUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__story_inv__from___498EEC8D");

                entity.HasOne(d => d.Story)
                    .WithMany(p => p.StoryInvites)
                    .HasForeignKey(d => d.StoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__story_inv__story__489AC854");

                entity.HasOne(d => d.ToUser)
                    .WithMany(p => p.StoryInviteToUsers)
                    .HasForeignKey(d => d.ToUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__story_inv__to_us__4A8310C6");
            });

            modelBuilder.Entity<StoryMedium>(entity =>
            {
                entity.HasKey(e => e.StoryMediaId)
                    .HasName("PK__story_me__29BD053CCEFB8E37");

                entity.ToTable("story_media");

                entity.Property(e => e.StoryMediaId).HasColumnName("story_media_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.Path)
                    .HasColumnType("text")
                    .HasColumnName("path");

                entity.Property(e => e.StoryId).HasColumnName("story_id");

                entity.Property(e => e.Type)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("type");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Story)
                    .WithMany(p => p.StoryMedia)
                    .HasForeignKey(d => d.StoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__story_med__story__4B7734FF");
            });

            modelBuilder.Entity<Timesheet>(entity =>
            {
                entity.ToTable("timesheet");

                entity.Property(e => e.TimesheetId).HasColumnName("timesheet_id");

                entity.Property(e => e.Action).HasColumnName("action");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateVolunteered)
                    .HasColumnType("datetime")
                    .HasColumnName("date_volunteered");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.MissionId).HasColumnName("mission_id");

                entity.Property(e => e.Notes)
                    .HasColumnType("text")
                    .HasColumnName("notes");

                entity.Property(e => e.Status)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('PENDING')");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.Timesheets)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__timesheet__missi__4D5F7D71");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Timesheets)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__timesheet__user___4C6B5938");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Availability)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("availability");

                entity.Property(e => e.Avatar)
                    .HasMaxLength(2048)
                    .IsUnicode(false)
                    .HasColumnName("avatar");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.Department)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("department");

                entity.Property(e => e.Email)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("employee_id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.LinkedInUrl)
                    .HasMaxLength(225)
                    .IsUnicode(false)
                    .HasColumnName("linked_in_url");

                entity.Property(e => e.Manager)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(225)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");

                entity.Property(e => e.ProfileText)
                    .HasColumnType("text")
                    .HasColumnName("profile_text");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.WhyIVolunteer)
                    .HasColumnType("text")
                    .HasColumnName("why_i_volunteer");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__user__city_id__4E53A1AA");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__user__country_id__4F47C5E3");
            });

            modelBuilder.Entity<UserSkill>(entity =>
            {
                entity.ToTable("user_skill");

                entity.Property(e => e.UserSkillId).HasColumnName("user_skill_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.SkillId).HasColumnName("skill_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.UserSkills)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_skil__skill__51300E55");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSkills)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_skil__user___503BEA1C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
