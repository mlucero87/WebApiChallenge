# WebApi - Challenge

Develop a RESTful API that would allow a web or mobile front-end to: <br><br>
• Create a contact record<br>
• Retrieve a contact record<br>
• Update a contact record<br>
• Delete a contact record<br>
• Search for a record by email or phone number<br>
• Retrieve all records from the same state or city<br>
The contact record should represent the following information: name, company, profile
image, email, birthdate, phone number (work, personal) and address.<br>

# Sobre el desarrollo
Esta pequeña API esta desarrollada en .NET 8, EntityFramework, FluenValidation para validaciones, MediaTr para el patrón Mediator y xUnit para los test unitarios.
Utilice el patron CQRS por ser el que mas use en mis ultimos proyectos.<br>
En los Test unitarios incluí algunos para el testeo del ContactController y otros para el testeo de comandos.<br>
La api utiliza SQLite para base de datos, y el proyecto de test utiliza un base de datos en memoria.<br>
Para correr la Api solo hay que clonar el repositorio y ejecutar.<br>

Espero que les guste! muchas gracias!
