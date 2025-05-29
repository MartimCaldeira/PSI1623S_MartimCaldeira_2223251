create database SmartWorkout
 use SmartWorkout







-- Tabela de Utilizadores
CREATE TABLE Utilizadores (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100) NOT NULL,
    PalavraPasse NVARCHAR(100) NOT NULL
);

-- Tabela de Tipos de Treino
CREATE TABLE TipoTreino (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100) NOT NULL
);

-- Tabela de Treinos
CREATE TABLE Treinos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    IdUtilizador INT NOT NULL,
    IdTipoTreino INT NOT NULL,
    Data DATE NOT NULL,
    Duracao INT NOT NULL, -- em minutos
    Notas NVARCHAR(255),

    FOREIGN KEY (IdUtilizador) REFERENCES Utilizadores(Id),
    FOREIGN KEY (IdTipoTreino) REFERENCES TipoTreino(Id)
);

select * from Utilizadores