CREATE TABLE raktar (
    rekeszID TEXT,
    alkatresz_id INT,
    darabszam INT,
    PRIMARY KEY(rekeszID),
    FOREIGN KEY(alkatresz_id) REFERENCES alkatresz(ID)
);