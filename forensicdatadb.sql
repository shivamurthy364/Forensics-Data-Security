/*
SQLyog Ultimate v8.55 
MySQL - 5.1.36-community : Database - forensicdata
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`forensicdata` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `forensicdata`;

/*Table structure for table `applicationmanager` */

DROP TABLE IF EXISTS `applicationmanager`;

CREATE TABLE `applicationmanager` (
  `AMId` int(11) DEFAULT NULL,
  `Password` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `areamaster` */

DROP TABLE IF EXISTS `areamaster`;

CREATE TABLE `areamaster` (
  `AreaId` int(11) NOT NULL AUTO_INCREMENT,
  `AreaName` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`AreaId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Table structure for table `crimemaster` */

DROP TABLE IF EXISTS `crimemaster`;

CREATE TABLE `crimemaster` (
  `CrimeId` int(11) NOT NULL AUTO_INCREMENT,
  `PSId` int(11) DEFAULT NULL,
  `CrimeName` varchar(100) DEFAULT NULL,
  `CrimePlace` varchar(100) DEFAULT NULL,
  `Description` varchar(8000) DEFAULT NULL,
  `CrimeDate` varchar(100) DEFAULT NULL,
  `Status` varbinary(20) DEFAULT NULL,
  PRIMARY KEY (`CrimeId`),
  KEY `FK_crimemaster` (`PSId`),
  CONSTRAINT `FK_crimemaster` FOREIGN KEY (`PSId`) REFERENCES `policestationmaster` (`PoliceStationId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Table structure for table `crimerequest` */

DROP TABLE IF EXISTS `crimerequest`;

CREATE TABLE `crimerequest` (
  `ReqId` int(11) NOT NULL AUTO_INCREMENT,
  `SlNo` int(11) DEFAULT NULL,
  `HOId` int(11) DEFAULT NULL,
  `AccessKey` int(11) DEFAULT NULL,
  `ReqDate` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`ReqId`),
  KEY `FK_crimerequest` (`HOId`),
  CONSTRAINT `FK_crimerequest` FOREIGN KEY (`HOId`) REFERENCES `higherofficermaster` (`HOId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `doctormaster` */

DROP TABLE IF EXISTS `doctormaster`;

CREATE TABLE `doctormaster` (
  `DoctorId` int(11) NOT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Password` varchar(10) DEFAULT NULL,
  `MobileNo` varchar(10) DEFAULT NULL,
  `EmailId` varchar(100) DEFAULT NULL,
  `Address` varchar(1000) DEFAULT NULL,
  PRIMARY KEY (`DoctorId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `forensicdatacollect` */

DROP TABLE IF EXISTS `forensicdatacollect`;

CREATE TABLE `forensicdatacollect` (
  `FDCId` int(11) NOT NULL AUTO_INCREMENT,
  `FSId` int(11) DEFAULT NULL,
  `CrimeId` int(11) DEFAULT NULL,
  `Description` varchar(8000) DEFAULT NULL,
  `FSCDate` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`FDCId`),
  KEY `FK_forensicdatacollect` (`FSId`),
  KEY `FK_forensicdatacollect_c` (`CrimeId`),
  CONSTRAINT `FK_forensicdatacollect` FOREIGN KEY (`FSId`) REFERENCES `forensicstaff` (`FSId`),
  CONSTRAINT `FK_forensicdatacollect_c` FOREIGN KEY (`CrimeId`) REFERENCES `crimemaster` (`CrimeId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Table structure for table `forensicstaff` */

DROP TABLE IF EXISTS `forensicstaff`;

CREATE TABLE `forensicstaff` (
  `FSId` int(11) NOT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Password` varchar(10) DEFAULT NULL,
  `MobileNo` varchar(10) DEFAULT NULL,
  `EmailId` varchar(100) DEFAULT NULL,
  `Address` varchar(1000) DEFAULT NULL,
  PRIMARY KEY (`FSId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `higherofficermaster` */

DROP TABLE IF EXISTS `higherofficermaster`;

CREATE TABLE `higherofficermaster` (
  `HOId` int(11) NOT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Password` varchar(10) DEFAULT NULL,
  `Role` varchar(100) DEFAULT NULL,
  `MobileNo` varchar(10) DEFAULT NULL,
  `EmailId` varchar(100) DEFAULT NULL,
  `Address` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`HOId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `messagemaster` */

DROP TABLE IF EXISTS `messagemaster`;

CREATE TABLE `messagemaster` (
  `PId` int(11) NOT NULL AUTO_INCREMENT,
  `HOId` int(11) DEFAULT NULL,
  `PSId` int(11) DEFAULT NULL,
  `PostDate` varchar(20) DEFAULT NULL,
  `Message` varchar(800) DEFAULT NULL,
  `Status` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`PId`),
  KEY `FK_messagemaster` (`HOId`),
  KEY `FK_messagemasterPS` (`PSId`),
  CONSTRAINT `FK_messagemaster` FOREIGN KEY (`HOId`) REFERENCES `higherofficermaster` (`HOId`),
  CONSTRAINT `FK_messagemasterPS` FOREIGN KEY (`PSId`) REFERENCES `policestationmaster` (`PoliceStationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `policestationmaster` */

DROP TABLE IF EXISTS `policestationmaster`;

CREATE TABLE `policestationmaster` (
  `PoliceStationId` int(11) NOT NULL,
  `AreaId` int(11) DEFAULT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Password` varchar(10) DEFAULT NULL,
  `MobileNo` varchar(10) DEFAULT NULL,
  `EmailId` varchar(100) DEFAULT NULL,
  `Address` varchar(800) DEFAULT NULL,
  PRIMARY KEY (`PoliceStationId`),
  KEY `FK_policestationmaster` (`AreaId`),
  CONSTRAINT `FK_policestationmaster` FOREIGN KEY (`AreaId`) REFERENCES `areamaster` (`AreaId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `reportrequest` */

DROP TABLE IF EXISTS `reportrequest`;

CREATE TABLE `reportrequest` (
  `RRId` int(11) NOT NULL AUTO_INCREMENT,
  `Id` int(11) DEFAULT NULL,
  `CrimeId` int(11) DEFAULT NULL,
  `UserType` varchar(50) DEFAULT NULL,
  `RDate` varchar(100) DEFAULT NULL,
  `AccessKey` varchar(10) DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`RRId`),
  KEY `FK_reportrequest` (`CrimeId`),
  CONSTRAINT `FK_reportrequest` FOREIGN KEY (`CrimeId`) REFERENCES `crimemaster` (`CrimeId`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
