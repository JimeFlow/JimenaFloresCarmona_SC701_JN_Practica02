-- ==========================================================================
-- ======================= PROCEDIMIENTOS ALMACENADOS =======================
-- ==========================================================================
USE [Practica2]
GO

-- ========================================================
-- ======================= VENDEDOR =======================
-- ========================================================
-- Insertar Vendedor
CREATE PROCEDURE InsertarVendedor_SP
    @Cedula VARCHAR(50),
    @Nombre VARCHAR(100),
    @Correo VARCHAR(100),
    @Estado BIT = 1
AS
BEGIN
    SET NOCOUNT ON; -- Added to prevent extra result sets from interfering with SELECT statements.
    IF NOT EXISTS (SELECT 1 FROM Vendedores WHERE Cedula = @Cedula)
    BEGIN
        INSERT INTO Vendedores (Cedula, Nombre, Correo, Estado)
        VALUES (@Cedula, @Nombre, @Correo, @Estado)
    END
END
GO

-- Consultar Vendedores
CREATE PROCEDURE ConsultarVendedores_SP
AS
BEGIN
    SET NOCOUNT ON;

    SELECT IdVendedor, Cedula, Nombre, Correo, Estado FROM Vendedores
END
GO

-- Consultar por Cedula
CREATE PROCEDURE ObtenerVendedorPorCedula_SP
    @Cedula VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT IdVendedor FROM Vendedores WHERE Cedula = @Cedula
END
GO

-- Actualizar Datos
CREATE PROCEDURE ActualizarVendedor_SP
    @IdVendedor BIGINT,
    @Nombre VARCHAR(100),
    @Correo VARCHAR(100),
    @Estado BIT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Vendedores
    SET Nombre = @Nombre,
        Correo = @Correo,
        Estado = @Estado
    WHERE IdVendedor = @IdVendedor
END
GO

-- ========================================================
-- ======================= VEHICULO =======================
-- ========================================================

-- Insertar Vehículo
CREATE PROCEDURE InsertarVehiculo_SP
    @Marca VARCHAR(100),
    @Modelo VARCHAR(100),
    @Color VARCHAR(100),
    @Precio DECIMAL(18,2),
    @IdVendedor BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Vehiculos (Marca, Modelo, Color, Precio, IdVendedor)
    VALUES (@Marca, @Modelo, @Color, @Precio, @IdVendedor)
END
GO

-- Consultar Vehículos
CREATE PROCEDURE ConsultarVehiculos_SP
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        V.Cedula,
        V.Nombre,
        VE.Marca,
        VE.Modelo,
        VE.Precio
    FROM Vehiculos VE
    INNER JOIN Vendedores V ON VE.IdVendedor = V.IdVendedor
END
GO

-- Actulizar Datos
CREATE PROCEDURE ActualizarVehiculo_SP
    @IdVehiculo BIGINT,
    @Marca VARCHAR(100),
    @Modelo VARCHAR(100),
    @Color VARCHAR(100),
    @Precio DECIMAL(18,2),
    @IdVendedor BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Vehiculos
    SET Marca = @Marca,
        Modelo = @Modelo,
        Color = @Color,
        Precio = @Precio,
        IdVendedor = @IdVendedor
    WHERE IdVehiculo = @IdVehiculo
END
GO

-- Eliminar Vehiculo
CREATE PROCEDURE EliminarVehiculo_SP
    @IdVehiculo BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Vehiculos WHERE IdVehiculo = @IdVehiculo
END
GO
