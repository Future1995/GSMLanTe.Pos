
using GSMLanTe.Model;
using GSMLanTe.POS.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSMLanTe.POS
{
    public partial class GoodsWeb : Form
    {
        public GoodsWeb()
        {
            InitializeComponent();
        }
        private GoodsService goodsService = new GoodsService();

        private void GoodsWeb_Load(object sender, EventArgs e)
        {

            var ds = goodsService.GetGoodsAll();

            dgvWebGoods.DataSource = ds.Tables[0];
            dgvWebGoods.Columns[0].HeaderCell.Value = "ID";
            dgvWebGoods.Columns[1].HeaderCell.Value = "编号";
            dgvWebGoods.Columns[2].HeaderCell.Value = "商品名称";
            dgvWebGoods.Columns[3].HeaderCell.Value = "库存";
            dgvWebGoods.Columns[4].HeaderCell.Value = "店存";
            dgvWebGoods.Columns[5].HeaderCell.Value = "单价";
            dgvWebGoods.Columns[6].HeaderCell.Value = "VIP价";
            dgvWebGoods.Columns[7].HeaderCell.Value = "批发价";
            dgvWebGoods.Columns[8].HeaderCell.Value = "图片";
            dgvWebGoods.Columns[0].ReadOnly = true;
            dgvWebGoods.Columns[1].ReadOnly = true;
            dgvWebGoods.Columns[2].ReadOnly = true;
            dgvWebGoods.Columns[0].Width = 39;
            dgvWebGoods.Columns[1].Width = 85;
            dgvWebGoods.Columns[2].Width = 225;
            dgvWebGoods.Columns[3].Width = 55;
            dgvWebGoods.Columns[4].Width = 55;
            dgvWebGoods.Columns[5].Width = 55;
            dgvWebGoods.Columns[6].Width = 60;
            dgvWebGoods.Columns[7].Width = 65;
            dgvWebGoods.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvWebGoods.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvWebGoods.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvWebGoods.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvWebGoods.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //int index = dataGridView1.CurrentRow.Index;
            //this.dataGridView1.Rows[index].Cells[7].Value = "http://www.fssay.com/" + dataGridView1.Rows[index].Cells[7].Value.ToString();
            //编号和ID设置只读
            dgvWebGoods.Columns[0].ReadOnly = true;
            dgvWebGoods.Columns[1].ReadOnly = true;
            dgvWebGoods.Columns[2].ReadOnly = false;
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Reseta_Click(object sender, EventArgs e)
        {
            //dataGridView1.Rows.Clear(); //清除表数据
            DataTable dt = (DataTable)dgvWebGoods.DataSource;
            dt.Rows.Clear();
            dgvWebGoods.DataSource = dt;
            txtNo.Text = "";
            txtName.Text = "";
            txtPCS.Text = "";
            txtStorePCS.Text = "";
            txtPrice.Text = "";
            txtVipPrice.Text = "";
            if (pictureBox1.Image != null)
            {
                //有图片
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            else
            {
                //无图片
            }
            //  var ds = service.GetGoodsAll();
            // WebGoods.DataSource = ds.Tables[0];
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //dataGridView1.Rows.Clear(); //清除表数据
            DataTable dt = (DataTable)dgvWebGoods.DataSource;
            dt.Rows.Clear();
            dgvWebGoods.DataSource = dt;
            txtNo.Text = "";
            txtName.Text = "";
            txtPCS.Text = "";
            txtStorePCS.Text = "";
            txtPrice.Text = "";
            txtVipPrice.Text = "";
            if (pictureBox1.Image != null)
            {
                //有图片
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            else
            {
                //无图片
            }
            // var ds = service.Getsearch();
            //dataGridView1.DataSource = ds.Tables[0];
        }

        private void dgvWebGoods_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvWebGoods.CurrentRow.Index;   // i表示选中行的行号（如选中第3行，则 i =2）
            txtNo.Text = dgvWebGoods.Rows[i].Cells[1].Value.ToString();  //选中行的第2列放入文本框中
            txtName.Text = dgvWebGoods.Rows[i].Cells[2].Value.ToString();  //选中行的第3列放入文本框中
            txtPCS.Text = dgvWebGoods.Rows[i].Cells[3].Value.ToString();  //选中行的第4列放入文本框中
            txtStorePCS.Text = dgvWebGoods.Rows[i].Cells[4].Value.ToString();  //选中行的第5列放入文本框中
            txtPrice.Text = dgvWebGoods.Rows[i].Cells[5].Value.ToString();  //选中行的第6列放入文本框中
            txtVipPrice.Text = dgvWebGoods.Rows[i].Cells[6].Value.ToString();  //选中行的第7列放入文本框中
            pictureBox1.ImageLocation = "http://www.fssay.com/" + dgvWebGoods.Rows[i].Cells[8].Value.ToString();  //选中行的第8列放入图片框中
        }

        //修改单元格数据事件
        private void dgvWebGoods_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvWebGoods.Rows.Count > 0)
            {
                Goods goods = new Goods();
                //{
                //    Id = int.Parse(this.dgvWebGoods.Rows[e.RowIndex].Cells[0].Value.ToString()),
                //    No = this.dgvWebGoods.Rows[e.RowIndex].Cells[1].Value.ToString(),
                //    Name = this.dgvWebGoods.Rows[e.RowIndex].Cells[2].Value.ToString(),
                //    PCS = int.Parse(this.dgvWebGoods.Rows[e.RowIndex].Cells[3].Value.ToString()),
                //    StorePCS = int.Parse(this.dgvWebGoods.Rows[e.RowIndex].Cells[4].Value.ToString()),
                //    Price = float.Parse(this.dgvWebGoods.Rows[e.RowIndex].Cells[5].Value.ToString()),
                //    VipPrice = float.Parse(this.dgvWebGoods.Rows[e.RowIndex].Cells[6].Value.ToString()),
                //    WholesalePrice = float.Parse(this.dgvWebGoods.Rows[e.RowIndex].Cells[7].Value.ToString()),
                //};
               
                string wholesalePrice = this.dgvWebGoods.Rows[e.RowIndex].Cells[7].Value.ToString();
                goods.Id = int.Parse(this.dgvWebGoods.Rows[e.RowIndex].Cells[0].Value.ToString());
                goods.No = this.dgvWebGoods.Rows[e.RowIndex].Cells[1].Value.ToString();
                goods.Name = this.dgvWebGoods.Rows[e.RowIndex].Cells[2].Value.ToString();
                goods.PCS = int.Parse(this.dgvWebGoods.Rows[e.RowIndex].Cells[3].Value.ToString());
                goods.StorePCS = int.Parse(this.dgvWebGoods.Rows[e.RowIndex].Cells[4].Value.ToString());
                goods.Price = float.Parse(this.dgvWebGoods.Rows[e.RowIndex].Cells[5].Value.ToString());
                goods.VipPrice = float.Parse(this.dgvWebGoods.Rows[e.RowIndex].Cells[6].Value.ToString());
                if (wholesalePrice == "")
                {
                    goods.WholesalePrice = null;
                }
                else {
                    goods.WholesalePrice =  float.Parse(wholesalePrice);
                }
                //调用服务更新数据
                var result = goodsService.UpdateGoodsInfo(goods);
                if (!result)
                {
                    MessageBox.Show("更新数据库失败，出现异常");
                }
            }
        }
    }
}
