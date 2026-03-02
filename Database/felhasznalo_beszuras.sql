INSERT INTO felhasznalo_adatok (szerepkor, jelszo, two_factor_secret, two_factor_enabled)
VALUES 
('raktárvezető', crypt('vezeto123', gen_salt('bf')), NULL, FALSE),
('raktáros', crypt('raktar123', gen_salt('bf')), NULL, FALSE),
('szakember', crypt('szaki123', gen_salt('bf')), NULL, FALSE);