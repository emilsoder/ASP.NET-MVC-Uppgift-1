using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BlogApplication2.Data;

namespace BlogApplication2.Migrations
{
    [DbContext(typeof(BlogRecordsContext))]
    [Migration("20170106155504_File")]
    partial class File
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlogApplication2.Models.BlogPost", b =>
                {
                    b.Property<int>("BlogPostID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BodyText")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 2000);

                    b.Property<string>("CategoryName");

                    b.Property<string>("HeaderText")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<DateTime>("PublishDate");

                    b.Property<string>("UserID");

                    b.HasKey("BlogPostID");

                    b.ToTable("BlogPost");
                });

            modelBuilder.Entity("BlogApplication2.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BlogApplication2.Models.File", b =>
                {
                    b.Property<int>("FileId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlogPostID");

                    b.Property<byte[]>("Content");

                    b.Property<string>("ContentType")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("FileName")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<int>("FileType");

                    b.HasKey("FileId");

                    b.HasIndex("BlogPostID");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("BlogApplication2.Models.File", b =>
                {
                    b.HasOne("BlogApplication2.Models.BlogPost", "BlogPost")
                        .WithMany("Files")
                        .HasForeignKey("BlogPostID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
