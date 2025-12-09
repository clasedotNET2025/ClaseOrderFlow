# Kahoot Quiz: Microservicios, Mensajería y Notificaciones

---

## Pregunta 1
¿Por qué usamos un Message Broker en vez de llamadas HTTP directas entre servicios?

Es más rápido siempre
Desacopla los servicios
Usa menos memoria RAM
Es más fácil de debug

**Correcta: Desacopla los servicios**

---

## Pregunta 2
¿Qué pasa si el servicio de Notificaciones está caído cuando se registra un usuario?

Se pierde el mensaje
El mensaje espera en cola
Falla el registro usuario
Se envía por HTTP direct

**Correcta: El mensaje espera en cola**

---

## Pregunta 3
¿Por qué el servicio Identity NO debe enviar emails directamente?

No tiene los permisos
Viola responsabilidad única
Es más lento hacerlo
No puede usar el SMTP

**Correcta: Viola responsabilidad única**

---

## Pregunta 4
¿Qué patrón de comunicación usamos entre Identity y Notifications?

Request-Response sync
Publicar-Suscribir async
Llamada HTTP directa
Base de datos compartida

**Correcta: Publicar-Suscribir async**

---

## Pregunta 5
¿Qué ventaja tiene que Notifications sea un servicio separado?

Usa menos recursos
Escala de forma independiente
Es más rápido
Tiene más seguridad

**Correcta: Escala de forma independiente**

---

## Pregunta 6
¿Por qué definimos eventos en un proyecto Shared entre servicios?

Para ahorrar código
Es el contrato entre ellos
Por convención solamente
Para compilar más rápido

**Correcta: Es el contrato entre ellos**

---

## Pregunta 7
¿Qué representa un Evento en arquitectura de microservicios?

Una petición de datos
Algo que ya ocurrió
Un comando a ejecutar
Una respuesta del API

**Correcta: Algo que ya ocurrió**

---

## Pregunta 8
¿Por qué el evento se llama UserCreatedEvent y no CreateUserCommand?

Es solo una convención
Describe un hecho pasado
Es más corto el nombre
Por el framework usado

**Correcta: Describe un hecho pasado**

---

## Pregunta 9
¿Qué sucede si agregamos un servicio de Analytics que necesita saber de nuevos usuarios?

Hay que modificar Identity
Solo suscribirse al evento
Crear un nuevo endpoint
Duplicar la base de datos

**Correcta: Solo suscribirse al evento**

---

## Pregunta 10
¿Por qué configuramos reintentos en el Consumer de mensajes?

Para ir más rápido
Para tolerar fallos temp
Por requisito del broker
Para usar menos memoria

**Correcta: Para tolerar fallos temp**

---

## Pregunta 11
¿Qué problema resuelve usar un EventId único en cada evento?

Mejora el rendimiento
Evita procesar duplicados
Ordena los mensajes
Reduce tamaño mensaje

**Correcta: Evita procesar duplicados**

---

## Pregunta 12
¿Por qué incluimos CreatedAt en los eventos?

Por requisito técnico
Auditoría y ordenamiento
El broker lo necesita
Para los logs solamente

**Correcta: Auditoría y ordenamiento**

---

## Pregunta 13
¿Qué pasa si Notifications procesa el mismo evento dos veces?

No tiene importancia
Usuario recibe dos emails
El sistema se cae
RabbitMQ lo evita solo

**Correcta: Usuario recibe dos emails**

---

## Pregunta 14
¿Por qué el Consumer debe ser idempotente idealmente?

Por mejor rendimiento
Mismo resultado si repite
Requisito de RabbitMQ
Para usar menos RAM

**Correcta: Mismo resultado si repite**

---

## Pregunta 15
¿Qué tipo de comunicación es publicar un evento a RabbitMQ?

Síncrona y bloqueante
Asíncrona no bloqueante
Semi-síncrona mixta
Directa punto a punto

**Correcta: Asíncrona no bloqueante**

---

## Pregunta 16
¿Por qué Identity no espera confirmación de que el email se envió?

No es posible técnico
Son procesos independientes
RabbitMQ no lo permite
Sería muy inseguro

**Correcta: Son procesos independientes**

---

## Pregunta 17
¿Qué pasaría si usáramos la misma base de datos para Identity y Notifications?

Sería más eficiente
Genera acoplamiento fuerte
Tendría mejor rendimiento
Sería más fácil mantener

**Correcta: Genera acoplamiento fuerte**

---

## Pregunta 18
¿Por qué cada microservicio debe tener su propia base de datos?

Por seguridad solamente
Autonomía y desacoplamiento
Para ahorrar costos
Es más rápido así

**Correcta: Autonomía y desacoplamiento**

---

## Pregunta 19
¿Qué rol cumple el API Gateway en la arquitectura?

Almacena todos los datos
Es punto de entrada único
Procesa los mensajes
Envía las notificaciones

**Correcta: Es punto de entrada único**

---

## Pregunta 20
¿Por qué usamos un servidor SMTP de desarrollo como MailDev?

Es más rápido enviar
No envía emails reales
Es requisito de .NET
Cuesta menos dinero

**Correcta: No envía emails reales**

---

## Resumen de Respuestas

1. Desacopla los servicios
2. El mensaje espera en cola
3. Viola responsabilidad única
4. Publicar-Suscribir async
5. Escala de forma independiente
6. Es el contrato entre ellos
7. Algo que ya ocurrió
8. Describe un hecho pasado
9. Solo suscribirse al evento
10. Para tolerar fallos temp
11. Evita procesar duplicados
12. Auditoría y ordenamiento
13. Usuario recibe dos emails
14. Mismo resultado si repite
15. Asíncrona no bloqueante
16. Son procesos independientes
17. Genera acoplamiento fuerte
18. Autonomía y desacoplamiento
19. Es punto de entrada único
20. No envía emails reales
