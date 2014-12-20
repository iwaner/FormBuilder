GO
CREATE TABLE [dbo].[FormTemplate](
	[FormTemplateId] [bigint] NULL,
	[FormName] [nchar](50) NULL,
	[FormDescription] [nchar](200) NULL,
	[FormHtmlTemplate] [bigint] NULL
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[FormInstance](
	[FormInstanceId] [bigint] NULL,
	[FormTemplateId] [bigint] NULL,
	[FormDataFields] [nvarchar](max) NULL
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[FormControlGroupProperty](
	[ControlPropertyId] [bigint] NOT NULL,
	[ControlPropertyKey] [nchar](50) NOT NULL,
	[ControlPropertyValue] [nvarchar](max) NOT NULL,
	[ControlGroupId] [bigint] NOT NULL
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[FormControlGroup](
	[ControlGroupId] [bigint] NOT NULL,
	[ControlType] [nvarchar](20) NOT NULL,
	[OrderInForm] [int] NOT NULL,
	[FormFieldMapKey] [nvarchar](20) NULL,
	[ControlGroupTemplateModel] [nvarchar](max) NULL,
	[FormTemplateId] [bigint] NOT NULL
) ON [PRIMARY]
GO

CREATE PROCEDURE [dbo].[SP_GETFormInstanceById] 
	@FormInstanceId BIGINT
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @templateId BIGINT = (SELECT FormTemplateId FROM dbo.FormInstance WHERE FormInstanceId = @FormInstanceId)
	SELECT * FROM dbo.FormInstance WHERE FormInstanceId = @FormInstanceId;
	SELECT * FROM dbo.FormTemplate WHERE FormTemplateId = @templateId;
	SELECT * FROM dbo.FormControlGroup WHERE FormTemplateId = @templateId;
	SELECT * FROM dbo.FormControlGroupProperty WHERE ControlGroupId IN (SELECT ControlGroupId FROM dbo.FormControlGroup WHERE FormTemplateId = @templateId)
END

GO
CREATE PROCEDURE [dbo].[SP_GETFormTemplateById] 
	@FormTemplateId BIGINT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM dbo.FormTemplate WHERE FormTemplateId = @FormTemplateId;
	SELECT * FROM dbo.FormControlGroup WHERE FormTemplateId = @FormTemplateId;
	SELECT * FROM dbo.FormControlGroupProperty WHERE ControlGroupId IN (SELECT ControlGroupId FROM dbo.FormControlGroup WHERE FormTemplateId = @FormTemplateId)
END