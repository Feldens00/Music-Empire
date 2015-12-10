-- MySQL Workbench Forward Engineering

-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema musicempire
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema musicempire
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `musicempire` DEFAULT CHARACTER SET utf8 ;
USE `musicempire` ;

-- -----------------------------------------------------
-- Table `musicempire`.`locais`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `musicempire`.`locais` (
  `idLocal` INT(11) NOT NULL AUTO_INCREMENT,
  `sigla` VARCHAR(45) NOT NULL,
  `nomeEstado` VARCHAR(45) NOT NULL,
  `nomeCidade` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idLocal`))
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `musicempire`.`empresas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `musicempire`.`empresas` (
  `idEmpresa` INT(11) NOT NULL AUTO_INCREMENT,
  `nomeEmpresa` VARCHAR(45) NOT NULL,
  `enderecoEmpresa` VARCHAR(45) NOT NULL,
  `idLocal` INT(11) NOT NULL,
  PRIMARY KEY (`idEmpresa`),
  INDEX `idLocal` (`idLocal` ASC),
  CONSTRAINT `empresas_ibfk_1`
    FOREIGN KEY (`idLocal`)
    REFERENCES `musicempire`.`locais` (`idLocal`))
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `musicempire`.`eventos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `musicempire`.`eventos` (
  `idEvento` INT(11) NOT NULL AUTO_INCREMENT,
  `nomeEvento` VARCHAR(45) NOT NULL,
  `dataEvento` datetime NOT NULL,
  `enderecoEvento` VARCHAR(45) NOT NULL,
  `idLocal` INT(11) NOT NULL,
  PRIMARY KEY (`idEvento`),
  INDEX `idLocal` (`idLocal` ASC),
  CONSTRAINT `eventos_ibfk_1`
    FOREIGN KEY (`idLocal`)
    REFERENCES `musicempire`.`locais` (`idLocal`))
ENGINE = InnoDB
AUTO_INCREMENT = 29
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `musicempire`.`eventos_empresas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `musicempire`.`eventos_empresas` (
  `eventos_idEvento` INT(11) NOT NULL,
  `empresas_idEmpresa` INT(11) NOT NULL,
  PRIMARY KEY (`eventos_idEvento`, `empresas_idEmpresa`),
  INDEX `fk_eventos_has_empresas_empresas1_idx` (`empresas_idEmpresa` ASC),
  INDEX `fk_eventos_has_empresas_eventos1_idx` (`eventos_idEvento` ASC),
  CONSTRAINT `fk_eventos_has_empresas_empresas1`
    FOREIGN KEY (`empresas_idEmpresa`)
    REFERENCES `musicempire`.`empresas` (`idEmpresa`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_eventos_has_empresas_eventos1`
    FOREIGN KEY (`eventos_idEvento`)
    REFERENCES `musicempire`.`eventos` (`idEvento`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `musicempire`.`musicos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `musicempire`.`musicos` (
  `idMusico` INT(11) NOT NULL AUTO_INCREMENT,
  `nomeMusico` VARCHAR(45) NOT NULL,
  `enderecoMusico` VARCHAR(45) NOT NULL,
  `idLocal` INT(11) NOT NULL,
  PRIMARY KEY (`idMusico`),
  INDEX `idLocal` (`idLocal` ASC),
  CONSTRAINT `musicos_ibfk_1`
    FOREIGN KEY (`idLocal`)
    REFERENCES `musicempire`.`locais` (`idLocal`))
ENGINE = InnoDB
AUTO_INCREMENT = 12
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `musicempire`.`eventos_musicos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `musicempire`.`eventos_musicos` (
  `eventos_idEvento` INT(11) NOT NULL,
  `musicos_idMusico` INT(11) NOT NULL,
  PRIMARY KEY (`eventos_idEvento`, `musicos_idMusico`),
  INDEX `fk_eventos_has_musicos_musicos1_idx` (`musicos_idMusico` ASC),
  INDEX `fk_eventos_has_musicos_eventos1_idx` (`eventos_idEvento` ASC),
  CONSTRAINT `fk_eventos_has_musicos_eventos1`
    FOREIGN KEY (`eventos_idEvento`)
    REFERENCES `musicempire`.`eventos` (`idEvento`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_eventos_has_musicos_musicos1`
    FOREIGN KEY (`musicos_idMusico`)
    REFERENCES `musicempire`.`musicos` (`idMusico`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `musicempire`.`login`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `musicempire`.`login` (
  `idLogin` INT(11) NOT NULL AUTO_INCREMENT,
  `empresas_idEmpresa` INT(11) NULL,
  `musicos_idMusico` INT(11) NULL,
  `user` VARCHAR(45) NOT NULL DEFAULT 0,
  `senha` VARCHAR(45) NOT NULL DEFAULT 0,
  INDEX `fk_empresas_has_musicos_musicos1_idx` (`musicos_idMusico` ASC),
  INDEX `fk_empresas_has_musicos_empresas1_idx` (`empresas_idEmpresa` ASC),
  PRIMARY KEY (`idLogin`),
  CONSTRAINT `fk_empresas_has_musicos_empresas1`
    FOREIGN KEY (`empresas_idEmpresa`)
    REFERENCES `musicempire`.`empresas` (`idEmpresa`)
    ON DELETE cascade
    ON UPDATE  cascade,
  CONSTRAINT `fk_empresas_has_musicos_musicos1`
    FOREIGN KEY (`musicos_idMusico`)
    REFERENCES `musicempire`.`musicos` (`idMusico`)
    ON DELETE cascade
    ON UPDATE  cascade)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;
				select * 
        
