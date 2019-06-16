CREATE USER 'admin'@'localhost' IDENTIFIED VIA mysql_native_password USING '***';GRANT USAGE ON *.* TO 'admin'@'localhost' REQUIRE NONE WITH MAX_QUERIES_PER_HOUR 0 MAX_CONNECTIONS_PER_HOUR 0 MAX_UPDATES_PER_HOUR 0 MAX_USER_CONNECTIONS 0;
GRANT SELECT, INSERT, UPDATE, DELETE ON `ekstraklasa`.* TO 'admin'@'localhost';

CREATE USER 'user'@'localhost' IDENTIFIED VIA mysql_native_password USING '***';GRANT USAGE ON *.* TO 'user'@'localhost' REQUIRE NONE WITH MAX_QUERIES_PER_HOUR 0 MAX_CONNECTIONS_PER_HOUR 0 MAX_UPDATES_PER_HOUR 0 MAX_USER_CONNECTIONS 0;
GRANT SELECT ON `ekstraklasa`.* TO 'user'@'localhost';

GRANT USAGE ON *.* TO 'admin'@'localhost' IDENTIFIED BY PASSWORD '***';

GRANT SELECT, INSERT, UPDATE, DELETE ON `ekstraklasa`.* TO 'admin'@'localhost';

GRANT USAGE ON *.* TO 'user'@'localhost' IDENTIFIED BY PASSWORD '***';

GRANT SELECT ON `ekstraklasa`.* TO 'user'@'localhost';
