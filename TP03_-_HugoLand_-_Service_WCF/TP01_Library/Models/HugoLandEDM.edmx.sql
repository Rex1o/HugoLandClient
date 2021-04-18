
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/18/2021 15:42:30
-- Generated from EDMX file: C:\Users\slala\Desktop\ECOLE\Session_4\bd\Tp03\TP03_-_HugoLand_-_Service_WCF\TP01_Library\Models\HugoLandEDM.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [4DB-Equipe5-2021];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BelongsToHero]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InventaireHero] DROP CONSTRAINT [FK_BelongsToHero];
GO
IF OBJECT_ID(N'[dbo].[FK_BelongsToItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InventaireHero] DROP CONSTRAINT [FK_BelongsToItem];
GO
IF OBJECT_ID(N'[dbo].[FK_Classe_Monde]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Classe] DROP CONSTRAINT [FK_Classe_Monde];
GO
IF OBJECT_ID(N'[dbo].[FK_EffetItem_Item]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EffetItem] DROP CONSTRAINT [FK_EffetItem_Item];
GO
IF OBJECT_ID(N'[dbo].[FK_Hero_Classe]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Heros] DROP CONSTRAINT [FK_Hero_Classe];
GO
IF OBJECT_ID(N'[dbo].[FK_Hero_Monde]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Heros] DROP CONSTRAINT [FK_Hero_Monde];
GO
IF OBJECT_ID(N'[dbo].[FK_Item_Heros]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Item] DROP CONSTRAINT [FK_Item_Heros];
GO
IF OBJECT_ID(N'[dbo].[FK_Item_Monde]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Item] DROP CONSTRAINT [FK_Item_Monde];
GO
IF OBJECT_ID(N'[dbo].[FK_Monstre_Monde]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Monstre] DROP CONSTRAINT [FK_Monstre_Monde];
GO
IF OBJECT_ID(N'[dbo].[FK_ObjetMonde_Monde]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ObjetMonde] DROP CONSTRAINT [FK_ObjetMonde_Monde];
GO
IF OBJECT_ID(N'[dbo].[FK_IsPartOfAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Heros] DROP CONSTRAINT [FK_IsPartOfAccount];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Classe]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Classe];
GO
IF OBJECT_ID(N'[dbo].[CompteJoueur]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CompteJoueur];
GO
IF OBJECT_ID(N'[dbo].[EffetItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EffetItem];
GO
IF OBJECT_ID(N'[dbo].[Heros]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Heros];
GO
IF OBJECT_ID(N'[dbo].[InventaireHero]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InventaireHero];
GO
IF OBJECT_ID(N'[dbo].[Item]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Item];
GO
IF OBJECT_ID(N'[dbo].[Monde]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Monde];
GO
IF OBJECT_ID(N'[dbo].[Monstre]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Monstre];
GO
IF OBJECT_ID(N'[dbo].[ObjetMonde]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ObjetMonde];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Classes'
CREATE TABLE [dbo].[Classes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NomClasse] nvarchar(50)  NOT NULL,
    [Description] nvarchar(128)  NOT NULL,
    [StatBaseStr] int  NOT NULL,
    [StatBaseDex] int  NOT NULL,
    [StatBaseInt] int  NOT NULL,
    [StatBaseVitalite] int  NOT NULL,
    [MondeId] int  NOT NULL
);
GO

-- Creating table 'CompteJoueurs'
CREATE TABLE [dbo].[CompteJoueurs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NomJoueur] nvarchar(50)  NOT NULL,
    [Courriel] nvarchar(255)  NOT NULL,
    [Prenom] nvarchar(50)  NOT NULL,
    [Nom] nvarchar(50)  NOT NULL,
    [TypeUtilisateur] int  NOT NULL,
    [MotDePasseHash] binary(64)  NOT NULL,
    [Salt] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'EffetItems'
CREATE TABLE [dbo].[EffetItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ItemId] int  NOT NULL,
    [ValeurEffet] int  NOT NULL,
    [TypeEffet] int  NOT NULL
);
GO

-- Creating table 'Heros'
CREATE TABLE [dbo].[Heros] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CompteJoueurId] int  NOT NULL,
    [Niveau] int  NOT NULL,
    [Experience] bigint  NOT NULL,
    [x] int  NOT NULL,
    [y] int  NOT NULL,
    [StatStr] int  NOT NULL,
    [StatDex] int  NOT NULL,
    [StatInt] int  NOT NULL,
    [StatVitalite] int  NOT NULL,
    [MondeId] int  NOT NULL,
    [ClasseId] int  NOT NULL,
    [NomHero] nvarchar(50)  NOT NULL,
    [EstConnecte] bit  NOT NULL,
    [ImageId] int  NOT NULL
);
GO

-- Creating table 'InventaireHeroes'
CREATE TABLE [dbo].[InventaireHeroes] (
    [IdHero] int IDENTITY(1,1) NOT NULL,
    [ItemId] int  NOT NULL,
    [IdInventaireHero] int  NOT NULL,
    [Quantite] int  NOT NULL
);
GO

-- Creating table 'Items'
CREATE TABLE [dbo].[Items] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(255)  NOT NULL,
    [Description] nvarchar(128)  NOT NULL,
    [x] int  NULL,
    [y] int  NULL,
    [MondeId] int  NOT NULL,
    [IdHero] int  NULL,
    [ImageId] int  NOT NULL
);
GO

-- Creating table 'Mondes'
CREATE TABLE [dbo].[Mondes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [LimiteX] int  NOT NULL,
    [LimiteY] int  NOT NULL
);
GO

-- Creating table 'Monstres'
CREATE TABLE [dbo].[Monstres] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NOT NULL,
    [Niveau] int  NOT NULL,
    [x] int  NOT NULL,
    [y] int  NOT NULL,
    [StatPV] int  NOT NULL,
    [StatDmgMin] real  NOT NULL,
    [StatDmgMax] real  NOT NULL,
    [MondeId] int  NOT NULL,
    [ImageId] int  NOT NULL
);
GO

-- Creating table 'ObjetMondes'
CREATE TABLE [dbo].[ObjetMondes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [x] int  NOT NULL,
    [y] int  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [TypeObjet] int  NOT NULL,
    [MondeId] int  NOT NULL,
    [ImageId] int  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'TileImgs'
CREATE TABLE [dbo].[TileImgs] (
    [ImageId] int IDENTITY(1,1) NOT NULL,
    [Imageb64] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Classes'
ALTER TABLE [dbo].[Classes]
ADD CONSTRAINT [PK_Classes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CompteJoueurs'
ALTER TABLE [dbo].[CompteJoueurs]
ADD CONSTRAINT [PK_CompteJoueurs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EffetItems'
ALTER TABLE [dbo].[EffetItems]
ADD CONSTRAINT [PK_EffetItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Heros'
ALTER TABLE [dbo].[Heros]
ADD CONSTRAINT [PK_Heros]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [IdInventaireHero] in table 'InventaireHeroes'
ALTER TABLE [dbo].[InventaireHeroes]
ADD CONSTRAINT [PK_InventaireHeroes]
    PRIMARY KEY CLUSTERED ([IdInventaireHero] ASC);
GO

-- Creating primary key on [Id] in table 'Items'
ALTER TABLE [dbo].[Items]
ADD CONSTRAINT [PK_Items]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Mondes'
ALTER TABLE [dbo].[Mondes]
ADD CONSTRAINT [PK_Mondes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Monstres'
ALTER TABLE [dbo].[Monstres]
ADD CONSTRAINT [PK_Monstres]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ObjetMondes'
ALTER TABLE [dbo].[ObjetMondes]
ADD CONSTRAINT [PK_ObjetMondes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [ImageId] in table 'TileImgs'
ALTER TABLE [dbo].[TileImgs]
ADD CONSTRAINT [PK_TileImgs]
    PRIMARY KEY CLUSTERED ([ImageId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MondeId] in table 'Classes'
ALTER TABLE [dbo].[Classes]
ADD CONSTRAINT [FK_Classe_Monde]
    FOREIGN KEY ([MondeId])
    REFERENCES [dbo].[Mondes]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Classe_Monde'
CREATE INDEX [IX_FK_Classe_Monde]
ON [dbo].[Classes]
    ([MondeId]);
GO

-- Creating foreign key on [ClasseId] in table 'Heros'
ALTER TABLE [dbo].[Heros]
ADD CONSTRAINT [FK_Hero_Classe]
    FOREIGN KEY ([ClasseId])
    REFERENCES [dbo].[Classes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Hero_Classe'
CREATE INDEX [IX_FK_Hero_Classe]
ON [dbo].[Heros]
    ([ClasseId]);
GO

-- Creating foreign key on [CompteJoueurId] in table 'Heros'
ALTER TABLE [dbo].[Heros]
ADD CONSTRAINT [FK_IsPartOfAccount]
    FOREIGN KEY ([CompteJoueurId])
    REFERENCES [dbo].[CompteJoueurs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IsPartOfAccount'
CREATE INDEX [IX_FK_IsPartOfAccount]
ON [dbo].[Heros]
    ([CompteJoueurId]);
GO

-- Creating foreign key on [ItemId] in table 'EffetItems'
ALTER TABLE [dbo].[EffetItems]
ADD CONSTRAINT [FK_EffetItem_Item]
    FOREIGN KEY ([ItemId])
    REFERENCES [dbo].[Items]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EffetItem_Item'
CREATE INDEX [IX_FK_EffetItem_Item]
ON [dbo].[EffetItems]
    ([ItemId]);
GO

-- Creating foreign key on [IdHero] in table 'InventaireHeroes'
ALTER TABLE [dbo].[InventaireHeroes]
ADD CONSTRAINT [FK_BelongsToHero]
    FOREIGN KEY ([IdHero])
    REFERENCES [dbo].[Heros]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BelongsToHero'
CREATE INDEX [IX_FK_BelongsToHero]
ON [dbo].[InventaireHeroes]
    ([IdHero]);
GO

-- Creating foreign key on [MondeId] in table 'Heros'
ALTER TABLE [dbo].[Heros]
ADD CONSTRAINT [FK_Hero_Monde]
    FOREIGN KEY ([MondeId])
    REFERENCES [dbo].[Mondes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Hero_Monde'
CREATE INDEX [IX_FK_Hero_Monde]
ON [dbo].[Heros]
    ([MondeId]);
GO

-- Creating foreign key on [IdHero] in table 'Items'
ALTER TABLE [dbo].[Items]
ADD CONSTRAINT [FK_Item_Heros]
    FOREIGN KEY ([IdHero])
    REFERENCES [dbo].[Heros]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Item_Heros'
CREATE INDEX [IX_FK_Item_Heros]
ON [dbo].[Items]
    ([IdHero]);
GO

-- Creating foreign key on [ItemId] in table 'InventaireHeroes'
ALTER TABLE [dbo].[InventaireHeroes]
ADD CONSTRAINT [FK_BelongsToItem]
    FOREIGN KEY ([ItemId])
    REFERENCES [dbo].[Items]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BelongsToItem'
CREATE INDEX [IX_FK_BelongsToItem]
ON [dbo].[InventaireHeroes]
    ([ItemId]);
GO

-- Creating foreign key on [MondeId] in table 'Items'
ALTER TABLE [dbo].[Items]
ADD CONSTRAINT [FK_Item_Monde]
    FOREIGN KEY ([MondeId])
    REFERENCES [dbo].[Mondes]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Item_Monde'
CREATE INDEX [IX_FK_Item_Monde]
ON [dbo].[Items]
    ([MondeId]);
GO

-- Creating foreign key on [MondeId] in table 'Monstres'
ALTER TABLE [dbo].[Monstres]
ADD CONSTRAINT [FK_Monstre_Monde]
    FOREIGN KEY ([MondeId])
    REFERENCES [dbo].[Mondes]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Monstre_Monde'
CREATE INDEX [IX_FK_Monstre_Monde]
ON [dbo].[Monstres]
    ([MondeId]);
GO

-- Creating foreign key on [MondeId] in table 'ObjetMondes'
ALTER TABLE [dbo].[ObjetMondes]
ADD CONSTRAINT [FK_ObjetMonde_Monde]
    FOREIGN KEY ([MondeId])
    REFERENCES [dbo].[Mondes]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ObjetMonde_Monde'
CREATE INDEX [IX_FK_ObjetMonde_Monde]
ON [dbo].[ObjetMondes]
    ([MondeId]);
GO

-- Creating foreign key on [ImageId] in table 'Monstres'
ALTER TABLE [dbo].[Monstres]
ADD CONSTRAINT [FK_MonstreTileImg]
    FOREIGN KEY ([ImageId])
    REFERENCES [dbo].[TileImgs]
        ([ImageId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MonstreTileImg'
CREATE INDEX [IX_FK_MonstreTileImg]
ON [dbo].[Monstres]
    ([ImageId]);
GO

-- Creating foreign key on [ImageId] in table 'ObjetMondes'
ALTER TABLE [dbo].[ObjetMondes]
ADD CONSTRAINT [FK_TileImgObjetMonde]
    FOREIGN KEY ([ImageId])
    REFERENCES [dbo].[TileImgs]
        ([ImageId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TileImgObjetMonde'
CREATE INDEX [IX_FK_TileImgObjetMonde]
ON [dbo].[ObjetMondes]
    ([ImageId]);
GO

-- Creating foreign key on [ImageId] in table 'Heros'
ALTER TABLE [dbo].[Heros]
ADD CONSTRAINT [FK_HeroTileImg]
    FOREIGN KEY ([ImageId])
    REFERENCES [dbo].[TileImgs]
        ([ImageId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HeroTileImg'
CREATE INDEX [IX_FK_HeroTileImg]
ON [dbo].[Heros]
    ([ImageId]);
GO

-- Creating foreign key on [ImageId] in table 'Items'
ALTER TABLE [dbo].[Items]
ADD CONSTRAINT [FK_TileImgItem]
    FOREIGN KEY ([ImageId])
    REFERENCES [dbo].[TileImgs]
        ([ImageId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TileImgItem'
CREATE INDEX [IX_FK_TileImgItem]
ON [dbo].[Items]
    ([ImageId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------