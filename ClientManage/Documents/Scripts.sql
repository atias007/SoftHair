UPDATE tblClients 
SET all_phones =
	TRIM(iif(cell_phone_1 is null, "", cell_phone_1 + " ") + 
		iif(cell_phone_2 is null, "", cell_phone_2 + " ") + 
		iif(home_phone is null, "", home_phone + " ") + 
		iif(work_phone is null, "", work_phone));


UPDATE tblClients SET first_name = ""	WHERE first_name IS NULL;
UPDATE tblClients SET last_name = ""	WHERE last_name IS NULL;
UPDATE tblClients SET home_phone = ""	WHERE home_phone IS NULL;
UPDATE tblClients SET work_phone = ""	WHERE work_phone IS NULL;
UPDATE tblClients SET cell_phone_1 = "" WHERE cell_phone_1 IS NULL;
UPDATE tblClients SET cell_phone_2 = "" WHERE cell_phone_2 IS NULL;
UPDATE tblClients SET address = ""		WHERE address IS NULL;
UPDATE tblClients SET city = ""			WHERE city IS NULL;
UPDATE tblClients SET zipcode = ""		WHERE zipcode IS NULL;
UPDATE tblClients SET email = ""		WHERE email IS NULL;
UPDATE tblClients SET remark = ""		WHERE remark IS NULL;
UPDATE tblClients SET picture = ""		WHERE picture IS NULL;

UPDATE tblPhoneBook SET first_name = ""		WHERE first_name IS NULL;
UPDATE tblPhoneBook SET last_name = ""		WHERE last_name IS NULL;
UPDATE tblPhoneBook SET company = ""		WHERE company IS NULL;
UPDATE tblPhoneBook SET job_title = ""		WHERE job_title IS NULL;
UPDATE tblPhoneBook SET email = ""			WHERE email IS NULL;
UPDATE tblPhoneBook SET web_site = ""		WHERE web_site IS NULL;
UPDATE tblPhoneBook SET phone_no_1 = ""		WHERE phone_no_1 IS NULL;
UPDATE tblPhoneBook SET phone_no_2 = ""		WHERE phone_no_2 IS NULL;
UPDATE tblPhoneBook SET phone_no_3 = ""		WHERE phone_no_3 IS NULL;
UPDATE tblPhoneBook SET fax = ""			WHERE fax IS NULL;
UPDATE tblPhoneBook SET street = ""			WHERE street IS NULL;
UPDATE tblPhoneBook SET notes = ""			WHERE notes IS NULL;
UPDATE tblPhoneBook SET city = ""			WHERE city IS NULL;
UPDATE tblPhoneBook SET zip_code = ""		WHERE zip_code IS NULL;
UPDATE tblPhoneBook SET mail_cell_no = ""	WHERE mail_cell_no IS NULL;
UPDATE tblPhoneBook SET picture = ""		WHERE picture IS NULL;