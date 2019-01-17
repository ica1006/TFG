# TFG - Desarrollo de una interfaz para planta piloto
Trabajo de Fin de Grado - Desarrollo de una interfaz para planta piloto
## Autor
Francisco Crespo Diez
## Universidad
Universidad de Burgos - España
## Tutor Universidad de Burgos
	- Dr. Alejandro Merino Gómez
	- Dr. Daniel Sarabia Ortiz
## Reuniones
### 18 de Octubre de 2018
Primer contacto con los doctores Merino y Sarabia. Se comenzó con una presentación de los materiales que se iban a utilizar en el proyecto, expresando las primeras ideas y conjeturas que cada uno tenía sobre el mismo. También se definieron el tipo de repositorio a utilizar, así como la metodología y el formato de la documentación. Tras la reunión se decidió que la próxima semana se dedicaría a la investigación sobre el lenguaje a utilizar para el desarrollo del proyecto, buscando facilitar la comunicación serie con la placa FRDM K64F.
### 30 de Octubre de 2018
Segunda reunión en la que se han tratado los siguientes temas:
1. Préstamo de la placa FRDM K64F al estudiante.
2. Conexión de la placa mediante puerto serie y visualización de los datos a través del programa Termite.
3. Explicación del documento "Especificaciones Interfaz planta piloto.docx".
4. Pasos siguientes:
    1. Crear una aplicación sencilla que se comunique con la placa a través del puerto serie.
    2. Definir un formato del archivo de configuración, donde se guardan los valores de las variables que se van a utilizar en la placa. La aplicación no tiene porqué trabajar siempre con las mismas variables, depende de cómo se configure la placa, por lo que deberá permitir introduccir las variables que el usuario considere y trabajar con ellas.
5. Se decide utilizar Visual Studio 2015 como IDE por mejor usabilidad con C++ y Windows Form.
### 15 de Noviembre de 2018
Durante la tercera reunión se estuvo revisando los avances hechos hasta el momento, teniendo en cuenta las razones por las que cambiar a C# y Visual Studio 2017 y marcando las pautas a seguir hasta la siguiente reunión. Los siguientes pasos que se llevarían a cabo son:
1. Finalización de las interfaces en desarrollo.
2. Escritura y lectura de un archivo con la configuración.
3. Validaciones tanto antes de la escritura como en la lectura.
4. Estudio de posibilidades de BBDD y adición al proyecto.
5. Estudio de librerías para dibujar gráficas y adición al proyecto.
6. Posibilidad de añadir variables PDI.
### 4 de Diciembre de 2018
En la cuarta reunión se ha expuesto el trabajo realizado hasta el momento y los tutores han comentado ciertas carencias que tenía la aplicación:
1. Limpieza de _proyect al guardar nueva fila en la BD.
2. Adición de una nueva columna a la BD con el tiempo que devuelve la placa.
3. Cambiar la configuración del tamaño del buffer del puerto serie, tanto de lectura como de escritura.
4. El botón "Gráfico" muestra una ventana en el que se seleccionan las variables que se quieren mostrar graficadas y abre tantas ventanas como variables seleccionadas.
5. Pasar SonarQube.
6. Botón "Archivo" guarda en un archivo de texto las variables seleccionadas previamente.
### 13 de Diciembre de 2018
En la quinta reunión se ha mostrado una primera versión de la aplicación (pre-release) y se han definido los siguientes pasos a llevar a cabo:
1. La cantidad de datos mostrados en la gráfica debe poder ser definible por el usuario.
2. Al pulsar el botón "Archivo", la aplicación guardará los valores de las variables seleccionadas en un archivo, incluyendo en este como cabecera los datos del proyecto (Nombre, Descripción, Fecha).
3. Investigar acerca de los ficheros de ayuda (fichero de ayuda .chm) y su implementación en windows forms.
4. Las gráficas deben mostrar unidades en los ejes.
5. Funcionalidad del botón "Variables": mostrará un listado con todas las variables (lectura y lectura/escritura).
6. Modificar configuración: cargará los datos de la configuración actual pudiendo modificar los mismos, pero no agregar nuevas variables.
### 20 de Diciembre de 2018
Reunión con Carlos López Nozal y Daniel Sarabia (las anteriores habían sido sin Carlos):
1. Uso de la herramienta Codacy, resolver errores.
2. Gestionar excepciones, archivo log.
3. Manual de usuario.
4. Memoria en Latex.
5. Controlar "Modificar proyecto" con proyecto no cargado; cambios de valores en datagridview dejando el campo en blanco.
6. Contemplar líneas de trabajo futuras:
	- Implementar distintos tipos de comunicación.
	- Una vez que exista una conexión con el puerto serie, sin que hubiera un proyecto cargado, poder ver las variables que se están emitiendo desde la placa.
	- Adición de idiomas.
	- Actualizar valores en la ventana VarSelection cuando se muestran todas las variables y sus valores.
	- Implementar variables PID.
### 15 de Enero de 2019
Reunión con Daniel Sarabia. Se comentaron los errores encontrados en la release V0.1 y se decicidió solventar todos esos errores para la siguiente reunión (.docx adjunto al issue #58).