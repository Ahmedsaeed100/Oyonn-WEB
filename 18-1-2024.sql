USE [oyonn]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 20/12/2023 10:04:18 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Adminid] [int] IDENTITY(1,1) NOT NULL,
	[AdminName] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[loginDate] [datetime] NULL,
	[login_time] [time](7) NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Adminid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[area]    Script Date: 20/12/2023 10:04:18 م ******/
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
/****** Object:  Table [dbo].[city]    Script Date: 20/12/2023 10:04:18 م ******/
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
/****** Object:  Table [dbo].[client]    Script Date: 20/12/2023 10:04:18 م ******/
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
/****** Object:  Table [dbo].[client_shop]    Script Date: 20/12/2023 10:04:18 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[client_shop](
	[shop_id] [int] NOT NULL,
	[client_id] [int] NULL,
	[shop_Name] [nvarchar](50) NULL,
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
/****** Object:  Table [dbo].[client_status]    Script Date: 20/12/2023 10:04:18 م ******/
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
/****** Object:  Table [dbo].[companies]    Script Date: 20/12/2023 10:04:18 م ******/
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
/****** Object:  Table [dbo].[order_details]    Script Date: 20/12/2023 10:04:18 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order_details](
	[order_details_id] [bigint] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[orders]    Script Date: 20/12/2023 10:04:18 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orders](
	[order_id] [bigint] IDENTITY(1,1) NOT NULL,
	[shop_id] [int] NULL,
	[total_orders_price] [decimal](8, 2) NULL,
	[order_date] [date] NULL,
	[order_time] [time](7) NULL,
	[order_delivery_date] [date] NULL,
	[order_delivery_time] [time](7) NULL,
	[Orders_StatusID] [int] NOT NULL,
 CONSTRAINT [PK_orders] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders_Status]    Script Date: 20/12/2023 10:04:18 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders_Status](
	[Orders_StatusID] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](10) NULL,
 CONSTRAINT [PK_Orders_Status] PRIMARY KEY CLUSTERED 
(
	[Orders_StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[products]    Script Date: 20/12/2023 10:04:18 م ******/
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
/****** Object:  Table [dbo].[products_details]    Script Date: 20/12/2023 10:04:18 م ******/
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
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([Adminid], [AdminName], [UserName], [Password], [loginDate], [login_time]) VALUES (1, N'mostafa.rezk', N'mostafa', N'123', CAST(N'2023-12-20 22:02:35.577' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Admin] OFF
SET IDENTITY_INSERT [dbo].[area] ON 

INSERT [dbo].[area] ([area_id], [area_name]) VALUES (1, N'امبابه')
INSERT [dbo].[area] ([area_id], [area_name]) VALUES (2, N'وراق')
SET IDENTITY_INSERT [dbo].[area] OFF
SET IDENTITY_INSERT [dbo].[city] ON 

INSERT [dbo].[city] ([city_id], [city_name]) VALUES (1, N'قاهره')
INSERT [dbo].[city] ([city_id], [city_name]) VALUES (2, N'جيزه')
SET IDENTITY_INSERT [dbo].[city] OFF
SET IDENTITY_INSERT [dbo].[client] ON 

INSERT [dbo].[client] ([client_id], [client_status_id], [client_name], [client_mobile], [client_location], [client_registration_date]) VALUES (1, 3, N'1', N'1', N'1', CAST(N'2020-10-10' AS Date))
INSERT [dbo].[client] ([client_id], [client_status_id], [client_name], [client_mobile], [client_location], [client_registration_date]) VALUES (2, 2, N'2', N'2', N'2', CAST(N'2022-02-10' AS Date))
INSERT [dbo].[client] ([client_id], [client_status_id], [client_name], [client_mobile], [client_location], [client_registration_date]) VALUES (3, 3, N'3', N'3', N'3', CAST(N'2022-06-10' AS Date))
INSERT [dbo].[client] ([client_id], [client_status_id], [client_name], [client_mobile], [client_location], [client_registration_date]) VALUES (5, 2, N'5', N'5', N'5', CAST(N'2022-08-10' AS Date))
SET IDENTITY_INSERT [dbo].[client] OFF
INSERT [dbo].[client_shop] ([shop_id], [client_id], [shop_Name], [shop_img], [area_id], [city_id], [Shop_mobile], [shop_phone], [shop_address]) VALUES (1, 1, N'الالمة', N'null', 1, 1, N'1', N'1', N'1')
INSERT [dbo].[client_shop] ([shop_id], [client_id], [shop_Name], [shop_img], [area_id], [city_id], [Shop_mobile], [shop_phone], [shop_address]) VALUES (2, 1, N'الزهوؤ', NULL, 2, 2, N'1', N'1', N'1')
INSERT [dbo].[client_shop] ([shop_id], [client_id], [shop_Name], [shop_img], [area_id], [city_id], [Shop_mobile], [shop_phone], [shop_address]) VALUES (3, 1, N'الفتح', NULL, 1, 1, N'011245', N'356565656', N'5656566')
INSERT [dbo].[client_status] ([client_status_id], [client_status]) VALUES (1, N'نشط')
INSERT [dbo].[client_status] ([client_status_id], [client_status]) VALUES (2, N'انتظر الرد')
INSERT [dbo].[client_status] ([client_status_id], [client_status]) VALUES (3, N'مغلق')
SET IDENTITY_INSERT [dbo].[companies] ON 

INSERT [dbo].[companies] ([company_id], [company_name_ar], [company_name_en], [company_img], [company_phone], [company_mobile], [company_address]) VALUES (2, N'222222222', N'1', N'60e0cb91-af9f-422a-a6e7-6748a61bb30c.png', N'1', N'01124190513', N'1')
INSERT [dbo].[companies] ([company_id], [company_name_ar], [company_name_en], [company_img], [company_phone], [company_mobile], [company_address]) VALUES (3, N'mostafa', N'mostafa', N'0', N'01124190513', N'01124190513', N'24 ش احمد ')
INSERT [dbo].[companies] ([company_id], [company_name_ar], [company_name_en], [company_img], [company_phone], [company_mobile], [company_address]) VALUES (4, N'mostafa222', N'mostafa222', N'7ce39f6a-72d2-420c-ba13-e062b6633697.png', N'01124190513', N'01124190513', N'24 ش احمد ')
INSERT [dbo].[companies] ([company_id], [company_name_ar], [company_name_en], [company_img], [company_phone], [company_mobile], [company_address]) VALUES (103, N'mostafa', N'mostafa', N'7ad76e7d-47cd-40b2-83ec-1c3007cba7a2.png', N'32331313', N'01124190513', N'222')
SET IDENTITY_INSERT [dbo].[companies] OFF
SET IDENTITY_INSERT [dbo].[order_details] ON 

INSERT [dbo].[order_details] ([order_details_id], [order_id], [product_details_id], [order_quantity], [order_price]) VALUES (1, 1, 1, 10, CAST(5.00 AS Decimal(8, 2)))
INSERT [dbo].[order_details] ([order_details_id], [order_id], [product_details_id], [order_quantity], [order_price]) VALUES (5, 2, 1, 5, CAST(6.00 AS Decimal(8, 2)))
SET IDENTITY_INSERT [dbo].[order_details] OFF
SET IDENTITY_INSERT [dbo].[orders] ON 

INSERT [dbo].[orders] ([order_id], [shop_id], [total_orders_price], [order_date], [order_time], [order_delivery_date], [order_delivery_time], [Orders_StatusID]) VALUES (1, 1, CAST(1.00 AS Decimal(8, 2)), CAST(N'2022-10-10' AS Date), CAST(N'12:31:56.2970000' AS Time), CAST(N'2022-10-10' AS Date), CAST(N'12:31:56.2970000' AS Time), 1)
INSERT [dbo].[orders] ([order_id], [shop_id], [total_orders_price], [order_date], [order_time], [order_delivery_date], [order_delivery_time], [Orders_StatusID]) VALUES (2, 2, CAST(5.00 AS Decimal(8, 2)), CAST(N'2022-10-10' AS Date), CAST(N'12:31:56.2970000' AS Time), CAST(N'2022-10-10' AS Date), CAST(N'12:31:56.2970000' AS Time), 2)
INSERT [dbo].[orders] ([order_id], [shop_id], [total_orders_price], [order_date], [order_time], [order_delivery_date], [order_delivery_time], [Orders_StatusID]) VALUES (4, 3, CAST(1.00 AS Decimal(8, 2)), CAST(N'2022-10-10' AS Date), CAST(N'12:31:56.2970000' AS Time), CAST(N'2022-10-10' AS Date), CAST(N'12:31:56.2970000' AS Time), 2)
SET IDENTITY_INSERT [dbo].[orders] OFF
SET IDENTITY_INSERT [dbo].[Orders_Status] ON 

INSERT [dbo].[Orders_Status] ([Orders_StatusID], [Status]) VALUES (1, N'معلق')
INSERT [dbo].[Orders_Status] ([Orders_StatusID], [Status]) VALUES (2, N'نشط')
SET IDENTITY_INSERT [dbo].[Orders_Status] OFF
SET IDENTITY_INSERT [dbo].[products] ON 

INSERT [dbo].[products] ([product_id], [product_name_ar], [product_name_en], [company_id]) VALUES (1, N'22222MMM', N'2MMM', 3)
INSERT [dbo].[products] ([product_id], [product_name_ar], [product_name_en], [company_id]) VALUES (3, N'222222222', N'22222222', 3)
SET IDENTITY_INSERT [dbo].[products] OFF
SET IDENTITY_INSERT [dbo].[products_details] ON 

INSERT [dbo].[products_details] ([product_details_id], [product_id], [product_name_ar], [product_name_en], [product_img], [product_quantity], [product_price]) VALUES (1, 3, N'22', N'22', N'371c99ec-4b4f-494e-b6ed-c46e90ed9084.png', 22, CAST(22.00 AS Decimal(8, 2)))
SET IDENTITY_INSERT [dbo].[products_details] OFF
ALTER TABLE [dbo].[client]  WITH CHECK ADD  CONSTRAINT [FK_client_client_status] FOREIGN KEY([client_status_id])
REFERENCES [dbo].[client_status] ([client_status_id])
GO
ALTER TABLE [dbo].[client] CHECK CONSTRAINT [FK_client_client_status]
GO
ALTER TABLE [dbo].[client_shop]  WITH CHECK ADD  CONSTRAINT [FK_client_shop_area] FOREIGN KEY([area_id])
REFERENCES [dbo].[area] ([area_id])
GO
ALTER TABLE [dbo].[client_shop] CHECK CONSTRAINT [FK_client_shop_area]
GO
ALTER TABLE [dbo].[client_shop]  WITH CHECK ADD  CONSTRAINT [FK_client_shop_city] FOREIGN KEY([city_id])
REFERENCES [dbo].[city] ([city_id])
GO
ALTER TABLE [dbo].[client_shop] CHECK CONSTRAINT [FK_client_shop_city]
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
ALTER TABLE [dbo].[orders]  WITH CHECK ADD  CONSTRAINT [FK_orders_Orders_Status] FOREIGN KEY([Orders_StatusID])
REFERENCES [dbo].[Orders_Status] ([Orders_StatusID])
GO
ALTER TABLE [dbo].[orders] CHECK CONSTRAINT [FK_orders_Orders_Status]
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
