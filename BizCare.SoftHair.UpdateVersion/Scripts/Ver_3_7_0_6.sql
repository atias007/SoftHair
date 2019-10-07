ALTER TABLE tblClients ADD COLUMN is_sync YesNo
;
CREATE PROCEDURE SYNC_GetSyncContacts
AS
SELECT tblClients.birth_date, tblClients.email, tblClients.first_name, tblClients.id, tblClients.last_name, tblClients.married_date, tblClients.cell_phone_1, tblClients.remark
FROM tblClients
where  is_sync is null OR is_sync = false
;