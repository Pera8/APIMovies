// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

namespace Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211025080408_addDTO")]
    partial class addDTO
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ActorMovie", b =>
                {
                    b.Property<int>("ActorsListId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesListId")
                        .HasColumnType("int");

                    b.HasKey("ActorsListId", "MoviesListId");

                    b.HasIndex("MoviesListId");

                    b.ToTable("ActorMovie");
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.Property<int>("GenreListId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesListId")
                        .HasColumnType("int");

                    b.HasKey("GenreListId", "MoviesListId");

                    b.HasIndex("MoviesListId");

                    b.ToTable("GenreMovie");
                });

            modelBuilder.Entity("Repository.Models.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("Repository.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Repository.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("ActorMovie", b =>
                {
                    b.HasOne("Repository.Models.Actor", null)
                        .WithMany()
                        .HasForeignKey("ActorsListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Repository.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.HasOne("Repository.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenreListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Repository.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
