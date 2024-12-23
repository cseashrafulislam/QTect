USE [EMSDB]
GO
/****** Object:  StoredProcedure [dbo].[AveragePerformanceScore]    Script Date: 12/19/2024 11:01:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- AveragePerformanceScore
-- =============================================
ALTER PROCEDURE [dbo].[AveragePerformanceScore]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT 
    d.DepartmentName,
    AVG(pr.ReviewScore) AS AveragePerformanceScore
FROM 
    Departments d
JOIN 
    Employees e ON e.DepartmentID = d.ID
JOIN 
    PerformanceReviews pr ON pr.EmployeeID = e.ID
WHERE 
    pr.ReviewScore IS NOT NULL 
GROUP BY 
    d.DepartmentName
ORDER BY 
    AveragePerformanceScore DESC;

END
