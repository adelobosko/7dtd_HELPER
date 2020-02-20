using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7dtd_HELP
{
    public partial class GroupPrefabs : Form
    {
        public DecorationGroup Result = new DecorationGroup()
        {
            Name = DateTime.Now.Ticks + "gName",
            Prefabs = new List<Prefab>(),
            Icon = null,
            IsEnabled = true
        };
        private List<string> items = new List<string>();
        private List<Prefab> prefabs = new List<Prefab>();

        public GroupPrefabs()
        {
            InitializeComponent();
            var tempItemsList = new List<string>();

            foreach (var prefab in GlobalHelper.Config.PrefabsConfig.Prefabs)
            {
                var blocks = prefab.Blocks.Select(b => b.Name);
                tempItemsList.AddRange(blocks);
            }

            items = tempItemsList.Distinct().OrderBy(s => s).ToList();
            UpdateItemsListbox(items);
            UpdatePrefabsListbox(GlobalHelper.Config.PrefabsConfig.Prefabs);
        }

        private void UpdateItemsListbox(List<string> list)
        {
            itemsListBox.Items.Clear();
            foreach (var item in list)
            {
                itemsListBox.Items.Add(item);
            }
        }

        private void UpdatePrefabsListbox(List<Prefab> prefabs, string containsItem = null)
        {
            prefabsListBox.Items.Clear();
            if (containsItem == null)
            {
                foreach (var prefab in prefabs)
                {
                    prefabsListBox.Items.Add(prefab.Name + ":0");
                }
                this.prefabs = new List<Prefab>(prefabs);
            }
            else
            {
                var filteredPrefabs = prefabs.Where(p => p.Blocks.Count(b => string.Equals(b.Name, containsItem, StringComparison.CurrentCultureIgnoreCase)) > 0).OrderBy(p => p.Name).ToList();

                var selected = filteredPrefabs.Select(p => new
                {
                    Name = p.Name,
                    BlockCount = p.Blocks.SingleOrDefault(b => string.Equals(b.Name, containsItem, StringComparison.CurrentCultureIgnoreCase))?.Count
                }).OrderByDescending(a => a.BlockCount).ThenBy(a => a.Name);

                foreach (var item in selected)
                {
                    prefabsListBox.Items.Add($"{item.Name}:{item.BlockCount}");
                }

                this.prefabs = new List<Prefab>(filteredPrefabs);
            }

            if (prefabsListBox.Items.Count > 0)
            {
                prefabsListBox.SelectedIndex = 0;
            }
        }

        private void GroupPrefabs_Load(object sender, EventArgs e)
        {
            nameTextBox.Text = Result.Name;
            UpdateSelectedPrefabs(Result.Prefabs);
            if (Result.Icon == null)
                return;
            widthTextBox.Text = Result.Icon.Width.ToString();
            heightTextBox.Text = Result.Icon.Height.ToString();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            var text = searchTextBox.Text;
            var tempItemsList = items.Where(b => b.ToLower().Contains(text.ToLower())).ToList();
            UpdateItemsListbox(tempItemsList);

            var tempPrefabsList = GlobalHelper.Config.PrefabsConfig.Prefabs
                .Where(p => p.Name.ToLower().Contains(text.ToLower()))
                .ToList();
            UpdatePrefabsListbox(tempPrefabsList);
        }

        private void itemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = itemsListBox.SelectedIndex;
            if (index >= itemsListBox.Items.Count || index <= -1) return;

            var itemName = itemsListBox.Items[index].ToString();
            UpdatePrefabsListbox(GlobalHelper.Config.PrefabsConfig.Prefabs, itemName);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var selItems = prefabsListBox.SelectedItems;
            foreach (var item in selItems)
            {
                var prefabName = item.ToString().Split(':')[0];
                var prefab = prefabs.FirstOrDefault(p => p?.Name == prefabName);
                if (prefab == null) continue;

                if (Result.Prefabs.Count(sp => sp.Name == prefabName) == 0)
                {
                    Result.Prefabs.Add(prefab);
                }
            }
            UpdateSelectedPrefabs(Result.Prefabs);
        }

        private void addAllButton_Click(object sender, EventArgs e)
        {
            var prefabsItems = prefabsListBox.Items;
            foreach (var item in prefabsItems)
            {
                var prefabName = item.ToString().Split(':')[0];
                var prefab = prefabs.FirstOrDefault(p => p?.Name == prefabName);
                if (prefab == null) continue;

                if (Result.Prefabs.Count(sp => sp.Name == prefabName) == 0)
                {
                    Result.Prefabs.Add(prefab);
                }
            }
            UpdateSelectedPrefabs(Result.Prefabs);
        }

        private void UpdateSelectedPrefabs(List<Prefab> list, string contains = null)
        {
            var tempList = list.OrderBy(p => p.Name);
            selectedPrefabsListBox.Items.Clear();
            if (contains != null)
            {
                tempList = list.Where(p => p.Name.ToLower().Contains(contains)).OrderBy(p => p.Name);
            }

            foreach (var item in tempList)
            {
                selectedPrefabsListBox.Items.Add(item.Name);
            }
        }

        private void selectedPrefabSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            var text = selectedPrefabSearchTextBox.Text;
            UpdateSelectedPrefabs(Result.Prefabs, text);
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            var selItems = selectedPrefabsListBox.SelectedItems;
            foreach (var item in selItems)
            {
                var prefabName = item.ToString();
                var prefab = Result.Prefabs.SingleOrDefault(p => p?.Name == prefabName);
                if (prefab == null) continue;

                Result.Prefabs.Remove(prefab);
            }
            UpdateSelectedPrefabs(Result.Prefabs);
        }

        private void delAllButton_Click(object sender, EventArgs e)
        {
            Result.Prefabs.Clear();
            UpdateSelectedPrefabs(Result.Prefabs);
        }

        private void selectedPrefabsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listbox = selectedPrefabsListBox;
            var index = listbox.SelectedIndex;
            if (index >= listbox.Items.Count || index <= -1) return;

            var itemName = listbox.Items[index].ToString();
            UpdateBlocksListbox(Result.Prefabs, itemName);
        }

        private void UpdateBlocksListbox(List<Prefab> list, string itemName)
        {
            blocksListBox.Items.Clear();
            var prefab = list.SingleOrDefault(p => p.Name == itemName);
            if(prefab == null)
                return;

            foreach (var block in prefab.Blocks.OrderBy(b => b.Name))
            {
                blocksListBox.Items.Add($"{block.Name}:{block.Count}");
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            var name = nameTextBox.Text;
            Result.Name = name;
        }

        private void setIconButton_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                try
                {
                    Result.Icon = new Icon()
                    {
                        FullName = openFileDialog.FileName,
                        Width = -1,
                        Height = -1,
                        IsShow = true
                    };
                    widthTextBox.Text = Result.Icon.Width.ToString();
                    heightTextBox.Text = Result.Icon.Height.ToString();
                }
                catch
                {
                }
            }
        }

        private void widthTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Result.Icon == null)
                {
                    return;
                }

                Result.Icon.Width = int.Parse(widthTextBox.Text);
            }
            catch { }
        }

        private void heightTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Result.Icon == null)
                {
                    return;
                }

                Result.Icon.Height = int.Parse(heightTextBox.Text);
            }
            catch { }
        }
    }
}
