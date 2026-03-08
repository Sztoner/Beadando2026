CREATE EXTENSION IF NOT EXISTS "pgcrypto";

CREATE TABLE felhasznalo_adatok (
    ID INT,
	nev TEXT,
    szerepkor TEXT,
    jelszoHash TEXT, 
    two_factor_secret TEXT,
    two_factor_enabled BOOLEAN DEFAULT FALSE,
    PRIMARY KEY(ID)
);

CREATE TABLE alkatresz (
    ID SERIAL,
    nev VARCHAR(50),
    ar INT,
    maxdb INT,
    PRIMARY KEY(ID)
);

CREATE TABLE raktar (
    rekeszID TEXT,
    alkatresz_id INT,
    darabszam INT,
    PRIMARY KEY(rekeszID),
    FOREIGN KEY(alkatresz_id) REFERENCES alkatresz(ID)
);

CREATE TABLE projekt (
    ID SERIAL,
	nev TEXT,
	helyszin TEXT,
    megrendelo TEXT,
    leiras TEXT,
	statusz TEXT,
    munkaido DATE,
	ar INT,
    PRIMARY KEY(ID)
);

CREATE TABLE projekt_alkatesz (
    projekt_id INT,
    alkatresz_id INT,
    darabszam INT,
	PRIMARY KEY(alkatresz_id, projekt_id),
    FOREIGN KEY(alkatresz_id) REFERENCES alkatresz(ID),
	FOREIGN KEY(projekt_id) REFERENCES projekt(ID)
);

CREATE TABLE projekt_naplo (
    id SERIAL,
	projekt_id INT,
	statusz TEXT,
	datum DATE,
    PRIMARY KEY(ID),
	FOREIGN KEY(projekt_id) REFERENCES projekt(ID)
);
