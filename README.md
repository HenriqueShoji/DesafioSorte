Proposta de solução para o desafio proposto pela Sorte Online.

Onde ao cadastrar um cliente você precisa cadastrar um pedido. Também podendo adicionar pedidos a clientes já existentes.

Os scripts de criação de tabelas SQL são:

CREATE TABLE Clientes (
    ClienteId INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Pedidos (
    PedidoId INT IDENTITY(1,1) PRIMARY KEY,
    ClienteId INT NOT NULL,
    DataPedido DATETIME NOT NULL,
    ValorTotal DECIMAL NOT NULL
    FOREIGN KEY (ClienteId) REFERENCES Clientes(ClienteId)
);

Desenvolvido por Henrique Shoji.
