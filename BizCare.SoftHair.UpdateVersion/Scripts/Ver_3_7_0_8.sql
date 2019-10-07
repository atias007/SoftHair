DROP PROCEDURE SMS_GetCalendarSMS2
;
CREATE PROCEDURE SMS_GetCalendarSMS2
AS
SELECT CAL.id, CAL.date_start, CLN.id AS client_id, CLN.first_name, CLN.cell_phone_1 AS cell_phone, W.first_name AS worker_first_name, CAL.cares, CLN.email
FROM (tblCalendar AS CAL INNER JOIN tblClients AS CLN ON CAL.client_id = CLN.id) INNER JOIN tblWorkers AS W ON CAL.worker_id = W.id
WHERE CAL.id = [?id] AND CAL.all_day_event=False AND CAL.active=True AND CLN.enable_sms=True AND CLN.cell_phone_1+""<>""
;