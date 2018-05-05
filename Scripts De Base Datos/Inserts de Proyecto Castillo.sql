#Proyecto Castillo
INSERT INTO sprinter.proyectos (proyectos.id_proyecto, proyectos.nombre_proyecto, proyectos.descripcion_proyectos,
proyectos.n_Sprints, proyectos.dur_Sprints)
values (0, "Castillo de Pelicula",
"Se va a filmar una adaptación cinematográfica de la historia del Rey Arturo. Con ánimos de recrear un escenario medieval la producción aprobó la construcción de un castillo; ustedes como equipo, deben plantear un prototipo a escala de dicha construcción. Este proyecto requiere Legos.",
3, 4);

#Historias de Usuario
INSERT INTO sprinter.historiasdeusuario (historiasdeusuario.Proyectos_id_proyecto, historiasdeusuario.id_HU, historiasdeusuario.HU_titulo, historiasdeusuario.HU_puntos, historiasdeusuario.HU_prioridad, historiasdeusuario.HU_numero)
values (1, 0, "Como productor deseo un escenario con un castillo que contenga una torre central con una puerta.", 3, 5, "HU000");
INSERT INTO sprinter.historiasdeusuario (historiasdeusuario.Proyectos_id_proyecto, historiasdeusuario.id_HU, historiasdeusuario.HU_titulo, historiasdeusuario.HU_puntos, historiasdeusuario.HU_prioridad, historiasdeusuario.HU_numero)
values (1, 1, "Como director deseo que alrededor de la torre central exista un jardín de flores con contenga un pozo.", 4, 4, "HU001");
INSERT INTO sprinter.historiasdeusuario (historiasdeusuario.Proyectos_id_proyecto, historiasdeusuario.id_HU, historiasdeusuario.HU_titulo, historiasdeusuario.HU_puntos, historiasdeusuario.HU_prioridad, historiasdeusuario.HU_numero)
values (1, 2, "Como jefe encargado de los escenarios deseo cuatro torres menores alrededor del jardín de la torre central.", 6, 5, "HU002");
INSERT INTO sprinter.historiasdeusuario (historiasdeusuario.Proyectos_id_proyecto, historiasdeusuario.id_HU, historiasdeusuario.HU_titulo, historiasdeusuario.HU_puntos, historiasdeusuario.HU_prioridad, historiasdeusuario.HU_numero)
values (1, 3, "Como grupo encargado de la producción deseo que el castillo tenga 4 murallas unidas como un cuadrado, en cada vértice estará una de las 4 torres menores.", 6, 4, "HU003");
INSERT INTO sprinter.historiasdeusuario (historiasdeusuario.Proyectos_id_proyecto, historiasdeusuario.id_HU, historiasdeusuario.HU_titulo, historiasdeusuario.HU_puntos, historiasdeusuario.HU_prioridad, historiasdeusuario.HU_numero)
values (1, 4, "Como director deseo una gran puerta en una de las murallas de la torre.", 2, 3, "HU004");
INSERT INTO sprinter.historiasdeusuario (historiasdeusuario.Proyectos_id_proyecto, historiasdeusuario.id_HU, historiasdeusuario.HU_titulo, historiasdeusuario.HU_puntos, historiasdeusuario.HU_prioridad, historiasdeusuario.HU_numero)
values (1, 5, "Como productor deseo que en los jardines del castillo existiera una horca.", 3, 2, "HU005");
INSERT INTO sprinter.historiasdeusuario (historiasdeusuario.Proyectos_id_proyecto, historiasdeusuario.id_HU, historiasdeusuario.HU_titulo, historiasdeusuario.HU_puntos, historiasdeusuario.HU_prioridad, historiasdeusuario.HU_numero)
values (1, 6, "Como jefe encargado de los escenarios deseo un puente colgante entre la torre central y una de las torres menores.", 3, 3, "HU006");
INSERT INTO sprinter.historiasdeusuario (historiasdeusuario.Proyectos_id_proyecto, historiasdeusuario.id_HU, historiasdeusuario.HU_titulo, historiasdeusuario.HU_puntos, historiasdeusuario.HU_prioridad, historiasdeusuario.HU_numero)
values (1, 7, "Como equipo de producción deseamos que el castillo posea un establo para caballos.", 2, 2, "HU007");
INSERT INTO sprinter.historiasdeusuario (historiasdeusuario.Proyectos_id_proyecto, historiasdeusuario.id_HU, historiasdeusuario.HU_titulo, historiasdeusuario.HU_puntos, historiasdeusuario.HU_prioridad, historiasdeusuario.HU_numero)
values (1, 8, "Como productor deseo que exista un camino que comunique la puerta de la torre con la puerta principal del castillo que esté iluminado por lámparas.", 3, 3, "HU008");
INSERT INTO sprinter.historiasdeusuario (historiasdeusuario.Proyectos_id_proyecto, historiasdeusuario.id_HU, historiasdeusuario.HU_titulo, historiasdeusuario.HU_puntos, historiasdeusuario.HU_prioridad, historiasdeusuario.HU_numero)
values (1, 9, "Como actriz que representará a la esposa de Arturo me gustaría que en frente del castillo exista una plaza con una fuente de agua.", 5, 2, "HU009");
INSERT INTO sprinter.historiasdeusuario (historiasdeusuario.Proyectos_id_proyecto, historiasdeusuario.id_HU, historiasdeusuario.HU_titulo, historiasdeusuario.HU_puntos, historiasdeusuario.HU_prioridad, historiasdeusuario.HU_numero)
values (1, 10, "Como productor deseo que cada torre y cada muralla tengan una bandera con el emblema del reino.", 4, 2, "HU010");

