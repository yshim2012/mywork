IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TB_User]') AND type in (N'U'))
DROP TABLE [dbo].[TB_User]

GO
CREATE TABLE [dbo].[TB_User]
(
    [ID]                             [int] IDENTITY(1,1) NOT NULL,
    [User_Name]                      [varchar] (100) NOT NULL,
    [Real_Name]                      [varchar] (100) NOT NULL,
    [Icon_Url]                       [text],
    [Employee_No]                    [varchar] (20) NOT NULL,
    [Password]                       [varchar] (20) NOT NULL,
    [Department_Name]                [varchar] (100) NOT NULL,
    [Company_Name]                   [varchar] (200) NOT NULL,
    [Tel]                            [varchar] (20) NOT NULL,
    [Email]                          [varchar] (50),
    [Is_Delete]                      [tinyint] DEFAULT (0)  NOT NULL,
    [Delete_Date]                    [datetime],
    [Last_Login_Time]                [datetime],
    [Create_Time]                     [datetime],
    [Create_Userid]                   [varchar](50),
    [Update_Time]                     [datetime],
    [Update_Userid]                   [varchar](50),
    CONSTRAINT [PK_TB_User] PRIMARY KEY CLUSTERED([ID] ASC) ON [PRIMARY]
)

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User', @level2type=N'COLUMN', @level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'昵称' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User', @level2type=N'COLUMN', @level2name=N'User_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'真实姓名' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User', @level2type=N'COLUMN', @level2name=N'Real_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'头像' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User', @level2type=N'COLUMN', @level2name=N'Icon_Url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工号' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User', @level2type=N'COLUMN', @level2name=N'Employee_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User', @level2type=N'COLUMN', @level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User', @level2type=N'COLUMN', @level2name=N'Department_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'在职公司' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User', @level2type=N'COLUMN', @level2name=N'Company_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系电话' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User', @level2type=N'COLUMN', @level2name=N'Tel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User', @level2type=N'COLUMN', @level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否作废' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User', @level2type=N'COLUMN', @level2name=N'Is_Delete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作废时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User', @level2type=N'COLUMN', @level2name=N'Delete_Date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后登录时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User', @level2type=N'COLUMN', @level2name=N'Last_Login_Time'

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TB_User_Change]') AND type in (N'U'))
DROP TABLE [dbo].[TB_User_Change]

GO
CREATE TABLE [dbo].[TB_User_Change]
(
    [ID]                             [int] IDENTITY(1,1) NOT NULL,
    [Real_Name]                      [varchar] (100) NOT NULL,
    [Employee_No]                    [varchar] (20) NOT NULL,
    [Department_Name]                [varchar] (100) NOT NULL,
    [Company_Name]                   [varchar] (200) NOT NULL,
    [Tel]                            [varchar] (20) NOT NULL,
    [Email]                          [varchar] (50),
    [Is_Delete]                      [tinyint] DEFAULT (0)  NOT NULL,
    [Delete_Date]                    [datetime],
    [Source]                         [int],
    [Inter_Create_Time]              [datetime],
    [Inter_Modify_Time]              [datetime],
    [User_Key_Num]                   [varchar] (20),
    [User_Type]                      [varchar] (20),
    [Create_Time]                     [datetime],
    [Create_Userid]                   [varchar](50),
    [Update_Time]                     [datetime],
    [Update_Userid]                   [varchar](50),
    CONSTRAINT [PK_TB_User_Change] PRIMARY KEY CLUSTERED([ID] ASC) ON [PRIMARY]
)

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User_Change', @level2type=N'COLUMN', @level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'真实姓名' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User_Change', @level2type=N'COLUMN', @level2name=N'Real_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工号' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User_Change', @level2type=N'COLUMN', @level2name=N'Employee_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User_Change', @level2type=N'COLUMN', @level2name=N'Department_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'在职公司' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User_Change', @level2type=N'COLUMN', @level2name=N'Company_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系电话' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User_Change', @level2type=N'COLUMN', @level2name=N'Tel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User_Change', @level2type=N'COLUMN', @level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否作废' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User_Change', @level2type=N'COLUMN', @level2name=N'Is_Delete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作废时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User_Change', @level2type=N'COLUMN', @level2name=N'Delete_Date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据来源' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User_Change', @level2type=N'COLUMN', @level2name=N'Source'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工创建时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User_Change', @level2type=N'COLUMN', @level2name=N'Inter_Create_Time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'接口修改时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User_Change', @level2type=N'COLUMN', @level2name=N'Inter_Modify_Time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身份证号' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User_Change', @level2type=N'COLUMN', @level2name=N'User_Key_Num'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户类型' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User_Change', @level2type=N'COLUMN', @level2name=N'User_Type'

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TB_User_Loc]') AND type in (N'U'))
DROP TABLE [dbo].[TB_User_Loc]

