CREATE OR REPLACE PROCEDURE alkatresz_modositas(
    IN p_id INT,
    IN p_ar INT,
    IN p_darabszam INT,
    IN p_pozicio STRING
)
LANGUAGE plpgsql
AS $$
BEGIN
    UPDATE alkatresz
    SET 
        ar = COALESCE(p_ar, ar),
        darabszam = COALESCE(p_darabszam, darabszam),
        pozicio = COALESCE(p_pozicio, pozicio)
    WHERE id = p_id;
END;
$$;