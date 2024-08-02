

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


SELECT * FROM ClassActivity


CREATE TABLE UserClassActivity (
    UserClassActivityId INT PRIMARY KEY IDENTITY,
    UserId INT FOREIGN KEY REFERENCES [User](id),
    ClassActivityId INT FOREIGN KEY REFERENCES ClassActivity(id),
    RegistrationDate DATETIME DEFAULT GETDATE()
);

ALTER TABLE ClassActivity
ADD Capacity INT



ALTER TABLE ClassActivity
ADD image_url NVARCHAR(2048)
ADD instructor NVARCHAR(100)
    Schedule DATETIME,
    Capacity INT


ALTER TABLE ClassActivity
ADD DayOfWeek NVARCHAR(50)













SELECT * FROM HistoryEnrollment
INNER JOIN Enrollment E on E.id = HistoryEnrollment.user_id



ALTER TABLE ClassActivity
ADD Hour NVARCHAR(50)

select * FROM ClassActivity

drop procedure CreateClassActivity

USE [GYM-Proyecto-2]

CREATE PROCEDURE CreateClassActivity
    @name NVARCHAR(100),
    @description NVARCHAR(255),
    @image_url NVARCHAR(255),
    @instructor INT,
    @dayOfWeek NVARCHAR(50),
    @hour TIME,
    @capacity INT
AS
BEGIN
    INSERT INTO ClassActivity (name, description, image_url, instructor, Capacity, DayOfWeek, Hour)
    VALUES (@name, @description, @image_url, @instructor,@capacity, @dayOfWeek, @hour);
END
GO


CREATE PROCEDURE UpdateClassActivity
    @id INT,
    @name NVARCHAR(100),
    @description NVARCHAR(255),
    @image_url NVARCHAR(255),
    @instructor INT,
    @dayOfWeek NVARCHAR(50),
    @hour TIME,
    @capacity INT
AS
BEGIN
    UPDATE ClassActivity
    SET name = @name,
        description = @description,
        image_url = @image_url,
        instructor = @instructor,
        DayOfWeek = @dayOfWeek,
        Hour = @hour,
        Capacity = @capacity
    WHERE Id = @id;
END



CREATE PROCEDURE GetAllClassActivities
AS
BEGIN
    SELECT A.id, A.name, A.description, A.image_url, A.instructor 'Instructor', U.name 'NameInstructor', A.Capacity, A.DayOfWeek, A.Hour FROM ClassActivity A
    INNER JOIN dbo.[User] U on A.instructor = U.id
END
