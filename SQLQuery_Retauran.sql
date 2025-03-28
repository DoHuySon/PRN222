USE [master]
GO

CREATE DATABASE [SP25_PRN222_RESTAURANT]
GO

USE [SP25_PRN222_RESTAURANT]
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 3/20/2025 5:56:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservations](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[TableID] [int] NULL,
	[ReservationDate] [datetime] NULL,
	[Status] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tables]    Script Date: 3/20/2025 5:56:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tables](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TableNumber] [int] NOT NULL,
	[Seats] [int] NULL,
	[Status] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/20/2025 5:56:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[Password] [nvarchar](255) NOT NULL,
	[Role] [nvarchar](20) NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Reservations] ON 

INSERT [dbo].[Reservations] ([ID], [UserID], [TableID], [ReservationDate], [Status], [CreatedAt]) VALUES (1, 2, 2, CAST(N'2025-03-21T18:00:00.000' AS DateTime), N'Confirmed', CAST(N'2025-03-15T09:00:00.000' AS DateTime))
INSERT [dbo].[Reservations] ([ID], [UserID], [TableID], [ReservationDate], [Status], [CreatedAt]) VALUES (2, 3, 3, CAST(N'2025-03-22T19:00:00.000' AS DateTime), N'Pending', CAST(N'2025-03-16T10:30:00.000' AS DateTime))
INSERT [dbo].[Reservations] ([ID], [UserID], [TableID], [ReservationDate], [Status], [CreatedAt]) VALUES (3, 5, 6, CAST(N'2025-03-23T20:00:00.000' AS DateTime), N'Confirmed', CAST(N'2025-03-17T11:45:00.000' AS DateTime))
INSERT [dbo].[Reservations] ([ID], [UserID], [TableID], [ReservationDate], [Status], [CreatedAt]) VALUES (4, 6, 8, CAST(N'2025-03-24T18:30:00.000' AS DateTime), N'Cancelled', CAST(N'2025-03-18T13:00:00.000' AS DateTime))
INSERT [dbo].[Reservations] ([ID], [UserID], [TableID], [ReservationDate], [Status], [CreatedAt]) VALUES (5, 7, 10, CAST(N'2025-03-25T19:30:00.000' AS DateTime), N'Pending', CAST(N'2025-03-19T14:15:00.000' AS DateTime))
INSERT [dbo].[Reservations] ([ID], [UserID], [TableID], [ReservationDate], [Status], [CreatedAt]) VALUES (6, 8, 12, CAST(N'2025-03-26T20:30:00.000' AS DateTime), N'Confirmed', CAST(N'2025-03-20T15:30:00.000' AS DateTime))
INSERT [dbo].[Reservations] ([ID], [UserID], [TableID], [ReservationDate], [Status], [CreatedAt]) VALUES (7, 2, 11, CAST(N'2025-04-02T18:00:00.000' AS DateTime), N'Confirmed', CAST(N'2025-03-27T14:15:00.000' AS DateTime))
INSERT [dbo].[Reservations] ([ID], [UserID], [TableID], [ReservationDate], [Status], [CreatedAt]) VALUES (8, 3, 13, CAST(N'2025-04-03T19:00:00.000' AS DateTime), N'Cancelled', CAST(N'2025-03-28T15:30:00.000' AS DateTime))
INSERT [dbo].[Reservations] ([ID], [UserID], [TableID], [ReservationDate], [Status], [CreatedAt]) VALUES (9, 5, 15, CAST(N'2025-04-04T20:00:00.000' AS DateTime), N'Pending', CAST(N'2025-03-29T16:45:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Reservations] OFF
GO
SET IDENTITY_INSERT [dbo].[Tables] ON 

INSERT [dbo].[Tables] ([ID], [TableNumber], [Seats], [Status], [CreatedAt]) VALUES (1, 1, 4, N'Available', CAST(N'2025-01-01T08:00:00.000' AS DateTime))
INSERT [dbo].[Tables] ([ID], [TableNumber], [Seats], [Status], [CreatedAt]) VALUES (2, 2, 6, N'Reserved', CAST(N'2025-01-01T08:00:00.000' AS DateTime))
INSERT [dbo].[Tables] ([ID], [TableNumber], [Seats], [Status], [CreatedAt]) VALUES (3, 3, 2, N'Occupied', CAST(N'2025-01-01T08:00:00.000' AS DateTime))
INSERT [dbo].[Tables] ([ID], [TableNumber], [Seats], [Status], [CreatedAt]) VALUES (4, 4, 8, N'Available', CAST(N'2025-01-01T08:00:00.000' AS DateTime))
INSERT [dbo].[Tables] ([ID], [TableNumber], [Seats], [Status], [CreatedAt]) VALUES (5, 5, 4, N'Available', CAST(N'2025-01-01T08:00:00.000' AS DateTime))
INSERT [dbo].[Tables] ([ID], [TableNumber], [Seats], [Status], [CreatedAt]) VALUES (6, 6, 6, N'Reserved', CAST(N'2025-01-01T08:00:00.000' AS DateTime))
INSERT [dbo].[Tables] ([ID], [TableNumber], [Seats], [Status], [CreatedAt]) VALUES (7, 7, 2, N'Available', CAST(N'2025-01-01T08:00:00.000' AS DateTime))
INSERT [dbo].[Tables] ([ID], [TableNumber], [Seats], [Status], [CreatedAt]) VALUES (8, 8, 10, N'Occupied', CAST(N'2025-01-01T08:00:00.000' AS DateTime))
INSERT [dbo].[Tables] ([ID], [TableNumber], [Seats], [Status], [CreatedAt]) VALUES (9, 9, 4, N'Available', CAST(N'2025-01-01T08:00:00.000' AS DateTime))
INSERT [dbo].[Tables] ([ID], [TableNumber], [Seats], [Status], [CreatedAt]) VALUES (10, 10, 6, N'Reserved', CAST(N'2025-01-01T08:00:00.000' AS DateTime))
INSERT [dbo].[Tables] ([ID], [TableNumber], [Seats], [Status], [CreatedAt]) VALUES (11, 11, 2, N'Available', CAST(N'2025-01-01T08:00:00.000' AS DateTime))
INSERT [dbo].[Tables] ([ID], [TableNumber], [Seats], [Status], [CreatedAt]) VALUES (12, 12, 8, N'Occupied', CAST(N'2025-01-01T08:00:00.000' AS DateTime))
INSERT [dbo].[Tables] ([ID], [TableNumber], [Seats], [Status], [CreatedAt]) VALUES (13, 13, 4, N'Available', CAST(N'2025-01-01T08:00:00.000' AS DateTime))
INSERT [dbo].[Tables] ([ID], [TableNumber], [Seats], [Status], [CreatedAt]) VALUES (14, 14, 6, N'Reserved', CAST(N'2025-01-01T08:00:00.000' AS DateTime))
INSERT [dbo].[Tables] ([ID], [TableNumber], [Seats], [Status], [CreatedAt]) VALUES (15, 15, 2, N'Available', CAST(N'2025-01-01T08:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Tables] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [FullName], [Email], [Password], [Role], [CreatedAt]) VALUES (1, N'Nguyen Van An', N'an.nguyen@email.com', N'hashed_password_1', N'Admin', CAST(N'2025-01-01T10:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [FullName], [Email], [Password], [Role], [CreatedAt]) VALUES (2, N'Tran Thi Bich', N'bich.tran@email.com', N'hashed_password_2', N'Customer', CAST(N'2025-01-02T12:30:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [FullName], [Email], [Password], [Role], [CreatedAt]) VALUES (3, N'Le Van Cuong', N'cuong.le@email.com', N'hashed_password_3', N'Customer', CAST(N'2025-01-03T15:45:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [FullName], [Email], [Password], [Role], [CreatedAt]) VALUES (4, N'Pham Thi Dung', N'dung.pham@email.com', N'hashed_password_4', N'Admin', CAST(N'2025-01-04T09:20:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [FullName], [Email], [Password], [Role], [CreatedAt]) VALUES (5, N'Hoang Van En', N'en.hoang@email.com', N'hashed_password_5', N'Customer', CAST(N'2025-01-05T14:10:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [FullName], [Email], [Password], [Role], [CreatedAt]) VALUES (6, N'Nguyen Thi Phuong', N'phuong.nguyen@email.com', N'hashed_password_6', N'Customer', CAST(N'2025-01-06T16:25:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [FullName], [Email], [Password], [Role], [CreatedAt]) VALUES (7, N'Tran Van Giang', N'giang.tran@email.com', N'hashed_password_7', N'Customer', CAST(N'2025-01-07T11:50:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [FullName], [Email], [Password], [Role], [CreatedAt]) VALUES (8, N'Le Thi Hoa', N'hoa.le@email.com', N'hashed_password_8', N'Customer', CAST(N'2025-01-08T13:15:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [UQ__Tables__E8E0DB522BD2DF99]    Script Date: 3/20/2025 5:56:51 PM ******/
ALTER TABLE [dbo].[Tables] ADD UNIQUE NONCLUSTERED 
(
	[TableNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__A9D10534D6F321BD]    Script Date: 3/20/2025 5:56:51 PM ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Reservations] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Tables] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD FOREIGN KEY([TableID])
REFERENCES [dbo].[Tables] ([ID])
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD CHECK  (([ReservationDate]>=getdate()))
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD CHECK  (([Status]='Cancelled' OR [Status]='Confirmed' OR [Status]='Pending'))
GO
ALTER TABLE [dbo].[Tables]  WITH CHECK ADD CHECK  (([Seats]>=(1)))
GO
ALTER TABLE [dbo].[Tables]  WITH CHECK ADD CHECK  (([Status]='Occupied' OR [Status]='Reserved' OR [Status]='Available'))
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD CHECK  (([Role]='Customer' OR [Role]='Admin'))
GO
