USE [oyonn]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 9/30/2022 1:00:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Adminid] [int] IDENTITY(1,1) NOT NULL,
	[AdminName] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[loginDate] [date] NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Adminid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[area]    Script Date: 9/30/2022 1:00:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[area](
	[area_id] [smallint] IDENTITY(1,1) NOT NULL,
	[area_name] [nvarchar](15) NULL,
 CONSTRAINT [PK_area] PRIMARY KEY CLUSTERED 
(
	[area_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[city]    Script Date: 9/30/2022 1:00:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[city](
	[city_id] [smallint] IDENTITY(1,1) NOT NULL,
	[city_name] [nvarchar](15) NULL,
 CONSTRAINT [PK_city] PRIMARY KEY CLUSTERED 
(
	[city_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[client]    Script Date: 9/30/2022 1:00:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[client](
	[client_id] [int] IDENTITY(1,1) NOT NULL,
	[client_status_id] [tinyint] NULL,
	[client_name] [nvarchar](30) NULL,
	[client_mobile] [nvarchar](15) NULL,
	[client_location] [nvarchar](250) NULL,
	[client_registration_date] [date] NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[client_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[client_shop]    Script Date: 9/30/2022 1:00:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[client_shop](
	[shop_id] [int] NOT NULL,
	[client_id] [int] NULL,
	[shop_img] [nvarchar](75) NULL,
	[area_id] [smallint] NULL,
	[city_id] [smallint] NULL,
	[Shop_mobile] [nvarchar](15) NULL,
	[shop_phone] [nvarchar](15) NULL,
	[shop_address] [nvarchar](250) NULL,
 CONSTRAINT [PK_UserShop] PRIMARY KEY CLUSTERED 
(
	[shop_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[client_status]    Script Date: 9/30/2022 1:00:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[client_status](
	[client_status_id] [tinyint] NOT NULL,
	[client_status] [nvarchar](15) NULL,
 CONSTRAINT [PK_client_status] PRIMARY KEY CLUSTERED 
(
	[client_status_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[companies]    Script Date: 9/30/2022 1:00:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[companies](
	[company_id] [smallint] IDENTITY(1,1) NOT NULL,
	[company_name_ar] [nvarchar](20) NULL,
	[company_name_en] [nvarchar](20) NULL,
	[company_img] [nvarchar](150) NULL,
	[company_phone] [nvarchar](15) NULL,
	[company_mobile] [nvarchar](15) NULL,
	[company_address] [nvarchar](250) NULL,
 CONSTRAINT [PK_companies] PRIMARY KEY CLUSTERED 
(
	[company_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[order_details]    Script Date: 9/30/2022 1:00:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order_details](
	[order_details_id] [bigint] NOT NULL,
	[order_id] [bigint] NULL,
	[product_details_id] [int] NULL,
	[order_quantity] [tinyint] NULL,
	[order_price] [decimal](8, 2) NULL,
 CONSTRAINT [PK_order_details] PRIMARY KEY CLUSTERED 
(
	[order_details_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[orders]    Script Date: 9/30/2022 1:00:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orders](
	[order_id] [bigint] NOT NULL,
	[shop_id] [int] NULL,
	[total_orders_price] [decimal](8, 2) NULL,
	[order_date] [date] NULL,
	[order_time] [time](7) NULL,
	[order_delivery_date] [date] NULL,
	[order_delivery_time] [time](7) NULL,
 CONSTRAINT [PK_orders] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[products]    Script Date: 9/30/2022 1:00:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products](
	[product_id] [smallint] IDENTITY(1,1) NOT NULL,
	[product_name_ar] [nvarchar](20) NULL,
	[product_name_en] [nvarchar](20) NULL,
	[company_id] [smallint] NOT NULL,
 CONSTRAINT [PK_department] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[products_details]    Script Date: 9/30/2022 1:00:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products_details](
	[product_details_id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [smallint] NULL,
	[product_name_ar] [nvarchar](50) NULL,
	[product_name_en] [nvarchar](50) NULL,
	[product_img] [nvarchar](100) NULL,
	[product_quantity] [int] NULL,
	[product_price] [decimal](8, 2) NULL,
 CONSTRAINT [PK_dpartment_details] PRIMARY KEY CLUSTERED 
(
	[product_details_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[client]  WITH CHECK ADD  CONSTRAINT [FK_client_client_status] FOREIGN KEY([client_status_id])
REFERENCES [dbo].[client_status] ([client_status_id])
GO
ALTER TABLE [dbo].[client] CHECK CONSTRAINT [FK_client_client_status]
GO
ALTER TABLE [dbo].[client_shop]  WITH CHECK ADD  CONSTRAINT [FK_client_shop_client] FOREIGN KEY([client_id])
REFERENCES [dbo].[client] ([client_id])
GO
ALTER TABLE [dbo].[client_shop] CHECK CONSTRAINT [FK_client_shop_client]
GO
ALTER TABLE [dbo].[order_details]  WITH CHECK ADD  CONSTRAINT [FK_order_details_orders] FOREIGN KEY([order_id])
REFERENCES [dbo].[orders] ([order_id])
GO
ALTER TABLE [dbo].[order_details] CHECK CONSTRAINT [FK_order_details_orders]
GO
ALTER TABLE [dbo].[order_details]  WITH CHECK ADD  CONSTRAINT [FK_order_details_products_details] FOREIGN KEY([product_details_id])
REFERENCES [dbo].[products_details] ([product_details_id])
GO
ALTER TABLE [dbo].[order_details] CHECK CONSTRAINT [FK_order_details_products_details]
GO
ALTER TABLE [dbo].[orders]  WITH CHECK ADD  CONSTRAINT [FK_orders_client_shop] FOREIGN KEY([shop_id])
REFERENCES [dbo].[client_shop] ([shop_id])
GO
ALTER TABLE [dbo].[orders] CHECK CONSTRAINT [FK_orders_client_shop]
GO
ALTER TABLE [dbo].[products]  WITH CHECK ADD  CONSTRAINT [FK_products_companies] FOREIGN KEY([company_id])
REFERENCES [dbo].[companies] ([company_id])
GO
ALTER TABLE [dbo].[products] CHECK CONSTRAINT [FK_products_companies]
GO
ALTER TABLE [dbo].[products_details]  WITH CHECK ADD  CONSTRAINT [FK_products_details_products] FOREIGN KEY([product_id])
REFERENCES [dbo].[products] ([product_id])
GO
ALTER TABLE [dbo].[products_details] CHECK CONSTRAINT [FK_products_details_products]
GO
