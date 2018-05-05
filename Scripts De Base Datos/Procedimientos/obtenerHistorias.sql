CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerHistorias`(IN idProyecto varchar(45))
BEGIN
SELECT h.id_HU, h.HU_titulo, h.HU_puntos, h.HU_prioridad, h.HU_numero FROM historiasdeusuario h
Where idProyecto = Proyectos_id_proyecto;
END