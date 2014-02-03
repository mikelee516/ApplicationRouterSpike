USE [AppRouter]
GO

/****** Object:  Table [dbo].[Endpoints]    Script Date: 2/2/2014 11:59:11 PM ******/
DROP TABLE [dbo].[Endpoints]
GO

/****** Object:  Table [dbo].[Endpoints]    Script Date: 2/2/2014 11:59:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Endpoints](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](256) NOT NULL,
	[URL] [varchar](1024) NOT NULL,
	[RegistrationTimeStamp] [datetime] DEFAULT GETDATE(),
 CONSTRAINT [PK_Endpoints] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


