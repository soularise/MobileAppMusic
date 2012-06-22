
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/13/2012 11:26:21
-- Generated from EDMX file: C:\VisualStudioProjects\RR-NEST-061312\RR-NEST-061312\NEST\Models\NESTMaster.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [RERNest];
GO
IF SCHEMA_ID(N'NESTSchema') IS NULL EXECUTE(N'CREATE SCHEMA [NESTSchema]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[NESTSchema].[FK_ContentSectionContentBody]', 'F') IS NOT NULL
    ALTER TABLE [NESTSchema].[ContentBodies] DROP CONSTRAINT [FK_ContentSectionContentBody];
GO
IF OBJECT_ID(N'[NESTSchema].[FK_ContentSectionContentType]', 'F') IS NOT NULL
    ALTER TABLE [NESTSchema].[ContentSections] DROP CONSTRAINT [FK_ContentSectionContentType];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[NESTSchema].[Configurations]', 'U') IS NOT NULL
    DROP TABLE [NESTSchema].[Configurations];
GO
IF OBJECT_ID(N'[NESTSchema].[ContentBodies]', 'U') IS NOT NULL
    DROP TABLE [NESTSchema].[ContentBodies];
GO
IF OBJECT_ID(N'[NESTSchema].[ContentSections]', 'U') IS NOT NULL
    DROP TABLE [NESTSchema].[ContentSections];
GO
IF OBJECT_ID(N'[NESTSchema].[ContentTypes]', 'U') IS NOT NULL
    DROP TABLE [NESTSchema].[ContentTypes];
GO
IF OBJECT_ID(N'[NESTSchema].[Registrants]', 'U') IS NOT NULL
    DROP TABLE [NESTSchema].[Registrants];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Configurations'
CREATE TABLE [NESTSchema].[Configurations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [GoogleAnalyticsAccount] nvarchar(max)  NULL,
    [TwitterAccount] nvarchar(max)  NULL,
    [FacebookPage] nvarchar(max)  NULL,
    [GooglePlusPage] nvarchar(max)  NULL,
    [SiteTitle] nvarchar(max)  NULL,
    [TagLine] nvarchar(max)  NULL,
    [BlogLink] nvarchar(max)  NULL,
    [RSSFeed] nvarchar(max)  NULL,
    [TwitterAnywhereAPIKey] nvarchar(max)  NULL,
    [WebsiteDomainName] nvarchar(max)  NULL,
    [LinkedInPage] nvarchar(max)  NULL,
    [ICOImage] nvarchar(max)  NULL,
    [PromotedArticleID] nvarchar(max)  NULL
);
GO

-- Creating table 'ContentBodies'
CREATE TABLE [NESTSchema].[ContentBodies] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [BodyText] nvarchar(max)  NOT NULL,
    [Type] nvarchar(max)  NULL,
    [SubHeader] nvarchar(max)  NULL,
    [Promote] nvarchar(max)  NULL,
    [CreationDate] nvarchar(max)  NULL,
    [Owner] nvarchar(max)  NULL,
    [ContentSection_ID] int  NOT NULL,
    [SortOrder] int  NULL,
    [Icon] nvarchar(max)  NULL,
    [SEOUrl] nvarchar(max)  NULL,
    [TeaserText] nvarchar(max)  NULL,
    [MediaSourceURL] nvarchar(max)  NULL,
    [IFrameURL] nvarchar(max)  NULL,
    [IncludePageHeader] nchar(10)  NULL,
    [TitleSize] nchar(2)  NULL,
    [SubHeaderSize] nchar(2)  NULL,
    [ExtraText] nvarchar(max)  NULL
);
GO

-- Creating table 'ContentSections'
CREATE TABLE [NESTSchema].[ContentSections] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Header] nvarchar(max)  NOT NULL,
    [URL] nvarchar(max)  NOT NULL,
    [CreationDate] nvarchar(max)  NOT NULL,
    [ContentTypeId] int  NOT NULL,
    [RegistrantId] int  NULL,
    [Active] nvarchar(50)  NULL,
    [Private] nvarchar(50)  NULL
);
GO

-- Creating table 'ContentTypes'
CREATE TABLE [NESTSchema].[ContentTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Behavior] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Registrants'
CREATE TABLE [NESTSchema].[Registrants] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [MI] nvarchar(max)  NULL,
    [Company] nvarchar(max)  NULL,
    [Occupation] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NOT NULL,
    [HomePhone] nvarchar(max)  NULL,
    [CellPhone] nvarchar(max)  NULL,
    [Address1] nvarchar(max)  NULL,
    [Address2] nvarchar(max)  NULL,
    [City] nvarchar(max)  NULL,
    [State] nvarchar(max)  NULL,
    [ZipCode] nvarchar(max)  NOT NULL,
    [WebsiteURL] nvarchar(max)  NULL,
    [TwitterURL] nvarchar(max)  NULL,
    [FacebookURL] nvarchar(max)  NULL,
    [LinkedInURL] nvarchar(max)  NULL,
    [Comments] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Configurations'
ALTER TABLE [NESTSchema].[Configurations]
ADD CONSTRAINT [PK_Configurations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContentBodies'
ALTER TABLE [NESTSchema].[ContentBodies]
ADD CONSTRAINT [PK_ContentBodies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContentSections'
ALTER TABLE [NESTSchema].[ContentSections]
ADD CONSTRAINT [PK_ContentSections]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContentTypes'
ALTER TABLE [NESTSchema].[ContentTypes]
ADD CONSTRAINT [PK_ContentTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Registrants'
ALTER TABLE [NESTSchema].[Registrants]
ADD CONSTRAINT [PK_Registrants]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ContentSection_ID] in table 'ContentBodies'
ALTER TABLE [NESTSchema].[ContentBodies]
ADD CONSTRAINT [FK_ContentSectionContentBody]
    FOREIGN KEY ([ContentSection_ID])
    REFERENCES [NESTSchema].[ContentSections]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContentSectionContentBody'
CREATE INDEX [IX_FK_ContentSectionContentBody]
ON [NESTSchema].[ContentBodies]
    ([ContentSection_ID]);
GO

-- Creating foreign key on [ContentTypeId] in table 'ContentSections'
ALTER TABLE [NESTSchema].[ContentSections]
ADD CONSTRAINT [FK_ContentSectionContentType]
    FOREIGN KEY ([ContentTypeId])
    REFERENCES [NESTSchema].[ContentTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContentSectionContentType'
CREATE INDEX [IX_FK_ContentSectionContentType]
ON [NESTSchema].[ContentSections]
    ([ContentTypeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------