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