GO
CREATE TABLE [dbo].[TB_User_Loc]
(
    [ID]                             [int] IDENTITY(1,1) NOT NULL,
    [User_Id]                        [int] NOT NULL,
    [First_Loc_Id]                   [int] NOT NULL,
    [Second_Loc_Id]                  [int],
    [Is_Delete]                      [tinyint] DEFAULT (0)  NOT NULL,
    [Create_Time]                     [datetime],
    [Create_Userid]                   [varchar](50),
    [Update_Time]                     [datetime],
    [Update_Userid]                   [varchar](50),
    CONSTRAINT [PK_TB_User_Loc] PRIMARY KEY CLUSTERED([ID] ASC) ON [PRIMARY]
)

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User_Loc', @level2type=N'COLUMN', @level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User_Loc', @level2type=N'COLUMN', @level2name=N'User_Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主站点ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User_Loc', @level2type=N'COLUMN', @level2name=N'First_Loc_Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'次站点ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User_Loc', @level2type=N'COLUMN', @level2name=N'Second_Loc_Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否作废' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_User_Loc', @level2type=N'COLUMN', @level2name=N'Is_Delete'

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TB_Loc]') AND type in (N'U'))
DROP TABLE [dbo].[TB_Loc]

GO
CREATE TABLE [dbo].[TB_Loc]
(
    [ID]                             [int] IDENTITY(1,1) NOT NULL,
    [Loc_Code]                       [nvarchar] (20) NOT NULL,
    [Loc_Name]                       [nvarchar] (100) NOT NULL,
    [Province_Code]                  [nvarchar] (20) NOT NULL,
    [City_Code]                      [nvarchar] (20) NOT NULL,
    [District_Code]                  [nvarchar] (20) NOT NULL,
    [LocAddress]                     [nvarchar] (255),
    [LocType]                        [nvarchar] (100),
    [Longitude]                      [varchar] (20) NOT NULL,
    [Latitude]                       [varchar] (20) NOT NULL,
    [Status]                         [tinyint] DEFAULT (0)  NOT NULL,
    [CreateTime]                     [datetime] NOT NULL,
    [CreateUserId]                   [tinyint] NOT NULL,
    [UpdateTime]                     [datetime] NOT NULL,
    [UpdateUserId]                   [tinyint] NOT NULL,
    [Create_Time]                     [datetime],
    [Create_Userid]                   [varchar](50),
    [Update_Time]                     [datetime],
    [Update_Userid]                   [varchar](50),
    CONSTRAINT [PK_TB_Loc] PRIMARY KEY CLUSTERED([ID] ASC) ON [PRIMARY]
)

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Loc', @level2type=N'COLUMN', @level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'站点编号' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Loc', @level2type=N'COLUMN', @level2name=N'Loc_Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'站点名称' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Loc', @level2type=N'COLUMN', @level2name=N'Loc_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属省份' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Loc', @level2type=N'COLUMN', @level2name=N'Province_Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属市' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Loc', @level2type=N'COLUMN', @level2name=N'City_Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属区域' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Loc', @level2type=N'COLUMN', @level2name=N'District_Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'站点地址' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Loc', @level2type=N'COLUMN', @level2name=N'LocAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'站点类型' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Loc', @level2type=N'COLUMN', @level2name=N'LocType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'经度' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Loc', @level2type=N'COLUMN', @level2name=N'Longitude'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'纬度' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Loc', @level2type=N'COLUMN', @level2name=N'Latitude'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Loc', @level2type=N'COLUMN', @level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Loc', @level2type=N'COLUMN', @level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Loc', @level2type=N'COLUMN', @level2name=N'CreateUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Loc', @level2type=N'COLUMN', @level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新用户' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Loc', @level2type=N'COLUMN', @level2name=N'UpdateUserId'

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TB_Route]') AND type in (N'U'))
DROP TABLE [dbo].[TB_Route]

