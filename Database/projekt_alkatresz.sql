CREATE TABLE projekt_alkatresz (
    projekt_id INT,
    alkatresz_id INT,
    darabszam INT,
    hianydb INT,
	PRIMARY KEY(alkatresz_id, projekt_id),
    FOREIGN KEY(alkatresz_id) REFERENCES alkatresz(ID),
	FOREIGN KEY(projekt_id) REFERENCES projekt(ID)
);