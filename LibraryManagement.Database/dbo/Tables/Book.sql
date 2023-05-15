-- Model New Model
-- Updated 17. 2. 2012. 07:00:00
-- DDL Generated 11. 5. 2023. 12:33:16

--**********************************************************************
--	Tables
--**********************************************************************

-- Table dbo.Book
create table
	[dbo].[Book]
(
	[BookId] uniqueidentifier not null
	, [Ttitle] nvarchar(100) not null
	, [Author] nvarchar(100) not null
	, [Publisher] nvarchar(100) not null
	, [ReleaseYear] datetime2(7) not null
,
constraint [Pk_Book_BookId] primary key clustered
(
	[BookId] asc
)
);
GO

