USE [master]
GO
/****** Object:  Database [TeleShow]    Script Date: 10/10/2019 09:03:50 ******/
CREATE DATABASE [TeleShow]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NoticiasBD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\NoticiasBD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NoticiasBD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\NoticiasBD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TeleShow] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TeleShow].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TeleShow] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TeleShow] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TeleShow] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TeleShow] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TeleShow] SET ARITHABORT OFF 
GO
ALTER DATABASE [TeleShow] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TeleShow] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TeleShow] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TeleShow] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TeleShow] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TeleShow] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TeleShow] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TeleShow] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TeleShow] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TeleShow] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TeleShow] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TeleShow] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TeleShow] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TeleShow] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TeleShow] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TeleShow] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TeleShow] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TeleShow] SET RECOVERY FULL 
GO
ALTER DATABASE [TeleShow] SET  MULTI_USER 
GO
ALTER DATABASE [TeleShow] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TeleShow] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TeleShow] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TeleShow] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TeleShow] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TeleShow', N'ON'
GO
ALTER DATABASE [TeleShow] SET QUERY_STORE = OFF
GO
USE [TeleShow]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [TeleShow]
GO
/****** Object:  User [alumno]    Script Date: 10/10/2019 09:03:50 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Noticia]    Script Date: 10/10/2019 09:03:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Noticia](
	[idNoticia] [int] IDENTITY(1,1) NOT NULL,
	[fkTipoNoticia] [int] NOT NULL,
	[Titulo] [varchar](max) NOT NULL,
	[Imagen] [varchar](150) NOT NULL,
	[Descripcion] [varchar](max) NOT NULL,
	[Destacada] [bit] NOT NULL,
 CONSTRAINT [PK_Noticia] PRIMARY KEY CLUSTERED 
(
	[idNoticia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoNoticia]    Script Date: 10/10/2019 09:03:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoNoticia](
	[idTipoNoticia] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoNoticia] PRIMARY KEY CLUSTERED 
(
	[idTipoNoticia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 10/10/2019 09:03:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Usuario] [varchar](50) NOT NULL,
	[Contra] [varchar](50) NOT NULL,
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Usuariod] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Noticia] ON 

INSERT [dbo].[Noticia] ([idNoticia], [fkTipoNoticia], [Titulo], [Imagen], [Descripcion], [Destacada]) VALUES (1, 1, N'Llamado oficial de Huracan a Dominguez', N'llamadoOficial.jpg', N'El candidato de Nadur para suceder a Vojvoda es Eduardo Domínguez, quien hizo historia en el Globo dentro y fuera de la cancha, en su primera experiencia como DT. Ya hubo una comunicación pero la negociación aún no está tan encaminada.  Cuando el domingo por la mañana en el Ducó aún retumbaba el eco del mensaje de Juan Pablo Vojvoda, quien afirmó su convencimiento para seguir trabajando en un proyecto a largo plazo, el nombre de Eduardo Domínguez ya tomaba fuerza (entre los hinchas) como alternativa para corregir el rumbo. Ahora, con el ex Talleres afuera del club, Alejandro Nadur admitió que es el candidato número uno para llegar a Patricios.

A pesar de las discrepancias que provocaron la salida del DT en 2016, las aguas se calmaron en la relación entre el ex jugador del Globo y el presidente, por lo que este antecedente no será un palo en la rueda para que el entrenador vuelva al club. Con las asperezas limadas, Nadur afirmó: “Me encantaría que Domínguez vuelva a Huracán, pero se tienen que alinear los planetas”. Con la precaución de que la negociación aún no está tan encaminada, aunque ya lo llamó para ofrecerle el cargo, el mandamás de Huracán fue precavido a la hora de hablar del sucesor. Diferente fue su actitud al caer en contradicciones con Vojvoda, a quien contrató para un proyecto a largo plazo pero le rescindió el contrato tras siete encuentros. “En mis ocho años de gestión es el DT que más trabajó, pero los resultados no fueron buenos en los últimos dos partidos”, explicó el mandamás del Globo.

En cuanto al principal candidato a sucederlo, se trata de alguien que hizo historia en la institución tanto en su etapa de jugador como después del retiro. Dentro de la cancha, el defensor ascendió a Primera en 2014, ganó la Copa Argentina del mismo año y la Supercopa. Luego, siendo entrenador, llevó al equipo hasta la final de la Sudamericana 2015. Por estos antecedentes es que, en encuestas entre los hinchas quemeros, Eduardo pica en punta como el preferido para intentar sacar al plantel de este mal momento.

En caso de que no se concrete su llegada en los próximos días, no hay un plan B definido. Sin embargo, Omar de Felippe es un anhelo de Nadur, quien tendrá la última palabra en la elección del próximo DT.', 0)
INSERT [dbo].[Noticia] ([idNoticia], [fkTipoNoticia], [Titulo], [Imagen], [Descripcion], [Destacada]) VALUES (2, 2, N'Para el Gobierno, "no hay razones" para suspender los debates presidenciales', N'debatePresidencial.jpg', N'Por ley, Mauricio Macri y Alberto Fernández deberían debatir el 13 y el 20 de octubre próximos; el candidato del Frente de Todos advirtió sobre un posible impacto en los mercados. No hay novedades. Es una ley y la vamos a cumplir". Fue esa la respuesta oficial en la Casa Rosada en relación a los debates presidenciales, previstos para los próximos 13 y 20 de octubre, y cuestionados por el candidato del Frente de Todos, Alberto Fernández.

En principio, en Balcarce 50 prefirieron no opinar sobre las declaraciones de Fernández, para quien los debates "pueden ser un problema" porque "el Presidente va a tener que debatir con personas que hacen hincapié en la crisis económica" y puede traer consecuencias negativas en los mercados.

"No sabemos por qué lo dijo. Nosotros vamos a ir, y el debate se hace porque es una ley. No hay razones para no debatir", respondieron cerca del presidente Mauricio Macri. Su vocero, Iván Pavlovsky, y el secretario de Medios, Jorge Grecco, representan a la fórmula oficialista en la reunión semanal organizada por la Cámara Nacional Electoral.', 0)
INSERT [dbo].[Noticia] ([idNoticia], [fkTipoNoticia], [Titulo], [Imagen], [Descripcion], [Destacada]) VALUES (3, 4, N'Seal: “Yo vivo para interpretar grandes canciones”', N'Seal.jpg', N'Cualquier compilación de éxitos de los noventas que no incluya Crazy y Kiss From a Rose, ambas canciones de Seal, puede considerarse un fracaso. Este inglés de 56 años apareció en la década del mestizaje musical por excelencia a fuerza de estos dos hits de acero y una voz prodigiosa. Tal es así que en Argentina muchos supimos de su existencia cuando, el 20 de abril de 1992, lo vimos cantar con éxito Who Wants To Live Forever, en el tributo a Freddie Mercury, organizado en el mítico estadio de Wembley.

Allí, antes unas 72 mil personas que colmaron el estadio y unas 500 millones de personas que lo vieron por televisión, un joven Seal se codeó con las máximas figuras del rock y el pop del momento. Entre muchos otros, desfilaron por aquel escenario artistas como Metallica, Guns N Roses, Extreme, David Bowie, Elton John, Def Leppard, Ian Hunter, Mick Ronson, Seal, George Michael, Roger Daltrey y Robert Plant. “Aquel fue uno de los momentos más grandes de mi carrera. Así lo recuerdo, como un privilegio y un honor, pararme en ese escenario con Queen y cantar con ellos algunas de mis canciones preferidas de toda la vida. Fue muy al comienzo de mi carrera. Recientemente alguien subió un video a las redes de los ensayos. Mientras George Michael practicaba Somebody To Love, David Bowie y yo estábamos en el fondo del escenario, escuchándolo”, recuerda el amable Seal desde Londres.', 0)
INSERT [dbo].[Noticia] ([idNoticia], [fkTipoNoticia], [Titulo], [Imagen], [Descripcion], [Destacada]) VALUES (4, 3, N'Según el Wall Street Journal, Argentina está en crisis porque no puede romper con su círculo vicioso económico', N'5.jpg', N' El diario financiero estadounidense The Wall Street Journal publicó este miércoles un artículo en el que asegura que la nueva crisis económica que atraviesa la Argentina refleja la imposibilidad del país de romper con un patrón que, de manera cíclica, repite desde “hace más de 70 años”. ', 0)
INSERT [dbo].[Noticia] ([idNoticia], [fkTipoNoticia], [Titulo], [Imagen], [Descripcion], [Destacada]) VALUES (5, 3, N'La peculiar respuesta de Roberto Lavagna cuando le preguntaron si sería ministro de Alberto Fernández', N'6.jpg', N'"Soy candidato a presidente, punto, nada más", dijo Roberto Lavagna, en la noche de este jueves, sobre las versiones de que podría ocupar un cargo económico en un eventual gobierno de Alberto Fernández.

Seguidamente, el candidato a presidente de Consenso Federal les dio a los conductores de A Dos Voces (TN) unos stickers con la leyenda "Lavagna al ballotage". Dijo el economista al respecto: "Les voy a regalar esto porque sirve para la respuesta. Añadió: "Mi compromiso es con Consenso Federal y ayudar a que crezca en el futuro porque evita estar en alguno de los dos extremos, el populista o el ultraconservador financiero".

 El economista se mostró muy duro con la gestión económica de Macri: "La herencia que recibió es mala, pero la que deja es peor". Consideró que actualmente la economía "pareciera no estar" en un escenario de hiperinflación, aunque barajó ese camino "si el Gobierno comete errores y la oposición actúa con irresponsabilidad".', 0)
INSERT [dbo].[Noticia] ([idNoticia], [fkTipoNoticia], [Titulo], [Imagen], [Descripcion], [Destacada]) VALUES (6, 2, N'La Corte Suprema ratificó que el beneficio del 2x1 no es aplicable a delitos de lesa humanidad', N'7.jpg ', N'La Corte Suprema de Justicia ratificó que el beneficio del 2x1 no es aplicable a los delitos de lesa humanidad. Lo hizo con el voto de la mayoría de sus ministros, que insistieron con su doctrina en el caso Hidalgo Garzón, un ex oficial de inteligencia condenado por delitos durante la última dictadura.

El máximo tribunal ratificó su postura también al aplicar el mismo criterio a diez casos vinculados con delitos de lesa humanidad, según difundió el Centro de Información Judicial (CIJ), que depende de la Corte Suprema. ', 0)
INSERT [dbo].[Noticia] ([idNoticia], [fkTipoNoticia], [Titulo], [Imagen], [Descripcion], [Destacada]) VALUES (7, 4, N'Festival Clave: celebración adolescente, con cabida para todo el mundo', N'8.jpg', N'Hay un dato esencial para entender el sentido de este festival: sus curadores, es decir los encargados de organizar y delinear la grilla del encuentro, son diez adolescentes de entre 13 y 17 años, que fueron seleccionados por referentes de la cultura local y el equipo del Recoleta, sobre un total de 1500 que se presentaron. Ellos se encargaron de elegir a las bandas participantes (desde Perras on the Beach, pasando por Florián, Ibiza Pareo y más), a los solistas que actuaron en los distintos escenarios, a las obras de danza y teatro, a los booktubers y youtubers que conversaron con el público. Y también fueron los encargados de darle una temática a las muestras de cine y charlas, que en este caso fue el miedo.', 0)
INSERT [dbo].[Noticia] ([idNoticia], [fkTipoNoticia], [Titulo], [Imagen], [Descripcion], [Destacada]) VALUES (8, 1, N'¿Lluvias para el Súper?', N'9.jpg', N'La información parte de varios sitios especializados en pronósticos del clima como AccuWeather, Infoclima, The Weather Channel y Meteored. Anuncian precipitaciones en sus previsiones extendidas, con bajas temperaturas para esa jornada. La excepción es el Servicio Meteorológico Nacional, que por ahora publica que el día estará nublado.', 1)
SET IDENTITY_INSERT [dbo].[Noticia] OFF
SET IDENTITY_INSERT [dbo].[TipoNoticia] ON 

INSERT [dbo].[TipoNoticia] ([idTipoNoticia], [Nombre]) VALUES (1, N'Deporte')
INSERT [dbo].[TipoNoticia] ([idTipoNoticia], [Nombre]) VALUES (2, N'Politica')
INSERT [dbo].[TipoNoticia] ([idTipoNoticia], [Nombre]) VALUES (3, N'Economia')
INSERT [dbo].[TipoNoticia] ([idTipoNoticia], [Nombre]) VALUES (4, N'Entretenimiento')
SET IDENTITY_INSERT [dbo].[TipoNoticia] OFF
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([Usuario], [Contra], [idUsuario]) VALUES (N'Pepe', N'Pepe123', 1)
INSERT [dbo].[Usuarios] ([Usuario], [Contra], [idUsuario]) VALUES (N'Juan', N'Juan123', 2)
INSERT [dbo].[Usuarios] ([Usuario], [Contra], [idUsuario]) VALUES (N'Pedro', N'Pedro123', 3)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
USE [master]
GO
ALTER DATABASE [TeleShow] SET  READ_WRITE 
GO
