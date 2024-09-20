# Wayni - Prueba técnica

Este proyecto es una aplicación web desarrollada en ASP\.NET Core que permite la gestión de usuarios\. A continuación, se detallan los pasos necesarios para configurar y ejecutar el proyecto\.

## Requisitos

\- \.NET 6\.0 SDK o superior
\- SQL Server
\- Visual Studio 2022 o JetBrains Rider 2024\.2\.4

## Configuración del Proyecto

### Paso 1: Clonar el Repositorio

Clona el repositorio en tu máquina local usando el siguiente comando:

```bash
git clone https://github.com/fdaniel13s/wayni-prueba.git
```

### Paso 2: Configurar la Base de Datos

Crea una base de datos en SQL Server y actualiza la cadena de conexión en el archivo `appsettings\.json` del proyecto `Wayni\.Prueba\.Web`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=wayni-prueba;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

### Paso 3: Aplicar Migraciones

Abre una terminal en la carpeta del proyecto `Wayni\.Prueba\.Web` y ejecuta el siguiente comando para aplicar las migraciones a la base de datos:

```bash

dotnet ef database update
```

### Paso 4: Ejecutar el Proyecto

Abre el proyecto en Visual Studio 2022 o JetBrains Rider 2024\.2\.4 y ejecútalo\.
Estará disponible en la URL `https://localhost:5001` o `http://localhost:5000`\.


