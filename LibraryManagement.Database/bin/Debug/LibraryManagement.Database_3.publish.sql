﻿/*
Deployment script for LibraryDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "LibraryDB"
:setvar DefaultFilePrefix "LibraryDB"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
The column [dbo].[Book].[Title] is being dropped, data loss could occur.

The column [dbo].[Book].[Ttitle] on table [dbo].[Book] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.
*/

IF EXISTS (select top 1 1 from [dbo].[Book])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Dropping Foreign Key [dbo].[Fk_Book_Rental_BookId]...';


GO
ALTER TABLE [dbo].[Rental] DROP CONSTRAINT [Fk_Book_Rental_BookId];


GO
PRINT N'Starting rebuilding table [dbo].[Book]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Book] (
    [BookId]      UNIQUEIDENTIFIER NOT NULL,
    [Ttitle]      NVARCHAR (100)   NOT NULL,
    [Author]      NVARCHAR (100)   NOT NULL,
    [Publisher]   NVARCHAR (100)   NOT NULL,
    [ReleaseYear] DATETIME2 (7)    NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_Pk_Book_BookId1] PRIMARY KEY CLUSTERED ([BookId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Book])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_Book] ([BookId], [Author], [Publisher], [ReleaseYear])
        SELECT   [BookId],
                 [Author],
                 [Publisher],
                 [ReleaseYear]
        FROM     [dbo].[Book]
        ORDER BY [BookId] ASC;
    END

DROP TABLE [dbo].[Book];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Book]', N'Book';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_Pk_Book_BookId1]', N'Pk_Book_BookId', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating Foreign Key [dbo].[Fk_Book_Rental_BookId]...';


GO
ALTER TABLE [dbo].[Rental] WITH NOCHECK
    ADD CONSTRAINT [Fk_Book_Rental_BookId] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Book] ([BookId]);


GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


INSERT INTO [dbo].Book (BookId,Author,Publisher,ReleaseYear,Ttitle)
VALUES (newid(),'Mato Lovrak','Svjetlost',GETUTCDATE(),'Vlak u snijegu')


-- Hint: napisat logiku da provjeri da li ima vec postojeci rekord
-- ako ima nemoj radit insert ako nema uradi
-- ScriptExecutionHistory tabela koja vodi racuna o scriptid i exeuction time

GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Rental] WITH CHECK CHECK CONSTRAINT [Fk_Book_Rental_BookId];


GO
PRINT N'Update complete.';


GO