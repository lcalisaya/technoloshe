# Tutorial: Primeros pasos con Entity Framework 6 Code First usando MVC 5
## Sitio web: [Microsoft Docs](https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/)
---
**Descripción:**
La aplicación web de ejemplo: "Contoso University" demuestra cómo crear aplicaciones ASP.NET MVC 5 utilizando Entity Framework 6 y Visual Studio 2013 (NOTA: se utilizará Visual Studio 2017). 
Este tutorial utiliza el flujo de trabajo Code First.

La aplicación "Contoso University" es un sitio web para una universidad de ficción de Contoso. 

Incluye funcionalidades tales como:
- Admisión de estudiantes, 
- Creación de cursos y 
- Asignaciones de instructores.

### Un poco de teoría:
**Especificando claves foráneas con Entity Framework:**
Entity Framework interpreta que una propiedad es clave foránea de dos maneras:
1) Si se llama <nombre de la navigation property>+<nombre de la PK>
	Ejemplo: la propiedad "StudentID" porque la navigation property es "Student" y porque la PK de la entidad Student es "ID"). 
2) Si se llama <nombre de la PK>
	Ejemplo: la propiedad "CourseID" porque la PK de la entidad Course es "CourseID").