GO
CREATE TABLE [dbo].[TB_Route]
(
    [ID]                             [int] IDENTITY(1,1) NOT NULL,
    [Route_Code]                     [varchar] (100) NOT NULL,
    [Route_Name]                     [varchar] (100) NOT NULL,
    [CarrierId]                      [int],
    [Status]                         [tinyint] DEFAULT (0)  NOT NULL,
    [CreateTime]                     [datetime] NOT NULL,
    [CreateUserId]                   [tinyint] NOT NULL,
    [UpdateTime]                     [datetime] NOT NULL,
    [UpdateUserId]                   [tinyint] NOT NULL,
    [Create_Time]                     [datetime],
    [Create_Userid]                   [varchar](50),
    [Update_Time]                     [datetime],
    [Update_Userid]                   [varchar](50),
    CONSTRAINT [PK_TB_Route] PRIMARY KEY CLUSTERED([ID] ASC) ON [PRIMARY]
)

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route', @level2type=N'COLUMN', @level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'路线编号' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route', @level2type=N'COLUMN', @level2name=N'Route_Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路名称' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route', @level2type=N'COLUMN', @level2name=N'Route_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'运营单位' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route', @level2type=N'COLUMN', @level2name=N'CarrierId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route', @level2type=N'COLUMN', @level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route', @level2type=N'COLUMN', @level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route', @level2type=N'COLUMN', @level2name=N'CreateUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route', @level2type=N'COLUMN', @level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新用户' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route', @level2type=N'COLUMN', @level2name=N'UpdateUserId'

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TB_Route_Shift]') AND type in (N'U'))
DROP TABLE [dbo].[TB_Route_Shift]

GO
CREATE TABLE [dbo].[TB_Route_Shift]
(
    [ID]                             [int] IDENTITY(1,1) NOT NULL,
    [Route_Id]                       [int] NOT NULL,
    [Table_Name]                     [varchar] (50),
    [Shift_Code]                     [varchar] (20) NOT NULL,
    [Shift_Type_Code]                [varchar] (20) NOT NULL,
    [Car_Type]                       [varchar] (50),
    [Company_Name]                   [varchar] (100),
    [Plan_Number]                    [int] NOT NULL,
    [Departure_Time]                 [varchar] (5) NOT NULL,
    [Space_Time]                     [int],
    [End_Time]                       [varchar] (5),
    [Status]                         [tinyint] DEFAULT (0)  NOT NULL,
    [CreateTime]                     [datetime] NOT NULL,
    [CreateUserId]                   [tinyint] NOT NULL,
    [UpdateTime]                     [datetime] NOT NULL,
    [UpdateUserId]                   [tinyint] NOT NULL,
    [Create_Time]                     [datetime],
    [Create_Userid]                   [varchar](50),
    [Update_Time]                     [datetime],
    [Update_Userid]                   [varchar](50),
    CONSTRAINT [PK_TB_Route_Shift] PRIMARY KEY CLUSTERED([ID] ASC) ON [PRIMARY]
)

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route_Shift', @level2type=N'COLUMN', @level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'路线ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route_Shift', @level2type=N'COLUMN', @level2name=N'Route_Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'路线所属表' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route_Shift', @level2type=N'COLUMN', @level2name=N'Table_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'班次编码' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route_Shift', @level2type=N'COLUMN', @level2name=N'Shift_Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'班次类型编码' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route_Shift', @level2type=N'COLUMN', @level2name=N'Shift_Type_Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'车型' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route_Shift', @level2type=N'COLUMN', @level2name=N'Car_Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属单位' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route_Shift', @level2type=N'COLUMN', @level2name=N'Company_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划人数' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route_Shift', @level2type=N'COLUMN', @level2name=N'Plan_Number'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发车时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route_Shift', @level2type=N'COLUMN', @level2name=N'Departure_Time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'间隔时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route_Shift', @level2type=N'COLUMN', @level2name=N'Space_Time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预约截止时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route_Shift', @level2type=N'COLUMN', @level2name=N'End_Time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route_Shift', @level2type=N'COLUMN', @level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route_Shift', @level2type=N'COLUMN', @level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route_Shift', @level2type=N'COLUMN', @level2name=N'CreateUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route_Shift', @level2type=N'COLUMN', @level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新用户' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route_Shift', @level2type=N'COLUMN', @level2name=N'UpdateUserId'

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TB_Employee]') AND type in (N'U'))
DROP TABLE [dbo].[TB_Employee]

