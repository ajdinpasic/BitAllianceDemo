-- Table dbo.Rental
-- Table dbo.Rental
create table
	[dbo].[Rental]
(
	[RentalId] uniqueidentifier not null
	, [BookId] uniqueidentifier not null
	, [MemberId] uniqueidentifier not null
,
constraint [Pk_Rental_RentalIdBookIdMemberId] primary key clustered
(
	[RentalId] asc
	, [BookId] asc
	, [MemberId] asc
)
);
GO
--**********************************************************************
--	Data
--**********************************************************************
--**********************************************************************
--	Relationships
--**********************************************************************

-- Relationship Fk_Book_Rental_BookId
--**********************************************************************
--	Data
--**********************************************************************
--**********************************************************************
--	Relationships
--**********************************************************************

-- Relationship Fk_Book_Rental_BookId
alter table [dbo].[Rental]
add constraint [Fk_Book_Rental_BookId] foreign key ([BookId]) references [dbo].[Book] ([BookId]);
GO
-- Relationship Fk_Member_Rental_MemberId
-- Relationship Fk_Member_Rental_MemberId
alter table [dbo].[Rental]
add constraint [Fk_Member_Rental_MemberId] foreign key ([MemberId]) references [dbo].[Member] ([MemberId]);