﻿# SSOMA Reports Manager

Sistema de Reportes de Seguridad y Salud Ocupacional en Minería (SSOMA)

## 📌 Descripción

Aplicación web para la gestión de incidentes, observaciones y actos inseguros en el sector minero. Permite registrar reportes, adjuntar evidencias (imágenes), categorizarlos por tipo, y hacer seguimiento de acciones correctivas.

---

## 🧱 Estructura del Proyecto

```
SSOMA-Reports-Manager/
├── backend/
│ └── SSOMA-System/
│ ├── SSOMA.API/ → ASP.NET Core Web API
│ ├── SSOMA.Application/ → Servicios, Casos de uso, DTOs
│ ├── SSOMA.Domain/ → Entidades, lógica de dominio
│ ├── SSOMA.Infrastructure/→ PostgreSQL, JWT, Repositorios
│ └── SSOMA.Tests/ → Pruebas unitarias
│
├── frontend/
│ └── ssoma-client/ → Cliente Vue 3 + Vite
│
└── README.md → Este archivo
```

---

## 🚀 Tecnologías Utilizadas

### 🔧 Backend
- ASP.NET Core 8
- PostgreSQL
- Entity Framework Core
- JWT Authentication
- Arquitectura limpia (Domain, Application, Infrastructure, API)
- Swagger

### 🖥️ Frontend
- Vue 3 (Vite)
- Vue Router
- Axios
- TailwindCSS (opcional)
- Consumo de API REST

---

