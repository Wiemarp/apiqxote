-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 23, 2023 at 10:47 AM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `databaseqxote`
--

-- --------------------------------------------------------

--
-- Table structure for table `animal`
--

CREATE TABLE `animal` (
  `animal_id` int(11) NOT NULL,
  `date` datetime DEFAULT NULL,
  `start_time` time DEFAULT NULL,
  `end_time` time DEFAULT NULL,
  `temperature` double DEFAULT NULL,
  `cloud_cover` int(11) DEFAULT NULL,
  `wind_speed` int(11) DEFAULT NULL,
  `species_name` varchar(45) DEFAULT NULL,
  `coordinates` varchar(90) DEFAULT NULL,
  `abudance` varchar(45) DEFAULT NULL,
  `coverboards` varchar(45) DEFAULT NULL,
  `zone` varchar(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `bio_concentration`
--

CREATE TABLE `bio_concentration` (
  `id` int(11) NOT NULL,
  `species` varchar(45) DEFAULT NULL,
  `bcf` decimal(10,0) DEFAULT NULL,
  `cf` decimal(10,0) DEFAULT NULL,
  `r` decimal(10,0) DEFAULT NULL,
  `ctree` decimal(10,0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `plant`
--

CREATE TABLE `plant` (
  `plant_id` int(11) NOT NULL,
  `plot_nr` varchar(4) DEFAULT NULL,
  `coordinate` varchar(90) DEFAULT NULL,
  `species` varchar(45) DEFAULT NULL,
  `cover` varchar(45) DEFAULT NULL,
  `temperature` varchar(45) DEFAULT NULL,
  `humidity` float DEFAULT NULL,
  `date` date DEFAULT NULL,
  `zone` varchar(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tree`
--

CREATE TABLE `tree` (
  `tree_nr` int(11) NOT NULL,
  `zone` varchar(1) NOT NULL,
  `coordinate` varchar(90) DEFAULT NULL,
  `height` decimal(10,0) DEFAULT NULL,
  `circumference` decimal(10,0) DEFAULT NULL,
  `volume` decimal(10,0) DEFAULT NULL,
  `bio_concentration_id` int(11) NOT NULL,
  `tree_name` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tree_name`
--

CREATE TABLE `tree_name` (
  `tree_name` varchar(45) NOT NULL,
  `coordinate_count` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `zone`
--

CREATE TABLE `zone` (
  `zone` varchar(1) NOT NULL,
  `area` int(11) DEFAULT NULL,
  `classification` enum('homogenuis','no_homogenuis','transition') DEFAULT NULL,
  `plots` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `animal`
--
ALTER TABLE `animal`
  ADD PRIMARY KEY (`animal_id`),
  ADD KEY `fk_animal_zone1` (`zone`);

--
-- Indexes for table `bio_concentration`
--
ALTER TABLE `bio_concentration`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `plant`
--
ALTER TABLE `plant`
  ADD PRIMARY KEY (`plant_id`),
  ADD KEY `fk_plant_zone1` (`zone`);

--
-- Indexes for table `tree`
--
ALTER TABLE `tree`
  ADD PRIMARY KEY (`tree_nr`,`zone`),
  ADD KEY `fk_tree_bio_concentration1` (`bio_concentration_id`),
  ADD KEY `fk_tree_tree_name1` (`tree_name`),
  ADD KEY `fk_tree_zone1` (`zone`);

--
-- Indexes for table `tree_name`
--
ALTER TABLE `tree_name`
  ADD PRIMARY KEY (`tree_name`);

--
-- Indexes for table `zone`
--
ALTER TABLE `zone`
  ADD PRIMARY KEY (`zone`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `animal`
--
ALTER TABLE `animal`
  MODIFY `animal_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `bio_concentration`
--
ALTER TABLE `bio_concentration`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `plant`
--
ALTER TABLE `plant`
  MODIFY `plant_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tree`
--
ALTER TABLE `tree`
  MODIFY `tree_nr` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `animal`
--
ALTER TABLE `animal`
  ADD CONSTRAINT `fk_animal_zone1` FOREIGN KEY (`zone`) REFERENCES `zone` (`zone`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `plant`
--
ALTER TABLE `plant`
  ADD CONSTRAINT `fk_plant_zone1` FOREIGN KEY (`zone`) REFERENCES `zone` (`zone`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `tree`
--
ALTER TABLE `tree`
  ADD CONSTRAINT `fk_tree_bio_concentration1` FOREIGN KEY (`bio_concentration_id`) REFERENCES `bio_concentration` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_tree_tree_name1` FOREIGN KEY (`tree_name`) REFERENCES `tree_name` (`tree_name`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_tree_zone1` FOREIGN KEY (`zone`) REFERENCES `zone` (`zone`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
