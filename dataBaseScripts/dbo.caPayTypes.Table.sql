USE [apiDashboard]
GO
/****** Object:  Table [dbo].[caPayTypes]    Script Date: 07/10/2015 02:48:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[caPayTypes](
	[id] [tinyint] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](50) NOT NULL,
	[fIns] [datetime] NOT NULL CONSTRAINT [DF_caPayTypes_fIns]  DEFAULT (getdate()),
	[fAct] [datetime] NULL,
 CONSTRAINT [PK_caPayTypes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[caPayTypes] ON 

INSERT [dbo].[caPayTypes] ([id], [description], [fIns], [fAct]) VALUES (1, N'Efectivo', CAST(N'2015-10-05 14:46:06.937' AS DateTime), NULL)
INSERT [dbo].[caPayTypes] ([id], [description], [fIns], [fAct]) VALUES (2, N'Pensionado', CAST(N'2015-10-05 14:46:12.130' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[caPayTypes] OFF
