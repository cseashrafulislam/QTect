USE [EMSDB]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 12/19/2024 11:07:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Position] [nvarchar](max) NOT NULL,
	[JoinDate] [datetime2](7) NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 
GO
INSERT [dbo].[Employees] ([ID], [Name], [Email], [Phone], [Position], [JoinDate], [DepartmentID], [Status], [Deleted]) VALUES (1, N'Mr. As', N'Mra@gmail.com', N'01733232323', N'1', CAST(N'2024-12-01T21:22:00.0000000' AS DateTime2), 2, N'Active', 1)
GO
INSERT [dbo].[Employees] ([ID], [Name], [Email], [Phone], [Position], [JoinDate], [DepartmentID], [Status], [Deleted]) VALUES (2, N'Mr. Ashik', N'Mra@gmail.com', N'01733232323', N'1', CAST(N'2024-12-19T21:22:00.0000000' AS DateTime2), 1, N'DeActive', 0)
GO
INSERT [dbo].[Employees] ([ID], [Name], [Email], [Phone], [Position], [JoinDate], [DepartmentID], [Status], [Deleted]) VALUES (3, N'Mr. Amit', N'Mra@gmail.com', N'01733232323', N'1', CAST(N'2024-12-19T21:23:00.0000000' AS DateTime2), 1, N'Active', 1)
GO
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Departments_DepartmentID] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Departments] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Departments_DepartmentID]
GO
