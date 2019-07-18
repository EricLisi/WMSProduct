CREATE VIEW [dbo].[V_STOCK_SHOW]
AS 
(
	SELECT S.F_ID,W.F_ID AS WHID,W.F_ENCODE WHCODE,W.F_FULLNAME WHNAME,C.F_ID POSID,C.F_ENCODE POSCODE,S.F_SellingPrice,S.F_Description,
		C.F_FULLNAME POSNAME,G.F_ID GOODSID,G.F_ENCODE GOODSCODE,S.F_BATCH,G.F_FULLNAME GOODSNAME,F_NUMBER,G.F_UNIT,G.F_SPECIFMODEL,S.F_SortCode
		FROM SYS_STOCK AS S
		LEFT JOIN MST_WAREHOUSE AS W ON W.F_ID=S.F_WAREHOUSEID
		LEFT JOIN MST_CARGOPOSITION AS C ON C.F_ID=S.F_CARGOPOSITIONID
		LEFT JOIN MST_GOODS AS G ON G.F_ID=S.F_GOODSID
)
GO