CREATE DEFINER=`rrazopardc`@`%` PROCEDURE `obtenerTodosLosProyectos`()
BEGIN
SELECT p.nombre_proyecto, p.descripcion_proyectos FROM Proyectos p;
END