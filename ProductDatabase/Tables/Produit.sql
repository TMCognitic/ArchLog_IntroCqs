CREATE TABLE [dbo].[Produit]
(
	[Id] INT NOT NULL IDENTITY, 
	[Nom] NVARCHAR(75) NOT NULL,
	[Prix] FLOAT NOT NULL,
    CONSTRAINT [PK_Produit] PRIMARY KEY ([Id]),
	CONSTRAINT [CK_Produit_Prix] CHECK ([Prix] >= 0)
)
