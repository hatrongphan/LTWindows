using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_NHASACH.Modules;

namespace QL_NHASACH
{
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtPassNew, "");
            errorProvider1.SetError(txtConfirmPass, "");
            //check password new
            if (txtPassNew.Text.Length < 8 || !txtPassNew.Text.Any(char.IsDigit) || !txtPassNew.Text.Any(char.IsLower) || !txtPassNew.Text.Any(char.IsUpper))
            {
                errorProvider1.SetError(txtPassNew, "Mật Khẩu Mới Tối Thiểu 8 Kí Tự, Bao Gồm Cả Chữ Số, " + "In Hoa, In Thường.");
                return;
            }
            //check pasword confirm
            if (txtPassNew.Text!= txtConfirmPass.Text)
            {
                errorProvider1.SetError(txtConfirmPass, "Mật Khẩu Nhập Lại Không Trùng!!! Vui Lòng Kiểm Tra Lại!");
                return;
            }

            frmMain f = (frmMain)this.MdiParent;
            int count = XLBANG.Thuc_hien_lenh("Update NHANVIEN set Password= '" + txtPassNew.Text + "' where MaNV ='" + f.maNV + " ' ");
            if (count > 0)
            {
                MessageBox.Show("Cập Nhật Mật Khẩu Thành Công!");
            }
            else
            {
                MessageBox.Show("Mật Khẩu Không Hợp Lệ!!! Vui Lòng Kiểm Tra Lại!");
            }    
        }
    }
}
