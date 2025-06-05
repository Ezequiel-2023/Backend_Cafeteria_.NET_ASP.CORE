
### App Cafetería Backend

### 📜 PARA VER LA DOCUMENTACION DEL PROYECTO 
## DIAGRAMAS
```sh
carpeta: doc\UML\
```
para visualizar los diagramas preciona

``` sh
Preview Diagram, Press Alt + D 
```
debes tener la extencion de PlantUML

## 📜 DOCUMENTACION EN PDF 
```sh
carpeta: doc\PDF\
```

### Configuración de Base de Datos y Migraciones

# 🚀 Configuración de Base de Datos y Migraciones en ASP.NET Core con MySQL

Este documento contiene los comandos esenciales para gestionar la base de datos y las migraciones en **Entity Framework Core** con **MySQL**.

## 📌 Instalación de Paquetes Necesarios
Antes de comenzar, asegúrate de instalar los paquetes necesarios:

```sh
dotnet add package MySql.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

### ⚙️ Configuración de la Cadena de Conexión
genera manualmente  el archivo appsettings.json, o modifica la cadena de conexión agregando esta parte y colocando tus credenciales  :

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "TodoContext": "Server=<local:?>;Database=<nameDB>;User=<user>;Password=<password>;TreatTinyAsBoolean=true"
}
}

```

### 🔄 Comandos para Migraciones
Cada vez que modifiques la estructura de la base de datos (agregar nuevas tablas, modificar columnas, etc.), ejecuta los siguientes comandos:

## ✨ Crear una nueva migración
```sh
dotnet ef migrations add NombreDeLaMigracion
```
# Ejemplo 
```sh
dotnet ef migrations add AgregarTablaUsuarios
```

### 🚀 Aplicar los cambios a la base de datos
```sh 
dotnet ef database update
```

### ❌ Eliminar la última migración (si es necesario)
Si cometiste un error y necesitas eliminar la última migración:

```sh 
dotnet ef migrations remove
📜 Ver lista de migraciones aplicadas
```
```sh 
dotnet ef migrations list
```
### 🛠️ Creación de la Base de Datos desde Cero
Si necesitas eliminar y recrear la base de datos desde cero:

```sh 
dotnet ef database drop
dotnet ef database update
```

### ⚡ Uso de Postman para Insertar Datos
Puedes insertar datos en tu tabla desde Postman utilizando una solicitud POST:
```sh 
URL: http://localhost:5000/api/usuarios
```

### Body (JSON):
```sh 
json
{
  "nombre": "Juan Pérez",
  "email": "juan@example.com",
  "contraseña": "123456"
}
```

### 📝 Recomendaciones
Siempre ejecuta dotnet ef migrations add cada vez que agregues nuevas tablas.
Mantén las migraciones organizadas con nombres descriptivos.
Verifica las conexiones antes de actualizar la base de datos.

