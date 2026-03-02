CREATE OR REPLACE PROCEDURE bejelentkezes(
    IN _szerepkor TEXT,
    IN _jelszo TEXT,
    INOUT r1 REFCURSOR
) 
AS $$
DECLARE
    _ID INT;
    _taroltjelszoHash BYTEA;
    _taroltjelszoSalt BYTEA;
    _jelszoHash BYTEA;
    _two_factor_secret TEXT;
    _two_factor_enabled BOOLEAN;
BEGIN

    SELECT id, jelszoHash, jelszoSalt, two_factor_secret, two_factor_enabled
    INTO _ID, _taroltjelszoHash, _taroltjelszoSalt, _two_factor_secret, _two_factor_enabled
    FROM felhasznalo_adatok
    WHERE szerepkor = _szerepkor;

    IF _ID IS NULL THEN
        OPEN r1 FOR
            SELECT 1 AS "eredmeny";
        RETURN;
    END IF;
    
    _jelszoHash := digest(convert_to(_jelszo, 'UTF8') || _taroltjelszoSalt, 'sha256');

    IF _jelszoHash = _taroltjelszoHash THEN
        
        OPEN r1 FOR 
            SELECT 
                0 AS "eredmeny",
                _ID AS User_ID,
                _two_factor_enabled AS ketlepcsos,
                _two_factor_secret AS secret;
        RETURN;

    ELSE 
        OPEN r1 FOR
            SELECT 1 AS "eredmeny";
        RETURN;
    END IF;

END;
$$ LANGUAGE plpgsql;