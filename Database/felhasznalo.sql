CREATE EXTENSION IF NOT EXISTS "pgcrypto"

CREATE TABLE felhasznalo_adatok (
    ID INT,
	nev TEXT
    szerepkor TEXT,
    jelszoHash TEXT, 
    two_factor_secret TEXT,
    two_factor_enabled BOOLEAN DEFAULT FALSE
    PRIMARY KEY(ID),
);
