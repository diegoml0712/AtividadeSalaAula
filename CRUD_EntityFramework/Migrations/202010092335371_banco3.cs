namespace CRUD_EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class banco3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalaAulas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Professor = c.String(),
                        Sala = c.String(),
                        Curso = c.String(),
                        Data = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Agenda");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Agenda",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Telefone = c.String(),
                        Cep = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.SalaAulas");
        }
    }
}
