/*==============================================================

                Music Sharing Seed Script

===============================================================*/
USE [musicsharing]
GO

DROP TABLE [musicsharing].[postcomment]
GO
DROP TABLE [musicsharing].[postlike]
GO
DROP TABLE [musicsharing].[follow]
GO
DROP TABLE [musicsharing].[post]
GO
DROP TABLE [musicsharing].[user]
GO
/*--------------- User Table -------------*/



CREATE TABLE [musicsharing].[user] (
    Id              INT             IDENTITY(1, 1) NOT NULL,
    SpotifyId  NVARCHAR(100)    NOT NULL,
    Name            NVARCHAR(50)    NOT NULL,
    IsActive        Bit             NOT NULL,
    CONSTRAINT PK_USER PRIMARY KEY (Id)
)
GO

/*--------------- Follow Table -------------*/
CREATE TABLE [musicsharing].[follow] (
    Id              INT             IDENTITY    (1, 1) NOT NULL,
    UserId          INT     NOT NULL,
    FollowId        INT     NOT NULL,
    IsActive        BIT     NOT NULL,
    CONSTRAINT PK_Follow PRIMARY KEY (Id),
    CONSTRAINT FK_Follow_UserId FOREIGN KEY (UserId) REFERENCES [musicsharing].[user] (Id),
    CONSTRAINT FK_Follow_FollowId FOREIGN KEY (UserId) REFERENCES [musicsharing].[user] (Id)
)
GO

/*--------------- Post Table -------------*/
CREATE TABLE [musicsharing].[post] (
    Id              INT             IDENTITY (1, 1) NOT NULL,
    ArtistName      NVARCHAR(100)   NOT NULL,
    Caption         NVARCHAR(100)   NOT NULL,
    SpotifyId       NVARCHAR(100)   NOT NULL,
    SpotifyUrl      NVARCHAR(1000)  NOT NULL,
    ImageUrl        NVARCHAR(1000)  NOT NULL,
    TrackName       NVARCHAR(100)   NOT NULL,
    UserId          INT             NOT NULL,
    IsActive        BIT             NOT NULL,
    CreatedOn        DATETIME        NOT NULL,
    CONSTRAINT PK_Post PRIMARY KEY (Id),
    CONSTRAINT FK_Post_User FOREIGN KEY (UserId) REFERENCES [musicsharing].[user] (Id)
)
GO

/*--------------- PostComment Table -------------*/
CREATE TABLE [musicsharing].[postcomment] (
    Id              INT             IDENTITY    (1, 1) NOT NULL,
    Comment         NVARCHAR(100)   NOT NULL,
    PostId          INT             NOT NULL,
    UserId          INT             NOT NULL,
    IsActive        BIT             NOT NULL,
    CreatedOn       DATETIME        NOT NULL,
    CONSTRAINT PK_PostComment PRIMARY KEY (Id),
    CONSTRAINT FK_PostComment_Post FOREIGN KEY (PostId) REFERENCES [musicsharing].[post] (Id),
    CONSTRAINT FK_PostComment_User FOREIGN KEY (UserId) REFERENCES [musicsharing].[user] (Id),
)
GO

/*--------------- PostLike Table -------------*/
CREATE TABLE [musicsharing].[postlike] (
    Id              INT             IDENTITY    (1, 1) NOT NULL,
    PostId          INT             NOT NULL,
    UserId          INT             NOT NULL,
    IsActive        BIT             NOT NULL,
    CONSTRAINT PK_PostLike PRIMARY KEY (Id),
    CONSTRAINT FK_PostLike_Post FOREIGN KEY (PostId) REFERENCES [musicsharing].[post] (Id),
    CONSTRAINT FK_PostLike_User FOREIGN KEY (UserId) REFERENCES [musicsharing].[user] (Id),
)
GO