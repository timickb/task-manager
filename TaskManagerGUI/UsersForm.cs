using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TaskManagerCLI;

namespace TaskManagerGUI
{
    public partial class UsersForm : Form
    {
        private CommandExecutor CmdExecutor { get; }

        public UsersForm(CommandExecutor ex)
        {
            CmdExecutor = ex;
            InitializeComponent();
            UpdateUsersList();

  
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            var form = new InputDialog("Введите имя нового пользователя");
            form.ShowDialog();
            var userName = form.Value;

            var result = CmdExecutor.Execute($"add_user {userName}");
            if (result.Status == CommandExecutionStatus.OK)
            {
                MessageBox.Show(result.TextOutput, "Сообщение");
            }
            else
            {
                MessageBox.Show(result.TextOutput, "Ошибка");
            }
            UpdateUsersList();
            TaskManagerAPI.TaskManager.GetInstance().CommitChanges();
        }

        private void RemoveUserButton_Click(object sender, EventArgs e)
        {
            var selectedItem = listView.SelectedItems;

            if (selectedItem == null) return;
            int userId;

            try
            {
                userId = (int)selectedItem[0].Tag;
            } catch(ArgumentOutOfRangeException)
            {
                return;
            }

            var result = CmdExecutor.Execute($"remove_user {userId}");
            MessageBox.Show(result.TextOutput,
                result.Status == CommandExecutionStatus.OK ? "Сообщение" : "Ошибка");
            UpdateUsersList();
            TaskManagerAPI.TaskManager.GetInstance().CommitChanges();
        }

        private void UpdateUsersList()
        {
            listView.Items.Clear();
            var users = TaskManagerAPI.TaskManager.GetInstance().Users;

            foreach (var user in users)
            {
                var listItem = new ListViewItem(user.ToString());
                listItem.Tag = user.Id;
                listView.Items.Add(listItem);
            }
            
            // В label1 положим информацию о количестве пользователей.
            label1.Text = $"{users.Count} пользователей:";
        }
    }
}
