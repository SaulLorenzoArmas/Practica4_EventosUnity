# Practica4_EventosUnity

En esta práctica se usan los eventos en Unity para comunicar objetos. En diferentes escenas, se puede apreciar cómo un objeto puede notificar a otros, mediante `delegate` y `event`. Además, se usan mecanismos de movimiento, colisiones, recogida de objetos y el uso del Canvas.

## Ejercicio1

En este ejercicio, un cubo se desplaza hasta un cilindro y, al colisionar con él, avisa al resto de objetos mediante un evento. Las esferas de tipo 1 persiguen una esfera verde concreta y las de tipo 2 se mueven hacia el cilindro.

Para conseguir esto, el cilindro actúa como un notificador y las esferas como suscriptores. El cubo  utiliza `Rigidbody.MovePosition` dentro de `FixedUpdate()` para moverse con el motor de físicas. Asimismo, se usa el `Vector3.MoveTowards` que calcula la posición siguiente del cubo hacia el cilindro a una velocidad.

El `Vector3.MoveTowards` es necesario, ya que el `Rigidbody.MovePosition` necesita una posición absoluta y no un desplazamiento relativo.

![alt text](/Imagenes/Ejercicio1_Eventos.gif)

## Ejercicio2

En este ejercicio se sustituyen las figuras geométricas de la escena anterior por modelos humanoides, manteniendo la misma mecánica.

Para simplificarlo, los personajes son hijos de un objeto simple; es decir, en el caso de las esferas, el personaje es hijo de la esfera y se oculta a esta última para que solo se vea el personaje.

![alt text](/Imagenes/Ejercicio2_Eventos.gif)

## Ejercicio3

En este ejercicio se utilizan los humanoides de tipo 1 y tipo 2, junto con escudos de ambos tipos. Dependiendo del tipo de personaje con el que colisiona el cubo, cada grupo recibe un evento distinto y se dirige al escudo correspondiente; al alcanzarlo, el escudo cambia de color.

El notificador utiliza dos eventos diferentes y comprueba la etiqueta del objeto con el que se encuentra para decidir cuál debe lanzar.

El grupo 2 busca todos los escudos con `FindGameObjectsWithTag` y selecciona uno al azar con `Random.Range`. Además, `GetComponentsInChildren<Renderer>()` permite cambiar el color de todos los renders del escudo, de modo que se vea cómo cambia de color al llegar el personaje.


![alt text](/Imagenes/Ejercicio3_Eventos.gif)

## Ejercicio4

Cuando el cubo se acerca al objeto de referencia, los personajes del grupo 1 se teletransportan a un escudo y los del grupo 2 se orientan hacia un objetivo. Al alejarse de nuevo, cada grupo recupera su posición o rotación inicial.

Para orientar a los humanoides del grupo 2, primero se calcula la dirección hacia el objetivo y luego se utiliza `Quaternion.LookRotation` para obtener el ángulo a partir de esa dirección. Esto es porque el MoveRotation de un `Rigidbody` usa cuaterniones.

![alt text](/Imagenes/Ejercicio4_Eventos.gif)

## Ejercicio5

En este ejercicio, el jugador recoge escudos. Para esto, se usan los eventos de trigger y se obtienen puntos diferentes según el tipo de escudo. Al recoger uno, se actualiza la puntuación y el escudo deja de mostrarse.

La puntuación se guarda en la componente  `Datos_personaje`, de modo que los distintos escudos pueden modificar los datos del jugador. 

Para conseguir que los escudos dejen de mostrarse, se desactivan los renders y el componente `Collider`: así el escudo desaparece y deja de colisionar. Otra opción sería desactivar el objeto completo, usando `gameObject.SetActive(false)`.

![alt text](/Imagenes/Ejercicio5_Eventos.gif)

## Ejercicio6

Ahora, la puntuación al recoger escudos se muestra en un Canvas. Cada vez que cambia la cantidad de puntos, el texto de la UI se actualiza.

Para hacerlo se usa un elemento Canvas. Este tiene un campo de texto que se actualiza cada vez que cambia la puntuación. Para hacerlo, se incluye en el script la librería `using TMPro` y creando un objeto de tipo `TextMeshProUGUI`.

![alt text](/Imagenes/Ejercicio6_Eventos.gif)

## Ejercicio7

Cada 100 puntos el jugador recibe una recompensa; en este caso, aumenta la masa de su `Rigidbody` y también su tamaño, mostrándose también en un campo de texto del canvas. Para hacerlo más fácil, ahora los escudos del tipo 2 dan 50 puntos y los del tipo 1 dan 25 puntos.

Para modificar la masa se usa `GetComponent<Rigidbody>().mass` y para modificar el tamaño se usa `transform.localScale`, aumentando la escala con la que se dibuja. 

![alt text](/Imagenes/Ejercicio7_Eventos.gif)

## Ejercicio8

Este ejercicio usa la técnica de recoger escudos en un pequeño laberinto donde el jugador debe recogerlos para conseguir puntos para aumentar de tamaño.

![alt text](/Imagenes/Ejercicio8_Eventos.gif)

## Ejercicio9

El ejercicio 9, es igual que el 3 ya que en este ya se tuvo en cuenta que el cuadrado sea un objeto físico.

![alt text](/Imagenes/Ejercicio9_Eventos.gif)