GO
CREATE TABLE [dbo].[TB_Employee]
(
    [ID]                             [int] IDENTITY(1,1) NOT NULL,
    [EmployeeNo]                     [varchar] (100) NOT NULL,
    [CardNo]                         [varchar] (100),
    [Name]                           [varchar] (255) NOT NULL,
    [Phone]                          [nvarchar] (255) NOT NULL,
    [Email]                          [nvarchar] (255),
    [ImportType]                     [tinyint] NOT NULL,
    [Department]                     [nvarchar] (255),
    [Company]                        [nvarchar] (255),
    [ListType]                       [int] DEFAULT (0)  NOT NULL,
    [Status]                         [tinyint] DEFAULT (0)  NOT NULL,
    [CreateTime]                     [datetime] NOT NULL,
    [CreateUserId]                   [tinyint] NOT NULL,
    [UpdateTime]                     [datetime] NOT NULL,
    [UpdateUserId]                   [tinyint] NOT NULL,
    [Create_Time]                     [datetime],
    [Create_Userid]                   [varchar](50),
    [Update_Time]                     [datetime],
    [Update_Userid]                   [varchar](50),
    CONSTRAINT [PK_TB_Employee] PRIMARY KEY CLUSTERED([ID] ASC) ON [PRIMARY]
)

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Employee', @level2type=N'COLUMN', @level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工号' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Employee', @level2type=N'COLUMN', @level2name=N'EmployeeNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'胸卡卡号' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Employee', @level2type=N'COLUMN', @level2name=N'CardNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Employee', @level2type=N'COLUMN', @level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Employee', @level2type=N'COLUMN', @level2name=N'Phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Employee', @level2type=N'COLUMN', @level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'导入类型' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Employee', @level2type=N'COLUMN', @level2name=N'ImportType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属部门' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Employee', @level2type=N'COLUMN', @level2name=N'Department'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属公司' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Employee', @level2type=N'COLUMN', @level2name=N'Company'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名单类型' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Employee', @level2type=N'COLUMN', @level2name=N'ListType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Employee', @level2type=N'COLUMN', @level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Employee', @level2type=N'COLUMN', @level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Employee', @level2type=N'COLUMN', @level2name=N'CreateUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Employee', @level2type=N'COLUMN', @level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新用户' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Employee', @level2type=N'COLUMN', @level2name=N'UpdateUserId'

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TB_Carrier]') AND type in (N'U'))
DROP TABLE [dbo].[TB_Carrier]

GO
CREATE TABLE [dbo].[TB_Carrier]
(
    [ID]                             [int] IDENTITY(1,1) NOT NULL,
    [CarrierName]                    [varchar] (100) NOT NULL,
    [Contact]                        [varchar] (255) NOT NULL,
    [Mobile]                         [nvarchar] (255),
    [Tel]                            [nvarchar] (255),
    [Address]                        [nvarchar] NOT NULL,
    [Status]                         [tinyint] DEFAULT (0)  NOT NULL,
    [CreateTime]                     [datetime] NOT NULL,
    [CreateUserId]                   [tinyint] NOT NULL,
    [UpdateTime]                     [datetime] NOT NULL,
    [UpdateUserId]                   [tinyint] NOT NULL,
    [Create_Time]                     [datetime],
    [Create_Userid]                   [varchar](50),
    [Update_Time]                     [datetime],
    [Update_Userid]                   [varchar](50),
    CONSTRAINT [PK_TB_Carrier] PRIMARY KEY CLUSTERED([ID] ASC) ON [PRIMARY]
)

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Carrier', @level2type=N'COLUMN', @level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'承运商名称' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Carrier', @level2type=N'COLUMN', @level2name=N'CarrierName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Carrier', @level2type=N'COLUMN', @level2name=N'Contact'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Carrier', @level2type=N'COLUMN', @level2name=N'Mobile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Carrier', @level2type=N'COLUMN', @level2name=N'Tel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Carrier', @level2type=N'COLUMN', @level2name=N'Address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Carrier', @level2type=N'COLUMN', @level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Carrier', @level2type=N'COLUMN', @level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Carrier', @level2type=N'COLUMN', @level2name=N'CreateUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Carrier', @level2type=N'COLUMN', @level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新用户' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Carrier', @level2type=N'COLUMN', @level2name=N'UpdateUserId'

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TB_RoutePublish]') AND type in (N'U'))
DROP TABLE [dbo].[TB_RoutePublish]

