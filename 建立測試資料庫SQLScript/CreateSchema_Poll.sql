USE [ASPNETCoreDemoDB]
GO
/****** Object:  Table [dbo].[Poll]    Script Date: 2020/2/5 下午 03:22:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Poll](
	[PollID] [int] IDENTITY(1,1) NOT NULL,
	[Question] [nvarchar](300) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Poll] PRIMARY KEY CLUSTERED 
(
	[PollID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PollOption]    Script Date: 2020/2/5 下午 03:22:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PollOption](
	[PollOptionID] [int] IDENTITY(1,1) NOT NULL,
	[PollID] [int] NOT NULL,
	[Answers] [nvarchar](200) NOT NULL,
	[Vote] [int] NOT NULL,
 CONSTRAINT [PK_PollOption] PRIMARY KEY CLUSTERED 
(
	[PollOptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PollOption]  WITH CHECK ADD  CONSTRAINT [FK_PollOption_PollOption] FOREIGN KEY([PollID])
REFERENCES [dbo].[Poll] ([PollID])
GO
ALTER TABLE [dbo].[PollOption] CHECK CONSTRAINT [FK_PollOption_PollOption]
GO
