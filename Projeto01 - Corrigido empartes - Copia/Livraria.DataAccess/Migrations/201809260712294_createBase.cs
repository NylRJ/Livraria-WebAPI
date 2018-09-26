namespace Livraria.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.BookAuthors",
                c => new
                    {
                        BookAuthorId = c.Guid(nullable: false),
                        BookBookId = c.Guid(nullable: false),
                        AuthorAuthorId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.BookAuthorId)
                .ForeignKey("dbo.Authors", t => t.AuthorAuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.BookBookId, cascadeDelete: true)
                .Index(t => t.BookBookId)
                .Index(t => t.AuthorAuthorId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Guid(nullable: false),
                        Titulo = c.String(),
                        Isbn = c.String(),
                        DataPublicacao = c.DateTime(nullable: false),
                        CategoriaCategoriaId = c.Guid(nullable: false),
                        EditoraEditoraId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Categorias", t => t.CategoriaCategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Editoras", t => t.EditoraEditoraId, cascadeDelete: true)
                .Index(t => t.CategoriaCategoriaId)
                .Index(t => t.EditoraEditoraId);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaId = c.Guid(nullable: false),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Editoras",
                c => new
                    {
                        EditoraId = c.Guid(nullable: false),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.EditoraId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "EditoraEditoraId", "dbo.Editoras");
            DropForeignKey("dbo.Books", "CategoriaCategoriaId", "dbo.Categorias");
            DropForeignKey("dbo.BookAuthors", "BookBookId", "dbo.Books");
            DropForeignKey("dbo.BookAuthors", "AuthorAuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "EditoraEditoraId" });
            DropIndex("dbo.Books", new[] { "CategoriaCategoriaId" });
            DropIndex("dbo.BookAuthors", new[] { "AuthorAuthorId" });
            DropIndex("dbo.BookAuthors", new[] { "BookBookId" });
            DropTable("dbo.Editoras");
            DropTable("dbo.Categorias");
            DropTable("dbo.Books");
            DropTable("dbo.BookAuthors");
            DropTable("dbo.Authors");
        }
    }
}
