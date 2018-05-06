CREATE DEFINER=`rrazopardc`@`%` PROCEDURE `obtenerProyecto`(IN nombreProyecto varchar(45))
BEGIN
SElECT p.id_proyecto, p.descripcion_proyectos, p.n_Sprints, p.dur_Sprints
FROM Proyectos p
WHERE nombreProyecto = nombre_proyecto;
END