using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kNN
{
    public  class KNN_algorithm
    {
        private List<Friend> l;
        private int k;
        public KNN_algorithm(List<Friend>l,int k)
        {
            this.l = l;
            this.k = k;
        }  
        private int getMax(List<int> list)
        {
            int max = 0;
            for(int i=0;i<list.Count;i++)
                if (max < list[i])
                    max = list[i];
            for (int i = 0; i < list.Count; i++)
                if (max == list[i])
                    return i;
            return -1;
        }
        public string run()
        {
            sort();
            List<string> list = new List<string>();
            List<int> list2 = new List<int>();
            for (int i = 0; i < k; i++)
            {
                if (list.IndexOf(l[i].TinhTrangNghienGame)==-1)
                {
                    list.Add(l[i].TinhTrangNghienGame);
                    list2.Add(1);
                }   
                else
                {
                    int id = list.IndexOf(l[i].TinhTrangNghienGame);
                    list2[id]++;
                }    
            }
            return list[getMax(list2)];
        }
        private void sort()
        {
            for (int i = 0; i < l.Count - 1; i++)
                for (int j = i + 1; j < l.Count; j++)
                    if (l[i].MucDoThanThiet < l[j].MucDoThanThiet)
                    {
                        Friend f = l[i];
                        l[i] = l[j];
                        l[j] = f;
                    }
        }
    }
}
