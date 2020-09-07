USE [Teste]
GO

/****** Object:  StoredProcedure [dbo].[SP_CfopPorValorTotalIcmsEIpi]    Script Date: 07/09/2020 18:41:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_CfopPorValorTotalIcmsEIpi]
AS
BEGIN
SELECT
	nfi.Cfop,
	SUM(nfi.BaseIcms) as ValorTotalBaseIcms,
	SUM(nfi.ValorIcms) as ValorTotalIcms,
	SUM(nfi.BaseIpi) as ValorTotalBaseIpi,
	SUM(nfi.ValorIpi) as ValorTotalIpi
FROM
NotaFiscalItem nfi
GROUP BY nfi.Cfop
END 
GO