GO
CREATE TABLE [dbo].[TB_RoutePublish]
(
    [ID]                             [int] IDENTITY(1,1) NOT NULL,
    [Route_Shift_id]                 [int] NOT NULL,
    [Route_Id]                       [int] NOT NULL,
    [Table_Name]                     [varchar] (50),
    [Shift_Code]                     [varchar] (20) NOT NULL,
    [Shift_Type_Code]                [varchar] (20) NOT NULL,
    [Car_Type]                       [varchar] (50),
    [Company_Name]                   [varchar] (100),
    [Plan_Number]                    [int] NOT NULL,
    [Departure_Time]                 [varchar] (5) NOT NULL,
    [Space_Time]                     [int],
    [End_Time]                       [varchar] (5),
    [Status]                         [tinyint] DEFAULT (0)  NOT NULL,
    [CreateTime]                     [datetime] NOT NULL,
    [CreateUserId]                   [tinyint] NOT NULL,
    [UpdateTime]                     [datetime] NOT NULL,
    [UpdateUserId]                   [tinyint] NOT NULL,
    [Create_Time]                     [datetime],
    [Create_Userid]                   [varchar](50),
    [Update_Time]                     [datetime],
    [Update_Userid]                   [varchar](50),
    CONSTRAINT [PK_TB_RoutePublish] PRIMARY KEY CLUSTERED([ID] ASC) ON [PRIMARY]
)

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RoutePublish', @level2type=N'COLUMN', @level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'班次路线ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RoutePublish', @level2type=N'COLUMN', @level2name=N'Route_Shift_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'路线ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RoutePublish', @level2type=N'COLUMN', @level2name=N'Route_Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'路线所属表' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RoutePublish', @level2type=N'COLUMN', @level2name=N'Table_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'班次编码' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RoutePublish', @level2type=N'COLUMN', @level2name=N'Shift_Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'班次类型编码' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RoutePublish', @level2type=N'COLUMN', @level2name=N'Shift_Type_Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'运营日期' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RoutePublish', @level2type=N'COLUMN', @level2name=N'Car_Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属单位' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RoutePublish', @level2type=N'COLUMN', @level2name=N'Company_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划人数' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RoutePublish', @level2type=N'COLUMN', @level2name=N'Plan_Number'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发车时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RoutePublish', @level2type=N'COLUMN', @level2name=N'Departure_Time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'间隔时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RoutePublish', @level2type=N'COLUMN', @level2name=N'Space_Time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预约截止时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RoutePublish', @level2type=N'COLUMN', @level2name=N'End_Time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RoutePublish', @level2type=N'COLUMN', @level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RoutePublish', @level2type=N'COLUMN', @level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RoutePublish', @level2type=N'COLUMN', @level2name=N'CreateUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RoutePublish', @level2type=N'COLUMN', @level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新用户' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RoutePublish', @level2type=N'COLUMN', @level2name=N'UpdateUserId'

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TB_Rel_POS_Carrier]') AND type in (N'U'))
DROP TABLE [dbo].[TB_Rel_POS_Carrier]

GO
CREATE TABLE [dbo].[TB_Rel_POS_Carrier]
(
    [ID]                             [int] IDENTITY(1,1) NOT NULL,
    [POSId]                          [varchar] (100) NOT NULL,
    [CarrierId]                      [varchar] (255) NOT NULL,
    [Status]                         [tinyint] DEFAULT (0)  NOT NULL,
    [CreateTime]                     [datetime] NOT NULL,
    [CreateUserId]                   [tinyint] NOT NULL,
    [UpdateTime]                     [datetime] NOT NULL,
    [UpdateUserId]                   [tinyint] NOT NULL,
    [Create_Time]                     [datetime],
    [Create_Userid]                   [varchar](50),
    [Update_Time]                     [datetime],
    [Update_Userid]                   [varchar](50),
    CONSTRAINT [PK_TB_Rel_POS_Carrier] PRIMARY KEY CLUSTERED([ID] ASC) ON [PRIMARY]
)

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Rel_POS_Carrier', @level2type=N'COLUMN', @level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'车载机ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Rel_POS_Carrier', @level2type=N'COLUMN', @level2name=N'POSId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'承运商ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Rel_POS_Carrier', @level2type=N'COLUMN', @level2name=N'CarrierId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Rel_POS_Carrier', @level2type=N'COLUMN', @level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Rel_POS_Carrier', @level2type=N'COLUMN', @level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Rel_POS_Carrier', @level2type=N'COLUMN', @level2name=N'CreateUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Rel_POS_Carrier', @level2type=N'COLUMN', @level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新用户' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Rel_POS_Carrier', @level2type=N'COLUMN', @level2name=N'UpdateUserId'

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TB_POS]') AND type in (N'U'))
DROP TABLE [dbo].[TB_POS]

GO
CREATE TABLE [dbo].[TB_POS]
(
    [ID]                             [int] IDENTITY(1,1) NOT NULL,
    [POSNo]                          [varchar] (100) NOT NULL,
    [IP]                             [varchar] (255) NOT NULL,
    [ModelNo]                        [nvarchar] (255),
    [SN]                             [nvarchar] (255),
    [Status]                         [tinyint] DEFAULT (0)  NOT NULL,
    [CreateTime]                     [datetime] NOT NULL,
    [CreateUserId]                   [tinyint] NOT NULL,
    [UpdateTime]                     [datetime] NOT NULL,
    [UpdateUserId]                   [tinyint] NOT NULL,
    [Create_Time]                     [datetime],
    [Create_Userid]                   [varchar](50),
    [Update_Time]                     [datetime],
    [Update_Userid]                   [varchar](50),
    CONSTRAINT [PK_TB_POS] PRIMARY KEY CLUSTERED([ID] ASC) ON [PRIMARY]
)

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_POS', @level2type=N'COLUMN', @level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'车载机编号' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_POS', @level2type=N'COLUMN', @level2name=N'POSNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'车载机地址' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_POS', @level2type=N'COLUMN', @level2name=N'IP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'型号' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_POS', @level2type=N'COLUMN', @level2name=N'ModelNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'S／N' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_POS', @level2type=N'COLUMN', @level2name=N'SN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_POS', @level2type=N'COLUMN', @level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_POS', @level2type=N'COLUMN', @level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_POS', @level2type=N'COLUMN', @level2name=N'CreateUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_POS', @level2type=N'COLUMN', @level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新用户' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_POS', @level2type=N'COLUMN', @level2name=N'UpdateUserId'

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TB_Route_Loc]') AND type in (N'U'))
DROP TABLE [dbo].[TB_Route_Loc]

