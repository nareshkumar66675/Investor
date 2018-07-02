

/****** Object:  Table [dbo].[Tickers]    Script Date: 01-Jul-18 7:25:57 PM ******/
DROP TABLE IF EXISTS [dbo].[Tickers]
GO

/****** Object:  Table [dbo].[Tickers]    Script Date: 01-Jul-18 7:25:58 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tickers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tickers](
	[TickerId] [int] IDENTITY(1,1) NOT NULL,
	[Ticker] [nvarchar](50) NOT NULL,
	[CompanyName] [nvarchar](300) NULL,
	[PortfolioID] [int] NOT NULL,
 CONSTRAINT [PK_Tickers] PRIMARY KEY CLUSTERED 
(
	[TickerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO


