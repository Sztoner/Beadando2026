CREATE EXTENSION IF NOT EXISTS "pgcrypto";

CREATE TABLE felhasznalo_adatok (
    ID SERIAL,
	nev TEXT,
    szerepkor TEXT,
    jelszoHash TEXT,
	email TEXT,
    two_factor_secret INT,
	two_factor_valid_date TIMESTAMPTZ,
    PRIMARY KEY(ID),
);

CREATE TABLE alkatresz (
    ID SERIAL,
    nev TEXT,
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
    munkaido INT,
    munkadij INT,
	ar INT,
    PRIMARY KEY(ID)
);

CREATE TABLE projekt_alkatresz (
    projekt_id INT,
    alkatresz_id INT,
    darabszam INT,
    hianydb INT,
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