GO
CREATE TABLE [dbo].[TB_Route_Loc]
(
    [ID]                             [int] IDENTITY(1,1) NOT NULL,
    [Route_Id]                       [int] NOT NULL,
    [Loc_Id]                         [int] NOT NULL,
    [Sequence]                       [int] NOT NULL,
    [Status]                         [tinyint] DEFAULT (0)  NOT NULL,
    [CreateTime]                     [datetime] NOT NULL,
    [CreateUserId]                   [tinyint] NOT NULL,
    [UpdateTime]                     [datetime] NOT NULL,
    [UpdateUserId]                   [tinyint] NOT NULL,
    [Create_Time]                     [datetime],
    [Create_Userid]                   [varchar](50),
    [Update_Time]                     [datetime],
    [Update_Userid]                   [varchar](50),
    CONSTRAINT [PK_TB_Route_Loc] PRIMARY KEY CLUSTERED([ID] ASC) ON [PRIMARY]
)

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route_Loc', @level2type=N'COLUMN', @level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线路ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route_Loc', @level2type=N'COLUMN', @level2name=N'Route_Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'站点ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route_Loc', @level2type=N'COLUMN', @level2name=N'Loc_Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'顺序' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route_Loc', @level2type=N'COLUMN', @level2name=N'Sequence'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route_Loc', @level2type=N'COLUMN', @level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route_Loc', @level2type=N'COLUMN', @level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route_Loc', @level2type=N'COLUMN', @level2name=N'CreateUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route_Loc', @level2type=N'COLUMN', @level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新用户' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Route_Loc', @level2type=N'COLUMN', @level2name=N'UpdateUserId'

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TB_Card]') AND type in (N'U'))
DROP TABLE [dbo].[TB_Card]

GO
CREATE TABLE [dbo].[TB_Card]
(
    [ID]                             [int] IDENTITY(1,1) NOT NULL,
    [CardNo]                         [varchar] (100) NOT NULL,
    [SerialNo]                       [varchar] (255) NOT NULL,
    [EmployeeId]                     [nvarchar] (255),
    [CardType]                       [tinyint],
    [Deposit]                        [tinyint],
    [Balance]                        [tinyint],
    [Count]                          [tinyint],
    [Status]                         [tinyint] DEFAULT (0)  NOT NULL,
    [CreateTime]                     [datetime] NOT NULL,
    [CreateUserId]                   [tinyint] NOT NULL,
    [UpdateTime]                     [datetime] NOT NULL,
    [UpdateUserId]                   [tinyint] NOT NULL,
    [Create_Time]                     [datetime],
    [Create_Userid]                   [varchar](50),
    [Update_Time]                     [datetime],
    [Update_Userid]                   [varchar](50),
    CONSTRAINT [PK_TB_Card] PRIMARY KEY CLUSTERED([ID] ASC) ON [PRIMARY]
)

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Card', @level2type=N'COLUMN', @level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'乘车卡卡号' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Card', @level2type=N'COLUMN', @level2name=N'CardNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'乘车卡流水号' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Card', @level2type=N'COLUMN', @level2name=N'SerialNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工Id' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Card', @level2type=N'COLUMN', @level2name=N'EmployeeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'乘车卡类型' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Card', @level2type=N'COLUMN', @level2name=N'CardType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'押金' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Card', @level2type=N'COLUMN', @level2name=N'Deposit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'余额' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Card', @level2type=N'COLUMN', @level2name=N'Balance'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'次数' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Card', @level2type=N'COLUMN', @level2name=N'Count'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Card', @level2type=N'COLUMN', @level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Card', @level2type=N'COLUMN', @level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Card', @level2type=N'COLUMN', @level2name=N'CreateUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Card', @level2type=N'COLUMN', @level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新用户' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Card', @level2type=N'COLUMN', @level2name=N'UpdateUserId'

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TB_RideRecord]') AND type in (N'U'))
DROP TABLE [dbo].[TB_RideRecord]

