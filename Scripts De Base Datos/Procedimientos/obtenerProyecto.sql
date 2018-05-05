CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerProyecto`(IN nombreProyecto varchar(45))
BEGIN
SElECT p.id_proyecto, p.descripcion_proyectos, p.n_Sprints, p.dur_Sprints
FROM proyectos p
WHERE nombreProyecto = nombre_proyecto;
END