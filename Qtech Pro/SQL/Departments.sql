USE [EMSDB]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 12/19/2024 11:09:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](max) NOT NULL,
	[Budget] [decimal](18, 2) NULL,
	[ManagerID] [int] NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 
GO
INSERT [dbo].[Departments] ([ID], [DepartmentName], [Budget], [ManagerID]) VALUES (1, N'Hr', CAST(100.00 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[Departments] ([ID], [DepartmentName], [Budget], [ManagerID]) VALUES (2, N'IT', CAST(100.00 AS Decimal(18, 2)), 3)
GO
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
ALTER TABLE [dbo].[Departments]  WITH CHECK ADD  CONSTRAINT [FK_Departments_Employees_ManagerID] FOREIGN KEY([ManagerID])
REFERENCES [dbo].[Employees] ([ID])
GO
ALTER TABLE [dbo].[Departments] CHECK CONSTRAINT [FK_Departments_Employees_ManagerID]
GO
