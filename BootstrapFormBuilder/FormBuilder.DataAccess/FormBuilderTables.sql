GO
CREATE TABLE [dbo].[FormTemplate](
	[FormTemplateId] [bigint] IDENTITY(1,1) NOT NULL,
	[FormName] [nvarchar](50) NULL,
	[FormDescription] [nvarchar](200) NULL,
	[FormTemplateData] [nvarchar](max) NULL,
	[WorkFlowId] [bigint] NULL,
	[CreateDate] [datetime] NULL,
	[CreateUser] [nvarchar](50) NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[FormTemplateId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormInstance]    Script Date: 12/29/2014 21:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormInstance](
	[FormInstanceId] [bigint] IDENTITY(1,1) NOT NULL,
	[FormDataFields] [nvarchar](max) NULL,
	[FormTemplateId] [bigint] NULL,
	[CeateDate] [datetime] NULL,
	[CeateUser] [nvarchar](50) NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[FormInstanceId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedTableType [dbo].[FormControlGroupUDT]    Script Date: 12/29/2014 21:43:06 ******/
CREATE TYPE [dbo].[FormControlGroupUDT] AS TABLE(
	[ControlType] [nvarchar](20) NOT NULL,
	[OrderInForm] [int] NOT NULL,
	[FormFieldMapKey] [nvarchar](20) NULL,
	[ControlGroupTemplateModel] [nvarchar](1) NULL,
	[FormTemplateId] [bigint] NOT NULL,
	[FormControlGroupPropertys] [nvarchar](max) NULL
)
GO
/****** Object:  Table [dbo].[FormControlGroupProperty]    Script Date: 12/29/2014 21:43:06 ******/
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
/****** Object:  Table [dbo].[FormControlGroup]    Script Date: 12/29/2014 21:43:06 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_GETFormTemplates]    Script Date: 12/29/2014 21:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GETFormTemplates] 
AS
BEGIN
	SELECT * FROM dbo.FormTemplate
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GETFormTemplateById]    Script Date: 12/29/2014 21:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GETFormTemplateById] 
	@FormTemplateId BIGINT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM dbo.FormTemplate WHERE FormTemplateId = @FormTemplateId;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GETFormInstanceById]    Script Date: 12/29/2014 21:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GETFormInstanceById] 
	@FormInstanceId BIGINT
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @templateId BIGINT = (SELECT FormTemplateId FROM dbo.FormInstance WHERE FormInstanceId = @FormInstanceId)
	SELECT * FROM dbo.FormInstance WHERE FormInstanceId = @FormInstanceId;
	SELECT * FROM dbo.FormTemplate WHERE FormTemplateId = @templateId;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteFormTemplate]    Script Date: 12/29/2014 21:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteFormInstance]    Script Date: 12/29/2014 21:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DeleteFormInstance] 
	@FormInstanceId BIGINT
AS
BEGIN
	DELETE dbo.FormInstance
	WHERE FormInstanceId = @FormInstanceId
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddOrUpdateFormTemplate]    Script Date: 12/29/2014 21:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddOrUpdateFormTemplate] 
	@FormTemplateId BIGINT,
	@FormName NVARCHAR(50),
	@FormDescription NVARCHAR(200),
	@FormTemplateData NVARCHAR(MAX),
	@WorkFlowId Bigint,
	@UpdateUser NVARCHAR(50) = NULL
AS
BEGIN
	IF (@FormTemplateId = 0) 
	BEGIN
		INSERT INTO dbo.FormTemplate
		VALUES(@FormName,@FormDescription,@FormTemplateData,@WorkFlowId,getdate(),@UpdateUser,getdate(),@UpdateUser)
		SET @FormTemplateId = SCOPE_IDENTITY()
	END 
	ELSE
	BEGIN
		UPDATE dbo.FormTemplate
		SET FormName = @FormName
			,FormDescription = @FormDescription
			,FormTemplateData = @FormTemplateData
			,WorkFlowId = @WorkFlowId
			,UpdateDate = getdate()
			,UpdateUser = @UpdateUser
		WHERE FormTemplateId = @FormTemplateId;
	END
	SELECT * FROM dbo.FormTemplate WHERE FormTemplateId = @FormTemplateId; 
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddOrUpdateFormInstance]    Script Date: 12/29/2014 21:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddOrUpdateFormInstance] 
	@FormInstanceId BIGINT,
	@FormDataFields NVARCHAR(MAX),
	@FormTemplateId BIGINT,
	@UpdateUser NVARCHAR(50)
AS
BEGIN
	IF (@FormInstanceId = -1) 
	BEGIN 
		INSERT INTO dbo.FormInstance
		VALUES(@FormDataFields,@FormTemplateId,getdate(),@UpdateUser,getdate(),@UpdateUser)
	END 
	ELSE
	BEGIN
		UPDATE dbo.FormInstance
		SET  FormDataFields = @FormDataFields
			,FormTemplateId = @FormTemplateId
			,UpdateDate = getdate()
			,UpdateUser = @UpdateUser
		WHERE FormInstanceId = @FormInstanceId;
	END
END
GO