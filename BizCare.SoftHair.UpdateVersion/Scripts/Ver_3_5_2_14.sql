UPDATE tblWorkers SET card_id = null
;
CREATE PROCEDURE Worker_GetWorkerIdByCardId
AS
SELECT id
FROM tblWorkers
WHERE [card_id]=[?card_id]
;
