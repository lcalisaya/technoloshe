README.md

#Proyecto: Aplicación "LosDiasYElClima-App"

##Requisitos del trabajo final:
Realizar una aplicación web (sitio, blog, tienda, juego, etc...) que incluya todos los contenidos vistos en el curso:
- Aplicación Web
- HTML-CSS-JS
- Bootstrap
- MVC C#.NET
- Base de Datos

###Descripción de la Aplicación:
Es una aplicación que cuando se ingresa el nombre de una ciudad, la aplicación devuelve datos del clima actuales y previstos para los siguientes días.
Asimismo, si el/la usuario/a necesita que la aplicación recuerde el clima de una o varias ciudades consultadas, dicha persona puede crear una cuenta que le proveerá de mencionada funcionalidad. Y también podrá acceder a la votación de temas del día, relacionados al cambio climático del medio ambiente.

###Funcionalidades:
####Para el usuario no registrado:
- La aplicación identifica la ubicación del Usuario y retorna nombre de la ciudad y país. Se presentan los datos del clima actual: descripción breve, temperatura (en ºC), viento (m/s), presión(hPa) y humedad (%). A su vez se muestra un ícono en movimiento que resume el estado del clima detallado (Ej: el Sol, las nubes o nubes con lluvia, etc.).
NOTA: Los datos pronosticados abarcan el estado del clima actual y de los siguientes 7 días.
En cuanto a los datos del Sol, se puede conocer el horario de salida y el horario de puesta.
- La app permite ingresar el nombre de una ciudad, con un botón “Buscar”. Si es una ciudad válida, se devuelve el resultado. 
- La aplicación permite presentar la temperatura en escala Celsius (predeterminada) o escala Fahrenheit.
- Existe una página llamada "Acerca", la cual indica los recursos utilizados para este proyecto.
- Existe una página llamada "Registrarse" para que los nuevos usuarios creen una cuenta.
- En la opción "Iniciar sesión", los usuarios se loguean y acceden a su cuenta.

####Para el usuario registrado:
Mismas funcionalidades que el usuario no registrado y se le adicionan las siguientes:
- Una vez encontrada una ciudad/ubicación el usuario puede guardar ese lugar en su lista de ciudades favoritas y acceder en otro momento sin la necesidad de especificar dicha ciudad nuevamente.
- El usuario tiene disponible la lista de ciudades guardadas.
- Cada usuario puede votar/participar una y solo una vez en una encuesta del día. La misma consiste en responder si una pregunta formulada le pareció interesante o no. Por lo general, los temas de las encuestas están relacionados al Medio ambiente.
- El usuario puede administrar sus ciudades: De la lista se pueden remover los lugares que el usuario ya no desee guardar.
- Al haber iniciado sesión también puede ponerse en contacto con el administrador de la aplicación y enviar un mensaje.
- Finalmente, tal como corresponde está la opción de "Cerrar sesión", la cual protege los datos del usuario logueado y así la aplicación vuelve a mostrar las funcionalidades de un usuario no registrado.