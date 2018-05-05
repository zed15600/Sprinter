CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerTodosLosProyectos`()
BEGIN
SELECT p.nombre_proyecto, p.descripcion_proyectos FROM proyectos p;
END