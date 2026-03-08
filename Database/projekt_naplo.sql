CREATE TABLE projekt_naplo (
    id SERIAL
	projekt_id INT,
	statusz TEXT,
	datum DATE,
    PRIMARY KEY(ID),
	FOREIGN KEY(projekt_id) REFERENCES projekt(ID)
);
