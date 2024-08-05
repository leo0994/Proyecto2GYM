

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


CREATE TABLE Participants (
    id INT PRIMARY KEY IDENTITY,
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






SELECT * FROM Participants

CREATE TABLE Participants (
    id INT PRIMARY KEY IDENTITY,
    UserId INT FOREIGN KEY REFERENCES [User](id),
    ClassActivityId INT FOREIGN KEY REFERENCES ClassActivity(id),
    RegistrationDate DATETIME DEFAULT GETDATE()
);

ALTER TABLE Participants
DROP CONSTRAINT FK__Participants__ClassActivityId; -- Drop the existing foreign key

ALTER TABLE Participants
ADD CONSTRAINT FK__Participants__ClassActivityId
FOREIGN KEY (ClassActivityId)
REFERENCES ClassActivity(id)
ON DELETE CASCADE; -- Add the foreign key with cascade delete

CREATE PROCEDURE RegisterParticipant
    @userId INT,
    @classActivityId INT,
    @registrationDate DATETIME
AS
BEGIN
    DECLARE @maxCapacity INT;
    DECLARE @currentParticipants INT;
    DECLARE @isAlreadyJoined BIT;

    -- Check if the user is already registered for the class
    SET @isAlreadyJoined = (SELECT CASE WHEN EXISTS
        (SELECT 1 FROM Participants
         WHERE id = @userId AND ClassActivityId = @classActivityId)
        THEN 1 ELSE 0 END);

    IF @isAlreadyJoined = 1
    BEGIN
        -- Already joined
        SELECT 3 AS Status; -- Already joined
        RETURN;
    END

    -- Get the maximum capacity of the class
    SELECT @maxCapacity = capacity
    FROM ClassActivity
    WHERE id = @classActivityId;

    -- Get the current number of participants in the class
    SET @currentParticipants = (SELECT COUNT(*) FROM Participants WHERE ClassActivityId = @classActivityId);

    IF @currentParticipants >= @maxCapacity
    BEGIN
        -- Maximum capacity reached
        SELECT 2 AS Status; -- Maximum capacity reached
        RETURN;
    END

    -- Insert the new record into Participants
    INSERT INTO Participants (u, class_id, RegistrationDate)
    VALUES (@userId, @classActivityId, @registrationDate);

    -- Registration success
    SELECT 1 AS Status; -- Success
END



CREATE PROCEDURE dbo.UpdateClassAttendance
    @id INT,
    @RegistrationDate DATETIME,
    @UserId INT,
    @ClassActivityId INT
AS
BEGIN
    UPDATE Participants
    SET RegistrationDate = @RegistrationDate,
        UserId = @UserId,
        ClassActivityId = @ClassActivityId
    WHERE id = @id;
END;
go
