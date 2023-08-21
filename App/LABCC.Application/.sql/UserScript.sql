-- CREATE TABLE: USER
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.Users') AND type = N'U')
    BEGIN
        CREATE TABLE Users (
                               Id UNIQUEIDENTIFIER PRIMARY KEY,
                               Document VARCHAR(18) NOT NULL,
                               Password NVARCHAR(255) NOT NULL,
                               Email NVARCHAR(100) NOT NULL,
                               Name NVARCHAR(100) NOT NULL,
                               DateOfBirth DATE NOT NULL,
                               Phone VARCHAR(15) NOT NULL,
                               Gender TINYINT,
                               UserRole TINYINT,
                               UpdatedAt DATETIMEOFFSET NOT NULL CONSTRAINT DF_Users_UpdatedAt DEFAULT SYSUTCDATETIME(),
                               CreatedAt DATETIMEOFFSET NOT NULL CONSTRAINT DF_Users_CreatedAt DEFAULT SYSUTCDATETIME(),
                               Status TINYINT,
                               CONSTRAINT UQ_Users_Document UNIQUE (Document),
                               CONSTRAINT UQ_Users_Email UNIQUE (Email),
                               CONSTRAINT UQ_Users_Phone UNIQUE (Phone),
                               CONSTRAINT CK_Users_Age_Valid CHECK (DateOfBirth <= DATEADD(YEAR, -18, GETDATE()))
        );

        CREATE INDEX IX_Users_Document ON Users (Document);
        CREATE INDEX IX_Users_Email ON Users (Email);
        CREATE INDEX IX_Users_Name ON Users (Name);
    END

-- CREATE PROCEDURE: INSERT USER
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.InsertUser') AND type in (N'P', N'PC'))
    BEGIN
        EXEC('CREATE  PROCEDURE dbo.InsertUser
            @Id UNIQUEIDENTIFIER,
            @Email NVARCHAR(100),
            @Password NVARCHAR(255),
            @Name NVARCHAR(100),
            @Document VARCHAR(18),
            @DateOfBirth DATE,
            @Gender TINYINT,
            @Phone VARCHAR(15),
            @UserRole TINYINT,
            @UpdatedAt DATETIMEOFFSET,
            @CreatedAt DATETIMEOFFSET,
            @Status TINYINT
        AS
        BEGIN
            INSERT INTO dbo.Users (
                Id, Email, Password, Name, Document, DateOfBirth,
                Gender, Phone, UserRole, UpdatedAt, CreatedAt, Status
            )
            VALUES (
                       @Id, @Email, @Password, @Name, @Document, @DateOfBirth,
                       @Gender, @Phone, @UserRole, @UpdatedAt, @CreatedAt, @Status
                   )
        END
        ');
    END

-- CREATE PROCEDURE: GET USER BY PAGE
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.GetUsersByPage') AND type in (N'P', N'PC'))
    BEGIN
        EXEC('CREATE PROCEDURE dbo.GetUsersByPage
            @PageNumber INT,
            @PageSize INT,
            @FilterName NVARCHAR(100) = NULL,
            @FilterDateOfBirth DATE = NULL,
            @FilterGender TINYINT = NULL,
            @FilterUserRole TINYINT = NULL,
            @FilterStatus TINYINT = NULL
        AS
        BEGIN
            SET NOCOUNT ON;

            SELECT Id, Document, Email, Name, DateOfBirth,
                   Phone, Gender, UserRole, UpdatedAt, CreatedAt, Status
            FROM (
                     SELECT ROW_NUMBER() OVER (ORDER BY CreatedAt DESC) AS RowNumber,
                            Id, Document, Email, Name, DateOfBirth,
                            Phone, Gender, UserRole, UpdatedAt, CreatedAt, Status
                     FROM dbo.Users
                     WHERE (@FilterName IS NULL OR Name LIKE ''%'' + @FilterName + ''%'')
                       AND (@FilterDateOfBirth IS NULL OR DateOfBirth = @FilterDateOfBirth)
                       AND (@FilterGender IS NULL OR Gender = @FilterGender)
                       AND (@FilterUserRole IS NULL OR UserRole = @FilterUserRole)
                       AND (@FilterStatus IS NULL OR Status = @FilterStatus)
                 ) AS UserWithRowNumber
            WHERE RowNumber BETWEEN (@PageNumber - 1) * @PageSize + 1 AND @PageNumber * @PageSize;

        END
        ');
    END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.GetSingleUser') AND type in (N'P', N'PC'))
    BEGIN
        EXEC('CREATE PROCEDURE dbo.GetSingleUser
            @SearchValue NVARCHAR(150),
            @Status TINYINT
        AS
        BEGIN
            SET NOCOUNT ON;
            
            DECLARE @Id UNIQUEIDENTIFIER;

            BEGIN TRY
                SET @Id = CAST(@SearchValue AS UNIQUEIDENTIFIER);
            END TRY
            BEGIN CATCH
                SET @Id = NULL;
            END CATCH;

            SELECT TOP 1 Id, Document, Email, Name, DateOfBirth,
                         Phone, Gender, UserRole, UpdatedAt, CreatedAt, Status
            FROM dbo.Users
            WHERE (@Id IS NULL OR Id = @Id)
               OR Document = @SearchValue
               OR Email = @SearchValue
               OR Phone = @SearchValue
               OR (@Status IS NULL OR Status = @Status);

        END
        ');
    END

-- CREATE PROCEDURE: USER LOGIN
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.UserLogin') AND type in (N'P', N'PC'))
    BEGIN
        EXEC('CREATE PROCEDURE dbo.UserLogin
            @LoginValue NVARCHAR(100)
        AS
        BEGIN
            SET NOCOUNT ON;

            SELECT TOP 1 Id, Document, Email, Name, Phone, Password, UserRole, Status
            FROM dbo.Users
            WHERE (Email = @LoginValue OR Phone = @LoginValue OR Document = @LoginValue);
        END');
    END

-- CREATE PROCEDURE: EDIT USER
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.EditUser') AND type in (N'P', N'PC'))
    BEGIN
        EXEC('CREATE PROCEDURE dbo.EditUser
        @Id UNIQUEIDENTIFIER,
        @Email NVARCHAR(100) = NULL,
        @Password NVARCHAR(255) = NULL,
        @Name NVARCHAR(100) = NULL,
        @Document VARCHAR(18) = NULL,
        @DateOfBirth DATE = NULL,
        @Gender TINYINT = NULL,
        @Phone VARCHAR(15) = NULL,
        @UserRole TINYINT = NULL,
        @Status TINYINT = NULL
    AS
    BEGIN
        SET NOCOUNT ON;

        UPDATE dbo.Users
        SET
            Email = ISNULL(@Email, Email),
            Password = ISNULL(@Password, Password),
            Name = ISNULL(@Name, Name),
            Document = ISNULL(@Document, Document),
            DateOfBirth = ISNULL(@DateOfBirth, DateOfBirth),
            Gender = ISNULL(@Gender, Gender),
            Phone = ISNULL(@Phone, Phone),
            UserRole = ISNULL(@UserRole, UserRole),
            Status = ISNULL(@Status, Status)
        WHERE Id = @Id;

    END');
    END
