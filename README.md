# API de Controle de Treinos

## Objetivo

API REST desenvolvida como trabalho AP1 da disciplina de Desenvolvimento Backend. O sistema gerencia treinos de academia, permitindo cadastrar, listar, buscar, atualizar e remover registros de treino (CRUD completo).

## Requisitos

- .NET SDK 10

## Como executar

```
dotnet restore
dotnet run --urls http://localhost:5050
```

A API ficará disponível em: `http://localhost:5050`

## Endpoints

| Método | Rota | Descrição |
|--------|------|-----------|
| GET | `/` | Confirma que a API está no ar |
| GET | `/api/treinos` | Lista todos os treinos |
| GET | `/api/treinos/{id}` | Busca um treino pelo id |
| POST | `/api/treinos` | Cadastra um novo treino |
| PUT | `/api/treinos/{id}` | Atualiza um treino existente |
| DELETE | `/api/treinos/{id}` | Remove um treino |

## Exemplo de JSON — POST e PUT

```json
{
  "nome": "Treino C - Pernas",
  "grupoMuscular": "Pernas",
  "series": 4,
  "repeticoes": 10,
  "carga": 40.0
}
```

## Observação sobre os dados

Os dados são armazenados em uma `List<TreinoDto>` em memória. Isso significa que **todos os registros são perdidos quando a aplicação é reiniciada**. Não há banco de dados nesta etapa do projeto.

## Testes

Os testes de todos os endpoints foram feitos com o **Bruno**. A Collection utilizada está disponível na pasta [`bruno/`](./bruno) deste repositório.

## Vídeo de demonstração

[\[Link do vídeo aqui\]](https://drive.google.com/file/d/1pSnKkNs5XXhI3IXExXjFp8tN2Lnl7vaG/view?usp=sharing)
