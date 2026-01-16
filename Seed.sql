USE [PhonebookDb]
GO

-- 1. Ensure Groups exist and capture their IDs
DECLARE @Groups TABLE (Name NVARCHAR(100), Id UNIQUEIDENTIFIER);

IF NOT EXISTS (SELECT 1 FROM [contacts].[ContactGroups] WHERE [Name] = N'Work')
    INSERT INTO [contacts].[ContactGroups] ([Name], [Description], [CreatedAt], [CreatedOn]) 
    VALUES (N'Work', N'Business contacts in Australia', SYSDATETIME(), SYSDATETIME());
IF NOT EXISTS (SELECT 1 FROM [contacts].[ContactGroups] WHERE [Name] = N'Family')
    INSERT INTO [contacts].[ContactGroups] ([Name], [Description], [CreatedAt], [CreatedOn]) 
    VALUES (N'Family', N'Family across the states', SYSDATETIME(), SYSDATETIME());
IF NOT EXISTS (SELECT 1 FROM [contacts].[ContactGroups] WHERE [Name] = N'Friends')
    INSERT INTO [contacts].[ContactGroups] ([Name], [Description], [CreatedAt], [CreatedOn]) 
    VALUES (N'Friends', N'Local social circle', SYSDATETIME(), SYSDATETIME());

INSERT INTO @Groups (Name, Id) SELECT [Name], [Id] FROM [contacts].[ContactGroups];

-- 2. Insert 10 Australian Contacts
WITH NewContacts AS (
    SELECT * FROM (VALUES 
        (N'Lachlan', N'Murdoch', N'0412 345 678', N'+61', NULL, N'lachlan@outback.com.au', N'12 St Georges Terrace', N'Perth', N'WA', N'6000', N'Australia', N'Mining Corp', N'Engineer', N'Work'),
        (N'Kylie', N'Minogue', N'0421 987 654', N'+61', N'ext 2', N'kylie@melbourne.vic.gov.au', N'45 Collins Street', N'Melbourne', N'VIC', N'3000', N'Australia', N'Arts Council', N'Director', N'Work'),
        (N'Bindi', N'Irwin', N'07 5433 3000', N'+61', NULL, N'bindi@zoo.com.au', N'1638 Steve Irwin Way', N'Beerwah', N'QLD', N'4519', N'Australia', N'Australia Zoo', N'Conservationist', N'Family'),
        (N'Hugh', N'Jackman', N'02 9123 4567', N'+61', NULL, N'hugh@sydney.com.au', N'88 George St', N'Sydney', N'NSW', N'2000', N'Australia', N'Stage & Screen', N'Actor', N'Friends'),
        (N'Ash', N'Barty', N'0455 111 222', N'+61', NULL, N'ash.b@tennis.com.au', N'10 Baseline Rd', N'Ipswich', N'QLD', N'4305', N'Australia', N'Sports Aus', N'Pro', N'Friends'),
        (N'Steve', N'Smith', N'02 8888 7777', N'+61', N'3', N'steve@cricket.org.au', N'Driver Ave', N'Moore Park', N'NSW', N'2021', N'Australia', N'Cricket NSW', N'Captain', N'Work'),
        (N'Margot', N'Robbie', N'0433 444 555', N'+61', NULL, N'margot@goldcoast.au', N'1 Surf Parade', N'Broadbeach', N'QLD', N'4218', N'Australia', N'Film Gold', N'Producer', N'Friends'),
        (N'Tim', N'Winton', N'08 9444 1234', N'+61', NULL, N'tim@wa-authors.net.au', N'5 Ocean View Rd', N'Fremantle', N'WA', N'6160', N'Australia', N'Literary Soc', N'Author', N'Family'),
        (N'Cate', N'Blanchett', N'03 9000 1111', N'+61', NULL, N'cate@theatre.vic.edu.au', N'22 Swanston St', N'Melbourne', N'VIC', N'3000', N'Australia', N'STC', N'Manager', N'Work'),
        (N'Ned', N'Kelly', N'0400 000 000', N'+61', NULL, N'ned@bushranger.com.au', N'10 Glenrowan Rd', N'Glenrowan', N'VIC', N'3675', N'Australia', N'Historic Sites', N'Guide', N'Family')
    ) AS t(FirstName, LastName, Phone, CCode, Ext, Email, Street, City, State, Zip, Country, Co, Job, GroupName)
)
INSERT INTO [contacts].[Contacts] (
    [Id], [FirstName], [LastName], [PhoneNumber], [CountryCode], [PhoneExtension], 
    [Email], [Street], [City], [State], [PostalCode], [Country], [Company], 
    [JobTitle], [Notes], [CreatedAt], [UpdatedAt], [IsFavorite], [ContactGroupId], 
    [CreatedOn], [UpdatedOn]
)
SELECT 
    NEWID(), src.FirstName, src.LastName, src.Phone, src.CCode, src.Ext, 
    src.Email, src.Street, src.City, src.State, src.Zip, src.Country, src.Co, 
    src.Job, N'Australian seed data', SYSDATETIME(), SYSDATETIME(), 
    CASE WHEN src.GroupName = N'Family' THEN 1 ELSE 0 END, -- Favourites for family
    g.Id, SYSDATETIME(), SYSDATETIME()
FROM NewContacts src
INNER JOIN @Groups g ON src.GroupName = g.Name
WHERE NOT EXISTS (SELECT 1 FROM [contacts].[Contacts] WHERE [Email] = src.Email);

GO

-- Display formatted results
SELECT 
    c.FirstName + ' ' + c.LastName AS FullName,
    c.PhoneNumber,
    c.City + ', ' + c.State AS Location,
    g.Name AS GroupName
FROM [contacts].[Contacts] c
JOIN [contacts].[ContactGroups] g ON c.ContactGroupId = g.Id
ORDER BY g.Name;