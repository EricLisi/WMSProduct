CREATE VIEW V_STOCKMASKHISTORY
AS

SELECT S.F_Id,G.F_ENCODE AS GOODSCODE,G.F_FULLNAME AS F_GoodsName,S.F_EnCode,S.F_Number,S.F_RealNumber,
S.F_DiffNumber,G.F_Unit,C.F_ENCODE AS CPOCODE,C.F_FULLNAME as F_CargoPositionName,W.F_ENCODE AS WHCODE,W.F_FULLNAME as F_WarehouseName,
S.F_Batch,S.F_SortCode 
FROM SYS_STOCKMASKHISTORY AS S
LEFT JOIN MST_GOODS  AS G ON S.F_GOODSID=G.F_ID
LEFT JOIN MST_WAREHOUSE AS W ON W.F_ID=S.F_WAREHOUSEID
LEFT JOIN MST_CARGOPOSITION AS C ON C.F_ID=S.F_CARGOPOSITIONID

GO