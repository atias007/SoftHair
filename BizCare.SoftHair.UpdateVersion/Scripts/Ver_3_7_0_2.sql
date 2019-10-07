DROP PROCEDURE SMS_GetCalendarSMS
;
CREATE PROCEDURE SMS_GetCalendarSMS
AS
SELECT CAL.id, DateDiff("n",Now(),CAL.date_start) AS Diff, CAL.date_start, CLN.id AS client_id, CLN.first_name, CLN.cell_phone_1 AS cell_phone, W.first_name AS worker_first_name, CAL.cares
FROM (tblCalendar AS CAL INNER JOIN tblClients AS CLN ON CAL.client_id=CLN.id) INNER JOIN tblWorkers AS W ON CAL.worker_id=W.id
WHERE (CAL.date_start Between [?from_date] And [?to_date]) And CAL.all_day_event=False And CAL.active=True And CAL.has_alert=False And CLN.enable_sms=True And CLN.cell_phone_1+""<>"" AND  datediff("n",date_created,Now()) >= 30
;
UPDATE tblParams SET param_value = 'clients_backup' WHERE param_name = 'FTP_DIRECTORY'
;
UPDATE tblParams SET param_value = 'chifon123!' WHERE param_name = 'FTP_PASSWORD'
;
UPDATE tblParams SET param_value = 'ftp://softhair.co.il' WHERE param_name = 'FTP_URL'
;
UPDATE tblParams SET param_value = 'Tzahi' WHERE param_name = 'FTP_USERNAME'
;