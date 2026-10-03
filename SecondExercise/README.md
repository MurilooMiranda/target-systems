## Exercício 2

Enunciado: "Faça um programa onde eu possa lançar movimentações de estoque dos produtos que estão no json abaixo, dando entrada ou saída da mercadoria no meu depósito, onde cada movimentação deve ter:
Um número identificador único.
Uma descrição para identificar o tipo da movimentação realizada
E que ao final da movimentação me retorne a qtde final do estoque do produto movimentado."

**Entrada**: Código do produto, Tipo de movimentação e quantidade.
**Saída:** Informações da movimentação realizada e atualização no json.

**Exemplo:**

Produtos disponíveis:
101 - Caneta Azul - Estoque: 100
102 - Caderno Universitário - Estoque: 75
103 - Borracha Branca - Estoque: 200
104 - Lápis Preto HB - Estoque: 320
105 - Marcador de Texto Amarelo - Estoque: 90

Código do produto: 101

1 - Entrada
2 - Saída
Tipo de movimentação: 2 
Quantidade: 50

Movimentação realizada!
ID: 1
Tipo: Saida
Produto: Caneta Azul
Quantidade: 50
Estoque final: 50

Novo estoque após a movimentação:
101 - Caneta Azul - Estoque: 50
102 - Caderno Universitário - Estoque: 75
103 - Borracha Branca - Estoque: 200
104 - Lápis Preto HB - Estoque: 320
105 - Marcador de Texto Amarelo - Estoque: 90