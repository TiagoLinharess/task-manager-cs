# API Task manager (task-manager-cs)

Guia r�pido para clonar, restaurar depend�ncias e executar o projeto (.NET 8, C# 12).

## Requisitos
- .NET SDK 8.x instalado: https://dotnet.microsoft.com/download
- Visual Studio 2022 (opcional, com workload ASP.NET and web development)
- (Opcional) `dotnet-ef` para migrations: `dotnet tool install --global dotnet-ef`

## Clonar o reposit�rio
```bash
https://github.com/TiagoLinharess/task-manager-cs.git
```

## Restaurar depend�ncias (CLI .NET)
No diret�rio do projeto (onde est� o `.csproj` ou da solu��o):	
```bash
dotnet restore && dotnet run --project task-manager.csproj
````
