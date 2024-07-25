

SELECT * FROM [User]

CREATE PROCEDURE GetUserById
    @p_user_id INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Retrieve user
    SELECT *
    FROM [User]
    WHERE id = @p_user_id
END;
go


drop procedure RetrieveAllAppointments

CREATE PROCEDURE RetrieveAllAppointments
AS
BEGIN
    SELECT A.id, A.date, A.user_A_id, A.user_B_id, U.name 'user_A_name', U2.name 'user_B_name'  FROM Appointment A INNER JOIN dbo.[User] U on U.id = A.user_A_id INNER JOIN dbo.[User] U2 on U2.id = A.user_B_id;
END;

CREATE PROCEDURE RetrieveAppointmentById
    @id INT
AS
BEGIN
    SELECT * FROM Appointment WHERE id = @id;
END;

CREATE PROCEDURE RetrieveAppointmentsByUser
    @userId INT
AS
BEGIN
    SELECT * FROM Appointment WHERE user_A_id = @userId OR user_B_id = @userId;
END;

CREATE PROCEDURE UpdateAppointment
    @id INT,
    @date DATETIME,
    @userAId INT,
    @userBId INT
AS
BEGIN
    UPDATE Appointment
    SET date = @date, user_A_id = @userAId, user_B_id = @userBId
    WHERE id = @id;
END;

CREATE PROCEDURE DeleteAppointment
    @id INT
AS
BEGIN
    DELETE FROM Appointment WHERE id = @id;
END;