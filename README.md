# colony-prototype
Prototipo de juego de Colony Builder

# Necesidades
Son las necesidades de la persona

## Sed
Es un valor entre [-100, 100] y se divide en dos fases
* **[100, 0]:**  Modo normal, el consumo transcurre normalmente a razon de 1 punto cada 7m
* **[0, -100]:**  Modo alerta, el consumo transcurre más lento, a razon de 1 punto cada 42m

### Modo normal
* **LLega a 50:** Tiene sed, cuando termina la tarea que está haciendo toma agua.
* **LLega a 0:** Tiene mucha sed, deja lo que está haciendo y toma agua.

### Modo alerta
* **LLega a -67:** Delirio, entra en modo delirio, solo tomara agua si le dan o si entra en el agua.
* **LLega a -85:** Desmayo, se desmaya, solo toma agua si le dan.
* **Llega a -100:** Muerte, la persona se muere.

## Sueño
Es valor entre [0, 100], se consume en 2 días por lo tanto el valor baja a razon de 30m.
* **Llega a 88:** Solo va a dormir si es hora de dormir
* **Llega a 68:** Si puede se va a dormir
* **Llega a 0:** Se queda dormido 

## Baño
Es valor entre [0, 100], se consume en 12 horas por lo tanto el valor baja a razon de 8m.
* **Llega a 33.33:** Si puede va al baño
* **Llega a 8.33:** Deja lo que tiene que hacer (Si no es muy importante)
* **Llega a 0:** Se mea

# Tiempo y distancias del juego
## Tiempo
El tiempo usa una velocidad de Unity de 1/5 de la velocidad por defecto.

**Por lo tanto las animaciones tienen que tener una velocidad X5 de la velocidad por defecto.**

### Velocidades del Juego:
* Play: 0.2 --> 1s Representa 2.4s en el juego.
* Play2X: 2 --> 1s Representa 24s en el juego.
* Play3X: 20 --> 1s Representa 4m en el juego.
* Play3X: 100 --> 1s Representa 20m en el juego.

## Tamaños
El tamaño del Tile puede representar 1 o 2 metros, pero con respecto a distancias son al rededor de 1.2m

### Calculo de velovidades 
Velocidad de humano: ```1m/s```
Por lo tanto en el juego debe moverse a ```2 Tiles/s``` a la velocidad de Play
