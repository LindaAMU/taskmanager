# TaskManager

Aplicación de gestión de tareas desarrollada con **ASP.NET Core 9**, **Blazor** y **Bootstrap**, utilizando almacenamiento en memoria.

---

## 🔧 Requisitos

- [Visual Studio](https://visualstudio.microsoft.com/es/)
- [.NET 9)](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

---

## 🚀 Instrucciones para ejecutar localmente

### Backend (`taskmanager.api`)

1. Abre **Visual Studio Code**.
2. Abre la carpeta `taskmanager.api` que contiene el archivo de solución (`.sln`).
3. Presiona `F5` o usa el botón **Run** para ejecutar la API.
4. La API estará disponible en:  
   👉 `https://localhost:44328/` (Dependerá del local)

> El backend utiliza **almacenamiento en memoria**, por lo que los datos no se persisten al reiniciar la aplicación.

---

### Frontend (`taskmanager.web`)

1. En la misma ventana o en otra de **Visual Studio Code**, abre la carpeta `taskmanager.web`.
2. Ejecuta la aplicación con `F5` o el botón **Run**.
3. El frontend estará disponible en:  
   👉 `https://localhost:44396/` (Dependerá del local, actualizar en appseting.json por url del backend)

> El frontend está construido con **Blazor Server**.

---

## 📌 Notas adicionales

- Asegúrate de que el backend esté corriendo antes de usar el frontend.
- No se necesita configurar base de datos ni archivos `.env`, ya que todo funciona en memoria.
- Si tienes errores con certificados HTTPS, puede que necesites confiar en el certificado de desarrollo generado por .NET. Puedes hacerlo con el siguiente comando:
  ```bash
  dotnet dev-certs https --trust# taskmanager
- Readme generado con IA y actualizado manualmente :)