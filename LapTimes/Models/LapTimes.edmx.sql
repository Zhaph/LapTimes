
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/25/2013 23:08:58
-- Generated from EDMX file: c:\users\ben.duguid\documents\visual studio 2010\Projects\LapTimes\LapTimes\Models\LapTimes.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-LapTimes-20131125201630];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_RaceCurrentRacer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Racers1_CurrentRacer] DROP CONSTRAINT [FK_RaceCurrentRacer];
GO
IF OBJECT_ID(N'[dbo].[FK_RacerLeague]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Racers1] DROP CONSTRAINT [FK_RacerLeague];
GO
IF OBJECT_ID(N'[dbo].[FK_RacerClassName]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Racers1] DROP CONSTRAINT [FK_RacerClassName];
GO
IF OBJECT_ID(N'[dbo].[FK_CurrentRacer_inherits_Racer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Racers1_CurrentRacer] DROP CONSTRAINT [FK_CurrentRacer_inherits_Racer];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Races]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Races];
GO
IF OBJECT_ID(N'[dbo].[Racers1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Racers1];
GO
IF OBJECT_ID(N'[dbo].[ClassNames]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClassNames];
GO
IF OBJECT_ID(N'[dbo].[Leagues]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Leagues];
GO
IF OBJECT_ID(N'[dbo].[Racers1_CurrentRacer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Racers1_CurrentRacer];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Races'
CREATE TABLE [dbo].[Races] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IsComplete] bit  NOT NULL
);
GO

-- Creating table 'Racers'
CREATE TABLE [dbo].[Racers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [BestTime] int  NOT NULL,
    [ClassNameId] nvarchar(max)  NOT NULL,
    [League_Id] int  NOT NULL
);
GO

-- Creating table 'ClassNames'
CREATE TABLE [dbo].[ClassNames] (
    [Id] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Leagues'
CREATE TABLE [dbo].[Leagues] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Racers_CurrentRacer'
CREATE TABLE [dbo].[Racers_CurrentRacer] (
    [RaceId] int  NOT NULL,
    [RaceTime] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Races'
ALTER TABLE [dbo].[Races]
ADD CONSTRAINT [PK_Races]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Racers'
ALTER TABLE [dbo].[Racers]
ADD CONSTRAINT [PK_Racers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ClassNames'
ALTER TABLE [dbo].[ClassNames]
ADD CONSTRAINT [PK_ClassNames]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Leagues'
ALTER TABLE [dbo].[Leagues]
ADD CONSTRAINT [PK_Leagues]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Racers_CurrentRacer'
ALTER TABLE [dbo].[Racers_CurrentRacer]
ADD CONSTRAINT [PK_Racers_CurrentRacer]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RaceId] in table 'Racers_CurrentRacer'
ALTER TABLE [dbo].[Racers_CurrentRacer]
ADD CONSTRAINT [FK_RaceCurrentRacer]
    FOREIGN KEY ([RaceId])
    REFERENCES [dbo].[Races]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RaceCurrentRacer'
CREATE INDEX [IX_FK_RaceCurrentRacer]
ON [dbo].[Racers_CurrentRacer]
    ([RaceId]);
GO

-- Creating foreign key on [League_Id] in table 'Racers'
ALTER TABLE [dbo].[Racers]
ADD CONSTRAINT [FK_RacerLeague]
    FOREIGN KEY ([League_Id])
    REFERENCES [dbo].[Leagues]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RacerLeague'
CREATE INDEX [IX_FK_RacerLeague]
ON [dbo].[Racers]
    ([League_Id]);
GO

-- Creating foreign key on [ClassNameId] in table 'Racers'
ALTER TABLE [dbo].[Racers]
ADD CONSTRAINT [FK_RacerClassName]
    FOREIGN KEY ([ClassNameId])
    REFERENCES [dbo].[ClassNames]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RacerClassName'
CREATE INDEX [IX_FK_RacerClassName]
ON [dbo].[Racers]
    ([ClassNameId]);
GO

-- Creating foreign key on [Id] in table 'Racers_CurrentRacer'
ALTER TABLE [dbo].[Racers_CurrentRacer]
ADD CONSTRAINT [FK_CurrentRacer_inherits_Racer]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Racers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------