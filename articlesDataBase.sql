-- phpMyAdmin SQL Dump
-- version 4.2.7.1
-- http://www.phpmyadmin.net
--
-- Client :  localhost
-- Généré le :  Jeu 21 Novembre 2019 à 22:04
-- Version du serveur :  5.6.20-log
-- Version de PHP :  5.4.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de données :  `articlesDataBase`
--

-- --------------------------------------------------------

--
-- Structure de la table `articlesDataBase`
--

CREATE TABLE IF NOT EXISTS `article` (
  `ID` varchar(63) NOT NULL,
  `TITRE` varchar(100) NOT NULL,
  `TEXTE` varchar(700) NOT NULL,
   `IMAGE` longblob,
   `LIKES` int DEFAULT 0,
   `DISLIKES` int DEFAULT 0
   
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Contenu de la table `article`
--

INSERT INTO `article` (`ID`, `TITRE`, `TEXTE`,`LIKES`,`DISLIKES`) VALUES
('35ea25a5-12ae-4cf5-ab5d-fcd1a649e9b5', 'Article sur c#', 'DescriptionC# est un langage de programmation orientée objet, commercialisé par Microsoft depuis 2002 et destiné à développer sur la plateforme Microsoft .NET',1,2),
('5aab1be1-61de-4943-8f24-c0a5491006a8', 'Article sur Java', 'Java est un langage de programmation orienté objet créé par James Gosling et Patrick Naughton, employés de Sun Microsystems, avec le soutien de Bill Joy, présenté officiellement le 23 mai 1995 au SunWorld.',3,1),

('5aab1be1-61de-4943-8f24-c0a5497286a8', 'Article sur Html', 'Le HyperText Markup Language, généralement abrégé HTML ou dans sa dernière version HTML5, est le langage de balisage conçu pour représenter les pages web.',3,1);


--
-- Index pour la table `article`
--
ALTER TABLE `article`
 ADD PRIMARY KEY (`ID`);
