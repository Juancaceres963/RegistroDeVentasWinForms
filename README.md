# 🧾 Registro de Ventas - WinForms VB.NET

Este proyecto fue desarrollado como parte de una **prueba técnica**, con el objetivo de construir una aplicación de escritorio en **Visual Basic .NET (VB.NET)** utilizando **Windows Forms** como interfaz gráfica y conectada a una base de datos SQL Server.

---

## 🧠 Tecnologías utilizadas

- Visual Basic .NET (.NET Framework)
- Windows Forms
- SQL Server
- Arquitectura en 3 capas:
  - **Capa de Presentación (UI)**
  - **Capa de Negocio (BLL)**
  - **Capa de Datos (DAL)**

---

## 🎯 Objetivo

Construir una aplicación capaz de conectarse a una base de datos existente (sin posibilidad de modificar su estructura), compuesta por las siguientes tablas:

- `Clientes`
- `Productos`
- `Ventas`
- `VentaItems`

---

## 🔍 Funcionalidades principales

### 🔹 Clientes
- Visualización de todos los clientes.
- Edición y eliminación de registros directamente desde la interfaz.
- Agregado de nuevos clientes a través de un formulario dedicado.

### 🔹 Productos
- Visualización de todos los productos.
- Gestión completa (crear, editar, eliminar).
- Clasificación interna por categorías, administradas desde un archivo JSON interno.

### 🔹 Ventas (Historial)
- Visualización del historial de ventas.
- Cada venta contiene múltiples items, insertados en cascada utilizando el ID generado en tiempo real.
- Inserción doble:
  - Primero en la tabla `Ventas` para obtener el ID.
  - Luego en la tabla `VentaItems` asociada.

> ⚠ Por decisión de diseño, la eliminación y edición de ventas **no se permite desde la interfaz**. Esto se consideró parte de la integridad de datos, la cual debería manejarse a nivel base de datos.

---

## 🔑 Otros aspectos destacados

- Conexión a SQL Server mediante autenticación SQL configurada manualmente.
- Primer experiencia con Visual Basic y Windows Forms, explorando un stack completamente nuevo.
- Implementación de almacenamiento local con JSON para ciertas configuraciones internas.
- Diseño modular separado en capas lógicas para facilitar el mantenimiento y la escalabilidad del sistema.

---

## 🚧 Pendientes / Mejoras futuras

- Agregar **filtros de búsqueda** en cada módulo (clientes, productos, ventas).
- Implementar un **reporte mensual de ventas por producto**.
- Mejorar la **responsividad de la interfaz** (tamaños, adaptabilidad).
- Permitir realizar **snapshots históricos** para conservar registros a largo plazo.

---

## 🗃️ Base de Datos

En la carpeta `/Database` se incluye un script SQL (`script.sql`) con la estructura necesaria para ejecutar el proyecto. Las tablas incluidas son:

- Clientes
- Productos
- Ventas
- VentaItems

> ⚠ El proyecto se conecta utilizando autenticación SQL con la cadena de conexión proporcionada en la prueba. Asegurate de ajustar la cadena si usás tus propios valores de servidor y credenciales.
