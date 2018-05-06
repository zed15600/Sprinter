CREATE DEFINER=`rrazopardc`@`%` PROCEDURE `obtenerCriterios`(IN idHistoria INT)
BEGIN
SELECT c.descripcion_cri FROM Criterios c
WHERE idHistoria = c.HistoriasDeUsuario_id_HU;
END