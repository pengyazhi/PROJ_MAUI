
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projAPP_MAUI.Models
{
    public class CPageStatus
    {
        public string crud { get { return "新增/修改商品"; }}
        public string list { get { return "商品總覽列表"; } }
        public string addProduct { get { return "新增商品"; } }
        public string removeProduct { get { return "刪除商品"; } }
        public string productInfo { get { return "商品詳情"; } }
        public string travelDate { get { return "Travel Date 廠商"; } }
    }
    public class CBtnStatus
    {
        public string addNext { get { return "新增下一筆"; } }
    }
}
