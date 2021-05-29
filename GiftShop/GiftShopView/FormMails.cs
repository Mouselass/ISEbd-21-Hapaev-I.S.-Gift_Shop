using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GiftShopBusinessLogic.BusinessLogic;
using GiftShopBusinessLogic.ViewModels;
using GiftShopBusinessLogic.BindingModels;

namespace GiftShopView
{
    public partial class FormMails : Form
    {
        private readonly MailLogic logic;

        private PageViewModel pageViewModel;

        public FormMails(MailLogic mailLogic)
        {
            logic = mailLogic;
            InitializeComponent();
        }

        private void FormMails_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData(int page = 1)
        {
            int pageSize = 7;

            var list = logic.GetMessagesForPage(new MessageInfoBindingModel
            {
                Page = page,
                PageSize = pageSize
            });

            if (list != null)
            {
                pageViewModel = new PageViewModel(logic.Count(), page, pageSize, list);

                Program.ConfigGrid(pageViewModel.Messages, dataGridView);
            }

            int pageStart = page < 3 ? 1 : page - 2;
            Button[] buttons = { buttonPage1, buttonPage2, buttonPage3, buttonPage4, buttonPage5 };
            for (int i = 0; i < buttons.Length; ++i)
            {
                buttons[i].Show();
                SetButtonPagetext(buttons[i], pageStart + i, pageViewModel.TotalPages);
            }
        }

        private void SetButtonPagetext(Button button, int pageNumber, int totalPages)
        {
            if (pageNumber <= totalPages)
            {
                button.Text = pageNumber.ToString();
            }
            else
            {
                button.Hide();
            }
        }

            private void buttonNext_Click(object sender, EventArgs e)
        {
            if (pageViewModel.HasNextPage)
            {
                LoadData(pageViewModel.PageNumber + 1);
            }
            else
            {
                MessageBox.Show("Это последняя страница", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (pageViewModel.HasPreviousPage)
            {
                LoadData(pageViewModel.PageNumber - 1);
            }
            else
            {
                MessageBox.Show("Это первая страница", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPage_Click(object sender, EventArgs e)
        {
            LoadData(Convert.ToInt32(((Button)sender).Text));
        }
    }
}
