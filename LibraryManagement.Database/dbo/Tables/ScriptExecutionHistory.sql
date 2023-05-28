-- Table dbo.ScriptExecutionHistory
create table
	[dbo].[ScriptExecutionHistory]
(
	[ScriptId] uniqueidentifier not null
	, [ExecutionTime] datetime2(7) not null
,
constraint [Pk_ScriptExecutionHistory_ScriptId] primary key clustered
(
	[ScriptId] asc
)
);