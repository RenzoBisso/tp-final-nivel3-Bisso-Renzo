# Portal de Administración de Productos

## Descripción
Este portal permite la gestión de productos a través de un sistema de login. Solo los usuarios con permisos de administrador podrán acceder al área de administración para realizar modificaciones en los productos publicados. Además, se cuenta con funcionalidades adicionales opcionales para mejorar la experiencia del usuario final.

## Link 
http://www.catalogowebnivel3.somee.com/Default.aspx

## ⚠️ Consideraciones
No utilicen para registrarse claves o emails que los puedan compremeter.

## Funcionalidades Principales
- **Home** con catálogo de productos y filtros.
- **Pantalla de detalle de producto.**
- **Pantalla de Login** con validación de usuario y contraseña.
- **Gestión de productos** (solo administradores):
  - Listado de artículos (formato grilla).
  - Búsqueda de artículos por distintos criterios.
  - Agregar artículos.
  - Modificar artículos.
  - Eliminar artículos.
- **Base de datos persistente** con los siguientes campos por artículo:
  - Código de artículo.
  - Nombre.
  - Descripción.
  - Marca (seleccionable de una lista desplegable).
  - Categoría (seleccionable de una lista desplegable).
  - Imagen.
  - Precio.

## Etapas de Desarrollo
### Etapa 1: Construcción del Modelo y Navegación
- Diseño de clases para representar los artículos y usuarios.
- Creación de las pantallas necesarias con su respectiva navegación.

### Etapa 2: Interacción con la Base de Datos
- Implementación de la conexión con la base de datos.
- Manejo de validaciones y excepciones.
- Desarrollo de la funcionalidad de gestión de productos.
- Implementación del sistema de Login con validación de credenciales.

### Etapa 3: Funcionalidades Opcionales
- **Registro de cliente** con opción de alta de usuario.
- **Pantalla "Mi Perfil"** para la gestión de datos personales.
- **Pantalla "Mis Favoritos"** para agregar y quitar productos de favoritos.

## Consideraciones
- Se debe implementar arquitectura en capas.
- Se deben manejar excepciones y validaciones adecuadas.

## Tecnologías Utilizadas
- C# (.NET Framework 4.8)
- SQL Server
- ASP.NET 
- Arquitectura en capas
  
## Usuario Admin
- Email: admin@prueba.com
- Password: admin1234
## Usuario Normal
- Email: test@test.com	
- Password: test1234

 
