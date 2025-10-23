-- ==========================================================================
-- ======================= PROCEDIMIENTOS ALMACENADOS =======================
-- ==========================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE <Procedure_Name, sysname, ProcedureName> 
	-- Add the parameters for the stored procedure here
	<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT <@Param1, sysname, @p1>, <@Param2, sysname, @p2>
END
GO

-- ============================================================================================================

-- ========================================================
-- ======================= VENDEDOR =======================
-- ========================================================
-- Insertar Vendedor
CREATE PROCEDURE InsertarVendedor
    -- Add the parameters for the stored procedure here
    @Cedula VARCHAR(50),
    @Nombre VARCHAR(100),
    @Correo VARCHAR(100),
    @Estado BIT = 1
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
    SET NOCOUNT ON;

    -- Insert statements for procedure here
    IF NOT EXISTS (SELECT 1 FROM Vendedores WHERE Cedula = @Cedula)
    BEGIN
        INSERT INTO Vendedores (Cedula, Nombre, Correo, Estado)
        VALUES (@Cedula, @Nombre, @Correo, @Estado)
    END
END
GO

-- Obtener Vendedor
CREATE PROCEDURE ConsultarVendedores
    -- No parameters required
AS
BEGIN
    SET NOCOUNT ON;

    SELECT IdVendedor, Cedula, Nombre, Correo, Estado FROM Vendedores
END
GO

-- ========================================================
-- ======================= VEHICULO =======================
-- ========================================================

-- Insertar Vehículo
CREATE PROCEDURE InsertarVehiculo
    -- Add the parameters for the stored procedure here
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
CREATE PROCEDURE ConsultarVehiculos
    -- No parameters required
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

