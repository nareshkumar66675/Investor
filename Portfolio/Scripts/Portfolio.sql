
/****** Object:  Table [dbo].[Portfolio]    Script Date: 01-Jul-18 7:26:39 PM ******/
DROP TABLE IF EXISTS [dbo].[Portfolio]
GO

/****** Object:  Table [dbo].[Portfolio]    Script Date: 01-Jul-18 7:26:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Portfolio]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Portfolio](
	[PortfolioID] [int] IDENTITY(1,1) NOT NULL,
	[PortfolioName] [nvarchar](200) NULL,
 CONSTRAINT [PK_Portfolio] PRIMARY KEY CLUSTERED 
(
	[PortfolioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO


