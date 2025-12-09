# Kahoot Quiz: Docker y Docker Compose

---

## Pregunta 1
¿Qué es un contenedor Docker?

Máquina virtual completa
Entorno aislado portátil
Servidor físico dedicado
Base de datos en memoria

**Correcta: Entorno aislado portátil**

> 💡 Un contenedor es un entorno aislado que empaqueta una aplicación con todas sus dependencias. A diferencia de una VM, comparte el kernel del sistema operativo, haciéndolo ligero y portátil entre diferentes máquinas.

---

## Pregunta 2
¿Qué archivo define cómo construir una imagen Docker?

docker-compose.yml
Dockerfile
appsettings.json
package.json

**Correcta: Dockerfile**

> 💡 El Dockerfile contiene las instrucciones paso a paso (FROM, COPY, RUN, etc.) para construir una imagen. Es como una "receta" que Docker sigue para crear la imagen.

---

## Pregunta 3
¿Qué comando construye una imagen Docker?

docker run
docker build
docker create
docker start

**Correcta: docker build**

> 💡 `docker build` lee el Dockerfile y ejecuta cada instrucción para crear una imagen. Ejemplo: `docker build -t mi-app .` construye la imagen con el tag "mi-app".

---

## Pregunta 4
¿Qué comando ejecuta un contenedor desde una imagen?

docker build
docker start
docker run
docker exec

**Correcta: docker run**

> 💡 `docker run` crea y arranca un nuevo contenedor a partir de una imagen. `docker start` solo arranca un contenedor existente que está parado.

---

## Pregunta 5
¿Qué ventaja tiene Docker sobre máquinas virtuales?

Más seguridad integrada
Menor consumo recursos
Mejor interfaz gráfica
Mayor almacenamiento

**Correcta: Menor consumo recursos**

> 💡 Los contenedores comparten el kernel del SO host, mientras que las VMs necesitan un SO completo cada una. Esto hace que los contenedores usen mucha menos RAM y disco, y arranquen en segundos.

---

## Pregunta 6
¿Qué es una imagen Docker?

Contenedor ejecutándose
Plantilla para contenedor
Archivo de configuración
Máquina virtual ligera

**Correcta: Plantilla para contenedor**

> 💡 Una imagen es una plantilla inmutable (solo lectura) que contiene el SO base, código y dependencias. Cuando ejecutas una imagen, se crea un contenedor (instancia ejecutable de esa imagen).

---

## Pregunta 7
¿Dónde se almacenan las imágenes Docker públicas?

En GitHub packages
En Docker Hub
En npm registry
En NuGet gallery

**Correcta: En Docker Hub**

> 💡 Docker Hub es el registro público oficial de Docker. Contiene imágenes oficiales (nginx, postgres, node, etc.) y permite subir tus propias imágenes para compartirlas.

---

## Pregunta 8
¿Qué comando lista los contenedores en ejecución?

docker images
docker ps
docker list
docker show

**Correcta: docker ps**

> 💡 `docker ps` muestra los contenedores activos. "ps" viene de "process status" en Linux. `docker images` lista las imágenes descargadas, no los contenedores.

---

## Pregunta 9
¿Qué hace "docker ps -a"?

Muestra solo activos
Muestra todos contenedores
Elimina los parados
Reinicia todos ellos

**Correcta: Muestra todos contenedores**

> 💡 El flag `-a` (all) muestra TODOS los contenedores, incluyendo los que están parados. Sin este flag, solo ves los que están corriendo actualmente.

---

## Pregunta 10
¿Qué instrucción en Dockerfile copia archivos al contenedor?

RUN
COPY
CMD
MOVE

**Correcta: COPY**

> 💡 `COPY` copia archivos desde tu máquina local al sistema de archivos de la imagen. Ejemplo: `COPY . /app` copia todo el directorio actual a /app en el contenedor.

---

## Pregunta 11
¿Qué instrucción ejecuta comandos durante el build?

COPY
CMD
RUN
EXEC

**Correcta: RUN**

> 💡 `RUN` ejecuta comandos durante la construcción de la imagen (build time). Se usa para instalar dependencias: `RUN npm install` o `RUN dotnet restore`.

---

## Pregunta 12
¿Qué diferencia hay entre CMD y ENTRYPOINT?

