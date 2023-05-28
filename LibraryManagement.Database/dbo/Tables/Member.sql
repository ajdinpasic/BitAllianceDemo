-- Table dbo.Member
-- Table dbo.Member
create table
	[dbo].[Member]
(
	[MemberId] uniqueidentifier not null
	, [FirstName] nvarchar(100) not null
	, [LastName] nvarchar(100) not null
,
constraint [Pk_Member_MemberId] primary key clustered
(
	[MemberId] asc
)
);