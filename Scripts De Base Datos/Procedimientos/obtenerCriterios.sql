CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerCriterios`(IN idHistoria INT)
BEGIN
SELECT c.descripcion_cri FROM criterios c
WHERE idHistoria = c.HistoriasDeUsuario_id_HU;
END