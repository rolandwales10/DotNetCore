using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FarmshareAdmin.Models
{
    public partial class ACF_FarmshareContext : DbContext
    {
        public ACF_FarmshareContext()
        {
        }

        public ACF_FarmshareContext(DbContextOptions<ACF_FarmshareContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CITIZEN_AGREEMENTS> CITIZEN_AGREEMENTS { get; set; } = null!;
        public virtual DbSet<CITIZEN_AGREEMENTS_CLIENT> CITIZEN_AGREEMENTS_CLIENT { get; set; } = null!;
        public virtual DbSet<CITIZEN_AGREEMENT_REDEMPTIONS> CITIZEN_AGREEMENT_REDEMPTIONS { get; set; } = null!;
        public virtual DbSet<CITIZEN_AGREEMENT_YEARS> CITIZEN_AGREEMENT_YEARS { get; set; } = null!;
        public virtual DbSet<CROP_OFFERING_LIST> CROP_OFFERING_LIST { get; set; } = null!;
        public virtual DbSet<EDIT_ACTIVITY> EDIT_ACTIVITY { get; set; } = null!;
        public virtual DbSet<FARMS> FARMS { get; set; } = null!;
        public virtual DbSet<FARM_CROPS> FARM_CROPS { get; set; } = null!;
        public virtual DbSet<FARM_PAYMENTS> FARM_PAYMENTS { get; set; } = null!;
        public virtual DbSet<FARM_PRODUCE_PICKUP_LOCATIONS> FARM_PRODUCE_PICKUP_LOCATIONS { get; set; } = null!;
        public virtual DbSet<FARM_PRODUCT_PURCHASES> FARM_PRODUCT_PURCHASES { get; set; } = null!;
        public virtual DbSet<FARM_REFERENCES> FARM_REFERENCES { get; set; } = null!;
        public virtual DbSet<FARM_YEARS> FARM_YEARS { get; set; } = null!;
        public virtual DbSet<FIELD_VALUES> FIELD_VALUES { get; set; } = null!;
        public virtual DbSet<LOCATIONS> LOCATIONS { get; set; } = null!;
        public virtual DbSet<MESSAGE_LOG> MESSAGE_LOG { get; set; } = null!;
        public virtual DbSet<REASON_CODES_FULL_VALUE_NOT_USED> REASON_CODES_FULL_VALUE_NOT_USED { get; set; } = null!;
        public virtual DbSet<REPORTS> REPORTS { get; set; } = null!;
        public virtual DbSet<SENIOR_LIVING_FACILITIES> SENIOR_LIVING_FACILITIES { get; set; } = null!;
        public virtual DbSet<STATUS_CODES> STATUS_CODES { get; set; } = null!;
        public virtual DbSet<USERS> USERS { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ACF_Farmshare");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CITIZEN_AGREEMENTS>(entity =>
            {
                entity.HasKey(e => e.CITIZEN_AGREEMENT_ID)
                    .IsClustered(false);

                entity.ToTable("CITIZEN_AGREEMENTS", "Farmshare");

                entity.Property(e => e.ADDRESS1).HasMaxLength(50);

                entity.Property(e => e.ADDRESS2).HasMaxLength(50);

                entity.Property(e => e.ADMIN_LAST_MOD_DATE).HasColumnType("datetime");

                entity.Property(e => e.BIRTH_DATE).HasColumnType("date");

                entity.Property(e => e.CITY).HasMaxLength(50);

                entity.Property(e => e.COMMENTS).HasColumnType("text");

                entity.Property(e => e.DELIVERY_DATE)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DELIVERY_LOCATION)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DELIVERY_LOCATION_TYPE)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DELIVERY_TIME)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.EMAIL).HasMaxLength(100);

                entity.Property(e => e.FARMER_LAST_MOD_DATE).HasColumnType("datetime");

                entity.Property(e => e.FIRST_NAME).HasMaxLength(50);

                entity.Property(e => e.LAST_NAME).HasMaxLength(50);

                entity.Property(e => e.PHONE).HasMaxLength(50);

                entity.Property(e => e.PHONE2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.STATE)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('ME')");

                entity.Property(e => e.TERMINATION_REASON)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WHO_SELECTS_PRODUCE)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ZIP).HasMaxLength(50);

                entity.HasOne(d => d.FARM)
                    .WithMany(p => p.CITIZEN_AGREEMENTS)
                    .HasForeignKey(d => d.FARM_ID)
                    .HasConstraintName("FK_CITIZEN_AGREEMENTS_FARMS");
            });

            modelBuilder.Entity<CITIZEN_AGREEMENTS_CLIENT>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_CITIZEN_AGREEMENTS_CLIENT_PK")
                    .IsClustered(false);

                entity.ToTable("CITIZEN_AGREEMENTS_CLIENT", "Farmshare");

                entity.Property(e => e.ADDRESS1).HasMaxLength(50);

                entity.Property(e => e.ADDRESS2).HasMaxLength(50);

                entity.Property(e => e.ADMIN_LAST_MOD_DATE)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.BIRTH_DATE)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CITY).HasMaxLength(50);

                entity.Property(e => e.COMMENTS).HasColumnType("text");

                entity.Property(e => e.DATE_ENROLLED)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DATE_INVOICED)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DELIVERY_DATE)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DELIVERY_LOCATION)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DELIVERY_LOCATION_TYPE)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DELIVERY_TIME)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.EMAIL).HasMaxLength(100);

                entity.Property(e => e.FARMER_LAST_MOD_DATE)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.FIRST_NAME).HasMaxLength(50);

                entity.Property(e => e.HISPANIC_OR_LATINO)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LAST_NAME).HasMaxLength(50);

                entity.Property(e => e.PHONE).HasMaxLength(50);

                entity.Property(e => e.PHONE2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.REASON_FULL_VALUE_NOT_USED)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.SIGNOFF_METHOD)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.STATE).HasMaxLength(50);

                entity.Property(e => e.STATUS).HasMaxLength(25);

                entity.Property(e => e.TERMINATION_REASON)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WHO_SELECTS_PRODUCE)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ZIP).HasMaxLength(50);
            });

            modelBuilder.Entity<CITIZEN_AGREEMENT_REDEMPTIONS>(entity =>
            {
                entity.HasKey(e => new { e.CITIZEN_AGREEMENT_ID, e.DATE_REDEEMED })
                    .HasName("CITIZEN_AGREEMENT_REDEMPTIONS_PK")
                    .IsClustered(false);

                entity.ToTable("CITIZEN_AGREEMENT_REDEMPTIONS", "Farmshare");

                entity.Property(e => e.DATE_REDEEMED).HasColumnType("datetime");

                entity.Property(e => e.AMOUNT).HasColumnType("money");

                entity.HasOne(d => d.CITIZEN_AGREEMENT)
                    .WithMany(p => p.CITIZEN_AGREEMENT_REDEMPTIONS)
                    .HasForeignKey(d => d.CITIZEN_AGREEMENT_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_citizen_agreement_distributions_citizen_agreements");
            });

            modelBuilder.Entity<CITIZEN_AGREEMENT_YEARS>(entity =>
            {
                entity.HasKey(e => new { e.CITIZEN_AGREEMENT_ID, e.YEAR })
                    .IsClustered(false);

                entity.ToTable("CITIZEN_AGREEMENT_YEARS", "Farmshare");

                entity.Property(e => e.DATE_ENROLLED).HasColumnType("date");

                entity.Property(e => e.REASON_FULL_VALUE_NOT_USED)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SIGNOFF_METHOD)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.STATUS).HasMaxLength(25);

                entity.HasOne(d => d.CITIZEN_AGREEMENT)
                    .WithMany(p => p.CITIZEN_AGREEMENT_YEARS)
                    .HasForeignKey(d => d.CITIZEN_AGREEMENT_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CITIZEN_AGREEMENT_YEARS_CITIZEN_AGREEMENT_ID");
            });

            modelBuilder.Entity<CROP_OFFERING_LIST>(entity =>
            {
                entity.HasKey(e => e.PRODUCE)
                    .HasName("aaaaaCROP_OFFERING_LIST_LUP_PK")
                    .IsClustered(false);

                entity.ToTable("CROP_OFFERING_LIST", "Farmshare");

                entity.Property(e => e.PRODUCE)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TYPE)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('V')");
            });

            modelBuilder.Entity<EDIT_ACTIVITY>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("EDIT_ACTIVITY_PK")
                    .IsClustered(false);

                entity.ToTable("EDIT_ACTIVITY", "Farmshare");

                entity.Property(e => e.ACTIVITY)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DATE).HasColumnType("datetime");

                entity.Property(e => e.TABLE)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FARMS>(entity =>
            {
                entity.HasKey(e => e.FARM_ID)
                    .HasName("aaaaaFARM_PK")
                    .IsClustered(false);

                entity.ToTable("FARMS", "Farmshare");

                entity.HasIndex(e => e.FARM_NAME, "farm_name_u")
                    .IsUnique();

                entity.Property(e => e.ACRES_IN_SMALL_FRUIT_CROPS).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ACRES_IN_VARIETY_OF_MIXED_VEGES).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ADMIN_COMMENTS).IsUnicode(false);

                entity.Property(e => e.CELL_PHONE).HasMaxLength(50);

                entity.Property(e => e.CITY).HasMaxLength(50);

                entity.Property(e => e.COMMENTS).HasColumnType("ntext");

                entity.Property(e => e.FARM_CONTACT_FIRST).HasMaxLength(100);

                entity.Property(e => e.FARM_CONTACT_LAST).HasMaxLength(100);

                entity.Property(e => e.FARM_LOCATION).HasMaxLength(255);

                entity.Property(e => e.FARM_NAME).HasMaxLength(200);

                entity.Property(e => e.FARM_OWNER_FIRST).HasMaxLength(50);

                entity.Property(e => e.FARM_OWNER_LAST).HasMaxLength(50);

                entity.Property(e => e.FAX).HasMaxLength(50);

                entity.Property(e => e.HOME_PHONE).HasMaxLength(50);

                entity.Property(e => e.LAST_INSPECTION_DATE).HasColumnType("date");

                entity.Property(e => e.LAST_MODIFIED_BY).HasMaxLength(50);

                entity.Property(e => e.LAST_MODIFIED_DATE)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MAIL_ADDRESS1).HasMaxLength(50);

                entity.Property(e => e.MAIL_ADDRESS2).HasMaxLength(50);

                entity.Property(e => e.NAME_ADDRESS_CHANGE_DATE).HasColumnType("datetime");

                entity.Property(e => e.SEASON_BEGINS)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SEASON_ENDS)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.STATE).HasMaxLength(2);

                entity.Property(e => e.STATUS)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VENDOR_INFO_UPDATED_DATE).HasColumnType("datetime");

                entity.Property(e => e.VENDOR_NUMBER).HasMaxLength(50);

                entity.Property(e => e.ZIP).HasMaxLength(15);
            });

            modelBuilder.Entity<FARM_CROPS>(entity =>
            {
                entity.HasKey(e => e.id)
                    .HasName("FARM_CROPS_PK")
                    .IsClustered(false);

                entity.ToTable("FARM_CROPS", "Farmshare");

                entity.HasIndex(e => new { e.FARM_ID, e.YEAR, e.PRODUCE }, "fc_natural_key")
                    .IsUnique();

                entity.Property(e => e.ACRES).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.PRODUCE)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FARM)
                    .WithMany(p => p.FARM_CROPS)
                    .HasForeignKey(d => d.FARM_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FARM_CROPS_FARMS");
            });

            modelBuilder.Entity<FARM_PAYMENTS>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("FARM_PAYMENTS_PK")
                    .IsClustered(false);

                entity.ToTable("FARM_PAYMENTS", "Farmshare");

                entity.Property(e => e.AMOUNT).HasColumnType("money");

                entity.Property(e => e.DATE_ENTERED).HasColumnType("datetime");

                entity.Property(e => e.DATE_INVOICED).HasColumnType("date");

                entity.Property(e => e.DATE_RECEIVED).HasColumnType("date");

                entity.Property(e => e.PAYMENT_TYPE)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.CITIZEN_AGREEMENT)
                    .WithMany(p => p.FARM_PAYMENTS)
                    .HasForeignKey(d => d.CITIZEN_AGREEMENT_ID)
                    .HasConstraintName("FK_FARM_PAYMENTS_AGREEMENTS");

                entity.HasOne(d => d.FARM)
                    .WithMany(p => p.FARM_PAYMENTS)
                    .HasForeignKey(d => d.FARM_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FARM_PAYMENTS_FARMS");
            });

            modelBuilder.Entity<FARM_PRODUCE_PICKUP_LOCATIONS>(entity =>
            {
                entity.ToTable("FARM_PRODUCE_PICKUP_LOCATIONS", "Farmshare");

                entity.Property(e => e.ADDRESS)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CITY)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DAYS)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LOCATION_NAME)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LOCATION_TYPE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.STATE)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.TIMES)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ZIP)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.FARM)
                    .WithMany(p => p.FARM_PRODUCE_PICKUP_LOCATIONS)
                    .HasForeignKey(d => d.FARM_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCE_PICKUP_LOCATIONS_FARMS");
            });

            modelBuilder.Entity<FARM_PRODUCT_PURCHASES>(entity =>
            {
                entity.ToTable("FARM_PRODUCT_PURCHASES", "Farmshare");

                entity.Property(e => e.FROM_FARM)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PRODUCE)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FARM)
                    .WithMany(p => p.FARM_PRODUCT_PURCHASES)
                    .HasForeignKey(d => d.FARM_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_PURCHASE_FARMS");
            });

            modelBuilder.Entity<FARM_REFERENCES>(entity =>
            {
                entity.HasKey(e => e.id)
                    .HasName("FARM_REFERENCES_PK")
                    .IsClustered(false);

                entity.ToTable("FARM_REFERENCES", "Farmshare");

                entity.Property(e => e.CONTACT_PERSON)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ORGANIZATION)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PHONE)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.FARM)
                    .WithMany(p => p.FARM_REFERENCES)
                    .HasForeignKey(d => d.FARM_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FARM_REFERENCES_FARMS");
            });

            modelBuilder.Entity<FARM_YEARS>(entity =>
            {
                entity.HasKey(e => new { e.FARM_ID, e.YEAR })
                    .IsClustered(false);

                entity.ToTable("FARM_YEARS", "Farmshare");

                entity.Property(e => e.DATE_APPLICATION_APPROVED).HasColumnType("datetime");

                entity.Property(e => e.DATE_FORM_SIGNED).HasColumnType("datetime");

                entity.Property(e => e.FARM_NAME)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.REDEMPTIONS_SIGNED_OFF).HasColumnType("date");

                entity.HasOne(d => d.FARM)
                    .WithMany(p => p.FARM_YEARS)
                    .HasForeignKey(d => d.FARM_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FARM_YEARS_FARM_ID");
            });

            modelBuilder.Entity<FIELD_VALUES>(entity =>
            {
                entity.ToTable("FIELD_VALUES", "Farmshare");

                entity.Property(e => e.COMMENTS).IsUnicode(false);

                entity.Property(e => e.FIELD_AMOUNT).HasColumnType("decimal(11, 2)");

                entity.Property(e => e.FIELD_ID)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FIELD_VALUE)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LOCATIONS>(entity =>
            {
                entity.HasKey(e => e.id)
                    .HasName("FarmshareLocation_PK")
                    .IsClustered(false);

                entity.ToTable("LOCATIONS", "Farmshare");

                entity.Property(e => e.COUNTY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LOCATION)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.ZIPCODE)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MESSAGE_LOG>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MESSAGE_LOG", "Farmshare");

                entity.Property(e => e.CREATE_TIME).HasColumnType("datetime");

                entity.Property(e => e.LOG_MESSAGE)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.USERID)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<REASON_CODES_FULL_VALUE_NOT_USED>(entity =>
            {
                entity.HasKey(e => e.CODE)
                    .HasName("FULL_VALUE_NOT_USED_REASON_CODES_PK")
                    .IsClustered(false);

                entity.ToTable("REASON_CODES_FULL_VALUE_NOT_USED", "Farmshare");

                entity.Property(e => e.CODE)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.EXPLANATION)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<REPORTS>(entity =>
            {
                entity.ToTable("REPORTS", "Farmshare");

                entity.HasIndex(e => e.reportName, "reportName_u")
                    .IsUnique();

                entity.Property(e => e.parmDate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.parmDateLabel)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.parmFarmName)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.parmId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.parmIdLabel)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.parmYear)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.parmYearLabel)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.reportComments)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.reportName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.reportingSoftware)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SENIOR_LIVING_FACILITIES>(entity =>
            {
                entity.HasKey(e => e.FACILITY_ID)
                    .HasName("SENIOR_LIVING_FACILITIES_PK")
                    .IsClustered(false);

                entity.ToTable("SENIOR_LIVING_FACILITIES", "Farmshare");

                entity.Property(e => e.ADDRESS)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CITY)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CONTACT_NAME)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CONTACT_ROLE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EMAIL)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.FACILITY_NAME)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PHONE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.STATE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ZIP)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<STATUS_CODES>(entity =>
            {
                entity.HasKey(e => e.STATUS)
                    .HasName("STATUS_CODES_PK")
                    .IsClustered(false);

                entity.ToTable("STATUS_CODES", "Farmshare");

                entity.Property(e => e.STATUS)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DESCRIPTION)
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<USERS>(entity =>
            {
                entity.ToTable("USERS", "Farmshare");

                entity.HasIndex(e => e.EMAIL_ADDRESS, "users_email")
                    .IsUnique();

                entity.Property(e => e.COMMENTS).IsUnicode(false);

                entity.Property(e => e.EMAIL_ADDRESS)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.FIRST_NAME)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.LAST_LOGIN).HasColumnType("datetime");

                entity.Property(e => e.LAST_NAME)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.PASSWORD)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TIMESTAMP)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
