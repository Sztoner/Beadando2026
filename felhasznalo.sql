CREATE EXTENSION IF NOT EXISTS "pgcrypto"

CREATE TABLE felhasznalo_adatok (
    ID UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    szerepkor STRING,
    jelszoHash BYTEA,
    jelszoSalt BYTEA, 
    two_factor_secret STRING,
    two_factor_enabled BOOLEAN DEFAULT FALSE
    PRIMARY KEY(ID),
);