GO
CREATE TABLE [dbo].[TB_RideRecord]
(
    [ID]                             [int] IDENTITY(1,1) NOT NULL,
    [Ride_Date]                      [datetime] NOT NULL,
    [EmployeeId]                     [int] NOT NULL,
    [Shift_Type_Code]                [int] NOT NULL,
    [Source]                         [nvarchar] NOT NULL,
    [UpTime]                         [datetime] DEFAULT (0)  NOT NULL,
    [DowmTime]                       [datetime],
    [UpLoc]                          [int],
    [DowmLoc]                        [int],
    [Company]                        [nvarchar],
    [LocType]                        [nvarchar],
    [TruckNo]                        [nvarchar],
    [CreateTime]                     [datetime] NOT NULL,
    [CreateUserId]                   [tinyint] NOT NULL,
    [UpdateTime]                     [datetime] NOT NULL,
    [UpdateUserId]                   [tinyint] NOT NULL,
    [Create_Time]                     [datetime],
    [Create_Userid]                   [varchar](50),
    [Update_Time]                     [datetime],
    [Update_Userid]                   [varchar](50),
    CONSTRAINT [PK_TB_RideRecord] PRIMARY KEY CLUSTERED([ID] ASC) ON [PRIMARY]
)

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RideRecord', @level2type=N'COLUMN', @level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'乘车时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RideRecord', @level2type=N'COLUMN', @level2name=N'Ride_Date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RideRecord', @level2type=N'COLUMN', @level2name=N'EmployeeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'班次类型' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RideRecord', @level2type=N'COLUMN', @level2name=N'Shift_Type_Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据来源' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RideRecord', @level2type=N'COLUMN', @level2name=N'Source'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上车时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RideRecord', @level2type=N'COLUMN', @level2name=N'UpTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下车时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RideRecord', @level2type=N'COLUMN', @level2name=N'DowmTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上车站点' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RideRecord', @level2type=N'COLUMN', @level2name=N'UpLoc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下车站点' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RideRecord', @level2type=N'COLUMN', @level2name=N'DowmLoc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属公司' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RideRecord', @level2type=N'COLUMN', @level2name=N'Company'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'站点类型' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RideRecord', @level2type=N'COLUMN', @level2name=N'LocType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'车牌号' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RideRecord', @level2type=N'COLUMN', @level2name=N'TruckNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RideRecord', @level2type=N'COLUMN', @level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RideRecord', @level2type=N'COLUMN', @level2name=N'CreateUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RideRecord', @level2type=N'COLUMN', @level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新用户' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_RideRecord', @level2type=N'COLUMN', @level2name=N'UpdateUserId'

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TB_Notice]') AND type in (N'U'))
DROP TABLE [dbo].[TB_Notice]

GO
CREATE TABLE [dbo].[TB_Notice]
(
    [ID]                             [int] IDENTITY(1,1) NOT NULL,
    [Title]                          [varchar] (100) NOT NULL,
    [Content]                        [varchar] (1000) NOT NULL,
    [Publish_Date]                   [datetime] NOT NULL,
    [User_Id]                        [int] NOT NULL,
    [Picture_Server_Host]            [varchar] (255),
    [Picture_Url]                    [varchar] (255),
    [Source]                         [int] DEFAULT (0)  NOT NULL,
    [Status]                         [tinyint] DEFAULT (0)  NOT NULL,
    [Create_Time]                     [datetime],
    [Create_Userid]                   [varchar](50),
    [Update_Time]                     [datetime],
    [Update_Userid]                   [varchar](50),
    CONSTRAINT [PK_TB_Notice] PRIMARY KEY CLUSTERED([ID] ASC) ON [PRIMARY]
)

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Notice', @level2type=N'COLUMN', @level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Notice', @level2type=N'COLUMN', @level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Notice', @level2type=N'COLUMN', @level2name=N'Content'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布日期' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Notice', @level2type=N'COLUMN', @level2name=N'Publish_Date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布人ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Notice', @level2type=N'COLUMN', @level2name=N'User_Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片服务器地址' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Notice', @level2type=N'COLUMN', @level2name=N'Picture_Server_Host'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片URL' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Notice', @level2type=N'COLUMN', @level2name=N'Picture_Url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消息来源' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Notice', @level2type=N'COLUMN', @level2name=N'Source'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Notice', @level2type=N'COLUMN', @level2name=N'Status'

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TB_Feedback]') AND type in (N'U'))
DROP TABLE [dbo].[TB_Feedback]

