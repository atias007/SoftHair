ALTER TABLE tblCares ADD COLUMN display_color INT
;
ALTER TABLE tblCares ADD COLUMN duration INT
;
UPDATE tblCares SET duration = 30
;
UPDATE tblCares SET display_color = 0
;
DELETE FROM tblParams WHERE param_name = 'CAL_AUTO_SET_DURATION'
;
DELETE FROM tblParams WHERE param_name = 'CAL_AUTO_SET_COLOR'
;
DELETE FROM tblParams WHERE param_name = 'CAL_SYNC_EVENTS'
;
INSERT INTO tblParams (param_value, param_name) VALUES ('False', 'CAL_AUTO_SET_DURATION')
;
INSERT INTO tblParams (param_value, param_name) VALUES ('False', 'CAL_AUTO_SET_COLOR')
;
INSERT INTO tblParams (param_value, param_name) VALUES ('False', 'CAL_SYNC_EVENTS')
;
ALTER TABLE tblCalendar ADD COLUMN is_sync BIT
;
CREATE PROCEDURE CAL_GetSyncEvents
AS
SELECT CAL.*, Trim(W.first_name+" "+W.last_name) AS worker_title, Trim(C.first_name+" "+C.last_name) AS client_title
FROM (tblCalendar AS CAL LEFT OUTER  JOIN  tblWorkers AS W ON W.id = CAL.worker_id) LEFT OUTER JOIN tblClients AS C ON C.id = CAL.client_id
WHERE CAL.is_sync Is Null Or CAL.is_sync=False AND CAL.worker_id > -1  AND now() - CAL.date_start <= 90;
;
update tblcalendar set is_sync = true
;
update tblcalendar set is_sync = false where month(date_start) = 4 and year(date_start) = 2013
;