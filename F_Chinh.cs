using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kNN
{
    public partial class frmMain : Form
    {
        private List<Friend> l;
        public frmMain()
        {
            InitializeComponent();
            l=new List<Friend>();
            nudK.Maximum = 0;
            loadCbTinhTrang();
        }
        private void loadCbTinhTrang()
        {
            cbTinhTrang.Items.Clear();
            cbTinhTrang.Items.Add("Không chơi game");
            cbTinhTrang.Items.Add("Chỉ chơi game giải trí");
            cbTinhTrang.Items.Add("Nghiện game nhẹ");
            cbTinhTrang.Items.Add("Nghiện game nặng");
            cbTinhTrang.Text = "Không chơi game";
        }
        private void loadDSFriend()
        {
            dgvFriend.Rows.Clear();
            int stt = 0;
            foreach (Friend i in l)
            {
                DataGridViewRow row = (DataGridViewRow)dgvFriend.Rows[0].Clone();
                stt++;
                row.Cells[0].Value = stt + "";
                row.Cells[1].Value = i.Ten;
                row.Cells[2].Value = i.MucDoThanThiet+"";
                row.Cells[3].Value = i.TinhTrangNghienGame;
                dgvFriend.Rows.Add(row);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbHoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống !", "Nhắc nhở");
                return;
            }
            l.Add(new Friend(tbHoTen.Text,(int)nudMucDoThanThiet.Value,cbTinhTrang.Text));
            loadDSFriend();
            nudK.Maximum = l.Count;
            tbKQ.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(l.Count==0)
            {
                MessageBox.Show("Danh sách bạn của A còn trống !", "Nhắc nhở");
                return;
            }
            if ((int)nudK.Value == 0)
            {
                MessageBox.Show("Cấp khoanh vùng K phải lớn hơn 0 !", "Nhắc nhở");
                return;
            }
            KNN_algorithm knn = new KNN_algorithm(l, (int)nudK.Value);
            tbKQ.Text = knn.run();
        }
    }
}
