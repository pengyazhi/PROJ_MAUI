using projAPP_MAUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projAPP_MAUI.ViewModels
{
    public class CProductViewModels:INotifyPropertyChanged
    {
        
        public CProductViewModels()
        {
            loadData();
        }
        //App app = Application.Current as App;
        private List<CProducts> _lists = new List<CProducts>();
        private int _postion = 0;
        public event PropertyChangedEventHandler PropertyChanged;
        public void loadData()
        {
            int sn = Preferences.Default.Get("COUNT", 0);
            if (sn == 0)
                return;
            List<CProducts> products = new List<CProducts>();
            for (int i = 1; i <= sn; i++)
            {
                string KeyN = "N" + i;
                string KeyS = "S" + i;
                string KeyP = "P" + i;
                string KeyD = "D" + i;
                string KeyMin = "MIN" + i;
                string KeyMax = "MAX" + i;
                if (Preferences.Default.ContainsKey(KeyN))
                {
                    CProducts x = new CProducts();
                    x.product = Preferences.Default.Get(KeyN, "");
                    x.supplier = Preferences.Default.Get(KeyS, "");
                    x.price = Convert.ToInt32(Preferences.Default.Get(KeyP, ""));
                    x.date = Preferences.Default.Get(KeyD, "");
                    x.min = Convert.ToInt32(Preferences.Default.Get(KeyMin, ""));
                    x.max = Convert.ToInt32(Preferences.Default.Get(KeyMax, ""));
                    x.流水號 = i;
                    products.Add(x);
                }
            }
            if (products.Count == 0)
                return;
            (Application.Current as App).allProdForList = products;
            App app = Application.Current as App;
            _lists = app.allProdForList;
        }
            

            public void moveFirst()
        {
            if (_lists.Count > 0) 
            _postion = 0;
            PropertyChanged(this, new PropertyChangedEventArgs("current"));
        }
        public void movePrevious()
        {
            if (_lists.Count > 0)
            {
                _postion--;
                if (_postion < 0)
                    _postion = 0;
                PropertyChanged(this, new PropertyChangedEventArgs("current"));
            }
              
        }
        public void moveNext()
        {
            if (_lists.Count > 0)
            {
                _postion++;
                if (_postion > _lists.Count - 1)
                    _postion = _lists.Count - 1;
                PropertyChanged(this, new PropertyChangedEventArgs("current"));
            }        
        }
        public void moveLast()
        {
            
            if (_lists.Count > 0)
            {
                _postion = _lists.Count - 1;
                PropertyChanged(this, new PropertyChangedEventArgs("current"));
            }
        }
        public void moveTo(int to)
        {
            if (_lists.Count > 0)
            {
                _postion = to;
                PropertyChanged(this, new PropertyChangedEventArgs("current"));
            }
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
        internal object queryByKeyword(List<CKeywordViewModel> keywords)
        {
            for(int i = 0; i < _lists.Count; i++) 
            {
                string keyword = keywords[i].keyword;
                if (_lists[i].product.ToUpper().Contains(keyword.ToUpper())
                    || _lists[i].supplier.ToUpper().Contains(keyword.ToUpper())
                    || _lists[i].date.ToUpper().Contains(keyword.ToUpper())
                    || _lists[i].price.ToString().Contains(keywords[i].price.ToString()))
                {
                    moveTo(i);
                    return _lists[i];
                }
            }
            return null;
          
        }
    }
}
