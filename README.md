
# .NET API CRUD with Entity Framework Core and SQL Server

## 1. Setup Scalar Documentation
Scalar es una alternativa moderna y altamente interactiva a Swagger para visualizar y probar tus endpoints en .NET de forma elegante.

```sh
dotnet add package Scalar.AspNetCore
```

### Initialize in Program.cs
Para habilitar Scalar, registra el soporte de OpenAPI y mapea la interfaz en el pipeline de la aplicación:

```csharp
// Program.cs
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(); // Accede vía /scalar/v1 por defecto
}
``

> [!NOTE]
> Scalar utiliza la especificación OpenAPI generada dinámicamente por .NET para renderizar la documentación interactiva.

## 2. Install Entity Framework Core & SQL Server
Para manejar la persistencia de datos y el mapeo objeto-relacional (ORM), instalamos las dependencias oficiales de Microsoft y las herramientas de diseño necesarias.

```sh
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

### Global EF Tool
Para ejecutar comandos de base de datos y migraciones desde la terminal, es obligatorio tener instalada la herramienta global de Entity Framework:

```sh
dotnet tool install --global dotnet-ef
```

> [!IMPORTANT]
> Si ya tienes instalada la herramienta y recibes errores de versión, puedes actualizarla con: dotnet tool update --global dotnet-ef.

## 3. Database Migrations
Las migraciones permiten que el esquema de la base de datos evolucione junto con tu código C# de forma versionada y segura.

### Create a Migration
Este comando analiza tus modelos y genera el código C# necesario para reflejar los cambios en las tablas:

```sh
dotnet ef migrations add MigrationName
```

### Update Database
Aplica físicamente las instrucciones generadas en la migración hacia el servidor de SQL Server configurado:

```sh
dotnet ef database update
```

> [!TIP]
> Si cometiste un error en la última migración generada y aún no has actualizado la base de datos, puedes borrarla con: dotnet ef migrations remove.

## 4. Understanding AppSettings.json
El archivo appsettings.json es el centro de configuración del proyecto, cumpliendo un rol similar al .env en Node.js para almacenar cadenas de conexión y parámetros globales.

Connection String Example
Configura tu acceso a base de datos dentro de la sección ConnectionStrings:

```JSON
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=MyApiDb;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

> [!WARNING]
> Por seguridad, nunca incluyas contraseñas reales en este archivo si el repositorio es público. En producción, utiliza Variables de Entorno.

## 5. Identity Management.
Para administrar identidades, es decir, tener la lógica necesaria para registrar usuarios, asignar roles y generar tokens que permitan adicionarle seguridad a nuestros endpoints se debe tener en cuenta que .Net cuenta con un paquete que ya tiene mucha de esta lógica integrada. Para instalarlo se debe correr los dos comandos a continuación en la consola de paquetes nuget o por medio de la interfaz.

```sh
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
```

Luego de esto se debe cambiar la herencia de DbContext en ApplicationDbContext por IdentityDbContext.

## 6. Signing Server Key.
Con la finalidad de reconocer que los tokens (JWT) que se validen si sean autenticos del servidor como su emisor, se debe agregar el siguiente atributo a nuestro archivo de appsettings.json.

```JSON
"Jwt": {
    "Key": "Generar_Una_Llave_Secreta_Lo_Suficientemente_Amplia_Y_Segura_Mezclando_C4r4ct3r3s_O_Num3r0s",
    "Issuer": "Replica",
    "Audience": "UsuariosReplicaAPI"
  },
```
> [!NOTE]
> Se puede agregar antes de la clave ConnectionString.

