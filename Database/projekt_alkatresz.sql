CREATE TABLE projekt_alkatesz (
    projekt_id INT,
    alkatresz_id INT,
    darabszam INT,
	PRIMARY KEY(alkatresz_id),
	PRIMARY KEY(projekt_id),
    FOREIGN KEY(alkatresz_id) REFERENCES alkatresz(ID),
	FOREIGN KEY(projekt_id) REFERENCES projekt(ID)
);