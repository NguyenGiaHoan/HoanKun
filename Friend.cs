using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kNN
{
    public class Friend
    {
        private string ten;
        private int mucDoThanThiet;
        private string tinhTrangNghienGame;
        public Friend()
        { }
        public Friend(string ten, int mucDoThanThiet, string tinhTrangNghienGame)
        {
            this.Ten = ten;
            this.MucDoThanThiet = mucDoThanThiet;
            this.TinhTrangNghienGame = tinhTrangNghienGame;
        }
        public string Ten { get => ten; set => ten = value; }
        public int MucDoThanThiet { get => mucDoThanThiet; set => mucDoThanThiet = value; }
        public string TinhTrangNghienGame { get => tinhTrangNghienGame; set => tinhTrangNghienGame = value; }
    }
}
