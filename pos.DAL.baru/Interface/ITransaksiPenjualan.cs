using System;
using System.Collections.Generic;
using System.Text;
using pos.BO;

namespace pos.DAL.Interface
{
    public interface ITransaksiPenjualan : ICrud<TransaksiPenjualan>
    {
        void InsertPayment(BO.TransaksiPenjualan transaksiPenjualan, BO.MasterMenu masterMenu, BO.MasterPelanggan masterPelanggan, BO.MasterMeja masterMeja);
        MasterMenu GetHargaByMenu(BO.MasterMenu masterMenu);
        IEnumerable<BO.TransaksiPenjualan> GetTransaksiPenjualan();


    }
}
