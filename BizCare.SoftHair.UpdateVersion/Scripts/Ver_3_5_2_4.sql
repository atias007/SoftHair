DELETE FROM tblMagneticCards
;
DROP PROCEDURE spGetFreeMagneticCards
;
UPDATE tblClients SET picture = 'C:\SoftHair\' +  MID(picture, 27)  WHERE MID(picture, 1,26) = 'C:\Program Files\SoftHair\'
;
DELETE FROM tblParams WHERE param_name IN ('PRINT_PAGE_MARGIN','PRINT_LABEL_PADDING','PRINT_LABEL_X_COUNT','PRINT_LABEL_Y_COUNT','PRINT_LABEL_BORDER','PRINT_LABEL_FONTSIZE','PRINT_LABEL_FONT','STICKERS_REPORT_NAME')
;
INSERT INTO tblParams (param_name, param_value) VALUES ('STICKERS_PRINT_SETUP', '3,7,21,29.7,1,1.5,0.6,0.6,2,True,')
;
