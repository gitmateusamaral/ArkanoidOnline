-- phpMyAdmin SQL Dump
-- version 4.1.12
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: 30-Set-2015 às 01:29
-- Versão do servidor: 5.6.16
-- PHP Version: 5.5.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `arkanoid`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `ranking`
--

CREATE TABLE IF NOT EXISTS `ranking` (
  `id` int(5) NOT NULL AUTO_INCREMENT,
  `user` varchar(20) NOT NULL,
  `score` int(4) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id` (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=13 ;

--
-- Extraindo dados da tabela `ranking`
--

INSERT INTO `ranking` (`id`, `user`, `score`) VALUES
(1, 'teste', 0),
(2, 'teste2', 15),
(3, 'teste3', 5),
(4, 'teste4', 20),
(5, 'teste5', 2),
(6, 'teste6', 1),
(7, 'teste7', 0),
(8, 'teste8', 3),
(9, 'teste9', 10),
(10, 'teste10', 21),
(11, 'teste11', 30),
(12, 'xablau', 1);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
