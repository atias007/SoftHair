DROP PROCEDURE spClearCallLog
;
CREATE PROCEDURE spClearCallLog
AS
DELETE *
FROM tblEventLog
WHERE (((DateDiff("m",[date_created],Now()))>3));
;
