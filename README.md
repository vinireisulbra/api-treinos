# API de Controle de Treinos

API em ASP.NET Core (.NET 10) com Entity Framework Core e SQLite para cadastrar treinos de academia, com interface web integrada (mesma origem da API).

## Requisitos

- .NET SDK 10
- Ferramenta do EF Core: `dotnet tool install --global dotnet-ef`

## Preparar o banco

Na pasta `ApiTreinos`:

```
dotnet ef database update
```

Isso cria o arquivo `treinos.db` a partir das migrations versionadas.

## Executar

```
dotnet run --urls http://localhost:5070
```

## Abrir a interface

Acesse http://localhost:5070 no navegador. A tela lista, cadastra, edita e exclui treinos usando a API real.

## Rotas da API

| Método | Rota | Descrição | Resposta |
|--------|------|-----------|----------|
| GET | /api/treinos | Lista todos os treinos | 200 |
| GET | /api/treinos/{id} | Busca um treino por id | 200 ou 404 |
| POST | /api/treinos | Cadastra um treino | 201 |
| PUT | /api/treinos/{id} | Atualiza um treino | 200 ou 404 |
| DELETE | /api/treinos/{id} | Exclui um treino | 204 ou 404 |

Exemplo de corpo (POST e PUT):

```json
{
  "nome": "Treino C - Pernas",
  "grupoMuscular": "Pernas",
  "series": 4,
  "repeticoes": 12,
  "carga": 30
}
```

## Testes da API

A collection do Bruno está na pasta `bruno/` e cobre GET da lista, GET por id, POST, PUT, DELETE e o 404 após excluir. Ela usa a porta 5070.

## Vídeo de demonstração — AP2

COLE_AQUI_O_LINK_DO_VIDEO