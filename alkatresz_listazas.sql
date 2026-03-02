CREATE OR REPLACE FUNCTION alkatresz_listazas(
    p_statusz VARCHAR
)
    id INT,
    tipus STRING,
    nev STRING,
    ar INT,
    darabszam INT,
    p_statusz STRING,
    pozicio STRING

LANGUAGE plpgsql
AS $$
BEGIN
    RETURN QUERY
    SELECT 
        a.id,
        a.tipus,
        a.nev,
        a.ar,
        a.darabszam,
        a.statusz,
        a.pozicio
    FROM alkatresz a
    WHERE a.statusz = p_statusz;
END;
$$;