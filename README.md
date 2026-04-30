# Ezana Tefera — Portfolio

Personal portfolio site built with Angular 21 and ASP.NET Core 10, deployed on Microsoft Azure.

🌐 **Live site:** [ezana.dev](https://ezana.dev)

## Tech Stack

**Frontend**
- Angular 21 (Standalone Components)
- TypeScript
- SCSS
- Angular Router

**Backend**
- ASP.NET Core 10 Web API
- C#
- MailKit (Gmail SMTP)

**Cloud & DevOps**
- Azure Static Web Apps (frontend)
- Azure App Service (backend)
- GitHub Actions CI/CD
- Custom domain with Azure-provisioned SSL

## Features
- Typing animation on hero section
- Responsive design with mobile hamburger navigation
- Contact form with client-side and server-side validation
- Email delivery via Gmail SMTP
- Automated deployments on every push to master
- Custom ET favicon
- Clean white minimal design with dot grid background

## Pages

| Page | Description |
|------|-------------|
| Home | Hero section with typing animation |
| About | Background, experience, and key metrics |
| Skills | Technical skills organized by category |
| Projects | Professional and personal project showcase |
| Contact | Contact form with email delivery |

## Architecture

Angular Frontend (ezana.dev) → HTTP POST → ASP.NET Core API → SMTP → Gmail Inbox

## Local Development

### Prerequisites
- Node.js 22+
- Angular CLI 21+
- .NET 10 SDK

### Frontend

```bash
git clone https://github.com/etefera11/portfolio.git
cd portfolio
npm install
ng serve
```

### Backend

```bash
cd portfolio-api
dotnet run
```

## Project Structure
```
src/
├── app/
│   ├── components/
│   │   └── navbar/
│   ├── pages/
│   │   ├── home/
│   │   ├── about/
│   │   ├── skills/
│   │   ├── projects/
│   │   └── contact/
│   ├── services/
│   │   └── contact.service.ts
│   └── app.routes.ts
portfolio-api/
├── Controllers/
├── Services/
└── Models/
```

## Contact

Ezana Tefera
- Email: etefera11@gmail.com
- LinkedIn: https://linkedin.com/in/ezanatefera
- GitHub: https://github.com/etefera11