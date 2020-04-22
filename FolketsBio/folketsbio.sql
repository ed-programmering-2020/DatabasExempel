-- --------------------------------------------------------
-- Värd:                         127.0.0.1
-- Serverversion:                10.4.6-MariaDB - mariadb.org binary distribution
-- Server-OS:                    Win64
-- HeidiSQL Version:             10.3.0.5771
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumpar databasstruktur för folketsbio
DROP DATABASE IF EXISTS `folketsbio`;
CREATE DATABASE IF NOT EXISTS `folketsbio` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `folketsbio`;

-- Dumpar struktur för tabell folketsbio.kunder
DROP TABLE IF EXISTS `kunder`;
CREATE TABLE IF NOT EXISTS `kunder` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Namn` varchar(50) NOT NULL DEFAULT '0',
  `LastLog` datetime NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

-- Dumpar data för tabell folketsbio.kunder: ~0 rows (ungefär)
/*!40000 ALTER TABLE `kunder` DISABLE KEYS */;
REPLACE INTO `kunder` (`ID`, `Namn`, `LastLog`) VALUES
	(1, 'Ralf', '2020-04-21 15:35:26'),
	(2, 'Linus', '2014-02-21 05:35:51'),
	(12, 'Edvin', '2020-04-13 00:06:17');
/*!40000 ALTER TABLE `kunder` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
