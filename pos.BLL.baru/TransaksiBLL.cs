using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pos.BLL.Interface;
using pos.DAL.Interface;

namespace pos.BLL
{
    public class TransaksiBLL: ITransaksiPenjualan 
    {
        private readonly ITransaksiPenjualan _transaksiBLL;
        public TransaksiBLL()
        {
            _transaksiBLL = new pos.DAL.DAL.TransaksiPenjualan();
        }
        public void InsertPayment(DTO.TransaksiPenjualanDTO transaksiPenjualanDTO)
        {
            _transaksiBLL.InsertPayment(transaksiPenjualanDTO);
        }
        public BO.MasterMenu GetHargaByMenu(BO.MasterMenu masterMenu)
        {
            return _transaksiBLL.GetHargaByMenu(masterMenu);
        }
        public IEnumerable<BO.GetTransactionData> GetTransaksiPenjualan()
        {
            return _transaksiBLL.GetTransaksiPenjualan();
        }


    }
}
