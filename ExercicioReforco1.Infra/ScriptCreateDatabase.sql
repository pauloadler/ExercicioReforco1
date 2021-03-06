GO
CREATE DATABASE ExercicioReforco1
 
GO
USE [ExercicioReforco1]
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 12/05/2018 20:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Produto](
	[id_produto] [bigint] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](200) NOT NULL,
	[preco_venda] [decimal](6, 2) NOT NULL,
	[preco_custo] [decimal](6, 2) NOT NULL,
	[disponibilidade] [bit] NOT NULL,
	[data_fabricacao] [datetime] NOT NULL,
	[data_validade] [datetime] NOT NULL,
 CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED 
(
	[id_produto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Venda]    Script Date: 12/05/2018 20:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venda](
	[id_venda] [bigint] IDENTITY(1,1) NOT NULL,
	[produto_id] [bigint] NOT NULL,
	[quantidade] [int] NOT NULL,
	[lucro] [decimal](6, 2) NOT NULL,
 CONSTRAINT [PK_Venda] PRIMARY KEY CLUSTERED 
(
	[id_venda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Venda]  WITH CHECK ADD FOREIGN KEY([produto_id])
REFERENCES [dbo].[Produto] ([id_produto])
GO
