CREATE DATABASE TurboPac
CREATE TABLE Empleado(idEmpleado INT PRIMARY KEY IDENTITY(1,1),Nombre VARCHAR(50),
ApellidoPaterno VARCHAR(50),ApellidoMaterno VARCHAR(50),Activo Bit)

 CREATE PROCEDURE EmpleadoConsultas
 AS
 SELECT idEmpleado,Nombre,ApellidoPaterno,ApellidoMaterno,Activo,Salario FROM Empleado 

 CREATE PROCEDURE EmpleadoConsulta 
 @IdEmpleado INT
 AS
 SELECT idEmpleado,Nombre,ApellidoPaterno,ApellidoMaterno,Activo,Salario FROM Empleado
 WHERE idEmpleado=@IdEmpleado 
 
 CREATE PROCEDURE EmpleadoAgregar 
 @Nombre VARCHAR(50),
 @ApellidoPaterno VARCHAR(50),
 @ApellidoMaterno VARCHAR(50),
 @Activo BIT,
 @Salario DECIMAL
 AS
 INSERT INTO Empleado (Nombre,ApellidoPaterno,ApellidoMaterno,Activo,Salario)VALUES(@Nombre,@ApellidoPaterno,@ApellidoMaterno,@Activo,@salario)
 
 EmpleadoAgregar 'Juan','Perez','Lopez',1,100

create PROCEDURE EmpleadoActualizar
@idEmpleado INT,
@Nombre VARCHAR(50),
 @ApellidoPaterno VARCHAR(50),
 @ApellidoMaterno VARCHAR(50),
 @Activo BIT,
 @salario DECIMAL
 AS
 UPDATE Empleado SET Nombre=@Nombre,ApellidoPaterno=@ApellidoPaterno,ApellidoMaterno=@ApellidoMaterno,Activo=@Activo,salario=@salario
 WHERE idEmpleado=@idEmpleado
 EmpleadoActualizar 2,'Carlos','Gonzales','Hernandez',0,200000

 create PROCEDURE ActivarDesactivar 

@idEmpleado int,
@Activo BIT
AS
if(@Activo=1)
begin
Update Empleado set Activo=0 WHere idEmpleado=@idEmpleado
end
else
begin
Update Empleado set Activo=1 WHere idEmpleado=@idEmpleado
end
 