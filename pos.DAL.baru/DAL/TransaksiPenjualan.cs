using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pos.DAL.Interface;
using Dapper;
using pos.BO;

namespace pos.DAL.DAL
{
    public class TransaksiPenjualan: ITransaksiPenjualan
    {
        private string GetConnectionString()
        {
            return Helper.GetConnectionString();
        }
        public void InsertPayment(GetTransactionData getTransactionData)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"sp_penjualan";
                var param = new
                {
                    nama_pelanggan = getTransactionData.nama_pelanggan,
                    no_meja = getTransactionData.no_meja,
                    jumlah_pesanan = getTransactionData.jumlah_pesanan,
                    harga_menu = getTransactionData.harga_menu,
                    nama_menu = getTransactionData.nama_menu,
                    amount = getTransactionData.amount


                };
                conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
      
       public MasterMenu GetHargaByMenu(BO.MasterMenu masterMenu)
        {
            using SqlConnection conn = new SqlConnection(GetConnectionString());
            string strSql = @"select harga_menu from MasterMenu where nama_menu = @nama_menu";
            var param = new { nama_menu = masterMenu.nama_menu };
            var result = conn.QueryFirstOrDefault<BO.MasterMenu>(strSql, param);
            return result;
        }
        public IEnumerable<GetTransactionData> GetTransaksiPenjualan()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"GetTransactionData";
                var results = conn.Query<BO.GetTransactionData>(strSql);
                return results;
            }
        }
        IEnumerable<BO.TransaksiPenjualan> ICrud<BO.TransaksiPenjualan>.GetAll()
        {
            throw new NotImplementedException();
        }

        BO.TransaksiPenjualan ICrud<BO.TransaksiPenjualan>.GetByID(int id)
        {
            throw new NotImplementedException();
        }

        void ICrud<BO.TransaksiPenjualan>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        void ICrud<BO.TransaksiPenjualan>.Insert(BO.TransaksiPenjualan entity)
        {
            throw new NotImplementedException();
        }

        void ICrud<BO.TransaksiPenjualan>.Update(BO.TransaksiPenjualan entity)
        {
            throw new NotImplementedException();
        }

        
    }
}
