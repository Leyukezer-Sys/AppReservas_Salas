-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema bd_reservaSala
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema bd_reservaSala
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `bd_reservaSala` DEFAULT CHARACTER SET utf8 ;
USE `bd_reservaSala` ;

-- -----------------------------------------------------
-- Table `bd_reservaSala`.`tipo_usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_reservaSala`.`tipo_usuario` (
  `id_tipo` INT NOT NULL AUTO_INCREMENT,
  `nome_tipo` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_tipo`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bd_reservaSala`.`usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_reservaSala`.`usuario` (
  `id_usuario` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NOT NULL,
  `matricula` VARCHAR(45) NOT NULL,
  `senha` VARCHAR(255) NOT NULL,
  `id_tipo_fk` INT NOT NULL,
  PRIMARY KEY (`id_usuario`),
  INDEX `fk_usuario_tipo_usuario1_idx` (`id_tipo_fk` ASC) VISIBLE,
  CONSTRAINT `fk_usuario_tipo_usuario1`
    FOREIGN KEY (`id_tipo_fk`)
    REFERENCES `bd_reservaSala`.`tipo_usuario` (`id_tipo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bd_reservaSala`.`tipo_sala`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_reservaSala`.`tipo_sala` (
  `id_tipo` INT NOT NULL AUTO_INCREMENT,
  `nome_tipo` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_tipo`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bd_reservaSala`.`sala`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_reservaSala`.`sala` (
  `id_sala` INT NOT NULL AUTO_INCREMENT,
  `numero` INT NOT NULL,
  `capacidade` INT NOT NULL,
  `bloco` VARCHAR(45) NOT NULL,
  `id_tipo_fk` INT NOT NULL,
  PRIMARY KEY (`id_sala`),
  INDEX `fk_sala_tipo_sala1_idx` (`id_tipo_fk` ASC) VISIBLE,
  CONSTRAINT `fk_sala_tipo_sala1`
    FOREIGN KEY (`id_tipo_fk`)
    REFERENCES `bd_reservaSala`.`tipo_sala` (`id_tipo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bd_reservaSala`.`reserva`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_reservaSala`.`reserva` (
  `id_reserva` INT NOT NULL AUTO_INCREMENT,
  `data_reserva` DATE NOT NULL,
  `hora_reserva` TIME NULL,
  `hora_fim_reserva` TIME NULL,
  `id_usuario_fk` INT NOT NULL,
  `id_sala_fk` INT NOT NULL,
  PRIMARY KEY (`id_reserva`),
  INDEX `fk_reserva_usuario_idx` (`id_usuario_fk` ASC) VISIBLE,
  INDEX `fk_reserva_sala1_idx` (`id_sala_fk` ASC) VISIBLE,
  CONSTRAINT `fk_reserva_usuario`
    FOREIGN KEY (`id_usuario_fk`)
    REFERENCES `bd_reservaSala`.`usuario` (`id_usuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_reserva_sala1`
    FOREIGN KEY (`id_sala_fk`)
    REFERENCES `bd_reservaSala`.`sala` (`id_sala`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
