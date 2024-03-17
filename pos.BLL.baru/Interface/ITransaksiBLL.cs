using System;
using System.Collections.Generic;
using System.Text;
using pos.BLL.DTO;


namespace pos.BLL.Interface
{
    public interface ITransaksiBLL
    {
        void InsertPayment(DTO.TransaksiPenjualanDTO transaksiPenjualanDTO);

        MasterMenuDTO GetHargaByMenu(BO.MasterMenu masterMenu);
        IEnumerable<GetTransactionDTO> GetTransaksiPenjualan();

    }
}
