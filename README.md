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

# Terrenos
**Nota:** El agua subterranea tiene una probabilidad de existir en un tile, pero se extiende a lo largo de varios tiles, dependiendo de un porcentaje de cantidad
## Ordenados por profundidad
* **Aguas profundas:** No es accesible (solo con bote), se puede pescar, peses grandes
* **Aguas bajas:** Se puede pasar y ademas construir puentes, no se puede pescar
* **Playa:** Se pueden conseguir rocas y piedras
* **Zona fertil:** La fertilidad deberia variar segun los vecinos y bioma
* **Zona poco fertil:** alejada de aguas
* **Zona no fertil:** Cerca de zonas montañosas
* **Zona Montañosa:**

### Aguas Profundas
* **Desplazamiento:** No se puede transitar, Accesible solo con bote
* **Recursos:** Peses, Agua
* **Peso:** __(si refinar)__ 25 __(compartido con aguas bajas)__
* **Especial:** Si es mar, no se puede tomar (tendria que ver cuando viene de mar)

### Aguas Bajas
* **Desplazamiento:** 30%
* **Recursos:** Peses, Agua
* **Peso:** __(si refinar)__ 25 __(compartido con aguas profundas)__
* **Especial:** Si es mar, no se puede tomar (tendria que ver cuando viene de mar)

### Playa
* **Desplazamiento:** 70%
* **Recursos:** Roca, Piedras
* **Fertilidad:** 10%
* **Peso:** __(si refinar)__ 5
* **Especial:** Solo cuando viene de mar (tendria que ver cuando viene de mar)

### Lago
* **Desplazamiento:** 30%
* **Recursos:** Peces (Menos que en el mar), Agua
* **Peso:** Todavia no se

### Cienaga
* **Desplazamiento:** 30%
* **Recursos:** Probabilidad de agua subterranea muy alta __(Habria que calularlo)__
* **Peso:** Todavia no se

### Zona Humeda
* **Donde**: Cerca de Cienaga
* **Desplazamiento:** 80%
* **Fertilidad:** 100%
* **Recursos**: Arboles, Hiervas (para heno, fibras), Probabilidad de agua subterranea alta __(Habria que calularlo)__
* **Peso**: Todavia no se

### Zona Fertil
* **Fertilidad:** 100%
* **Desplazamiento:** 87%
* **Recursos**: Arboles, Arbustos de todo tipo (para fibras, palos, frutos), Probabilidad de agua subterranea poca __(Habria que calularlo)__
* **Peso**: 25, pero deberia ser al rededor del 50% del total

### Zona Muy fertil
* **Donde**: Si hay agua subterranea
* **Fertilidad:** 140%
* **Desplazamiento:** 87%
* **Recursos**: Mas de todo, Arboles, Arbustos de todo tipo (para fibras, palos, frutos), Probabilidad de agua subterranea poca __(Habria que calularlo)__
* **Peso**: Deberia ser muy poco

### Suelo pedregoso
* **Donde**: Cerca de zonas infertiles, al pie de la montaña
* **Fertilidad:** 70%
* **Desplazamiento:** 87%
* **Recursos**: Arboles, Arbustos (para fibras, palos)
* **Peso**: Deberia ser muy poco

### Ladera
* **Donde**: Al pie de la montaña (como playa para el agua),
* **Fertilidad:** 0%
* **Desplazamiento:** 87%
* **Recursos**: Rocas, piedras
* **Peso**: Como playa
* **Especial**: Con el tiempo y muchas lluvias puede transformarse en Suelo pedregoso

### Montaña
* **Fertilidad:** 0%
* **Desplazamiento:** No se puede transitar
* **Recursos**: Rocas, piedras, Otros metales
* **Peso**: 45 pero deberia ser poco (quizas menos)
* **Especial**: Al excavar se transforma en Ladera
