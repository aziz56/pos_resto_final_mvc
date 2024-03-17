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
        public void InsertPayment(BO.TransaksiPenjualan transaksiPenjualan, BO.MasterMenu masterMenu, BO.MasterPelanggan masterPelanggan,BO.MasterMeja masterMeja)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"sp_penjualan";
                var param = new
                {
                    nama_pelanggan = masterPelanggan.nama_pelanggan,
                    no_meja = masterMeja.no_meja,
                    jumlah_pesanan = transaksiPenjualan.jumlah_pesanan,
                    harga_menu = masterMenu.harga_menu,
                    nama_menu = masterMenu.nama_menu,
                    amount = transaksiPenjualan.amount


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
        public IEnumerable<TransaksiPenjualan> GetTransaksiPenjualans()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = 
                var results = conn.Query<BO.TransaksiPenjualan>(strSql);
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
