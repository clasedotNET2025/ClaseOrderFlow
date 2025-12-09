# Kahoot Quiz: Git - Comandos y Estados

---

## Pregunta 1
¿Cuáles son las tres áreas principales de Git en local?

Working, Staging, Remote
Working, Staging, Repository
Local, Remote, Cloud
Files, Commits, Branches

**Correcta: Working, Staging, Repository**

> 💡 Git tiene 3 áreas locales: **Working Directory** (donde editas archivos), **Staging Area** (donde preparas cambios con `git add`), y **Repository** (donde se guardan los commits). Remote es el servidor externo, no es local.

---

## Pregunta 2
¿Qué comando inicializa un repositorio Git vacío?

git start
git init
git create
git new

**Correcta: git init**

> 💡 `git init` crea la carpeta oculta `.git` que contiene toda la base de datos de Git. Es el primer paso para empezar a versionar un proyecto existente.

---

## Pregunta 3
¿En qué estado están los archivos modificados sin agregar?

Staged
Committed
Unstaged / Modified
Remote

**Correcta: Unstaged / Modified**

> 💡 Cuando modificas un archivo pero no has hecho `git add`, está en estado "modified" o "unstaged". Git lo detecta como cambiado pero no lo incluirá en el próximo commit.

---

## Pregunta 4
¿Qué comando mueve archivos al Staging Area?

git commit
git add
git stage
git move

**Correcta: git add**

> 💡 `git add archivo.txt` mueve los cambios al Staging Area, preparándolos para el commit. Es como poner cosas en una caja antes de enviarla.

---

## Pregunta 5
¿Qué hace "git add ." (con punto)?

Agrega solo un archivo
Agrega todos cambios
Elimina los archivos
Crea commit vacío

**Correcta: Agrega todos cambios**

> 💡 El punto `.` representa el directorio actual. `git add .` agrega TODOS los archivos modificados y nuevos del directorio actual y subdirectorios al Staging Area.

---

## Pregunta 6
¿Qué comando guarda cambios en el repositorio local?

git save
git push
git commit
git store

**Correcta: git commit**

> 💡 `git commit -m "mensaje"` toma todo lo que está en Staging y lo guarda como una "foto" permanente en tu repositorio local. Cada commit tiene un ID único (hash).

---

## Pregunta 7
¿Dónde están los cambios después de hacer commit?

Solo en Staging
En repositorio local
Ya en el remoto
En Working Directory

**Correcta: En repositorio local**

> 💡 Después de `commit`, los cambios están guardados SOLO en tu máquina (repositorio local). Para que otros los vean, necesitas hacer `push` al remoto.

---

## Pregunta 8
¿Qué comando envía commits al repositorio remoto?

git send
git upload
git push
git sync

**Correcta: git push**

> 💡 `git push origin main` envía tus commits locales al servidor remoto (GitHub, GitLab, etc.). Solo después del push, otros desarrolladores pueden ver tus cambios.

---

## Pregunta 9
¿Qué comando descarga y fusiona cambios del remoto?

git download
git pull
git get
git fetch

**Correcta: git pull**

> 💡 `git pull` hace dos cosas: descarga los cambios del remoto (`fetch`) y los fusiona (`merge`) con tu rama actual. Es la forma rápida de actualizar tu código local.

---

## Pregunta 10
¿Cuál es la diferencia entre fetch y pull?

Son exactamente iguales
Fetch solo descarga
Pull es más seguro
Fetch está obsoleto

**Correcta: Fetch solo descarga**

> 💡 `git fetch` solo descarga los cambios pero NO los aplica a tu código. `git pull` = `fetch` + `merge`. Fetch es más seguro porque puedes revisar los cambios antes de fusionar.

---

## Pregunta 11
¿Qué comando muestra el estado actual de archivos?

git show
git status
git info
git state

**Correcta: git status**

