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

