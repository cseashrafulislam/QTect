USE [EMSDB]
GO
/****** Object:  Table [dbo].[PerformanceReviews]    Script Date: 12/19/2024 11:04:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceReviews](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[ReviewDate] [datetime2](7) NOT NULL,
	[ReviewScore] [int] NOT NULL,
	[ReviewNotes] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_PerformanceReviews] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PerformanceReviews] ON 
GO
INSERT [dbo].[PerformanceReviews] ([ID], [EmployeeID], [ReviewDate], [ReviewScore], [ReviewNotes]) VALUES (3, 1, CAST(N'2024-12-19T00:00:00.0000000' AS DateTime2), 3, N'tr')
GO
INSERT [dbo].[PerformanceReviews] ([ID], [EmployeeID], [ReviewDate], [ReviewScore], [ReviewNotes]) VALUES (4, 3, CAST(N'2024-12-19T00:00:00.0000000' AS DateTime2), 9, N't')
GO
INSERT [dbo].[PerformanceReviews] ([ID], [EmployeeID], [ReviewDate], [ReviewScore], [ReviewNotes]) VALUES (5, 3, CAST(N'2024-12-19T00:00:00.0000000' AS DateTime2), 8, N'8')
GO
INSERT [dbo].[PerformanceReviews] ([ID], [EmployeeID], [ReviewDate], [ReviewScore], [ReviewNotes]) VALUES (6, 1, CAST(N'2024-12-19T00:00:00.0000000' AS DateTime2), 7, N'8')
GO
SET IDENTITY_INSERT [dbo].[PerformanceReviews] OFF
GO
ALTER TABLE [dbo].[PerformanceReviews]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceReviews_Employees_EmployeeID] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PerformanceReviews] CHECK CONSTRAINT [FK_PerformanceReviews_Employees_EmployeeID]
GO
