USE [GlobalLogistics]
GO
ALTER TABLE [dbo].[familia_patente] DROP CONSTRAINT [FK_familia_patente_patente]
GO
ALTER TABLE [dbo].[familia_patente] DROP CONSTRAINT [FK_familia_patente_familia]
GO
ALTER TABLE [dbo].[cuenta_usuario_patente] DROP CONSTRAINT [FK_cuenta_usuario_patente_patente]
GO
ALTER TABLE [dbo].[cuenta_usuario_patente] DROP CONSTRAINT [FK_cuenta_usuario_patente_cuenta_usuario]
GO
ALTER TABLE [dbo].[cuenta_usuario_familia] DROP CONSTRAINT [FK_cuenta_usuario_familia_familia]
GO
ALTER TABLE [dbo].[cuenta_usuario_familia] DROP CONSTRAINT [FK_cuenta_usuario_familia_cuenta_usuario]
GO
ALTER TABLE [dbo].[bitacora] DROP CONSTRAINT [FK_bitacora_bitacora_tipo_movimiento]
GO
ALTER TABLE [dbo].[cuenta_usuario] DROP CONSTRAINT [DF_cuenta_usuario_cuenta_usuario_DVH]
GO
ALTER TABLE [dbo].[cuenta_usuario] DROP CONSTRAINT [DF_cuenta_usuario_cuenta_activa]
GO
/****** Object:  Table [dbo].[usuario_permiso]    Script Date: 23/10/2022 11:47:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usuario_permiso]') AND type in (N'U'))
DROP TABLE [dbo].[usuario_permiso]
GO
/****** Object:  Table [dbo].[producto]    Script Date: 23/10/2022 11:47:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[producto]') AND type in (N'U'))
DROP TABLE [dbo].[producto]
GO
/****** Object:  Table [dbo].[permiso_permiso]    Script Date: 23/10/2022 11:47:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[permiso_permiso]') AND type in (N'U'))
DROP TABLE [dbo].[permiso_permiso]
GO
/****** Object:  Table [dbo].[permiso]    Script Date: 23/10/2022 11:47:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[permiso]') AND type in (N'U'))
DROP TABLE [dbo].[permiso]
GO
/****** Object:  Table [dbo].[patente]    Script Date: 23/10/2022 11:47:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[patente]') AND type in (N'U'))
DROP TABLE [dbo].[patente]
GO
/****** Object:  Table [dbo].[familia_patente]    Script Date: 23/10/2022 11:47:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[familia_patente]') AND type in (N'U'))
DROP TABLE [dbo].[familia_patente]
GO
/****** Object:  Table [dbo].[familia]    Script Date: 23/10/2022 11:47:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[familia]') AND type in (N'U'))
DROP TABLE [dbo].[familia]
GO
/****** Object:  Table [dbo].[DVV]    Script Date: 23/10/2022 11:47:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DVV]') AND type in (N'U'))
DROP TABLE [dbo].[DVV]
GO
/****** Object:  Table [dbo].[cuenta_usuario_patente]    Script Date: 23/10/2022 11:47:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cuenta_usuario_patente]') AND type in (N'U'))
DROP TABLE [dbo].[cuenta_usuario_patente]
GO
/****** Object:  Table [dbo].[cuenta_usuario_familia]    Script Date: 23/10/2022 11:47:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cuenta_usuario_familia]') AND type in (N'U'))
DROP TABLE [dbo].[cuenta_usuario_familia]
GO
/****** Object:  Table [dbo].[cuenta_usuario]    Script Date: 23/10/2022 11:47:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cuenta_usuario]') AND type in (N'U'))
DROP TABLE [dbo].[cuenta_usuario]
GO
/****** Object:  Table [dbo].[bitacora_tipo_movimiento]    Script Date: 23/10/2022 11:47:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bitacora_tipo_movimiento]') AND type in (N'U'))
DROP TABLE [dbo].[bitacora_tipo_movimiento]
GO
/****** Object:  Table [dbo].[bitacora]    Script Date: 23/10/2022 11:47:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bitacora]') AND type in (N'U'))
DROP TABLE [dbo].[bitacora]
GO
USE [master]
GO
/****** Object:  Database [GlobalLogistics]    Script Date: 23/10/2022 11:47:05 ******/
DROP DATABASE [GlobalLogistics]
GO
/****** Object:  Database [GlobalLogistics]    Script Date: 23/10/2022 11:47:05 ******/
CREATE DATABASE [GlobalLogistics]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GlobalLogistics', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.GLOBAL\MSSQL\DATA\GlobalLogistics.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GlobalLogistics_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.GLOBAL\MSSQL\DATA\GlobalLogistics_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [GlobalLogistics] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GlobalLogistics].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GlobalLogistics] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GlobalLogistics] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GlobalLogistics] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GlobalLogistics] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GlobalLogistics] SET ARITHABORT OFF 
GO
ALTER DATABASE [GlobalLogistics] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GlobalLogistics] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GlobalLogistics] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GlobalLogistics] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GlobalLogistics] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GlobalLogistics] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GlobalLogistics] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GlobalLogistics] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GlobalLogistics] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GlobalLogistics] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GlobalLogistics] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GlobalLogistics] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GlobalLogistics] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GlobalLogistics] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GlobalLogistics] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GlobalLogistics] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GlobalLogistics] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GlobalLogistics] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GlobalLogistics] SET  MULTI_USER 
GO
ALTER DATABASE [GlobalLogistics] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GlobalLogistics] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GlobalLogistics] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GlobalLogistics] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [GlobalLogistics] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GlobalLogistics] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'GlobalLogistics', N'ON'
GO
ALTER DATABASE [GlobalLogistics] SET QUERY_STORE = OFF
GO
USE [GlobalLogistics]
GO
/****** Object:  Table [dbo].[bitacora]    Script Date: 23/10/2022 11:47:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bitacora](
	[bitacora_id] [int] NOT NULL,
	[cuenta_usuario_id] [int] NOT NULL,
	[bitacora_criticidad] [int] NOT NULL,
	[bitacora_transaccion_id] [int] NOT NULL,
	[bitacora_fecha] [date] NOT NULL,
	[bitacora_hora] [time](7) NOT NULL,
	[bitacora_dvh] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_bitacora] PRIMARY KEY CLUSTERED 
(
	[bitacora_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bitacora_tipo_movimiento]    Script Date: 23/10/2022 11:47:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bitacora_tipo_movimiento](
	[bitacora_transaccion_id] [int] NOT NULL,
	[bitacora_transaccion_desc] [varchar](139) NOT NULL,
 CONSTRAINT [PK_bitacora_tipo_movimiento] PRIMARY KEY CLUSTERED 
(
	[bitacora_transaccion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cuenta_usuario]    Script Date: 23/10/2022 11:47:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuenta_usuario](
	[cuenta_usuario_id] [int] NOT NULL,
	[cuenta_usuario_username] [nvarchar](500) NOT NULL,
	[cuenta_usuario_password] [nvarchar](500) NOT NULL,
	[cuenta_usuario_intentos_login] [int] NOT NULL,
	[cuenta_fecha_alta] [date] NOT NULL,
	[cuenta_usuario_activa] [int] NOT NULL,
	[cuenta_usuario_DVH] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_cuenta_usuario] PRIMARY KEY CLUSTERED 
(
	[cuenta_usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cuenta_usuario_familia]    Script Date: 23/10/2022 11:47:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuenta_usuario_familia](
	[cuenta_usuario_id] [int] NOT NULL,
	[familia_id] [int] NOT NULL,
	[cuenta_usuario_familia_dvh] [nvarchar](500) NULL,
 CONSTRAINT [PK_cuenta_usuario_familia] PRIMARY KEY CLUSTERED 
(
	[cuenta_usuario_id] ASC,
	[familia_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cuenta_usuario_patente]    Script Date: 23/10/2022 11:47:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuenta_usuario_patente](
	[cuenta_usuario_id] [int] NOT NULL,
	[patente_id] [int] NOT NULL,
	[cuenta_usuario_patente_dvh] [nvarchar](500) NULL,
 CONSTRAINT [PK_cuenta_usuario_patente] PRIMARY KEY CLUSTERED 
(
	[cuenta_usuario_id] ASC,
	[patente_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DVV]    Script Date: 23/10/2022 11:47:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DVV](
	[tabla] [varchar](50) NOT NULL,
	[dvv_valor] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_DVV] PRIMARY KEY CLUSTERED 
(
	[tabla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[familia]    Script Date: 23/10/2022 11:47:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[familia](
	[familia_id] [int] NOT NULL,
	[familia_nombre] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_familia] PRIMARY KEY CLUSTERED 
(
	[familia_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[familia_patente]    Script Date: 23/10/2022 11:47:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[familia_patente](
	[familia_id] [int] NOT NULL,
	[patente_id] [int] NOT NULL,
	[familia_patente_dvh] [nvarchar](500) NULL,
 CONSTRAINT [PK_familia_patente] PRIMARY KEY CLUSTERED 
(
	[familia_id] ASC,
	[patente_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[patente]    Script Date: 23/10/2022 11:47:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[patente](
	[patente_id] [int] NOT NULL,
	[patente_nombre] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_patente] PRIMARY KEY CLUSTERED 
(
	[patente_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[permiso]    Script Date: 23/10/2022 11:47:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permiso](
	[permiso_id] [int] NOT NULL,
	[permiso_nombre] [varchar](50) NOT NULL,
	[permiso_desc] [varchar](50) NOT NULL,
 CONSTRAINT [PK_permiso] PRIMARY KEY CLUSTERED 
(
	[permiso_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[permiso_permiso]    Script Date: 23/10/2022 11:47:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permiso_permiso](
	[permiso_padre_id] [int] NOT NULL,
	[permiso_hijo_id] [int] NOT NULL,
 CONSTRAINT [PK_permiso_permiso] PRIMARY KEY CLUSTERED 
(
	[permiso_padre_id] ASC,
	[permiso_hijo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[producto]    Script Date: 23/10/2022 11:47:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producto](
	[producto_id] [int] NOT NULL,
	[producto_nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_producto] PRIMARY KEY CLUSTERED 
(
	[producto_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario_permiso]    Script Date: 23/10/2022 11:47:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario_permiso](
	[usuario_id] [int] NOT NULL,
	[permiso_id] [int] NOT NULL,
 CONSTRAINT [PK_usuario_permiso] PRIMARY KEY CLUSTERED 
(
	[usuario_id] ASC,
	[permiso_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (41, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'14:37:52.6639739' AS Time), N'e0lig9vXRVE3cX3IRUP0HQ==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (42, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'14:40:19.3085781' AS Time), N'sirWjR7qcK7RO0jzG9nuRQ==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (45, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'15:25:47.5053954' AS Time), N'W7f1iV/WZ7SSf9SPF7H00A==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (46, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'15:30:27.1208042' AS Time), N'gCR+oIz4gfPaBwPpZrR7Zw==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (47, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'14:55:21.0016143' AS Time), N'BXDI2eV3cLeKrimV9Tkn8w==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (48, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'14:57:29.9588628' AS Time), N'DImRgS1iSQeL9QpNiC/VEw==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (51, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'15:23:03.2045817' AS Time), N'PP7hZVeKGM+4x4tkAYyVUA==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (52, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'15:24:07.2241865' AS Time), N'n0af3lBjvXLzl36/EHbEkQ==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (54, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'15:27:31.8684483' AS Time), N'yz5FoPmiLYUMKYZmp7s+Og==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (56, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'15:36:22.0106098' AS Time), N'n0af3lBjvXLzl36/EHbEkQ==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (57, 1, 4, 6, CAST(N'2022-07-05' AS Date), CAST(N'15:37:02.5201921' AS Time), N'u3dVfFWTio+yB5UgAvZn9A==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (58, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'15:37:22.2770889' AS Time), N'ztavdah8h4fUmfte3HRiTA==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (59, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'15:39:47.5858565' AS Time), N'XkQnlq6PR5+nD19eH7UxOQ==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (60, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'15:41:50.0568285' AS Time), N'u3dVfFWTio+yB5UgAvZn9A==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (61, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'15:43:13.3837757' AS Time), N'W7f1iV/WZ7SSf9SPF7H00A==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (62, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'15:44:03.4033552' AS Time), N'PP7hZVeKGM+4x4tkAYyVUA==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (63, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'15:44:52.7959132' AS Time), N'fvwqKkbEzKiNWHNMHYK2Lw==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (64, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'15:46:45.8737359' AS Time), N's/NbJrC28OpWCX35z2dUwg==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (66, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'15:48:28.9813735' AS Time), N'gHZ936zP12GcvKRnkvN17g==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (67, 1, 4, 6, CAST(N'2022-07-05' AS Date), CAST(N'15:49:27.6866989' AS Time), N'76uGv+P39IKvlpx+/BiJcA==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (68, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'15:50:14.8365203' AS Time), N'sirWjR7qcK7RO0jzG9nuRQ==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (69, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'15:51:04.3051252' AS Time), N'3con+/jocaVMCz28kWcSrw==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (70, 1, 2, 3, CAST(N'2022-07-05' AS Date), CAST(N'15:51:59.9625414' AS Time), N'c8BZlrRlwC65Kg09G3QcEA==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (71, -1, 3, 2, CAST(N'2022-07-05' AS Date), CAST(N'15:52:05.7618123' AS Time), N'T/slDh6+Cy2WKggLp6dPIw==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (72, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'15:52:14.6779900' AS Time), N'c8BZlrRlwC65Kg09G3QcEA==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (73, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'15:53:02.5106538' AS Time), N'n0af3lBjvXLzl36/EHbEkQ==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (74, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'16:02:29.2153017' AS Time), N'6OjbhQe7FZFRRFtSIqjJNg==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (75, 2, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'16:05:56.8250282' AS Time), N'Eo0+Sn2GYH69WIzubTOz7Q==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (76, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'16:08:54.6904233' AS Time), N'W7f1iV/WZ7SSf9SPF7H00A==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (77, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'16:15:39.8398103' AS Time), N'hkJOpw0X5jYq34rX81VWww==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (78, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'16:16:29.6602993' AS Time), N'lDU8b4SpSTvc/DOA98/XtQ==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (79, 1, 4, 6, CAST(N'2022-07-05' AS Date), CAST(N'16:16:40.5548912' AS Time), N'ztavdah8h4fUmfte3HRiTA==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (80, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'16:16:48.1697492' AS Time), N'W8TZFarq61jAXMeNjsMoxQ==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (81, 1, 4, 6, CAST(N'2022-07-05' AS Date), CAST(N'16:17:00.3978404' AS Time), N'c8BZlrRlwC65Kg09G3QcEA==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (82, 2, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'16:17:38.7151057' AS Time), N'Eo0+Sn2GYH69WIzubTOz7Q==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (83, 2, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'16:20:06.1163534' AS Time), N'6OjbhQe7FZFRRFtSIqjJNg==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (84, 2, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'16:24:32.1492972' AS Time), N'c8BZlrRlwC65Kg09G3QcEA==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (85, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'16:24:40.6692836' AS Time), N'e0lig9vXRVE3cX3IRUP0HQ==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (86, 2, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'16:25:17.4838824' AS Time), N'ztavdah8h4fUmfte3HRiTA==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (87, 2, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'16:27:58.9866410' AS Time), N'CUG6pRWZZtdBMfWX9B7raw==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (88, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'16:30:51.5888643' AS Time), N'ztavdah8h4fUmfte3HRiTA==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (89, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'16:33:48.9269786' AS Time), N'gxNV9GLHYA/GQXzM2oh5Ww==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (90, 2, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'16:44:36.2152409' AS Time), N'sirWjR7qcK7RO0jzG9nuRQ==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (91, 2, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'16:49:17.9295730' AS Time), N'ztavdah8h4fUmfte3HRiTA==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (92, 2, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'16:51:48.5857574' AS Time), N'e6cXgrDFgGiZLQN41GdP7g==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (93, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'16:52:07.8255498' AS Time), N'ztavdah8h4fUmfte3HRiTA==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (94, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'16:55:31.6274085' AS Time), N'fvwqKkbEzKiNWHNMHYK2Lw==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (95, 1, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'16:57:12.1497890' AS Time), N'ztavdah8h4fUmfte3HRiTA==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (96, 1, 4, 6, CAST(N'2022-07-05' AS Date), CAST(N'17:00:31.8104212' AS Time), N'C2njsj846n9IdPXu38B/Ng==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (97, 2, 3, 1, CAST(N'2022-07-05' AS Date), CAST(N'17:00:44.5475673' AS Time), N'e0lig9vXRVE3cX3IRUP0HQ==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (98, 1, 3, 1, CAST(N'2022-09-13' AS Date), CAST(N'21:22:38.3444132' AS Time), N'1aDYrc38+FEzcijtJLfqyw==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (99, 1, 3, 1, CAST(N'2022-09-24' AS Date), CAST(N'20:52:49.8407097' AS Time), N's5VSmJBbt0FMqfMnZI/ikg==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (100, 1, 3, 1, CAST(N'2022-09-24' AS Date), CAST(N'20:56:14.2470219' AS Time), N'Zee4bpGDVys9qLPN6AJuFQ==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (101, 1, 3, 1, CAST(N'2022-09-24' AS Date), CAST(N'20:57:38.6543326' AS Time), N'uCiRMPvq4VNncvyo/T8PRA==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (102, 1, 3, 1, CAST(N'2022-09-24' AS Date), CAST(N'20:58:50.1615572' AS Time), N'F5yZhYrLnTNCdr1syhKW/w==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (103, 1, 3, 1, CAST(N'2022-09-24' AS Date), CAST(N'21:00:11.0912319' AS Time), N'3vtV18I02A1tv3ikf6E07Q==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (104, 1, 3, 1, CAST(N'2022-09-24' AS Date), CAST(N'21:13:14.1403070' AS Time), N'pvloz7ZC0z7ztgnJ0tGelw==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (105, 1, 3, 1, CAST(N'2022-09-24' AS Date), CAST(N'21:14:42.2574772' AS Time), N'flzyoA/6LqsCpEEL+LSXyg==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (106, 1, 3, 1, CAST(N'2022-09-24' AS Date), CAST(N'21:17:25.4730858' AS Time), N'eSNZUXuj4vgdsAo2OYEtyA==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (107, 1, 3, 1, CAST(N'2022-10-18' AS Date), CAST(N'20:22:19.6806099' AS Time), N'uxdmlQ/XyDqEEh9jvfZQ4g==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (108, 1, 3, 1, CAST(N'2022-10-18' AS Date), CAST(N'20:23:48.7880244' AS Time), N'czSKkw5PIkM/CnyKDAAzVw==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (109, 1, 4, 6, CAST(N'2022-10-18' AS Date), CAST(N'20:24:36.0012317' AS Time), N'bA5Rv8okbuZYLZGV1ZGVEA==')
INSERT [dbo].[bitacora] ([bitacora_id], [cuenta_usuario_id], [bitacora_criticidad], [bitacora_transaccion_id], [bitacora_fecha], [bitacora_hora], [bitacora_dvh]) VALUES (110, 1, 3, 1, CAST(N'2022-10-23' AS Date), CAST(N'11:23:21.5650127' AS Time), N'qhFve98DeDHrqWtXSXsxLg==')
GO
INSERT [dbo].[bitacora_tipo_movimiento] ([bitacora_transaccion_id], [bitacora_transaccion_desc]) VALUES (1, N'Login Ok')
INSERT [dbo].[bitacora_tipo_movimiento] ([bitacora_transaccion_id], [bitacora_transaccion_desc]) VALUES (2, N'Usuario Incorrecto')
INSERT [dbo].[bitacora_tipo_movimiento] ([bitacora_transaccion_id], [bitacora_transaccion_desc]) VALUES (3, N'Contrasenia Incorrecta')
INSERT [dbo].[bitacora_tipo_movimiento] ([bitacora_transaccion_id], [bitacora_transaccion_desc]) VALUES (4, N'Cuenta Bloqueada')
INSERT [dbo].[bitacora_tipo_movimiento] ([bitacora_transaccion_id], [bitacora_transaccion_desc]) VALUES (5, N'Creacion de Cuenta de Usuario')
INSERT [dbo].[bitacora_tipo_movimiento] ([bitacora_transaccion_id], [bitacora_transaccion_desc]) VALUES (6, N'Logout')
GO
INSERT [dbo].[cuenta_usuario] ([cuenta_usuario_id], [cuenta_usuario_username], [cuenta_usuario_password], [cuenta_usuario_intentos_login], [cuenta_fecha_alta], [cuenta_usuario_activa], [cuenta_usuario_DVH]) VALUES (1, N'B8gmG2kQFgOKCj9Nzh8vZg==', N'ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f', 0, CAST(N'2022-07-05' AS Date), 1, N'MMg85cvMU5Y6UikA30RIHg==')
INSERT [dbo].[cuenta_usuario] ([cuenta_usuario_id], [cuenta_usuario_username], [cuenta_usuario_password], [cuenta_usuario_intentos_login], [cuenta_fecha_alta], [cuenta_usuario_activa], [cuenta_usuario_DVH]) VALUES (2, N'yrm0c3cxsWzE+yHmcEdxcQ==', N'ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f', 0, CAST(N'2022-07-05' AS Date), 1, N'7aefmr0BYXmAMXqdLIaykg==')
GO
INSERT [dbo].[cuenta_usuario_familia] ([cuenta_usuario_id], [familia_id], [cuenta_usuario_familia_dvh]) VALUES (1, 1, N'4eHEeiV9WhHsZpYDyFRV2g==')
INSERT [dbo].[cuenta_usuario_familia] ([cuenta_usuario_id], [familia_id], [cuenta_usuario_familia_dvh]) VALUES (1, 2, N'4eHEeiV9WhHsZpYDyFRV2g==')
INSERT [dbo].[cuenta_usuario_familia] ([cuenta_usuario_id], [familia_id], [cuenta_usuario_familia_dvh]) VALUES (2, 2, N'4eHEeiV9WhHsZpYDyFRV2g==')
GO
INSERT [dbo].[cuenta_usuario_patente] ([cuenta_usuario_id], [patente_id], [cuenta_usuario_patente_dvh]) VALUES (1, 1, N'4eHEeiV9WhHsZpYDyFRV2g==')
INSERT [dbo].[cuenta_usuario_patente] ([cuenta_usuario_id], [patente_id], [cuenta_usuario_patente_dvh]) VALUES (1, 2, N'R70RJ/u1Cd0GDWKzci8ItA==')
GO
INSERT [dbo].[DVV] ([tabla], [dvv_valor]) VALUES (N'bitacora', N'oaXDmX60M6KAUQ5Gtnebhg==')
INSERT [dbo].[DVV] ([tabla], [dvv_valor]) VALUES (N'cuenta_usuario', N'AvkZjb5I0jF25GCKes9FBw==')
INSERT [dbo].[DVV] ([tabla], [dvv_valor]) VALUES (N'cuenta_usuario_familia', N'g2dvX4+gKBwiGJ5sszT3JQ==')
INSERT [dbo].[DVV] ([tabla], [dvv_valor]) VALUES (N'cuenta_usuario_patente', N'9rCGI6CMBqnCBWX7PChyTg==')
GO
INSERT [dbo].[familia] ([familia_id], [familia_nombre]) VALUES (1, N'Administrador')
INSERT [dbo].[familia] ([familia_id], [familia_nombre]) VALUES (2, N'Usuario')
GO
INSERT [dbo].[familia_patente] ([familia_id], [patente_id], [familia_patente_dvh]) VALUES (1, 1, NULL)
INSERT [dbo].[familia_patente] ([familia_id], [patente_id], [familia_patente_dvh]) VALUES (1, 2, NULL)
GO
INSERT [dbo].[patente] ([patente_id], [patente_nombre]) VALUES (1, N'Ver bitacora')
INSERT [dbo].[patente] ([patente_id], [patente_nombre]) VALUES (2, N'Recalcular DVV y DVH')
GO
INSERT [dbo].[producto] ([producto_id], [producto_nombre]) VALUES (3, N'Zapatillas Nike 2')
INSERT [dbo].[producto] ([producto_id], [producto_nombre]) VALUES (4, N'Zapatillas Adidas')
GO
ALTER TABLE [dbo].[cuenta_usuario] ADD  CONSTRAINT [DF_cuenta_usuario_cuenta_activa]  DEFAULT ((1)) FOR [cuenta_usuario_activa]
GO
ALTER TABLE [dbo].[cuenta_usuario] ADD  CONSTRAINT [DF_cuenta_usuario_cuenta_usuario_DVH]  DEFAULT ((0)) FOR [cuenta_usuario_DVH]
GO
ALTER TABLE [dbo].[bitacora]  WITH CHECK ADD  CONSTRAINT [FK_bitacora_bitacora_tipo_movimiento] FOREIGN KEY([bitacora_transaccion_id])
REFERENCES [dbo].[bitacora_tipo_movimiento] ([bitacora_transaccion_id])
GO
ALTER TABLE [dbo].[bitacora] CHECK CONSTRAINT [FK_bitacora_bitacora_tipo_movimiento]
GO
ALTER TABLE [dbo].[cuenta_usuario_familia]  WITH CHECK ADD  CONSTRAINT [FK_cuenta_usuario_familia_cuenta_usuario] FOREIGN KEY([cuenta_usuario_id])
REFERENCES [dbo].[cuenta_usuario] ([cuenta_usuario_id])
GO
ALTER TABLE [dbo].[cuenta_usuario_familia] CHECK CONSTRAINT [FK_cuenta_usuario_familia_cuenta_usuario]
GO
ALTER TABLE [dbo].[cuenta_usuario_familia]  WITH CHECK ADD  CONSTRAINT [FK_cuenta_usuario_familia_familia] FOREIGN KEY([familia_id])
REFERENCES [dbo].[familia] ([familia_id])
GO
ALTER TABLE [dbo].[cuenta_usuario_familia] CHECK CONSTRAINT [FK_cuenta_usuario_familia_familia]
GO
ALTER TABLE [dbo].[cuenta_usuario_patente]  WITH CHECK ADD  CONSTRAINT [FK_cuenta_usuario_patente_cuenta_usuario] FOREIGN KEY([cuenta_usuario_id])
REFERENCES [dbo].[cuenta_usuario] ([cuenta_usuario_id])
GO
ALTER TABLE [dbo].[cuenta_usuario_patente] CHECK CONSTRAINT [FK_cuenta_usuario_patente_cuenta_usuario]
GO
ALTER TABLE [dbo].[cuenta_usuario_patente]  WITH CHECK ADD  CONSTRAINT [FK_cuenta_usuario_patente_patente] FOREIGN KEY([patente_id])
REFERENCES [dbo].[patente] ([patente_id])
GO
ALTER TABLE [dbo].[cuenta_usuario_patente] CHECK CONSTRAINT [FK_cuenta_usuario_patente_patente]
GO
ALTER TABLE [dbo].[familia_patente]  WITH CHECK ADD  CONSTRAINT [FK_familia_patente_familia] FOREIGN KEY([familia_id])
REFERENCES [dbo].[familia] ([familia_id])
GO
ALTER TABLE [dbo].[familia_patente] CHECK CONSTRAINT [FK_familia_patente_familia]
GO
ALTER TABLE [dbo].[familia_patente]  WITH CHECK ADD  CONSTRAINT [FK_familia_patente_patente] FOREIGN KEY([patente_id])
REFERENCES [dbo].[patente] ([patente_id])
GO
ALTER TABLE [dbo].[familia_patente] CHECK CONSTRAINT [FK_familia_patente_patente]
GO
USE [master]
GO
ALTER DATABASE [GlobalLogistics] SET  READ_WRITE 
GO
