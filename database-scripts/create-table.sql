IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Calculations'))
BEGIN
    DROP TABLE [dbo].[Calculations]
END
GO

GO
CREATE TABLE [dbo].[Calculations] (
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [FirstNumber] [float] NOT NULL,
    [SecondNumber] [float] NOT NULL,
    [OperationName] [nvarchar](20) NOT NULL,
    [ResultNumber] [float] NOT NULL,
    [CreateAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Calculations] PRIMARY KEY CLUSTERED ( [Id] ASC)
 WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Calculations] ADD CONSTRAINT [DF_CreateAt] DEFAULT GETDATE() FOR [CreateAt]
GO