Son exactamente iguales
CMD se sobrescribe fácil
ENTRYPOINT está obsoleto
CMD ejecuta más rápido

**Correcta: CMD se sobrescribe fácil**

> 💡 `CMD` define el comando por defecto pero se puede reemplazar al hacer `docker run imagen otro-comando`. `ENTRYPOINT` es más fijo: los argumentos se añaden al final en vez de reemplazarlo.

---

## Pregunta 13
¿Para qué sirve EXPOSE en un Dockerfile?

Abre puerto automático
Documenta puerto usado
Bloquea otros puertos
Configura el firewall

**Correcta: Documenta puerto usado**

> 💡 `EXPOSE` solo documenta qué puerto usa la aplicación. NO abre el puerto automáticamente. Para exponer el puerto real, debes usar `-p` al ejecutar: `docker run -p 8080:80`.

---

## Pregunta 14
¿Cómo se persisten datos en Docker?

No es posible hacerlo
Usando volúmenes
Solo con Compose
Con imágenes grandes

**Correcta: Usando volúmenes**

> 💡 Los contenedores son efímeros: al eliminarlos, sus datos se pierden. Los volúmenes (`-v`) guardan datos fuera del contenedor, permitiendo persistencia aunque el contenedor se elimine.

---

## Pregunta 15
¿Qué beneficio aporta el multi-stage build?

Más seguridad total
Imágenes más pequeñas
Compilación más lenta
Mayor compatibilidad

**Correcta: Imágenes más pequeñas**

> 💡 Multi-stage permite usar una imagen grande para compilar (con SDK) y luego copiar solo los archivos finales a una imagen pequeña (runtime). Así la imagen final es mucho más ligera.

---

## Pregunta 16
¿Para qué sirve Docker Compose?

Solo crear imágenes
Orquestar contenedores
Monitorear el sistema
Hacer backups auto

**Correcta: Orquestar contenedores**

> 💡 Docker Compose permite definir y ejecutar múltiples contenedores como un sistema. En un solo archivo YAML defines tu app, base de datos, cache, etc., y los levantas todos juntos.

---

## Pregunta 17
¿Qué comando levanta servicios en Docker Compose?

docker compose up
docker run --all
docker start all
docker build all

**Correcta: docker compose up**

> 💡 `docker compose up` lee el archivo docker-compose.yml, descarga las imágenes necesarias, crea los contenedores, la red, y arranca todo. Es el comando principal de Compose.

---

## Pregunta 18
¿Qué hace el flag -d en "docker compose up -d"?

Descarga las imágenes
Ejecuta en background
Activa modo de debug
Elimina contenedores

**Correcta: Ejecuta en background**

> 💡 El flag `-d` (detached) ejecuta los contenedores en segundo plano, liberando la terminal. Sin él, los logs se muestran en la terminal y al cerrarla se paran los contenedores.

---

## Pregunta 19
¿Cómo se comunican servicios en Docker Compose?

Solo por dirección IP
Por nombre servicio
No pueden comunicarse
Solo por localhost

**Correcta: Por nombre servicio**

> 💡 Docker Compose crea una red automáticamente donde cada servicio es accesible por su nombre. Si tu servicio se llama "db", otros pueden conectarse usando "db" como hostname.

---

## Pregunta 20
¿Qué hace "docker compose down"?

Solo para servicios
Detiene y elimina todo
Hace backup de datos
Actualiza las imágenes

**Correcta: Detiene y elimina todo**

> 💡 `docker compose down` detiene todos los contenedores, los elimina, y también elimina las redes creadas. Con `--volumes` también elimina los volúmenes. Es el opuesto de `up`.

---

## Resumen de Respuestas

1. Entorno aislado portátil
2. Dockerfile
3. docker build
4. docker run
5. Menor consumo recursos
6. Plantilla para contenedor
7. En Docker Hub
8. docker ps
9. Muestra todos contenedores
10. COPY
11. RUN
12. CMD se sobrescribe fácil
13. Documenta puerto usado
14. Usando volúmenes
15. Imágenes más pequeñas
16. Orquestar contenedores
17. docker compose up
18. Ejecuta en background
19. Por nombre servicio
20. Detiene y elimina todo
