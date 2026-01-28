# ⚖️ Estudio Jurídico Coiman & Asociados - Web Institucional

![.NET Core](https://img.shields.io/badge/.NET%20Core-10.0-purple) ![Status](https://img.shields.io/badge/Status-Production-success) ![License](https://img.shields.io/badge/License-MIT-blue)

> **Solución web a medida** desarrollada para una firma legal, enfocada en la conversión de clientes y la identidad institucional.

## 📋 Descripción del Proyecto

Este proyecto consiste en el desarrollo *Full Stack* de una Landing Page institucional. A diferencia de soluciones basadas en plantillas (Wordpress/Wix), se optó por una arquitectura en **ASP.NET Core** para garantizar control total sobre la seguridad, la performance y la escalabilidad del sistema.

El objetivo principal fue digitalizar el canal de entrada de clientes del estudio, ofreciendo una experiencia de usuario (UX) fluida y un sistema de contacto robusto que integra Email y WhatsApp.

---

## 🚀 Live Demo

🔗 **Deploy en Producción:** [Link a tu página en Somee aquí]

![Demo del Proyecto]([Ruta a tu GIF o Imagen Principal aquí])
*(Vista previa de la interfaz y funcionamiento del formulario)*

---

## 🛠️ Tech Stack & Herramientas

### Backend
* **Framework:** ASP.NET Core 10 (MVC Pattern).
* **Lenguaje:** C#.
* **Email Services:** MailKit / MimeKit (Implementación SMTP asíncrona).
* **Hosting:** IIS (Windows Server) en Somee.

### Frontend
* **Vistas:** Razor Views (.cshtml).
* **Estilos:** CSS3 (Diseño Custom Responsive).
* **Scripting:** JavaScript (Validaciones client-side).
* **Integraciones:** Google Maps Embed API, WhatsApp Business API.

---

## ✨ Funcionalidades Clave

### 1. Sistema de Contacto Seguro
Implementación de un formulario con **doble capa de validación**:
* **Frontend:** Feedback inmediato al usuario.
* **Backend (C#):** Data Annotations y validación de modelo para asegurar la integridad de los datos antes del procesamiento.

### 2. Servicio de Notificaciones (SMTP)
Integración de `MailKit` para el envío automatizado de correos. El sistema procesa la consulta del cliente y la despacha instantáneamente a la casilla del estudio, manejando excepciones de conexión SMTP.

### 3. UX/UI Centrada en el Cliente
Diseño de interfaz de alta fidelidad con jerarquía visual clara. Incluye "Call to Actions" estratégicos y feedback visual (modales de éxito/error) para mejorar la tasa de conversión.
