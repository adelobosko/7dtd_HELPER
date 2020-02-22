namespace _7dtd_HELP
{
    partial class GroupPrefabsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.brushSizeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.brushColorButton = new System.Windows.Forms.Button();
            this.setIconButton = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.bodyTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.leftSplitContainer = new System.Windows.Forms.SplitContainer();
            this.itemsListBox = new System.Windows.Forms.ListBox();
            this.itemLabel = new System.Windows.Forms.Label();
            this.prefabsListBox = new System.Windows.Forms.ListBox();
            this.addPanel = new System.Windows.Forms.Panel();
            this.addButton = new System.Windows.Forms.Button();
            this.addAllButton = new System.Windows.Forms.Button();
            this.prefabsLabel = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchLabel = new System.Windows.Forms.Label();
            this.rightSplitContainer = new System.Windows.Forms.SplitContainer();
            this.selectedPrefabsListBox = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.delButton = new System.Windows.Forms.Button();
            this.delAllButton = new System.Windows.Forms.Button();
            this.seklectedPrefabsLabel = new System.Windows.Forms.Label();
            this.selectedPrefabSearchTextBox = new System.Windows.Forms.TextBox();
            this.selectedPrefabsSearchLabel = new System.Windows.Forms.Label();
            this.blocksListBox = new System.Windows.Forms.ListBox();
            this.prefabInformationLabel = new System.Windows.Forms.Label();
            this.blockSearchTextBox = new System.Windows.Forms.TextBox();
            this.blockSearchLabel = new System.Windows.Forms.Label();
            this.bottomPanel.SuspendLayout();
            this.bodyTableLayoutPanel.SuspendLayout();
            this.leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftSplitContainer)).BeginInit();
            this.leftSplitContainer.Panel1.SuspendLayout();
            this.leftSplitContainer.Panel2.SuspendLayout();
            this.leftSplitContainer.SuspendLayout();
            this.addPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightSplitContainer)).BeginInit();
            this.rightSplitContainer.Panel1.SuspendLayout();
            this.rightSplitContainer.Panel2.SuspendLayout();
            this.rightSplitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.brushSizeTextBox);
            this.bottomPanel.Controls.Add(this.label1);
            this.bottomPanel.Controls.Add(this.brushColorButton);
            this.bottomPanel.Controls.Add(this.setIconButton);
            this.bottomPanel.Controls.Add(this.nameTextBox);
            this.bottomPanel.Controls.Add(this.nameLabel);
            this.bottomPanel.Controls.Add(this.saveButton);
            this.bottomPanel.Controls.Add(this.cancelButton);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 461);
            this.bottomPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(964, 37);
            this.bottomPanel.TabIndex = 0;
            // 
            // brushSizeTextBox
            // 
            this.brushSizeTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.brushSizeTextBox.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.brushSizeTextBox.Location = new System.Drawing.Point(592, 0);
            this.brushSizeTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.brushSizeTextBox.Name = "brushSizeTextBox";
            this.brushSizeTextBox.Size = new System.Drawing.Size(116, 41);
            this.brushSizeTextBox.TabIndex = 10;
            this.brushSizeTextBox.TextChanged += new System.EventHandler(this.brushSizeTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(478, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 37);
            this.label1.TabIndex = 9;
            this.label1.Text = "Brush size:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // brushColorButton
            // 
            this.brushColorButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.brushColorButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.brushColorButton.Location = new System.Drawing.Point(348, 0);
            this.brushColorButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.brushColorButton.Name = "brushColorButton";
            this.brushColorButton.Size = new System.Drawing.Size(130, 37);
            this.brushColorButton.TabIndex = 8;
            this.brushColorButton.Text = "BrushColor";
            this.brushColorButton.UseVisualStyleBackColor = true;
            this.brushColorButton.Click += new System.EventHandler(this.brushColorButton_Click);
            // 
            // setIconButton
            // 
            this.setIconButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.setIconButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.setIconButton.Location = new System.Drawing.Point(263, 0);
            this.setIconButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.setIconButton.Name = "setIconButton";
            this.setIconButton.Size = new System.Drawing.Size(85, 37);
            this.setIconButton.TabIndex = 7;
            this.setIconButton.Text = "Icon";
            this.setIconButton.UseVisualStyleBackColor = true;
            this.setIconButton.Click += new System.EventHandler(this.setIconButton_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.nameTextBox.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameTextBox.Location = new System.Drawing.Point(114, 0);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(149, 41);
            this.nameTextBox.TabIndex = 6;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.nameLabel.Location = new System.Drawing.Point(0, 0);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(114, 37);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Group name:";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // saveButton
            // 
            this.saveButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.saveButton.Location = new System.Drawing.Point(794, 0);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(85, 37);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.cancelButton.Location = new System.Drawing.Point(879, 0);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(85, 37);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // bodyTableLayoutPanel
            // 
            this.bodyTableLayoutPanel.ColumnCount = 2;
            this.bodyTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.bodyTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.bodyTableLayoutPanel.Controls.Add(this.leftPanel, 0, 0);
            this.bodyTableLayoutPanel.Controls.Add(this.rightSplitContainer, 1, 0);
            this.bodyTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.bodyTableLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bodyTableLayoutPanel.Name = "bodyTableLayoutPanel";
            this.bodyTableLayoutPanel.RowCount = 1;
            this.bodyTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.bodyTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 462F));
            this.bodyTableLayoutPanel.Size = new System.Drawing.Size(964, 461);
            this.bodyTableLayoutPanel.TabIndex = 4;
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.leftSplitContainer);
            this.leftPanel.Controls.Add(this.searchTextBox);
            this.leftPanel.Controls.Add(this.searchLabel);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftPanel.Location = new System.Drawing.Point(4, 3);
            this.leftPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(474, 455);
            this.leftPanel.TabIndex = 0;
            // 
            // leftSplitContainer
            // 
            this.leftSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftSplitContainer.Location = new System.Drawing.Point(0, 42);
            this.leftSplitContainer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.leftSplitContainer.Name = "leftSplitContainer";
            // 
            // leftSplitContainer.Panel1
            // 
            this.leftSplitContainer.Panel1.Controls.Add(this.itemsListBox);
            this.leftSplitContainer.Panel1.Controls.Add(this.itemLabel);
            // 
            // leftSplitContainer.Panel2
            // 
            this.leftSplitContainer.Panel2.Controls.Add(this.prefabsListBox);
            this.leftSplitContainer.Panel2.Controls.Add(this.addPanel);
            this.leftSplitContainer.Panel2.Controls.Add(this.prefabsLabel);
            this.leftSplitContainer.Size = new System.Drawing.Size(474, 413);
            this.leftSplitContainer.SplitterDistance = 154;
            this.leftSplitContainer.TabIndex = 6;
            // 
            // itemsListBox
            // 
            this.itemsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemsListBox.FormattingEnabled = true;
            this.itemsListBox.ItemHeight = 17;
            this.itemsListBox.Location = new System.Drawing.Point(0, 18);
            this.itemsListBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.itemsListBox.Name = "itemsListBox";
            this.itemsListBox.Size = new System.Drawing.Size(154, 395);
            this.itemsListBox.TabIndex = 7;
            this.itemsListBox.SelectedIndexChanged += new System.EventHandler(this.itemsListBox_SelectedIndexChanged);
            // 
            // itemLabel
            // 
            this.itemLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.itemLabel.Location = new System.Drawing.Point(0, 0);
            this.itemLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.itemLabel.Name = "itemLabel";
            this.itemLabel.Size = new System.Drawing.Size(154, 18);
            this.itemLabel.TabIndex = 9;
            this.itemLabel.Text = "Items:";
            this.itemLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // prefabsListBox
            // 
            this.prefabsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prefabsListBox.FormattingEnabled = true;
            this.prefabsListBox.ItemHeight = 17;
            this.prefabsListBox.Location = new System.Drawing.Point(0, 18);
            this.prefabsListBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.prefabsListBox.Name = "prefabsListBox";
            this.prefabsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.prefabsListBox.Size = new System.Drawing.Size(316, 356);
            this.prefabsListBox.TabIndex = 11;
            // 
            // addPanel
            // 
            this.addPanel.Controls.Add(this.addButton);
            this.addPanel.Controls.Add(this.addAllButton);
            this.addPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.addPanel.Location = new System.Drawing.Point(0, 374);
            this.addPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.addPanel.Name = "addPanel";
            this.addPanel.Size = new System.Drawing.Size(316, 39);
            this.addPanel.TabIndex = 12;
            // 
            // addButton
            // 
            this.addButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.addButton.Location = new System.Drawing.Point(146, 0);
            this.addButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(85, 39);
            this.addButton.TabIndex = 1;
            this.addButton.Text = ">";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // addAllButton
            // 
            this.addAllButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.addAllButton.Location = new System.Drawing.Point(231, 0);
            this.addAllButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.addAllButton.Name = "addAllButton";
            this.addAllButton.Size = new System.Drawing.Size(85, 39);
            this.addAllButton.TabIndex = 0;
            this.addAllButton.Text = ">>";
            this.addAllButton.UseVisualStyleBackColor = true;
            this.addAllButton.Click += new System.EventHandler(this.addAllButton_Click);
            // 
            // prefabsLabel
            // 
            this.prefabsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.prefabsLabel.Location = new System.Drawing.Point(0, 0);
            this.prefabsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.prefabsLabel.Name = "prefabsLabel";
            this.prefabsLabel.Size = new System.Drawing.Size(316, 18);
            this.prefabsLabel.TabIndex = 10;
            this.prefabsLabel.Text = "Prefabs:";
            this.prefabsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchTextBox.Location = new System.Drawing.Point(0, 18);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(474, 24);
            this.searchTextBox.TabIndex = 5;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // searchLabel
            // 
            this.searchLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchLabel.Location = new System.Drawing.Point(0, 0);
            this.searchLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(474, 18);
            this.searchLabel.TabIndex = 5;
            this.searchLabel.Text = "Search:";
            this.searchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightSplitContainer
            // 
            this.rightSplitContainer.Location = new System.Drawing.Point(486, 3);
            this.rightSplitContainer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rightSplitContainer.Name = "rightSplitContainer";
            // 
            // rightSplitContainer.Panel1
            // 
            this.rightSplitContainer.Panel1.Controls.Add(this.selectedPrefabsListBox);
            this.rightSplitContainer.Panel1.Controls.Add(this.panel1);
            this.rightSplitContainer.Panel1.Controls.Add(this.seklectedPrefabsLabel);
            this.rightSplitContainer.Panel1.Controls.Add(this.selectedPrefabSearchTextBox);
            this.rightSplitContainer.Panel1.Controls.Add(this.selectedPrefabsSearchLabel);
            // 
            // rightSplitContainer.Panel2
            // 
            this.rightSplitContainer.Panel2.Controls.Add(this.blocksListBox);
            this.rightSplitContainer.Panel2.Controls.Add(this.prefabInformationLabel);
            this.rightSplitContainer.Panel2.Controls.Add(this.blockSearchTextBox);
            this.rightSplitContainer.Panel2.Controls.Add(this.blockSearchLabel);
            this.rightSplitContainer.Size = new System.Drawing.Size(474, 451);
            this.rightSplitContainer.SplitterDistance = 222;
            this.rightSplitContainer.TabIndex = 4;
            // 
            // selectedPrefabsListBox
            // 
            this.selectedPrefabsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedPrefabsListBox.FormattingEnabled = true;
            this.selectedPrefabsListBox.ItemHeight = 17;
            this.selectedPrefabsListBox.Location = new System.Drawing.Point(0, 60);
            this.selectedPrefabsListBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.selectedPrefabsListBox.Name = "selectedPrefabsListBox";
            this.selectedPrefabsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.selectedPrefabsListBox.Size = new System.Drawing.Size(222, 352);
            this.selectedPrefabsListBox.TabIndex = 6;
            this.selectedPrefabsListBox.SelectedIndexChanged += new System.EventHandler(this.selectedPrefabsListBox_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.delButton);
            this.panel1.Controls.Add(this.delAllButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 412);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(222, 39);
            this.panel1.TabIndex = 13;
            // 
            // delButton
            // 
            this.delButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.delButton.Location = new System.Drawing.Point(85, 0);
            this.delButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(85, 39);
            this.delButton.TabIndex = 1;
            this.delButton.Text = "<";
            this.delButton.UseVisualStyleBackColor = true;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // delAllButton
            // 
            this.delAllButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.delAllButton.Location = new System.Drawing.Point(0, 0);
            this.delAllButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.delAllButton.Name = "delAllButton";
            this.delAllButton.Size = new System.Drawing.Size(85, 39);
            this.delAllButton.TabIndex = 0;
            this.delAllButton.Text = "<<";
            this.delAllButton.UseVisualStyleBackColor = true;
            this.delAllButton.Click += new System.EventHandler(this.delAllButton_Click);
            // 
            // seklectedPrefabsLabel
            // 
            this.seklectedPrefabsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.seklectedPrefabsLabel.Location = new System.Drawing.Point(0, 42);
            this.seklectedPrefabsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.seklectedPrefabsLabel.Name = "seklectedPrefabsLabel";
            this.seklectedPrefabsLabel.Size = new System.Drawing.Size(222, 18);
            this.seklectedPrefabsLabel.TabIndex = 7;
            this.seklectedPrefabsLabel.Text = "Selected prefabs:";
            this.seklectedPrefabsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // selectedPrefabSearchTextBox
            // 
            this.selectedPrefabSearchTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectedPrefabSearchTextBox.Location = new System.Drawing.Point(0, 18);
            this.selectedPrefabSearchTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.selectedPrefabSearchTextBox.Name = "selectedPrefabSearchTextBox";
            this.selectedPrefabSearchTextBox.Size = new System.Drawing.Size(222, 24);
            this.selectedPrefabSearchTextBox.TabIndex = 4;
            this.selectedPrefabSearchTextBox.TextChanged += new System.EventHandler(this.selectedPrefabSearchTextBox_TextChanged);
            // 
            // selectedPrefabsSearchLabel
            // 
            this.selectedPrefabsSearchLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectedPrefabsSearchLabel.Location = new System.Drawing.Point(0, 0);
            this.selectedPrefabsSearchLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.selectedPrefabsSearchLabel.Name = "selectedPrefabsSearchLabel";
            this.selectedPrefabsSearchLabel.Size = new System.Drawing.Size(222, 18);
            this.selectedPrefabsSearchLabel.TabIndex = 3;
            this.selectedPrefabsSearchLabel.Text = "Selected search:";
            this.selectedPrefabsSearchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // blocksListBox
            // 
            this.blocksListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blocksListBox.FormattingEnabled = true;
            this.blocksListBox.ItemHeight = 17;
            this.blocksListBox.Location = new System.Drawing.Point(0, 60);
            this.blocksListBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.blocksListBox.Name = "blocksListBox";
            this.blocksListBox.Size = new System.Drawing.Size(248, 391);
            this.blocksListBox.TabIndex = 1;
            // 
            // prefabInformationLabel
            // 
            this.prefabInformationLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.prefabInformationLabel.Location = new System.Drawing.Point(0, 42);
            this.prefabInformationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.prefabInformationLabel.Name = "prefabInformationLabel";
            this.prefabInformationLabel.Size = new System.Drawing.Size(248, 18);
            this.prefabInformationLabel.TabIndex = 0;
            this.prefabInformationLabel.Text = "Prefab information:";
            this.prefabInformationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // blockSearchTextBox
            // 
            this.blockSearchTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.blockSearchTextBox.Location = new System.Drawing.Point(0, 18);
            this.blockSearchTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.blockSearchTextBox.Name = "blockSearchTextBox";
            this.blockSearchTextBox.Size = new System.Drawing.Size(248, 24);
            this.blockSearchTextBox.TabIndex = 0;
            this.blockSearchTextBox.TextChanged += new System.EventHandler(this.blockSearchTextBox_TextChanged);
            // 
            // blockSearchLabel
            // 
            this.blockSearchLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.blockSearchLabel.Location = new System.Drawing.Point(0, 0);
            this.blockSearchLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.blockSearchLabel.Name = "blockSearchLabel";
            this.blockSearchLabel.Size = new System.Drawing.Size(248, 18);
            this.blockSearchLabel.TabIndex = 2;
            this.blockSearchLabel.Text = "Block search:";
            this.blockSearchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GroupPrefabsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 498);
            this.Controls.Add(this.bodyTableLayoutPanel);
            this.Controls.Add(this.bottomPanel);
            this.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "GroupPrefabsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GroupPrefabs";
            this.Load += new System.EventHandler(this.GroupPrefabs_Load);
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.bodyTableLayoutPanel.ResumeLayout(false);
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            this.leftSplitContainer.Panel1.ResumeLayout(false);
            this.leftSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.leftSplitContainer)).EndInit();
            this.leftSplitContainer.ResumeLayout(false);
            this.addPanel.ResumeLayout(false);
            this.rightSplitContainer.Panel1.ResumeLayout(false);
            this.rightSplitContainer.Panel1.PerformLayout();
            this.rightSplitContainer.Panel2.ResumeLayout(false);
            this.rightSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightSplitContainer)).EndInit();
            this.rightSplitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TableLayoutPanel bodyTableLayoutPanel;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.SplitContainer leftSplitContainer;
        private System.Windows.Forms.ListBox itemsListBox;
        private System.Windows.Forms.Label itemLabel;
        private System.Windows.Forms.Panel addPanel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button addAllButton;
        private System.Windows.Forms.ListBox prefabsListBox;
        private System.Windows.Forms.Label prefabsLabel;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.SplitContainer rightSplitContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button delButton;
        private System.Windows.Forms.Button delAllButton;
        private System.Windows.Forms.ListBox selectedPrefabsListBox;
        private System.Windows.Forms.Label seklectedPrefabsLabel;
        private System.Windows.Forms.TextBox selectedPrefabSearchTextBox;
        private System.Windows.Forms.Label selectedPrefabsSearchLabel;
        private System.Windows.Forms.ListBox blocksListBox;
        private System.Windows.Forms.Label prefabInformationLabel;
        private System.Windows.Forms.TextBox blockSearchTextBox;
        private System.Windows.Forms.Label blockSearchLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button setIconButton;
        private System.Windows.Forms.Button brushColorButton;
        private System.Windows.Forms.TextBox brushSizeTextBox;
        private System.Windows.Forms.Label label1;
    }
}