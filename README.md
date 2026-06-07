# 🎓 Architect Academy

Uma universidade virtual para formar especialistas em arquitetura de software.

## 📋 Estrutura do Projeto

```
src/
├── ArchitectAcademy.Domain/          # DDD - Domain Layer
│   ├── Common/                        # Classes base
│   ├── Entities/                      # Entidades e Agregados
│   ├── ValueObjects/                  # Value Objects
│   └── Repositories/                  # Interfaces de repositório
├── ArchitectAcademy.Application/      # CQRS - Application Layer
├── ArchitectAcademy.Infrastructure/   # Implementações
├── ArchitectAcademy.Shared/           # DTOs e Enums compartilhados
└── ArchitectAcademy.Web/              # Blazor Server UI
```

## 🎯 Fases do Projeto

### Fase 1: MVP (Semana 1-4)
- [ ] Estrutura Clean Architecture
- [ ] Modelos de Disciplina, Aula, Exercício, Prova
- [ ] Sistema de Autenticação
- [ ] Dashboard básico
- [ ] 1ª disciplina: SOLID

### Fase 2: Gamificação (Semana 5-7)
- [ ] Sistema de XP e Níveis
- [ ] Sistema de Badges
- [ ] Leaderboard
- [ ] Bloqueio de disciplinas

### Fase 3: Mais Conteúdo (Contínuo)
- [ ] Disciplinas adicionais
- [ ] Centro de Aprendizado
- [ ] Simulador de Arquiteto

## 🚀 Como Começar

```bash
# Clone o repositório
git clone https://github.com/anfsusax/ArchitectAcademy.git

# Entre no diretório
cd ArchitectAcademy

# Crie o projeto
dotnet new sln -n ArchitectAcademy
```

## 📚 Estrutura de Aprendizado

### 1º Semestre - Fundamentos
- SOLID
- Clean Code
- Design Patterns

### 2º Semestre - Arquitetura
- DDD
- CQRS
- Event Driven

### 3º Semestre - Cloud
- Docker
- Kubernetes
- Azure

### 4º Semestre - Empresarial
- Microsserviços
- Integrações
- Observabilidade

## 👨‍💻 Tecnologias

- **Frontend**: Blazor Server + MudBlazor
- **Backend**: ASP.NET Core 8
- **Banco**: SQL Server
- **Arquitetura**: Clean Architecture + DDD + CQRS
- **ORM**: Entity Framework Core
- **Validação**: FluentValidation
- **Mediator**: MediatR

## 📝 Licença

MIT
