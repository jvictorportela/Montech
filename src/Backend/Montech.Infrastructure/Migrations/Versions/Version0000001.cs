using FluentMigrator;

namespace Montech.Infrastructure.Migrations.Versions;

[Migration(DatabaseVersion.TABLE_USER, "Create table to save the user's information")]
public class Version0000001 : VersionBase
{
    public override void Up()
    {
        CreateTable("Usuarios")
            .WithColumn("Nome").AsString(255).NotNullable()
            .WithColumn("CpfOrCnpj").AsString(255).NotNullable()
            .WithColumn("Email").AsString(255).NotNullable()
            .WithColumn("Senha").AsString(2000).NotNullable()
            .WithColumn("UserIdentifier").AsGuid().NotNullable();

        CreateTable("Produtos")
            .WithColumn("Nome").AsString(255).NotNullable()
            .WithColumn("Categoria").AsInt64().NotNullable() // Use int para a enum CategoriaEnum
            .WithColumn("ValorCompra").AsDecimal().NotNullable()
            .WithColumn("ValorMercado").AsDecimal().Nullable()
            .WithColumn("ValorVenda").AsDecimal().Nullable()
            .WithColumn("UsuarioId").AsInt64().NotNullable().ForeignKey("FK_Produtos_Usuarios", "Usuarios", "Id");
    }
}
