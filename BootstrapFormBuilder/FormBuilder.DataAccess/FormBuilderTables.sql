GO
CREATE TABLE [dbo].[FormTemplate](
	[FormId] [bigint] NULL,
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