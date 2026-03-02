CREATE TABLE raktar (
    rekeszID STRING,
    alkatresz_id INT,
    darabszam INTEGER,
    PRIMARY KEY(rekeszID),
    FOREIGN KEY alkatresz(ID) REFERENCES rekesz(ID)

);
