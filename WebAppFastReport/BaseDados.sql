-- Criação da Base de Dados --
CREATE DATABASE DB_TestesEds;
GO

-- Usando base de dados Criada --
USE DB_TestesEds;
GO

-- Criação da tabela CATEGORIA
CREATE TABLE CATEGORIA (
    id INT IDENTITY(1,1) PRIMARY KEY,  -- ID auto-incremental
    descricao NVARCHAR(255) NOT NULL,  -- Descrição da categoria
    ativo BIT NOT NULL  -- Indica se a categoria está ativa (1) ou inativa (0)
);

-- Criação da tabela PRODUTO
CREATE TABLE PRODUTO (
    id INT IDENTITY(1,1) PRIMARY KEY,  -- ID auto-incremental
    id_categoria INT NOT NULL,  -- ID da categoria a que o produto pertence
    descricao NVARCHAR(255) NOT NULL,  -- Descrição do produto
    valor DECIMAL(10, 2) NOT NULL,  -- Valor do produto
    qtd INT NOT NULL,  -- Quantidade em estoque

    -- Chave estrangeira para referenciar a tabela CATEGORIA
    CONSTRAINT FK_PRODUTO_CATEGORIA FOREIGN KEY (id_categoria) 
    REFERENCES CATEGORIA(id)
);

-- Exemplo de inserção de dados
INSERT INTO CATEGORIA (descricao, ativo) VALUES ('Eletrônicos', 1);
INSERT INTO CATEGORIA (descricao, ativo) VALUES ('Roupas', 1);

INSERT INTO PRODUTO (id_categoria, descricao, valor, qtd) VALUES (1, 'Smartphone', 1999.99, 50);
INSERT INTO PRODUTO (id_categoria, descricao, valor, qtd) VALUES (1, 'Televisão', 1500.00, 30);
INSERT INTO PRODUTO (id_categoria, descricao, valor, qtd) VALUES (2, 'Camiseta', 49.99, 100);
INSERT INTO PRODUTO (id_categoria, descricao, valor, qtd) VALUES (2, 'Calça Jeans', 89.99, 60);