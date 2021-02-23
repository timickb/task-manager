using System.Windows.Forms;
using TaskManagerAPI;

namespace TaskManagerGUI
{
    /// <summary>
    /// ListViewItem, адаптированный для
    /// работы с проектом.
    /// </summary>
    public class ProjectListViewItem : ListViewItem
    {
        public Project ConnectedProject { get; private set; }
        
        public ProjectListViewItem(Project project)
        {
            this.Text = project.ToString();
            ConnectedProject = project;
        }
    }
}