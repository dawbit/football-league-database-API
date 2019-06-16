-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Czas generowania: 15 Cze 2019, 21:50
-- Wersja serwera: 10.1.16-MariaDB
-- Wersja PHP: 5.6.24

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `ekstraklasa`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `clubs`
--

CREATE TABLE `clubs` (
  `id` int(10) UNSIGNED NOT NULL,
  `name` varchar(50) COLLATE utf8_polish_ci NOT NULL,
  `city` varchar(50) COLLATE utf8_polish_ci NOT NULL,
  `founded` year(4) DEFAULT NULL,
  `active` enum('ekstraklasa','other league','doesn''t exist') COLLATE utf8_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `clubs_has_stadiums`
--

CREATE TABLE `clubs_has_stadiums` (
  `clubs_id_clubs` int(10) UNSIGNED NOT NULL,
  `stadiums_id_stadiums` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `coaches`
--

CREATE TABLE `coaches` (
  `id` int(10) UNSIGNED NOT NULL,
  `name` varchar(50) COLLATE utf8_polish_ci NOT NULL,
  `lastname` varchar(50) COLLATE utf8_polish_ci NOT NULL,
  `dateofbirth` date DEFAULT NULL,
  `nationality` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `club` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `crests`
--

CREATE TABLE `crests` (
  `id` int(10) UNSIGNED NOT NULL,
  `image` longblob,
  `club` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `domesticcups`
--

CREATE TABLE `domesticcups` (
  `id` int(10) UNSIGNED NOT NULL,
  `name` varchar(50) COLLATE utf8_polish_ci NOT NULL,
  `year` varchar(9) COLLATE utf8_polish_ci NOT NULL,
  `winner` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `kits`
--

CREATE TABLE `kits` (
  `id` int(10) UNSIGNED NOT NULL,
  `home` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `away` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `clubcolours` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `club` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `logs`
--

CREATE TABLE `logs` (
  `id` int(11) NOT NULL,
  `user` varchar(40) COLLATE utf8_polish_ci NOT NULL,
  `date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `players`
--

CREATE TABLE `players` (
  `id` int(10) UNSIGNED NOT NULL,
  `name` varchar(50) COLLATE utf8_polish_ci NOT NULL,
  `lastname` varchar(50) COLLATE utf8_polish_ci NOT NULL,
  `dateofbirth` date DEFAULT NULL,
  `position` enum('goalkeeper','defender','midfielder','striker') COLLATE utf8_polish_ci NOT NULL,
  `height` tinyint(3) UNSIGNED DEFAULT NULL,
  `weight` tinyint(3) UNSIGNED DEFAULT NULL,
  `nationality` varchar(50) COLLATE utf8_polish_ci DEFAULT NULL,
  `club` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `seasons`
--

CREATE TABLE `seasons` (
  `id` int(10) UNSIGNED NOT NULL,
  `leaguename` varchar(50) COLLATE utf8_polish_ci NOT NULL,
  `year` varchar(9) COLLATE utf8_polish_ci NOT NULL,
  `winner` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `stadiums`
--

CREATE TABLE `stadiums` (
  `id` int(10) UNSIGNED NOT NULL,
  `name` varchar(100) COLLATE utf8_polish_ci NOT NULL,
  `city` varchar(50) COLLATE utf8_polish_ci NOT NULL,
  `capacity` mediumint(8) UNSIGNED DEFAULT NULL,
  `buildyear` year(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Indeksy dla zrzutów tabel
--

--
-- Indexes for table `clubs`
--
ALTER TABLE `clubs`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id_clubs_UNIQUE` (`id`),
  ADD UNIQUE KEY `name_clubs_UNIQUE` (`name`);

--
-- Indexes for table `clubs_has_stadiums`
--
ALTER TABLE `clubs_has_stadiums`
  ADD PRIMARY KEY (`clubs_id_clubs`,`stadiums_id_stadiums`),
  ADD KEY `clubs_has_stadiums_stadiums_idx` (`stadiums_id_stadiums`),
  ADD KEY `clubs_has_stadiums_clubs_idx` (`clubs_id_clubs`);

--
-- Indexes for table `coaches`
--
ALTER TABLE `coaches`
  ADD PRIMARY KEY (`id`),
  ADD KEY `coaches_clubs_idx` (`club`);

--
-- Indexes for table `crests`
--
ALTER TABLE `crests`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id_crests_UNIQUE` (`id`),
  ADD KEY `crests_clubs_idx` (`club`);

--
-- Indexes for table `domesticcups`
--
ALTER TABLE `domesticcups`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id_domesticcup_UNIQUE` (`id`),
  ADD KEY `domesticcup_clubs_idx` (`winner`);

--
-- Indexes for table `kits`
--
ALTER TABLE `kits`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id_kits_UNIQUE` (`id`),
  ADD UNIQUE KEY `club_UNIQUE` (`club`),
  ADD KEY `kits_clubs_idx` (`club`);

--
-- Indexes for table `logs`
--
ALTER TABLE `logs`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `players`
--
ALTER TABLE `players`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id_players_UNIQUE` (`id`),
  ADD KEY `players_clubs_idx` (`club`);

--
-- Indexes for table `seasons`
--
ALTER TABLE `seasons`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id_seasons_UNIQUE` (`id`),
  ADD KEY `seasons_clubs_idx` (`winner`);

--
-- Indexes for table `stadiums`
--
ALTER TABLE `stadiums`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id_stadiums_UNIQUE` (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT dla tabeli `clubs`
--
ALTER TABLE `clubs`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT dla tabeli `coaches`
--
ALTER TABLE `coaches`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT dla tabeli `crests`
--
ALTER TABLE `crests`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT dla tabeli `kits`
--
ALTER TABLE `kits`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT dla tabeli `logs`
--
ALTER TABLE `logs`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT dla tabeli `players`
--
ALTER TABLE `players`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT dla tabeli `seasons`
--
ALTER TABLE `seasons`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT dla tabeli `stadiums`
--
ALTER TABLE `stadiums`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;
--
-- Ograniczenia dla zrzutów tabel
--

--
-- Ograniczenia dla tabeli `clubs_has_stadiums`
--
ALTER TABLE `clubs_has_stadiums`
  ADD CONSTRAINT `clubs_has_stadiums_clubs` FOREIGN KEY (`clubs_id_clubs`) REFERENCES `clubs` (`id`),
  ADD CONSTRAINT `clubs_has_stadiums_stadiums` FOREIGN KEY (`stadiums_id_stadiums`) REFERENCES `stadiums` (`id`);

--
-- Ograniczenia dla tabeli `coaches`
--
ALTER TABLE `coaches`
  ADD CONSTRAINT `coaches_clubs` FOREIGN KEY (`club`) REFERENCES `clubs` (`id`);

--
-- Ograniczenia dla tabeli `crests`
--
ALTER TABLE `crests`
  ADD CONSTRAINT `crests_clubs` FOREIGN KEY (`club`) REFERENCES `clubs` (`id`);

--
-- Ograniczenia dla tabeli `domesticcups`
--
ALTER TABLE `domesticcups`
  ADD CONSTRAINT `domesticcup_clubs` FOREIGN KEY (`winner`) REFERENCES `clubs` (`id`);

--
-- Ograniczenia dla tabeli `kits`
--
ALTER TABLE `kits`
  ADD CONSTRAINT `kits_clubs` FOREIGN KEY (`club`) REFERENCES `clubs` (`id`);

--
-- Ograniczenia dla tabeli `players`
--
ALTER TABLE `players`
  ADD CONSTRAINT `players_clubs` FOREIGN KEY (`club`) REFERENCES `clubs` (`id`);

--
-- Ograniczenia dla tabeli `seasons`
--
ALTER TABLE `seasons`
  ADD CONSTRAINT `seasons_clubs` FOREIGN KEY (`winner`) REFERENCES `clubs` (`id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
