# ISC Tracker

**Sistema de gestión y seguimiento de asignaturas de Ingeniería en Sistemas Computacionales**

ISC Tracker es un proyecto académico desarrollado como parte de la asignatura **Programación Web** de la carrera de Ingeniería en Sistemas Computacionales de la Universidad Nacional Autónoma de Honduras (UNAH). Su propósito es facilitar el registro, la organización y la consulta de las asignaturas del plan de estudios, clasificándolas por área académica y estado académico.

## Información académica

| Campo | Descripción |
|---|---|
| **Estudiante** | Johnny Marcel Euceda Gutierrez |
| **Universidad** | Universidad Nacional Autónoma de Honduras (UNAH) |
| **Carrera** | Ingeniería en Sistemas Computacionales |
| **Período académico** | III PAC |
| **Asignatura** | Programación Web |
| **Proyecto** | ISC Tracker |

## Objetivo del proyecto

Desarrollar una aplicación web que permita organizar las asignaturas de la carrera, consultar su información y registrar su estado académico mediante una arquitectura de software organizada por responsabilidades.

El proyecto también busca aplicar los principios y herramientas estudiados durante el desarrollo de la asignatura, incluyendo el diseño de API REST, la separación de capas, la persistencia de datos y el control de versiones.

## Funcionalidades

### Implementadas

- Registro de asignaturas mediante un endpoint HTTP `POST`.
- Consulta de asignaturas registradas mediante un endpoint HTTP `GET`.
- Persistencia de los registros en PostgreSQL.
- Relación de las asignaturas con sus áreas académicas y estados mediante claves foráneas.
- Migraciones de base de datos con Entity Framework Core.
- Documentación de endpoints mediante OpenAPI.

### Planificadas para el desarrollo

- Implementar la actualización y eliminación de asignaturas.
- Incorporar validaciones de negocio y manejo consistente de errores.
- Desarrollar la interfaz web para gestionar y visualizar las asignaturas.
- Mejorar las consultas y respuestas de la API según las necesidades de la aplicación.

> El alcance y el estado de las funcionalidades pueden cambiar conforme avance el desarrollo académico.

## Modelo de datos

El modelo inicial contempla tres entidades principales:

### Asignatura

Representa una asignatura de la carrera.

| Campo | Descripción |
|---|---|
| `Id` | Identificador único |
| `Codigo` | Código de la asignatura |
| `Nombre` | Nombre de la asignatura |
| `UnidadesValorativas` | Cantidad de unidades valorativas |
| `AreaAcademicaId` | Clave foránea del área académica |
| `EstadoAsignaturaId` | Clave foránea del estado académico |

### AreaAcademica

Clasifica las asignaturas según su área de formación dentro de la carrera.

### EstadoAsignatura

Define la situación académica de cada asignatura. Los estados contemplados son:

- **Aprobada**
- **Cursando**
- **Reprobada**
- **Pendiente**

Las relaciones se representan mediante claves foráneas. Los nombres de las áreas y los estados se consultan cuando sea necesario, evitando duplicar esos datos en cada asignatura.

## Arquitectura

El backend está organizado en capas para separar las responsabilidades y facilitar el mantenimiento:

| Proyecto | Responsabilidad |
|---|---|
| `ISCTracker.Domain` | Entidades y modelo central del dominio |
| `ISCTracker.Application` | Interfaces y contratos de las operaciones de la aplicación |
| `ISCTracker.Infrastructure` | Acceso a datos, persistencia y migraciones |
| `ISCTracker.API` | Endpoints HTTP y exposición de la API REST |

La solución aplica una separación de responsabilidades basada en arquitectura por capas, utilizando el patrón Repository y la inyección de dependencias.

## Tecnologías utilizadas

| Tecnología | Uso |
|---|---|
| **C#** | Lenguaje de programación del backend |
| **.NET 10** | Plataforma de desarrollo |
| **ASP.NET Core Web API** | Construcción de la API REST |
| **Entity Framework Core** | Acceso a datos y migraciones |
| **PostgreSQL 16** | Sistema de gestión de bases de datos |
| **Docker Compose** | Configuración del entorno de infraestructura |
| **OpenAPI** | Descripción y documentación de la API |
| **Git y GitHub** | Control de versiones y alojamiento del código |

## Estructura del repositorio

```text
ISC-Tracker/
├── backend/
│   ├── ISCTracker.Domain/
│   ├── ISCTracker.Application/
│   ├── ISCTracker.Infrastructure/
│   ├── ISCTracker.API/
│   └── dotnet-tools.json
├── frontend/
├── infra/
│   └── docker-compose.yml
└── README.md
```

La carpeta `backend` contiene la solución .NET y sus capas. `frontend` está destinada a la interfaz web, mientras que `infra` contiene la configuración de infraestructura del proyecto.

## Endpoints disponibles

La API de asignaturas utiliza la ruta base `/api/Asignaturas`.

| Método HTTP | Endpoint | Descripción |
|---|---|---|
| `GET` | `/api/Asignaturas` | Consulta las asignaturas registradas |
| `POST` | `/api/Asignaturas` | Registra una nueva asignatura |

### Ejemplo de registro

Solicitud `POST /api/Asignaturas`:

```json
{
  "codigo": "ISC-102",
  "nombre": "Fundamentos de Programacion",
  "unidadesValorativas": 4,
  "areaAcademicaId": 7,
  "estadoAsignaturaId": 4
}
```

Los identificadores del área académica y del estado deben corresponder a registros existentes en la base de datos.

## Ejecución local

### Requisitos previos

- .NET SDK 10.
- Docker Desktop.
- Git.
- Un cliente HTTP o el navegador para consultar los endpoints.

### 1. Clonar el repositorio

```bash
git clone https://github.com/JohnnyEuceda/ISC-Tracker.git
cd ISC-Tracker
```

### 2. Iniciar la infraestructura

Desde la raíz del repositorio:

```bash
docker compose -f infra/docker-compose.yml up -d
```

La configuración de conexión debe corresponder a los valores definidos para el entorno local. No se deben publicar contraseñas ni otros secretos en el repositorio.

### 3. Ejecutar la API

```bash
dotnet run --project backend/ISCTracker.API/ISCTracker.API.csproj
```

La dirección local depende de la configuración de inicio de ASP.NET Core. En el entorno de desarrollo utilizado actualmente, la API está disponible en:

`http://localhost:5218`

### 4. Consultar las asignaturas

```http
GET http://localhost:5218/api/Asignaturas
```

Para registrar una asignatura, se utiliza el endpoint `POST /api/Asignaturas` con un cuerpo JSON que contenga sus datos.

## Control de versiones

El código fuente se administra mediante Git y se publica en GitHub.

**Repositorio:** [github.com/JohnnyEuceda/ISC-Tracker](https://github.com/JohnnyEuceda/ISC-Tracker)

## Propósito académico

ISC Tracker constituye un ejercicio práctico para aplicar los conocimientos adquiridos durante el III PAC de la carrera de Ingeniería en Sistemas Computacionales de la UNAH. El proyecto se desarrolla progresivamente, documentando las decisiones técnicas y las funcionalidades implementadas durante el proceso de aprendizaje.

---

**Autor:** Johnny Marcel Euceda Gutierrez  
**Universidad:** Universidad Nacional Autónoma de Honduras (UNAH)  
**Carrera:** Ingeniería en Sistemas Computacionales  
**Período académico:** III PAC  
**Asignatura:** Programación Web
