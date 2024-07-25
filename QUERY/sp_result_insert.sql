create procedure sp_result_insert
(
	@p_kode_barang nvarchar(8)
	,@p_uaraian_barang nvarchar(200)
	,@p_bm int
	,@p_nilai_komoditas float
	,@p_nilai_bm float
)
as
begin
	INSERT INTO [dbo].[RESULT]
           ([KODE_BARANG]
           ,[URAIAN_BARANG]
           ,[BM]
           ,[NILAI_KOMODITAS]
           ,[NILAI_BM]
           ,[CRE_DATE])
     VALUES
           (@p_kode_barang
		   ,@p_uaraian_barang
		   ,@p_bm
		   ,@p_nilai_komoditas
		   ,@p_nilai_bm
		   ,getdate()
		   )
end