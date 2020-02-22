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
    public partial class GroupPrefabsForm : Form
    {
        public DecorationGroup Result = new DecorationGroup()
        {
            Name = DateTime.Now.Ticks + "gName",
            Prefabs = new List<Prefab>(),
            Icon = null,
            IsEnabled = true,
            BrushColor = DecorationGroup.DefaultBrush,
            BrushSize = DecorationGroup.DefaultBrushSize
        };
        private List<string> items = new List<string>();
        private List<Prefab> prefabs = new List<Prefab>();

        public GroupPrefabsForm()
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
            setIconButton.Image = Result.Icon == null
                ? new Bitmap(16, 16)
                : Image.FromFile(Result.Icon.FullName).ResizeImage(16, 16);
            brushSizeTextBox.Text = Result.BrushSize.ToString();
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
                    prefab.Description = item.ToString().Split(':')[1];
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
                    prefab.Description = item.ToString().Split(':')[1];
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
            var setIconForm = new SetIconForm();
            setIconForm.Icon = Result.Icon;
            setIconForm.PreviewIcon();
            if (setIconForm.ShowDialog(this) == DialogResult.OK)
            {
                var resultIcon = setIconForm.Icon;
                Result.Icon = resultIcon;
            }
            setIconForm.Dispose();
            setIconButton.Image = Result.Icon == null 
                ? new Bitmap(16, 16) 
                : Image.FromFile(Result.Icon.FullName).ResizeImage(16, 16);
        }

        private void brushColorButton_Click(object sender, EventArgs e)
        {
            var colorDialog1 = new ColorDialog();
            SolidBrush color;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                color = new SolidBrush(colorDialog1.Color);
                Result.BrushColor = color;
            }
        }

        private void brushSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var brushSize = Convert.ToInt32(brushSizeTextBox.Text);
                Result.BrushSize = brushSize > 0 ? brushSize : 1;
            }
            catch { }
        }

        private void blockSearchTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
