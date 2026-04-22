CREATE EXTENSION IF NOT EXISTS "pgcrypto"

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
