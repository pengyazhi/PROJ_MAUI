using projAPP_MAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projAPP_MAUI.ViewModels
{
    public class CProductViewModels
    {
        private List<CProducts>_lists = new List<CProducts>();
        private int _postion =0;
        private CProductViewModels()
        {
            loadData();
        }
        private void loadData()
        {
            CProducts x = new CProducts();
            x.流水號 = 1;
            x.product = "蘭嶼｜三天兩夜自由行";
            x.supplier = "可樂旅遊";
            x.price = 4700;
            x.date = "2023-09-15";
            x.min = 0;
            x.max = 20;
            _lists.Add(x);
            x = new CProducts();
            x.流水號 = 2;
            x.product = "台灣南投｜合歡山暗空公園觀星體驗";
            x.supplier = "雄獅旅遊";
            x.price = 3999;
            x.date = "2023-10-10";
            x.min = 10;
            x.max = 30;
            _lists.Add(x);
            x = new CProducts();
            x.流水號 = 3;
            x.product = "花蓮鯉魚潭露營渡假村山水谷豪華露營";
            x.supplier = "山富旅行";
            x.price = 9000;
            x.date = "2024-04-20";
            x.min = 5;
            x.max = 40;
            _lists.Add(x);
        }
        public void moveFirst()
        {
            _postion = 0;
        }
        public void movePrevious()
        {
            _postion--;
            if (_postion < 0)
                _postion = 0;
        }
        public void moveNext()
        {
            _postion++;
            if(_postion > _lists.Count-1)
                _postion = _lists.Count-1;
        }
        public void moveLast()
        {
            _postion = _lists.Count - 1;

        }
        public void moveTo(int to)
        {
            _postion = to;
        }
        public CProducts current
        {
            get { return _lists[_postion]; }
            set { _lists[_postion] = value; }
        }
        public List<CProducts> all
        {
            get { return _lists; }
            set { _lists = value; }
        }
    }
}