#Criterios HU 0
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("La torre central debe medir 15 pisos.", 0);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("La puerta debe estar en la base y medir 2 pisos.", 0);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("La torre solo puede estar compuesta de bloques de dos colores diferentes.", 0);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("La torre debe tener una cúpula con forma cónica.", 0);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("La cúpula solo puede ser de un color.", 0);

#Criterios HU 1
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("El jardín debe tener dos tipos diferentes de flores.", 1);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("El jardín debe rodear la torre central en un radio de más de 10 cm.", 1);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("El jardín debe tener un prado verde.", 1);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("El pozo debe ser de un solo color.", 1);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("El pozo debe ser hueco en el centro.", 1);

#Criterios HU 2
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("Cada torre debe medir 10 pisos.", 2);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("Las torres deben estar a una distancia de más de 10 cm de la torre central (Si ya la hicieron).", 2);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("Todas las torres deben ser iguales en color y forma.", 2);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("Cada torre debe estar en un punto cardinal con respecto a la torre central (Si ya la hicieron).", 2);

#Criterios HU 3
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("Cada muralla debe tener 5 pisos de alto.", 3);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("Cada muralla debe ser de un mismo color.", 3);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("Cada muralla debe conectarse con dos torres menores.", 3);

#Criterios HU 4
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("La puerta es de un solo color.", 4);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("La puerta deb ser de 3 pisos de alto.", 4);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("La puerta debe ser ubicada en una muralla.", 4);

#Criterios HU 5
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("La horca debe tener un podio de dos pisos de alto.", 5);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("En el centro del podio debe haber una ranura hueca.", 5);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("La cuerda de la horca debe estar colgando 4 pisos del podio.", 5);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("La cuerda debe tener un nudo circular. ", 5);

#Criterios HU 6
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("El puente debe sostenerse por medio de cuerdas.", 6);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("El puente debe ser de máximo dos colores.", 6);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("Debe colgar desde un piso superior al piso 10 de la torre central hasta el centro de una de las murallas.", 6);

#Criterios HU 7
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("El establo debe ser de forma cuadrada.", 7);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("El establo debe ser techado.", 7);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("El establo debe tener dos pisos de altura.", 7);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("El establo debe estar afuera de las murallas.", 7);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("El establo debe ser de más de 3 bloques de ancho.", 7);

#Criterios HU 8
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("El camino debe conectar la puerta de la torre central con la gran puerta de la muralla.", 8);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("El camino debe ser de un solo color.", 8);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("El camino debe ser adornado por lámparas de un solo color.", 8);

#Criterios HU 9
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("La plaza debe tener un piso de piedra de 1 solo color.", 9);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("La plaza debe estar ubicada a las afueras de las murallas.", 9);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("La fuente debe tener forma circular.", 9);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("El agua de la fuente debe ser representada con un material azul.", 9);

#Criterios HU 10
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("El emblema debe tener forma de sol.", 10);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("El emblema debe estar en banderas en las cuatro murallas.", 10);
INSERT INTO sprinter.criterios (criterios.descripcion_cri, criterios.HistoriasDeUsuario_id_HU) 
values ("El emblema debe estar en banderas en las cuatro torres.", 10);
