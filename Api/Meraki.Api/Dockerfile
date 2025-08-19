# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Api/Meraki.Api/Meraki.Api.csproj", "Api/Meraki.Api/"]
COPY ["BoundedContext/Agenda/Meraki.Agenda.Aplication/Meraki.Agenda.Aplication.csproj", "BoundedContext/Agenda/Meraki.Agenda.Aplication/"]
COPY ["BoundedContext/Agenda/Meraki.Agenda.Data/Meraki.Agenda.Data.csproj", "BoundedContext/Agenda/Meraki.Agenda.Data/"]
COPY ["BoundedContext/Agenda/Meraki.Agenda.Domain/Meraki.Agenda.Domain.csproj", "BoundedContext/Agenda/Meraki.Agenda.Domain/"]
COPY ["BoundedContext/Cadastros/Meraki.Cadastros.Aplication/Meraki.Cadastros.Aplication.csproj", "BoundedContext/Cadastros/Meraki.Cadastros.Aplication/"]
COPY ["BoundedContext/Cadastros/Meraki.Cadastros.Domain/Meraki.Cadastros.Domain.csproj", "BoundedContext/Cadastros/Meraki.Cadastros.Domain/"]
COPY ["BoundedContext/Core/Meraki.Core/Meraki.Core.csproj", "BoundedContext/Core/Meraki.Core/"]
COPY ["BoundedContext/Cadastros/Meraki.Cadastros.Data/Meraki.Cadastros.Data.csproj", "BoundedContext/Cadastros/Meraki.Cadastros.Data/"]
COPY ["BoundedContext/Estoque/Meraki.Estoque.Aplication/Meraki.Estoque.Aplication.csproj", "BoundedContext/Estoque/Meraki.Estoque.Aplication/"]
COPY ["BoundedContext/Estoque/Meraki.Estoque.Data/Meraki.Estoque.Data.csproj", "BoundedContext/Estoque/Meraki.Estoque.Data/"]
COPY ["BoundedContext/Estoque/Meraki.Estoque.Domain/Meraki.Estoque.Domain.csproj", "BoundedContext/Estoque/Meraki.Estoque.Domain/"]
COPY ["BoundedContext/Orcamentos/Meraki.Orcamento.Aplication/Meraki.Orcamento.Aplication.csproj", "BoundedContext/Orcamentos/Meraki.Orcamento.Aplication/"]
COPY ["BoundedContext/Orcamentos/Meraki.Orcamento.Data/Meraki.Orcamento.Data.csproj", "BoundedContext/Orcamentos/Meraki.Orcamento.Data/"]
COPY ["BoundedContext/Orcamentos/Meraki.Orcamento.Domain/Meraki.Orcamento.Domain.csproj", "BoundedContext/Orcamentos/Meraki.Orcamento.Domain/"]
COPY ["BoundedContext/OrdemServico/Meraki.OrdemServico.Aplication/Meraki.OrdemServico.Aplication.csproj", "BoundedContext/OrdemServico/Meraki.OrdemServico.Aplication/"]
COPY ["BoundedContext/OrdemServico/Meraki.OrdemServico.Data/Meraki.OrdemServico.Data.csproj", "BoundedContext/OrdemServico/Meraki.OrdemServico.Data/"]
COPY ["BoundedContext/OrdemServico/Meraki.OrdemServico.Domain/Meraki.OrdemServico.Domain.csproj", "BoundedContext/OrdemServico/Meraki.OrdemServico.Domain/"]
COPY ["BoundedContext/Servicos/Meraki.Servicos.Aplication/Meraki.Servicos.Aplication.csproj", "BoundedContext/Servicos/Meraki.Servicos.Aplication/"]
COPY ["BoundedContext/Servicos/Meraki.Servicos.Data/Meraki.Servicos.Data.csproj", "BoundedContext/Servicos/Meraki.Servicos.Data/"]
COPY ["BoundedContext/Servicos/Meraki.Servicos.Domain/Meraki.Servicos.Domain.csproj", "BoundedContext/Servicos/Meraki.Servicos.Domain/"]
COPY ["BoundedContext/Vendas/Meraki.Vendas.Aplication/Meraki.Vendas.Aplication.csproj", "BoundedContext/Vendas/Meraki.Vendas.Aplication/"]
COPY ["BoundedContext/Vendas/Meraki.Vendas.Data/Meraki.Vendas.Data.csproj", "BoundedContext/Vendas/Meraki.Vendas.Data/"]
COPY ["BoundedContext/Vendas/Meraki.Vendas.Domain/Meraki.Vendas.Domain.csproj", "BoundedContext/Vendas/Meraki.Vendas.Domain/"]
RUN dotnet restore "./Api/Meraki.Api/Meraki.Api.csproj"
COPY . .
WORKDIR "/src/Api/Meraki.Api"
RUN dotnet build "./Meraki.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Meraki.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Meraki.Api.dll"]