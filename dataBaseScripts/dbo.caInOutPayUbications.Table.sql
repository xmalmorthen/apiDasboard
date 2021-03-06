USE [apiDashboard]
GO
/****** Object:  Table [dbo].[caInOutPayUbications]    Script Date: 07/10/2015 02:48:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[caInOutPayUbications](
	[id] [tinyint] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](50) NOT NULL,
	[mode] [tinyint] NOT NULL,
	[fIns] [datetime] NOT NULL CONSTRAINT [DF_caInOutUbications_fIns]  DEFAULT (getdate()),
	[fAct] [datetime] NULL,
 CONSTRAINT [PK_caInOutUbications] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[caInOutPayUbications] ON 

INSERT [dbo].[caInOutPayUbications] ([id], [description], [mode], [fIns], [fAct]) VALUES (1, N'Norte', 1, CAST(N'2015-10-05 14:41:21.357' AS DateTime), NULL)
INSERT [dbo].[caInOutPayUbications] ([id], [description], [mode], [fIns], [fAct]) VALUES (2, N'Sur', 1, CAST(N'2015-10-05 14:41:26.800' AS DateTime), NULL)
INSERT [dbo].[caInOutPayUbications] ([id], [description], [mode], [fIns], [fAct]) VALUES (3, N'Norte', 2, CAST(N'2015-10-05 14:41:30.720' AS DateTime), NULL)
INSERT [dbo].[caInOutPayUbications] ([id], [description], [mode], [fIns], [fAct]) VALUES (4, N'Sur', 2, CAST(N'2015-10-05 14:45:36.897' AS DateTime), NULL)
INSERT [dbo].[caInOutPayUbications] ([id], [description], [mode], [fIns], [fAct]) VALUES (5, N'Pago 1', 3, CAST(N'2015-10-05 14:45:47.373' AS DateTime), NULL)
INSERT [dbo].[caInOutPayUbications] ([id], [description], [mode], [fIns], [fAct]) VALUES (6, N'Pago 2', 3, CAST(N'2015-10-05 14:45:52.750' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[caInOutPayUbications] OFF
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 = Entrada 
2 = Salida
3 = Módulo de pago' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'caInOutPayUbications', @level2type=N'COLUMN',@level2name=N'description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 = Entrada; 2 = Salida; 3 = Modulo de Pago' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'caInOutPayUbications', @level2type=N'COLUMN',@level2name=N'mode'
GO
