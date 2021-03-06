USE [apiDashboard]
GO
/****** Object:  StoredProcedure [dbo].[getPaymentsByMonthofYear]    Script Date: 07/10/2015 02:48:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author		:	XMALMORTHEN
-- Create date	:	06/10/2015
-- Description	:	OBTIENE CANTIDAD DE PAGOS POR MES EN UN AÑO ESPECIFICADO
-- =============================================
CREATE PROCEDURE [dbo].[getPaymentsByMonthofYear]
	@year int
AS
BEGIN	
	SET NOCOUNT ON;
	
	DECLARE @MESES AS TABLE(ID TINYINT)
	INSERT INTO @MESES VALUES(1),(2),(3),(4),(5),(6),(7),(8),(9),(10),(11),(12)
	SELECT 
		DATENAME( MONTH , DATEADD( MONTH , M.ID , -1 ) ) AS MES ,
		COUNT(1) AS CANTIDAD
	FROM 
		@MESES M
	LEFT OUTER JOIN 
		MAFLOW T 
	  ON 
		M.ID = MONTH(T.PAYDATETIME) 
	WHERE
		YEAR(T.PAYDATETIME) = @year
	GROUP BY 
		M.ID,MONTH(T.PAYDATETIME)
	ORDER BY 
		M.ID
END

GO
