
-- -----------------------------------------------------
-- Schema Sprinter
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `Sprinter` DEFAULT CHARACTER SET utf8 ;
USE `Sprinter` ;

-- -----------------------------------------------------
-- Table `Sprinter`.`Proyectos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Sprinter`.`Proyectos` (
  `id_proyecto` INT NOT NULL AUTO_INCREMENT,
  `descripcion_proyectos` TINYTEXT NOT NULL,
  `n_Sprints` INT NOT NULL,
  `dur_Sprints` INT NOT NULL,
  `nombre_proyecto` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_proyecto`),
  UNIQUE INDEX `idProyectos_UNIQUE` (`id_proyecto` ASC),
  UNIQUE INDEX `nombre_proyecto_UNIQUE` (`nombre_proyecto` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Sprinter`.`HistoriasDeUsuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Sprinter`.`HistoriasDeUsuario` (
  `id_HU` INT NOT NULL,
  `HU_titulo` VARCHAR(45) NOT NULL,
  `HU_puntos` INT NOT NULL,
  `HU_prioridad` INT NOT NULL,
  `Proyectos_id_proyecto` INT NOT NULL,
  PRIMARY KEY (`id_HU`),
  UNIQUE INDEX `id_HU_UNIQUE` (`id_HU` ASC),
  UNIQUE INDEX `id_titulo_UNIQUE` (`HU_titulo` ASC),
  INDEX `fk_HistoriasDeUsuario_Proyectos_idx` (`Proyectos_id_proyecto` ASC),
  CONSTRAINT `fk_HistoriasDeUsuario_Proyectos`
    FOREIGN KEY (`Proyectos_id_proyecto`)
    REFERENCES `Sprinter`.`Proyectos` (`id_proyecto`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Sprinter`.`Criterios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Sprinter`.`Criterios` (
  `id_cri` INT NOT NULL,
  `descripcion_cri` TINYTEXT NOT NULL,
  `HistoriasDeUsuario_id_HU` INT NOT NULL,
  PRIMARY KEY (`id_cri`),
  UNIQUE INDEX `id_cri_UNIQUE` (`id_cri` ASC),
  INDEX `fk_Criterios_HistoriasDeUsuario1_idx` (`HistoriasDeUsuario_id_HU` ASC),
  CONSTRAINT `fk_Criterios_HistoriasDeUsuario1`
    FOREIGN KEY (`HistoriasDeUsuario_id_HU`)
    REFERENCES `Sprinter`.`HistoriasDeUsuario` (`id_HU`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Sprinter`.`Partidas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Sprinter`.`Partidas` (
  `id_partida` INT NOT NULL AUTO_INCREMENT,
  `nombre_partida` VARCHAR(45) NOT NULL,
  `estado` VARCHAR(20) NULL,
  `Proyectos_id_proyecto` INT NOT NULL,
  PRIMARY KEY (`id_partida`),
  UNIQUE INDEX `id_partida_UNIQUE` (`id_partida` ASC),
  INDEX `fk_Partidas_Proyectos1_idx` (`Proyectos_id_proyecto` ASC),
  CONSTRAINT `fk_Partidas_Proyectos1`
    FOREIGN KEY (`Proyectos_id_proyecto`)
    REFERENCES `Sprinter`.`Proyectos` (`id_proyecto`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Sprinter`.`PuntuacionesPorPartida`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Sprinter`.`PuntuacionesPorPartida` (
  `puntuacion` INT NULL,
  `HistoriasDeUsuario_id_HU` INT NOT NULL,
  `Partidas_id_partida` INT NOT NULL,
  INDEX `fk_PuntuacionesPorPartida_HistoriasDeUsuario1_idx` (`HistoriasDeUsuario_id_HU` ASC),
  PRIMARY KEY (`HistoriasDeUsuario_id_HU`, `Partidas_id_partida`),
  INDEX `fk_PuntuacionesPorPartida_Partidas1_idx` (`Partidas_id_partida` ASC),
  CONSTRAINT `fk_PuntuacionesPorPartida_HistoriasDeUsuario1`
    FOREIGN KEY (`HistoriasDeUsuario_id_HU`)
    REFERENCES `Sprinter`.`HistoriasDeUsuario` (`id_HU`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_PuntuacionesPorPartida_Partidas1`
    FOREIGN KEY (`Partidas_id_partida`)
    REFERENCES `Sprinter`.`Partidas` (`id_partida`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Sprinter`.`Impedimentos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Sprinter`.`Impedimentos` (
  `id_impedimento` INT NOT NULL AUTO_INCREMENT,
  `titulo_impedimento` VARCHAR(45) NOT NULL,
  `efecto_impedimento` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_impedimento`),
  UNIQUE INDEX `id_impedimento_UNIQUE` (`id_impedimento` ASC),
  UNIQUE INDEX `titulo_impedimento_UNIQUE` (`titulo_impedimento` ASC),
  UNIQUE INDEX `efecto_impedimento_UNIQUE` (`efecto_impedimento` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Sprinter`.`Jugadores`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Sprinter`.`Jugadores` (
  `id_jugador` INT NOT NULL AUTO_INCREMENT,
  `nombre_jugador` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_jugador`),
  UNIQUE INDEX `id_jugador_UNIQUE` (`id_jugador` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Sprinter`.`JugadoresPorPartida`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Sprinter`.`JugadoresPorPartida` (
  `Partidas_id_partida` INT NOT NULL,
  `Jugadores_id_jugador` INT NOT NULL,
  INDEX `fk_JugadoresPorPartida_Partidas1_idx` (`Partidas_id_partida` ASC),
  INDEX `fk_JugadoresPorPartida_Jugadores1_idx` (`Jugadores_id_jugador` ASC),
  PRIMARY KEY (`Partidas_id_partida`, `Jugadores_id_jugador`),
  CONSTRAINT `fk_JugadoresPorPartida_Partidas1`
    FOREIGN KEY (`Partidas_id_partida`)
    REFERENCES `Sprinter`.`Partidas` (`id_partida`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_JugadoresPorPartida_Jugadores1`
    FOREIGN KEY (`Jugadores_id_jugador`)
    REFERENCES `Sprinter`.`Jugadores` (`id_jugador`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Sprinter`.`Preguntas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Sprinter`.`Preguntas` (
  `pregunta` TINYTEXT NOT NULL,
  `respuestasPosibles` TINYTEXT NOT NULL,
  `id_pregunta` INT NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id_pregunta`),
  UNIQUE INDEX `id_pregunta_UNIQUE` (`id_pregunta` ASC),
  UNIQUE INDEX `Preguntascol_UNIQUE` (`id_pregunta` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Sprinter`.`RespuestasDeJugadores`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Sprinter`.`RespuestasDeJugadores` (
  `respuestas_J` TINYTEXT NULL,
  `Jugadores_id_jugador` INT NOT NULL,
  `Preguntas_id_pregunta` INT NOT NULL,
  INDEX `fk_RespuestasDeJugadores_Jugadores1_idx` (`Jugadores_id_jugador` ASC),
  INDEX `fk_RespuestasDeJugadores_Preguntas1_idx` (`Preguntas_id_pregunta` ASC),
  CONSTRAINT `fk_RespuestasDeJugadores_Jugadores1`
    FOREIGN KEY (`Jugadores_id_jugador`)
    REFERENCES `Sprinter`.`Jugadores` (`id_jugador`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_RespuestasDeJugadores_Preguntas1`
    FOREIGN KEY (`Preguntas_id_pregunta`)
    REFERENCES `Sprinter`.`Preguntas` (`id_pregunta`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;
