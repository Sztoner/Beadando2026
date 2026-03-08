-- Alkatrész hozzáadása (ár, darabszám, pozíció)
CREATE OR REPLACE PROCEDURE alkatresz_hozzaadas(
    p_nev STRING,
    p_ar INT,
    p_darabszam INT,
    p_statusz STRING,
    p_pozicio STRING  -- pl. '10,20,30'
)
LANGUAGE plpgsql
AS $$
DECLARE
    a_alkatresz_id INT;
BEGIN
    -- Alkatrész beszúrása
    INSERT INTO alkatresz (nev, ar, darabszam, pozicio)
    VALUES (p_nev, p_ar, p_darabszam, p_pozicio)
    RETURNING ID INTO a_alkatresz_id;
    
END;
$$;