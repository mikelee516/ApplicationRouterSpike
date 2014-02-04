USE [AppRouter]
GO

/****** Object:  Table [dbo].[EndpointRegistrations]    Script Date: 02/03/2014 18:46:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[EndpointRegistrations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EndPoint] [varchar](256) NOT NULL,
	[Version] [varchar](128) NOT NULL,
	[URL] [varchar](1024) NOT NULL,
	[RegistrationTime] [datetime] NOT NULL,
 CONSTRAINT [PK_EndpointRegistrations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[EndpointRegistrations] ADD  CONSTRAINT [DF_EndpointRegistrations_RegistrationTime]  DEFAULT (getdate()) FOR [RegistrationTime]
GO


