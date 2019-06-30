-- FUNKCJA

set global log_bin_trust_function_creators = 1;

delimiter //

-- ustaw i (indeks) jako liczba która będzie zawierała indeks 
-- ustaw res (result) jako upper case dla 1 wartości w stringu wejściowym
-- substr reszte stringa do zmiennej base
-- ustaw i (indeks) jako indeks pierwszego wystąpienia spacji w base (po "przesunięciu" o pierwszą literę)

-- w pętli, która wykonuje się dopóki dojdzie do kolejnej spacji
-- ustaw x jako substring od 1 wartości base do indeksu spacji
-- ustaw jako złączenie res i x
-- ustaw x jako upper case pierwsze wystąpienie literki x nowego wyrazu po spacji
-- ustaw nowy base, jest to reszta ze stringa
-- ustaw nowy indeks spacji
-- ustaw i na nowy indeks spacji,

CREATE FUNCTION capitalize (string varchar(50) CHARACTER SET utf8mb4)
RETURNS varchar(50) CHARACTER SET utf8mb4
BEGIN
	DECLARE i int;
	DECLARE res, base, x varchar(50) CHARACTER SET utf8mb4;
	SET res = upper(substring(string, 1, 1));
	SET base = lower(substr(string, 2));
	SET i = instr(base, ' ');
	WHILE i > 0
	DO
		SET x = substr(base, 1, i);
		SET res = concat(res, x);
		SET x = upper(substr(base, i + 1, 1));
		SET res = concat(res, x);
		SET base = substr(base, i + 2);
		SET i = instr(base, ' ');
	END WHILE;
	SET res = concat(res, base);
	RETURN res;
END //

-- TRIGGERY:

-- Players
CREATE TRIGGER capitalize_letters_insert_players
BEFORE INSERT ON players
FOR EACH ROW
SET NEW.name = capitalize(NEW.name),
NEW.lastname = capitalize(NEW.lastname),
NEW.nationality = capitalize(NEW.nationality) //

CREATE TRIGGER capitalize_letters_update_players
BEFORE UPDATE ON players
FOR EACH ROW
SET NEW.name = capitalize(NEW.name),
NEW.lastname = capitalize(NEW.lastname),
NEW.nationality = capitalize(NEW.nationality) //

-- Clubs
CREATE TRIGGER capitalize_letters_insert_clubs
BEFORE INSERT ON clubs
FOR EACH ROW
SET NEW.name = capitalize(NEW.name),
NEW.city = capitalize(NEW.city) //

CREATE TRIGGER capitalize_letters_update_clubs
BEFORE UPDATE ON clubs
FOR EACH ROW
SET NEW.name = capitalize(NEW.name),
NEW.city = capitalize(NEW.city) //

-- Coaches
CREATE TRIGGER capitalize_letters_insert_coaches
BEFORE INSERT ON coaches
FOR EACH ROW
SET NEW.name = capitalize(NEW.name),
NEW.lastname = capitalize(NEW.lastname),
NEW.nationality = capitalize(NEW.nationality) //

CREATE TRIGGER capitalize_letters_update_coaches
BEFORE UPDATE ON coaches
FOR EACH ROW
SET NEW.name = capitalize(NEW.name),
NEW.lastname = capitalize(NEW.lastname),
NEW.nationality = capitalize(NEW.nationality) //

-- Kits
CREATE TRIGGER capitalize_letters_insert_kits
BEFORE INSERT ON kits
FOR EACH ROW
SET NEW.home = capitalize(NEW.home),
NEW.away = capitalize(NEW.away),
NEW.clubcolours = capitalize(NEW.clubcolours) //

CREATE TRIGGER capitalize_letters_update_kits
BEFORE UPDATE ON kits
FOR EACH ROW
SET NEW.home = capitalize(NEW.home),
NEW.away = capitalize(NEW.away),
NEW.clubcolours = capitalize(NEW.clubcolours) //

-- STADIUMS
CREATE TRIGGER capitalize_letters_insert_stadiums
BEFORE INSERT ON stadiums
FOR EACH ROW
SET NEW.name = capitalize(NEW.name),
NEW.city = capitalize(NEW.city) //

CREATE TRIGGER capitalize_letters_update_stadiums
BEFORE UPDATE ON stadiums
FOR EACH ROW
SET NEW.name = capitalize(NEW.name),
NEW.city = capitalize(NEW.city) //

-- ZMIANA KODOWANIA W TABELI

ALTER DATABASE ekstraklasa CHARACTER SET utf8 COLLATE utf8_polish_ci;
ALTER TABLE players CONVERT TO CHARACTER SET utf8 COLLATE utf8_polish_ci;
ALTER TABLE clubs CONVERT TO CHARACTER SET utf8 COLLATE utf8_polish_ci;
ALTER TABLE coaches CONVERT TO CHARACTER SET utf8 COLLATE utf8_polish_ci;
ALTER TABLE stadiums CONVERT TO CHARACTER SET utf8 COLLATE utf8_polish_ci;
ALTER TABLE kits CONVERT TO CHARACTER SET utf8 COLLATE utf8_polish_ci;
ALTER TABLE logs CONVERT TO CHARACTER SET utf8 COLLATE utf8_polish_ci;
ALTER TABLE clubs_has_stadiums CONVERT TO CHARACTER SET utf8 COLLATE utf8_polish_ci;
ALTER TABLE crests CONVERT TO CHARACTER SET utf8 COLLATE utf8_polish_ci;


ALTER DATABASE ekstraklasa DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
ALTER TABLE players DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
ALTER TABLE clubs DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
ALTER TABLE coaches DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
ALTER TABLE stadiums DEFAULT CHARACTER SET utf8mb 4COLLATE utf8mb4_unicode_ci;
ALTER TABLE kits DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
ALTER TABLE logs DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
ALTER TABLE clubs_has_stadiums DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
ALTER TABLE crests DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;