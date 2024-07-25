USE [RENTAL]
GO

/****** Object:  Table [dbo].[RESULT]    Script Date: 25/07/2024 14.42.49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RESULT](
	[ID_SIMULASI] [int] IDENTITY(1,1) NOT NULL,
	[KODE_BARANG] [nvarchar](8) NULL,
	[URAIAN_BARANG] [nvarchar](200) NULL,
	[BM] [int] NULL,
	[NILAI_KOMODITAS] [float] NULL,
	[NILAI_BM] [nchar](10) NULL,
	[CRE_DATE] [datetime] NULL,
 CONSTRAINT [PK_RESULT] PRIMARY KEY CLUSTERED 
(
	[ID_SIMULASI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


