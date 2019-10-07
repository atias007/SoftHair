UPDATE tblParams SET param_value = 'dd/MM/yyyy', param_name = 'APP_DATE_FORMAT' WHERE param_name = 'SMS_WS_MANAGE_URL'
;
DELETE FROM tblParams WHERE param_name = 'CARD_ADD_NEWLINE_CHAR'
;
DELETE FROM tblParams WHERE param_name = 'APP_WRITE_EVENT_LOG'
;