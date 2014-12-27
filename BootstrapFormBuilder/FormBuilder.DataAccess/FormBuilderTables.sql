GO
CREATE TABLE [dbo].[FormTemplate](
	[FormTemplateId] [bigint] IDENTITY(1,1) NOT NULL,
	[FormName] [nvarchar](50) NULL,
	[FormDescription] [nvarchar](200) NULL,
	[FormTemplateData] [nvarchar](max) NULL,

PRIMARY KEY CLUSTERED 
(
	[FormTemplateId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FormInstance]    Script Date: 12/21/2014 15:31:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormInstance](
	[FormInstanceId] [bigint] IDENTITY(1,1) NOT NULL,
	[FormDataFields] [nvarchar](max) NULL,
	[FormTemplateId] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[FormInstanceId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedTableType [dbo].[FormControlGroupUDT]    Script Date: 12/21/2014 15:31:46 ******/
CREATE TYPE [dbo].[FormControlGroupUDT] AS TABLE(
	[ControlType] [nvarchar](20) NOT NULL,
	[OrderInForm] [int] NOT NULL,
	[FormFieldMapKey] [nvarchar](20) NULL,
	[ControlGroupTemplateModel] [nvarchar](1) NULL,
	[FormTemplateId] [bigint] NOT NULL,
	[FormControlGroupPropertys] [nvarchar](max) NULL
)
GO
/****** Object:  Table [dbo].[FormControlGroupProperty]    Script Date: 12/21/2014 15:31:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormControlGroupProperty](
	[ControlPropertyId] [bigint] NOT NULL,
	[ControlPropertyKey] [nchar](50) NOT NULL,
	[ControlPropertyValue] [nvarchar](max) NOT NULL,
	[ControlGroupId] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormControlGroup]    Script Date: 12/21/2014 15:31:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormControlGroup](
	[ControlType] [nvarchar](20) NOT NULL,
	[OrderInForm] [int] NOT NULL,
	[FormFieldMapKey] [nvarchar](20) NULL,
	[ControlGroupTemplateModel] [nvarchar](max) NULL,
	[FormTemplateId] [bigint] NOT NULL,
	[ControlGroupId] [bigint] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ControlGroupId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SP_GETFormTemplateById]    Script Date: 12/21/2014 15:31:51 ******/
CREATE PROCEDURE [dbo].[SP_GETFormTemplateById] 
	@FormTemplateId BIGINT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM dbo.FormTemplate WHERE FormTemplateId = @FormTemplateId;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GETFormInstanceById]    Script Date: 12/21/2014 15:31:51 ******/
CREATE PROCEDURE [dbo].[SP_GETFormInstanceById] 
	@FormInstanceId BIGINT
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @templateId BIGINT = (SELECT FormTemplateId FROM dbo.FormInstance WHERE FormInstanceId = @FormInstanceId)
	SELECT * FROM dbo.FormInstance WHERE FormInstanceId = @FormInstanceId;
	SELECT * FROM dbo.FormTemplate WHERE FormTemplateId = @templateId;
END
/****** Object:  StoredProcedure [dbo].[SP_AddOrUpdateFormTemplate]    Script Date: 12/21/2014 15:31:51 ******/
GO
CREATE PROCEDURE [dbo].[SP_AddOrUpdateFormTemplate] 
	@FormTemplateId BIGINT,
	@FormName NVARCHAR(50),
	@FormDescription NVARCHAR(200),
	@FormTemplateData NVARCHAR(MAX)
AS
BEGIN
	IF (@FormTemplateId = -1) 
	BEGIN
		INSERT INTO dbo.FormTemplate
		VALUES(@FormName,@FormDescription,@FormTemplateData)
		SET @FormTemplateId = SCOPE_IDENTITY()
	END 
	ELSE
	BEGIN
		UPDATE dbo.FormTemplate
		SET FormName = @FormName
			,FormDescription = @FormDescription
			,FormTemplateData = @FormTemplateData
		WHERE FormTemplateId = @FormTemplateId;
	END
	SELECT * FROM dbo.FormTemplate WHERE FormTemplateId = @FormTemplateId; 
END

/****** Object:  StoredProcedure [dbo].[SP_AddOrUpdateFormInstance]    Script Date: 12/21/2014 15:31:51 ******/

GO
CREATE PROCEDURE [dbo].[SP_AddOrUpdateFormInstance] 
	@FormInstanceId BIGINT,
	@FormDataFields NVARCHAR(MAX),
	@FormTemplateId BIGINT
AS
BEGIN
	IF (@FormInstanceId = -1) 
	BEGIN 
		INSERT INTO dbo.FormInstance
		VALUES(@FormDataFields,@FormTemplateId)
	END 
	ELSE
	BEGIN
		UPDATE dbo.FormInstance
		SET  FormDataFields = @FormDataFields
			,FormTemplateId = @FormTemplateId
		WHERE FormInstanceId = @FormInstanceId;
	END
END
GO
CREATE PROCEDURE [dbo].[SP_DeleteFormInstance] 
	@FormInstanceId BIGINT
AS
BEGIN
	DELETE dbo.FormInstance
	WHERE FormInstanceId = @FormInstanceId
END

GO 
CREATE PROCEDURE [dbo].[SP_DeleteFormTemplate] 
	@FormTemplateId BIGINT
AS
BEGIN
	DELETE dbo.FormControlGroup
	WHERE FormTemplateId = @FormTemplateId
	DELETE dbo.FormTemplate
	WHERE FormTemplateId = @FormTemplateId
END