GO
CREATE TABLE [dbo].[TB_Feedback]
(
    [ID]                             [int] IDENTITY(1,1) NOT NULL,
    [Title]                          [varchar] (100) NOT NULL,
    [Type_Code]                      [varchar] (20) NOT NULL,
    [Content]                        [varchar] (1000) NOT NULL,
    [Publish_Date]                   [datetime] NOT NULL,
    [Publish_User_Id]                [int] NOT NULL,
    [Reply_Num]                      [int] DEFAULT (0)  NOT NULL,
    [Status]                         [tinyint] DEFAULT (0)  NOT NULL,
    [Create_Time]                     [datetime],
    [Create_Userid]                   [varchar](50),
    [Update_Time]                     [datetime],
    [Update_Userid]                   [varchar](50),
    CONSTRAINT [PK_TB_Feedback] PRIMARY KEY CLUSTERED([ID] ASC) ON [PRIMARY]
)

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Feedback', @level2type=N'COLUMN', @level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Feedback', @level2type=N'COLUMN', @level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Feedback', @level2type=N'COLUMN', @level2name=N'Type_Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Feedback', @level2type=N'COLUMN', @level2name=N'Content'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布日期' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Feedback', @level2type=N'COLUMN', @level2name=N'Publish_Date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布人ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Feedback', @level2type=N'COLUMN', @level2name=N'Publish_User_Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'回复数' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Feedback', @level2type=N'COLUMN', @level2name=N'Reply_Num'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Feedback', @level2type=N'COLUMN', @level2name=N'Status'

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TB_Feedback_Reply]') AND type in (N'U'))
DROP TABLE [dbo].[TB_Feedback_Reply]

GO
CREATE TABLE [dbo].[TB_Feedback_Reply]
(
    [ID]                             [int] IDENTITY(1,1) NOT NULL,
    [Feedback_Id]                    [int] DEFAULT (0)  NOT NULL,
    [Content]                        [varchar] (1000) NOT NULL,
    [Publish_Date]                   [datetime] NOT NULL,
    [User_Id]                        [int] NOT NULL,
    [Status]                         [tinyint] DEFAULT (0)  NOT NULL,
    [Create_Time]                     [datetime],
    [Create_Userid]                   [varchar](50),
    [Update_Time]                     [datetime],
    [Update_Userid]                   [varchar](50),
    CONSTRAINT [PK_TB_Feedback_Reply] PRIMARY KEY CLUSTERED([ID] ASC) ON [PRIMARY]
)

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Feedback_Reply', @level2type=N'COLUMN', @level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主消息ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Feedback_Reply', @level2type=N'COLUMN', @level2name=N'Feedback_Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Feedback_Reply', @level2type=N'COLUMN', @level2name=N'Content'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布日期' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Feedback_Reply', @level2type=N'COLUMN', @level2name=N'Publish_Date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布人ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Feedback_Reply', @level2type=N'COLUMN', @level2name=N'User_Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Feedback_Reply', @level2type=N'COLUMN', @level2name=N'Status'

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TB_About]') AND type in (N'U'))
DROP TABLE [dbo].[TB_About]

GO
CREATE TABLE [dbo].[TB_About]
(
    [ID]                             [int] IDENTITY(1,1) NOT NULL,
    [Content]                        [text],
    [Create_Time]                     [datetime],
    [Create_Userid]                   [varchar](50),
    [Update_Time]                     [datetime],
    [Update_Userid]                   [varchar](50),
    CONSTRAINT [PK_TB_About] PRIMARY KEY CLUSTERED([ID] ASC) ON [PRIMARY]
)

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_About', @level2type=N'COLUMN', @level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_About', @level2type=N'COLUMN', @level2name=N'Content'

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TB_Dict]') AND type in (N'U'))
DROP TABLE [dbo].[TB_Dict]

GO
CREATE TABLE [dbo].[TB_Dict]
(
    [ID]                             [int] IDENTITY(1,1) NOT NULL,
    [Code]                           [varchar] (20) NOT NULL,
    [Name]                           [varchar] (100) NOT NULL,
    [Parent_Code]                    [varchar] (20) NOT NULL,
    [Status]                         [tinyint] DEFAULT (0)  NOT NULL,
    [Create_Time]                     [datetime],
    [Create_Userid]                   [varchar](50),
    [Update_Time]                     [datetime],
    [Update_Userid]                   [varchar](50),
    CONSTRAINT [PK_TB_Dict] PRIMARY KEY CLUSTERED([ID] ASC) ON [PRIMARY]
)

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Dict', @level2type=N'COLUMN', @level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编码' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Dict', @level2type=N'COLUMN', @level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Dict', @level2type=N'COLUMN', @level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上级编码' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Dict', @level2type=N'COLUMN', @level2name=N'Parent_Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' 
, @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'TB_Dict', @level2type=N'COLUMN', @level2name=N'Status'

