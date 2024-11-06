Esta es la implementación básica del sistema de rayos para interactuar con el entorno (objetos y demás).

Para incluir en el proyecto base:
1. Incluir todos los scripts del paquete en una carpeta
2. Resolver incompatibilidades de nombres de dependencias (si hubiese)
3. Incluir SistemaPersonaje en el prefab del personaje en caso de que no exista ese script o similar. Si existe, complementar con el que incluye el paquete, es decir, actualizarlo para que requiera Gravedad, Controles y Apuntado.
4. Añadir el script InteraccionEjemplo a aquellos prefabs u objetos con los que se quiera hacer las pruebas de interacción. En estos, marca las propiedades que le quieras dar, como TRANSPARENTE, INTERACTUABLE o ATRAVIESA TRANSPARENTES