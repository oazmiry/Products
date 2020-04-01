FROM microsoft/dotnet:2.1-sdk AS builder
WORKDIR /app

COPY . ./
# Debug, to enable attaching with a remote debugger
RUN dotnet publish -c Debug -o /app/out Products.SI

FROM microsoft/dotnet:2.1-aspnetcore-runtime
ARG env=Development
ENV ASPNETCORE_ENVIRONMENT=$env
WORKDIR /app
COPY --from=builder /app/out .
ENTRYPOINT ["dotnet", "Products.SI.dll"]
