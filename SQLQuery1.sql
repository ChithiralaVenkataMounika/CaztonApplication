/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [ProductId]
      ,[Title]
      ,[Description]
      ,[ModelNumber]
      ,[Picture]
      ,[Price]
  FROM [CaztonProducts].[dbo].[Product]

UPDATE [CaztonProducts].[dbo].[Product]
SET [Picture] = 
    (SELECT tablet2.*
    from Openrowset(Bulk 'C:\Users\Mounika\Desktop\product-pictures\tablet2.jpg', Single_Blob) tablet2)
    where [ProductId] = 8