> 💡 `git status` muestra qué archivos están modificados, cuáles están en staging, y cuáles no están siendo rastreados. Es el comando más usado para saber "en qué estado estoy".

---

## Pregunta 12
¿Qué comando muestra el historial de commits?

git history
git log
git commits
git show-all

**Correcta: git log**

> 💡 `git log` muestra la lista de commits con su hash, autor, fecha y mensaje. `git log --oneline` muestra una versión compacta, más fácil de leer.

---

## Pregunta 13
¿Qué comando crea una nueva rama?

git branch nombre
git new-branch
git create branch
git rama nueva

**Correcta: git branch nombre**

> 💡 `git branch feature-login` crea una nueva rama, pero NO te cambia a ella. La rama es como una línea paralela de desarrollo independiente.

---

## Pregunta 14
¿Qué hace "git checkout -b nombre"?

Solo crea la rama
Crea y cambia a rama
Elimina la rama
Renombra rama actual

**Correcta: Crea y cambia a rama**

> 💡 El flag `-b` hace que `checkout` cree la rama Y te mueva a ella en un solo comando. Equivale a: `git branch nombre` + `git checkout nombre`. También puedes usar `git switch -c nombre`.

---

## Pregunta 15
¿Qué comando une una rama con la actual?

git join
git merge
git combine
git unite

**Correcta: git merge**

> 💡 `git merge feature-login` trae los commits de "feature-login" a tu rama actual. Si estás en `main`, los cambios de la feature se integran en main.

---

## Pregunta 16
¿Qué es un conflicto de merge en Git?

Un error del sistema
Cambios incompatibles
Rama eliminada
Commit duplicado

**Correcta: Cambios incompatibles**

> 💡 Un conflicto ocurre cuando dos ramas modificaron las MISMAS líneas de un archivo. Git no sabe cuál versión elegir, así que te pide que lo resuelvas manualmente.

---

## Pregunta 17
¿Qué archivo indica a Git qué archivos ignorar?

.gitconfig
.gitignore
.gitexclude
ignore.txt

**Correcta: .gitignore**

> 💡 El archivo `.gitignore` lista patrones de archivos que Git debe ignorar: `node_modules/`, `*.log`, `.env`, etc. Estos archivos no se subirán al repositorio.

---

## Pregunta 18
¿Qué es HEAD en Git?

El primer commit
Puntero commit actual
La rama principal
Repositorio remoto

**Correcta: Puntero commit actual**

> 💡 HEAD es un puntero que indica "dónde estás ahora" en el historial. Normalmente apunta a la rama actual, y esa rama apunta al último commit. Si haces checkout a un commit específico, HEAD apunta directamente ahí.

---

## Pregunta 19
¿Qué representa "origin" normalmente en Git?

La rama principal
Alias repo remoto
El primer commit
Tu nombre usuario

**Correcta: Alias repo remoto**

> 💡 "origin" es el nombre por defecto que Git da al repositorio remoto cuando haces `clone`. Es un alias para la URL completa. Puedes tener varios remotos con diferentes nombres.

---

## Pregunta 20
¿En qué orden fluyen los cambios al hacer push?

Working → Remote
Working → Stage → Local → Remote
Stage → Working → Remote
Remote → Local → Working

**Correcta: Working → Stage → Local → Remote**

> 💡 El flujo completo es: 1) Editas archivos (Working), 2) `git add` los mueve a Staging, 3) `git commit` los guarda en Local, 4) `git push` los envía al Remote. ¡Cuatro pasos!

---

## Resumen de Respuestas

1. Working, Staging, Repository
2. git init
3. Unstaged / Modified
4. git add
5. Agrega todos cambios
6. git commit
7. En repositorio local
8. git push
9. git pull
10. Fetch solo descarga
11. git status
12. git log
13. git branch nombre
14. Crea y cambia a rama
15. git merge
16. Cambios incompatibles
17. .gitignore
18. Puntero commit actual
19. Alias repo remoto
20. Working → Stage → Local → Remote
