USE [master]
GO
/****** Object:  Database [QuotaSoftDb]    Script Date: 31/07/2023 1:19:28 a. m. ******/
CREATE DATABASE [QuotaSoftDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuotaSoftDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QuotaSoftDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuotaSoftDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QuotaSoftDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QuotaSoftDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuotaSoftDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuotaSoftDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuotaSoftDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuotaSoftDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuotaSoftDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuotaSoftDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuotaSoftDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuotaSoftDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuotaSoftDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuotaSoftDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuotaSoftDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuotaSoftDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuotaSoftDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuotaSoftDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuotaSoftDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuotaSoftDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuotaSoftDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuotaSoftDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuotaSoftDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuotaSoftDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuotaSoftDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuotaSoftDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuotaSoftDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuotaSoftDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuotaSoftDb] SET  MULTI_USER 
GO
ALTER DATABASE [QuotaSoftDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuotaSoftDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuotaSoftDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuotaSoftDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuotaSoftDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuotaSoftDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QuotaSoftDb] SET QUERY_STORE = OFF
GO
USE [QuotaSoftDb]
GO
/****** Object:  Table [dbo].[EntEntity]    Script Date: 31/07/2023 1:19:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntEntity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BusinessNumber] [int] NOT NULL,
	[BusinessName] [nvarchar](max) NOT NULL,
	[IsPartQuotaEntity] [bit] NOT NULL,
	[IsProvidingEntity] [bit] NOT NULL,
	[IsEmployingEntity] [bit] NOT NULL,
	[IsLiquidated] [bit] NOT NULL,
 CONSTRAINT [PK_EntEntity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LcpLiquidationPartQuota]    Script Date: 31/07/2023 1:19:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LcpLiquidationPartQuota](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LiquidationNumber] [int] NOT NULL,
	[LiquidationType] [int] NOT NULL,
	[LiquidationYear] [int] NOT NULL,
	[PerUserRetiredId] [int] NULL,
	[RetireResolutionNumber] [int] NOT NULL,
	[RetireResolutionDate] [datetime] NULL,
	[DoneDatePayment] [datetime] NULL,
	[CutoffDate] [datetime] NULL,
	[AllowenceValueMonthly] [numeric](18, 2) NOT NULL,
	[AllowenceValueCurrently] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_LcpLiquidationPartQuota] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LcpLiquidationPayment]    Script Date: 31/07/2023 1:19:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LcpLiquidationPayment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LcpPaymentId] [int] NULL,
	[LcpLiquidationPartQuotaId] [int] NULL,
	[LiquidationPaymentValue] [numeric](18, 2) NULL,
 CONSTRAINT [PK_LcpLiquidationPayment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LcpMonthlyLiquidation]    Script Date: 31/07/2023 1:19:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LcpMonthlyLiquidation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LcpLiquidationPartQuotaId] [int] NULL,
	[Year] [int] NOT NULL,
	[Month] [int] NOT NULL,
	[AllowenceValueMonthly] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_LcpMonthlyLiquidation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LcpMonthlyLiquidationEntity]    Script Date: 31/07/2023 1:19:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LcpMonthlyLiquidationEntity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LcpMonthlyLiquidationId] [int] NULL,
	[AllowenceValueMonthlyEntity] [numeric](18, 2) NOT NULL,
	[CurrentTax] [numeric](18, 2) NOT NULL,
	[EntEntityId] [int] NULL,
 CONSTRAINT [PK_MonthlyLiquidationEntity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LcpPayment]    Script Date: 31/07/2023 1:19:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LcpPayment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PaymentCode] [nvarchar](50) NULL,
	[EntEntityId] [int] NULL,
	[LiquidationDate] [datetime] NULL,
	[PaymentTotalValue] [numeric](18, 2) NULL,
	[PaymentDueDate] [datetime] NULL,
	[PaymentStatus] [int] NULL,
	[PaymentDate] [datetime] NULL,
	[PaymentMethod] [int] NULL,
	[PaymentCodeConfirmation] [nvarchar](50) NULL,
 CONSTRAINT [PK_LcpPayment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LcpRetireSubstitute]    Script Date: 31/07/2023 1:19:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LcpRetireSubstitute](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LcpLiquidationPartQuotaId] [int] NULL,
	[PerUserSusbtituteId] [int] NULL,
	[ResolutionNumberSubstitute] [int] NULL,
	[ResolutionSubstituteDate] [datetime] NULL,
	[SubstitutePercent] [numeric](18, 2) NOT NULL,
	[ContributionPercent] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_LcpRetireSubstitute] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LcpWorkPeriod]    Script Date: 31/07/2023 1:19:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LcpWorkPeriod](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LcpLiquidationPartQuotaId] [int] NULL,
	[EntEntityId] [int] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[WorkDay] [numeric](18, 2) NOT NULL,
	[PercentContribution] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_LcpWorkPeriod] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 31/07/2023 1:19:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RolName] [nvarchar](max) NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 31/07/2023 1:19:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NumberId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[RolId] [int] NULL,
 CONSTRAINT [PK_PerUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[EntEntity] ADD  CONSTRAINT [DF_EntEntity_IsPartQuotaEntity]  DEFAULT ((0)) FOR [IsPartQuotaEntity]
GO
ALTER TABLE [dbo].[EntEntity] ADD  CONSTRAINT [DF_EntEntity_IsProvidingEntity]  DEFAULT ((0)) FOR [IsProvidingEntity]
GO
ALTER TABLE [dbo].[EntEntity] ADD  CONSTRAINT [DF_EntEntity_IsEmployingEntity]  DEFAULT ((0)) FOR [IsEmployingEntity]
GO
ALTER TABLE [dbo].[EntEntity] ADD  CONSTRAINT [DF_EntEntity_IsLiquidated]  DEFAULT ((0)) FOR [IsLiquidated]
GO
ALTER TABLE [dbo].[LcpLiquidationPartQuota] ADD  CONSTRAINT [DF_LcpLiquidationPartQuota_LiquidationNumber]  DEFAULT ((0)) FOR [LiquidationNumber]
GO
ALTER TABLE [dbo].[LcpLiquidationPartQuota] ADD  CONSTRAINT [DF_LcpLiquidationPartQuota_LiquidationType]  DEFAULT ((0)) FOR [LiquidationType]
GO
ALTER TABLE [dbo].[LcpLiquidationPartQuota] ADD  CONSTRAINT [DF_LcpLiquidationPartQuota_LiquidationYear]  DEFAULT ((0)) FOR [LiquidationYear]
GO
ALTER TABLE [dbo].[LcpLiquidationPartQuota] ADD  CONSTRAINT [DF_Table_1_RetiredResolutionNumber]  DEFAULT ((0)) FOR [RetireResolutionNumber]
GO
ALTER TABLE [dbo].[LcpLiquidationPartQuota] ADD  CONSTRAINT [DF_LcpLiquidationPartQuota_AllowenceValueMonthly]  DEFAULT ((0)) FOR [AllowenceValueMonthly]
GO
ALTER TABLE [dbo].[LcpLiquidationPartQuota] ADD  CONSTRAINT [DF_LcpLiquidationPartQuota_AllowenceValueCurrently]  DEFAULT ((0)) FOR [AllowenceValueCurrently]
GO
ALTER TABLE [dbo].[LcpMonthlyLiquidation] ADD  CONSTRAINT [DF_LcpMonthlyLiquidation_Year]  DEFAULT ((0)) FOR [Year]
GO
ALTER TABLE [dbo].[LcpMonthlyLiquidation] ADD  CONSTRAINT [DF_LcpMonthlyLiquidation_Month]  DEFAULT ((0)) FOR [Month]
GO
ALTER TABLE [dbo].[LcpMonthlyLiquidation] ADD  CONSTRAINT [DF_LcpMonthlyLiquidation_AllowenceValueMonthly]  DEFAULT ((0)) FOR [AllowenceValueMonthly]
GO
ALTER TABLE [dbo].[LcpMonthlyLiquidationEntity] ADD  CONSTRAINT [DF_LcpMonthlyLiquidationEntity_AllowenceValueMonthlyEntity]  DEFAULT ((0)) FOR [AllowenceValueMonthlyEntity]
GO
ALTER TABLE [dbo].[LcpMonthlyLiquidationEntity] ADD  CONSTRAINT [DF_LcpMonthlyLiquidationEntity_CurrentTax]  DEFAULT ((0)) FOR [CurrentTax]
GO
ALTER TABLE [dbo].[LcpRetireSubstitute] ADD  CONSTRAINT [DF_LcpRetireSubstitute_SubstitutePercent]  DEFAULT ((0)) FOR [SubstitutePercent]
GO
ALTER TABLE [dbo].[LcpRetireSubstitute] ADD  CONSTRAINT [DF_LcpRetireSubstitute_ContributionPercent]  DEFAULT ((0)) FOR [ContributionPercent]
GO
ALTER TABLE [dbo].[LcpWorkPeriod] ADD  CONSTRAINT [DF_LcpWorkPeriod_WorkDay]  DEFAULT ((0)) FOR [WorkDay]
GO
ALTER TABLE [dbo].[LcpWorkPeriod] ADD  CONSTRAINT [DF_LcpWorkPeriod_PercentContribution]  DEFAULT ((0)) FOR [PercentContribution]
GO
ALTER TABLE [dbo].[Rol] ADD  CONSTRAINT [DF_Rol_Active]  DEFAULT ((0)) FOR [Active]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_PerUser_NumberId]  DEFAULT ((0)) FOR [NumberId]
GO
ALTER TABLE [dbo].[LcpLiquidationPartQuota]  WITH CHECK ADD  CONSTRAINT [FK_LcpLiquidationPartQuota_User] FOREIGN KEY([PerUserRetiredId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[LcpLiquidationPartQuota] CHECK CONSTRAINT [FK_LcpLiquidationPartQuota_User]
GO
ALTER TABLE [dbo].[LcpLiquidationPayment]  WITH CHECK ADD  CONSTRAINT [FK_LcpLiquidationPayment_LcpLiquidationPartQuota] FOREIGN KEY([LcpLiquidationPartQuotaId])
REFERENCES [dbo].[LcpLiquidationPartQuota] ([Id])
GO
ALTER TABLE [dbo].[LcpLiquidationPayment] CHECK CONSTRAINT [FK_LcpLiquidationPayment_LcpLiquidationPartQuota]
GO
ALTER TABLE [dbo].[LcpLiquidationPayment]  WITH CHECK ADD  CONSTRAINT [FK_LcpLiquidationPayment_LcpPayment] FOREIGN KEY([LcpPaymentId])
REFERENCES [dbo].[LcpPayment] ([Id])
GO
ALTER TABLE [dbo].[LcpLiquidationPayment] CHECK CONSTRAINT [FK_LcpLiquidationPayment_LcpPayment]
GO
ALTER TABLE [dbo].[LcpMonthlyLiquidation]  WITH CHECK ADD  CONSTRAINT [FK_LcpMonthlyLiquidation_LcpLiquidationPartQuota] FOREIGN KEY([LcpLiquidationPartQuotaId])
REFERENCES [dbo].[LcpLiquidationPartQuota] ([Id])
GO
ALTER TABLE [dbo].[LcpMonthlyLiquidation] CHECK CONSTRAINT [FK_LcpMonthlyLiquidation_LcpLiquidationPartQuota]
GO
ALTER TABLE [dbo].[LcpMonthlyLiquidationEntity]  WITH CHECK ADD  CONSTRAINT [FK_LcpMonthlyLiquidationEntity_EntEntity] FOREIGN KEY([EntEntityId])
REFERENCES [dbo].[EntEntity] ([Id])
GO
ALTER TABLE [dbo].[LcpMonthlyLiquidationEntity] CHECK CONSTRAINT [FK_LcpMonthlyLiquidationEntity_EntEntity]
GO
ALTER TABLE [dbo].[LcpMonthlyLiquidationEntity]  WITH CHECK ADD  CONSTRAINT [FK_LcpMonthlyLiquidationEntity_LcpMonthlyLiquidationEntity] FOREIGN KEY([Id])
REFERENCES [dbo].[LcpMonthlyLiquidationEntity] ([Id])
GO
ALTER TABLE [dbo].[LcpMonthlyLiquidationEntity] CHECK CONSTRAINT [FK_LcpMonthlyLiquidationEntity_LcpMonthlyLiquidationEntity]
GO
ALTER TABLE [dbo].[LcpPayment]  WITH CHECK ADD  CONSTRAINT [FK_LcpPayment_EntEntity] FOREIGN KEY([EntEntityId])
REFERENCES [dbo].[EntEntity] ([Id])
GO
ALTER TABLE [dbo].[LcpPayment] CHECK CONSTRAINT [FK_LcpPayment_EntEntity]
GO
ALTER TABLE [dbo].[LcpRetireSubstitute]  WITH CHECK ADD  CONSTRAINT [FK_LcpRetireSubstitute_User] FOREIGN KEY([PerUserSusbtituteId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[LcpRetireSubstitute] CHECK CONSTRAINT [FK_LcpRetireSubstitute_User]
GO
ALTER TABLE [dbo].[LcpWorkPeriod]  WITH CHECK ADD  CONSTRAINT [FK_LcpWorkPeriod_LcpLiquidationPartQuota] FOREIGN KEY([LcpLiquidationPartQuotaId])
REFERENCES [dbo].[LcpLiquidationPartQuota] ([Id])
GO
ALTER TABLE [dbo].[LcpWorkPeriod] CHECK CONSTRAINT [FK_LcpWorkPeriod_LcpLiquidationPartQuota]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Rol] FOREIGN KEY([RolId])
REFERENCES [dbo].[Rol] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Rol]
GO
USE [master]
GO
ALTER DATABASE [QuotaSoftDb] SET  READ_WRITE 
GO
