namespace GameFootball
{
    partial class FootballGameForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PlayerTimer = new System.Windows.Forms.Timer(this.components);
            this.ChangImage_timer = new System.Windows.Forms.Timer(this.components);
            this.checktimer = new System.Windows.Forms.Timer(this.components);
            this.firstTeamLabel = new System.Windows.Forms.Label();
            this.secondTeamScoreLabel = new System.Windows.Forms.Label();
            this.firstTeamScoreLabel = new System.Windows.Forms.Label();
            this.secondTeamLabel = new System.Windows.Forms.Label();
            this.goalLabel = new System.Windows.Forms.Label();
            this.whoScoredLabel = new System.Windows.Forms.Label();
            this.scoredGoalLabel = new System.Windows.Forms.Label();
            this.slashLabel = new System.Windows.Forms.Label();
            this.secondTeamGoal = new System.Windows.Forms.PictureBox();
            this.firstTeamGoal = new System.Windows.Forms.PictureBox();
            this.rightForw = new System.Windows.Forms.PictureBox();
            this.centralForw = new System.Windows.Forms.PictureBox();
            this.leftForw = new System.Windows.Forms.PictureBox();
            this.Mid5 = new System.Windows.Forms.PictureBox();
            this.Mid1 = new System.Windows.Forms.PictureBox();
            this.Mid2 = new System.Windows.Forms.PictureBox();
            this.Goalkeeper = new System.Windows.Forms.PictureBox();
            this.aBall = new System.Windows.Forms.PictureBox();
            this.rightBottomPictBox = new System.Windows.Forms.PictureBox();
            this.rightHighPictBox = new System.Windows.Forms.PictureBox();
            this.leftHighPictBox = new System.Windows.Forms.PictureBox();
            this.leftBottomPictBox = new System.Windows.Forms.PictureBox();
            this.bottomPictBox = new System.Windows.Forms.PictureBox();
            this.highBoundPictBox = new System.Windows.Forms.PictureBox();
            this.Mid4 = new System.Windows.Forms.PictureBox();
            this.CentrDef2 = new System.Windows.Forms.PictureBox();
            this.CentrDef1 = new System.Windows.Forms.PictureBox();
            this.Mid3 = new System.Windows.Forms.PictureBox();
            this.BottomRightpictureBox5 = new System.Windows.Forms.PictureBox();
            this.TopRightpictureBox4 = new System.Windows.Forms.PictureBox();
            this.TopLeftPB = new System.Windows.Forms.PictureBox();
            this.bottomLeftPB = new System.Windows.Forms.PictureBox();
            this.BottomPictureBox = new System.Windows.Forms.PictureBox();
            this.ToppictureBox = new System.Windows.Forms.PictureBox();
            this.aPitch = new System.Windows.Forms.PictureBox();
            this.listViewWhoScored = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.secondTeamGoal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstTeamGoal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightForw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.centralForw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftForw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mid5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Goalkeeper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aBall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightBottomPictBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightHighPictBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftHighPictBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftBottomPictBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomPictBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.highBoundPictBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mid4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CentrDef2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CentrDef1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mid3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRightpictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRightpictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopLeftPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomLeftPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToppictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPitch)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 25;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PlayerTimer
            // 
            this.PlayerTimer.Enabled = true;
            this.PlayerTimer.Interval = 10;
            this.PlayerTimer.Tick += new System.EventHandler(this.PlayerTimer_Tick);
            // 
            // ChangImage_timer
            // 
            this.ChangImage_timer.Enabled = true;
            this.ChangImage_timer.Tick += new System.EventHandler(this.ChangImage_timer_Tick);
            // 
            // checktimer
            // 
            this.checktimer.Enabled = true;
            this.checktimer.Interval = 30;
            this.checktimer.Tick += new System.EventHandler(this.checktimer_Tick);
            // 
            // firstTeamLabel
            // 
            this.firstTeamLabel.AutoSize = true;
            this.firstTeamLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.firstTeamLabel.Font = new System.Drawing.Font("Britannic Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstTeamLabel.Location = new System.Drawing.Point(736, 9);
            this.firstTeamLabel.Name = "firstTeamLabel";
            this.firstTeamLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.firstTeamLabel.Size = new System.Drawing.Size(621, 135);
            this.firstTeamLabel.TabIndex = 22;
            this.firstTeamLabel.Text = "First Team";
            this.firstTeamLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // secondTeamScoreLabel
            // 
            this.secondTeamScoreLabel.AutoSize = true;
            this.secondTeamScoreLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.secondTeamScoreLabel.Font = new System.Drawing.Font("Britannic Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondTeamScoreLabel.Location = new System.Drawing.Point(1723, 9);
            this.secondTeamScoreLabel.Name = "secondTeamScoreLabel";
            this.secondTeamScoreLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.secondTeamScoreLabel.Size = new System.Drawing.Size(132, 135);
            this.secondTeamScoreLabel.TabIndex = 23;
            this.secondTeamScoreLabel.Text = "0";
            this.secondTeamScoreLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // firstTeamScoreLabel
            // 
            this.firstTeamScoreLabel.AutoSize = true;
            this.firstTeamScoreLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.firstTeamScoreLabel.Font = new System.Drawing.Font("Britannic Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstTeamScoreLabel.Location = new System.Drawing.Point(1359, 9);
            this.firstTeamScoreLabel.Name = "firstTeamScoreLabel";
            this.firstTeamScoreLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.firstTeamScoreLabel.Size = new System.Drawing.Size(132, 135);
            this.firstTeamScoreLabel.TabIndex = 24;
            this.firstTeamScoreLabel.Text = "0";
            this.firstTeamScoreLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // secondTeamLabel
            // 
            this.secondTeamLabel.AutoSize = true;
            this.secondTeamLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.secondTeamLabel.Font = new System.Drawing.Font("Britannic Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondTeamLabel.Location = new System.Drawing.Point(1861, 9);
            this.secondTeamLabel.Name = "secondTeamLabel";
            this.secondTeamLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.secondTeamLabel.Size = new System.Drawing.Size(763, 135);
            this.secondTeamLabel.TabIndex = 25;
            this.secondTeamLabel.Text = "Second Team";
            this.secondTeamLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // goalLabel
            // 
            this.goalLabel.AutoSize = true;
            this.goalLabel.BackColor = System.Drawing.Color.Transparent;
            this.goalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.goalLabel.Location = new System.Drawing.Point(1293, 526);
            this.goalLabel.Name = "goalLabel";
            this.goalLabel.Size = new System.Drawing.Size(940, 78);
            this.goalLabel.TabIndex = 31;
            this.goalLabel.Text = "GOOOOOOOOAAAAAAAL!!!";
            this.goalLabel.Visible = false;
            // 
            // whoScoredLabel
            // 
            this.whoScoredLabel.BackColor = System.Drawing.Color.Transparent;
            this.whoScoredLabel.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.whoScoredLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.whoScoredLabel.Location = new System.Drawing.Point(1315, 594);
            this.whoScoredLabel.Name = "whoScoredLabel";
            this.whoScoredLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.whoScoredLabel.Size = new System.Drawing.Size(935, 117);
            this.whoScoredLabel.TabIndex = 32;
            this.whoScoredLabel.Text = "Valya";
            this.whoScoredLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.whoScoredLabel.Visible = false;
            // 
            // scoredGoalLabel
            // 
            this.scoredGoalLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoredGoalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scoredGoalLabel.Location = new System.Drawing.Point(1249, 711);
            this.scoredGoalLabel.Name = "scoredGoalLabel";
            this.scoredGoalLabel.Size = new System.Drawing.Size(1107, 85);
            this.scoredGoalLabel.TabIndex = 33;
            this.scoredGoalLabel.Text = "scored a screamer!!!";
            this.scoredGoalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.scoredGoalLabel.Visible = false;
            // 
            // slashLabel
            // 
            this.slashLabel.AutoSize = true;
            this.slashLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.slashLabel.Font = new System.Drawing.Font("Britannic Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slashLabel.Location = new System.Drawing.Point(1551, 9);
            this.slashLabel.Name = "slashLabel";
            this.slashLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.slashLabel.Size = new System.Drawing.Size(121, 135);
            this.slashLabel.TabIndex = 34;
            this.slashLabel.Text = "--";
            this.slashLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // secondTeamGoal
            // 
            this.secondTeamGoal.BackColor = System.Drawing.Color.White;
            this.secondTeamGoal.Location = new System.Drawing.Point(2980, 638);
            this.secondTeamGoal.Name = "secondTeamGoal";
            this.secondTeamGoal.Size = new System.Drawing.Size(20, 408);
            this.secondTeamGoal.TabIndex = 30;
            this.secondTeamGoal.TabStop = false;
            // 
            // firstTeamGoal
            // 
            this.firstTeamGoal.BackColor = System.Drawing.Color.White;
            this.firstTeamGoal.Location = new System.Drawing.Point(400, 637);
            this.firstTeamGoal.Name = "firstTeamGoal";
            this.firstTeamGoal.Size = new System.Drawing.Size(20, 408);
            this.firstTeamGoal.TabIndex = 29;
            this.firstTeamGoal.TabStop = false;
            // 
            // rightForw
            // 
            this.rightForw.BackColor = System.Drawing.Color.Black;
            this.rightForw.Location = new System.Drawing.Point(2183, 1184);
            this.rightForw.Name = "rightForw";
            this.rightForw.Size = new System.Drawing.Size(24, 86);
            this.rightForw.TabIndex = 28;
            this.rightForw.TabStop = false;
            // 
            // centralForw
            // 
            this.centralForw.BackColor = System.Drawing.Color.Black;
            this.centralForw.Location = new System.Drawing.Point(2183, 793);
            this.centralForw.Name = "centralForw";
            this.centralForw.Size = new System.Drawing.Size(24, 86);
            this.centralForw.TabIndex = 27;
            this.centralForw.TabStop = false;
            // 
            // leftForw
            // 
            this.leftForw.BackColor = System.Drawing.Color.Black;
            this.leftForw.Location = new System.Drawing.Point(2183, 402);
            this.leftForw.Name = "leftForw";
            this.leftForw.Size = new System.Drawing.Size(24, 86);
            this.leftForw.TabIndex = 26;
            this.leftForw.TabStop = false;
            // 
            // Mid5
            // 
            this.Mid5.BackColor = System.Drawing.Color.Black;
            this.Mid5.Location = new System.Drawing.Point(1422, 1294);
            this.Mid5.Name = "Mid5";
            this.Mid5.Size = new System.Drawing.Size(24, 86);
            this.Mid5.TabIndex = 21;
            this.Mid5.TabStop = false;
            // 
            // Mid1
            // 
            this.Mid1.BackColor = System.Drawing.Color.Black;
            this.Mid1.Location = new System.Drawing.Point(1422, 284);
            this.Mid1.Name = "Mid1";
            this.Mid1.Size = new System.Drawing.Size(24, 86);
            this.Mid1.TabIndex = 20;
            this.Mid1.TabStop = false;
            // 
            // Mid2
            // 
            this.Mid2.BackColor = System.Drawing.Color.Black;
            this.Mid2.Location = new System.Drawing.Point(1422, 526);
            this.Mid2.Name = "Mid2";
            this.Mid2.Size = new System.Drawing.Size(24, 86);
            this.Mid2.TabIndex = 19;
            this.Mid2.TabStop = false;
            // 
            // Goalkeeper
            // 
            this.Goalkeeper.BackColor = System.Drawing.Color.Black;
            this.Goalkeeper.Location = new System.Drawing.Point(494, 799);
            this.Goalkeeper.Name = "Goalkeeper";
            this.Goalkeeper.Size = new System.Drawing.Size(24, 86);
            this.Goalkeeper.TabIndex = 18;
            this.Goalkeeper.TabStop = false;
            // 
            // aBall
            // 
            this.aBall.BackColor = System.Drawing.Color.Transparent;
            this.aBall.Image = global::Football_Game.Properties.Resources.Ball1;
            this.aBall.Location = new System.Drawing.Point(2036, 303);
            this.aBall.Name = "aBall";
            this.aBall.Size = new System.Drawing.Size(55, 55);
            this.aBall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.aBall.TabIndex = 7;
            this.aBall.TabStop = false;
            this.aBall.Click += new System.EventHandler(this.aBall_Click);
            // 
            // rightBottomPictBox
            // 
            this.rightBottomPictBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rightBottomPictBox.Location = new System.Drawing.Point(2950, 1051);
            this.rightBottomPictBox.Name = "rightBottomPictBox";
            this.rightBottomPictBox.Size = new System.Drawing.Size(25, 433);
            this.rightBottomPictBox.TabIndex = 17;
            this.rightBottomPictBox.TabStop = false;
            // 
            // rightHighPictBox
            // 
            this.rightHighPictBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rightHighPictBox.Location = new System.Drawing.Point(2950, 200);
            this.rightHighPictBox.Name = "rightHighPictBox";
            this.rightHighPictBox.Size = new System.Drawing.Size(25, 433);
            this.rightHighPictBox.TabIndex = 16;
            this.rightHighPictBox.TabStop = false;
            // 
            // leftHighPictBox
            // 
            this.leftHighPictBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.leftHighPictBox.Location = new System.Drawing.Point(426, 197);
            this.leftHighPictBox.Name = "leftHighPictBox";
            this.leftHighPictBox.Size = new System.Drawing.Size(25, 433);
            this.leftHighPictBox.TabIndex = 15;
            this.leftHighPictBox.TabStop = false;
            // 
            // leftBottomPictBox
            // 
            this.leftBottomPictBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.leftBottomPictBox.Location = new System.Drawing.Point(426, 1052);
            this.leftBottomPictBox.Name = "leftBottomPictBox";
            this.leftBottomPictBox.Size = new System.Drawing.Size(25, 433);
            this.leftBottomPictBox.TabIndex = 14;
            this.leftBottomPictBox.TabStop = false;
            // 
            // bottomPictBox
            // 
            this.bottomPictBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.bottomPictBox.Location = new System.Drawing.Point(426, 1480);
            this.bottomPictBox.Name = "bottomPictBox";
            this.bottomPictBox.Size = new System.Drawing.Size(2547, 25);
            this.bottomPictBox.TabIndex = 13;
            this.bottomPictBox.TabStop = false;
            // 
            // highBoundPictBox
            // 
            this.highBoundPictBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.highBoundPictBox.Location = new System.Drawing.Point(426, 176);
            this.highBoundPictBox.Name = "highBoundPictBox";
            this.highBoundPictBox.Size = new System.Drawing.Size(2547, 25);
            this.highBoundPictBox.TabIndex = 12;
            this.highBoundPictBox.TabStop = false;
            // 
            // Mid4
            // 
            this.Mid4.BackColor = System.Drawing.Color.Black;
            this.Mid4.Location = new System.Drawing.Point(1422, 1054);
            this.Mid4.Name = "Mid4";
            this.Mid4.Size = new System.Drawing.Size(24, 86);
            this.Mid4.TabIndex = 11;
            this.Mid4.TabStop = false;
            // 
            // CentrDef2
            // 
            this.CentrDef2.BackColor = System.Drawing.Color.Black;
            this.CentrDef2.Location = new System.Drawing.Point(860, 1051);
            this.CentrDef2.Name = "CentrDef2";
            this.CentrDef2.Size = new System.Drawing.Size(24, 86);
            this.CentrDef2.TabIndex = 10;
            this.CentrDef2.TabStop = false;
            // 
            // CentrDef1
            // 
            this.CentrDef1.BackColor = System.Drawing.Color.Black;
            this.CentrDef1.Location = new System.Drawing.Point(860, 544);
            this.CentrDef1.Name = "CentrDef1";
            this.CentrDef1.Size = new System.Drawing.Size(24, 86);
            this.CentrDef1.TabIndex = 9;
            this.CentrDef1.TabStop = false;
            // 
            // Mid3
            // 
            this.Mid3.BackColor = System.Drawing.Color.Black;
            this.Mid3.Location = new System.Drawing.Point(1422, 791);
            this.Mid3.Name = "Mid3";
            this.Mid3.Size = new System.Drawing.Size(24, 86);
            this.Mid3.TabIndex = 8;
            this.Mid3.TabStop = false;
            // 
            // BottomRightpictureBox5
            // 
            this.BottomRightpictureBox5.BackColor = System.Drawing.Color.White;
            this.BottomRightpictureBox5.Location = new System.Drawing.Point(2950, 1052);
            this.BottomRightpictureBox5.Name = "BottomRightpictureBox5";
            this.BottomRightpictureBox5.Size = new System.Drawing.Size(50, 430);
            this.BottomRightpictureBox5.TabIndex = 6;
            this.BottomRightpictureBox5.TabStop = false;
            // 
            // TopRightpictureBox4
            // 
            this.TopRightpictureBox4.BackColor = System.Drawing.Color.White;
            this.TopRightpictureBox4.Location = new System.Drawing.Point(2950, 200);
            this.TopRightpictureBox4.Name = "TopRightpictureBox4";
            this.TopRightpictureBox4.Size = new System.Drawing.Size(50, 430);
            this.TopRightpictureBox4.TabIndex = 5;
            this.TopRightpictureBox4.TabStop = false;
            // 
            // TopLeftPB
            // 
            this.TopLeftPB.BackColor = System.Drawing.Color.White;
            this.TopLeftPB.Location = new System.Drawing.Point(399, 200);
            this.TopLeftPB.Name = "TopLeftPB";
            this.TopLeftPB.Size = new System.Drawing.Size(50, 430);
            this.TopLeftPB.TabIndex = 4;
            this.TopLeftPB.TabStop = false;
            // 
            // bottomLeftPB
            // 
            this.bottomLeftPB.BackColor = System.Drawing.Color.White;
            this.bottomLeftPB.Location = new System.Drawing.Point(400, 1051);
            this.bottomLeftPB.Name = "bottomLeftPB";
            this.bottomLeftPB.Size = new System.Drawing.Size(50, 430);
            this.bottomLeftPB.TabIndex = 3;
            this.bottomLeftPB.TabStop = false;
            // 
            // BottomPictureBox
            // 
            this.BottomPictureBox.BackColor = System.Drawing.Color.White;
            this.BottomPictureBox.Location = new System.Drawing.Point(400, 1480);
            this.BottomPictureBox.Name = "BottomPictureBox";
            this.BottomPictureBox.Size = new System.Drawing.Size(2600, 50);
            this.BottomPictureBox.TabIndex = 2;
            this.BottomPictureBox.TabStop = false;
            this.BottomPictureBox.Click += new System.EventHandler(this.BottomPictureBox_Click);
            // 
            // ToppictureBox
            // 
            this.ToppictureBox.BackColor = System.Drawing.Color.White;
            this.ToppictureBox.Location = new System.Drawing.Point(400, 150);
            this.ToppictureBox.Name = "ToppictureBox";
            this.ToppictureBox.Size = new System.Drawing.Size(2600, 50);
            this.ToppictureBox.TabIndex = 1;
            this.ToppictureBox.TabStop = false;
            // 
            // aPitch
            // 
            this.aPitch.Image = global::Football_Game.Properties.Resources.MyPitch;
            this.aPitch.Location = new System.Drawing.Point(52, 1494);
            this.aPitch.Margin = new System.Windows.Forms.Padding(100);
            this.aPitch.Name = "aPitch";
            this.aPitch.Size = new System.Drawing.Size(209, 128);
            this.aPitch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.aPitch.TabIndex = 0;
            this.aPitch.TabStop = false;
            // 
            // listViewWhoScored
            // 
            this.listViewWhoScored.BackColor = System.Drawing.Color.White;
            this.listViewWhoScored.BackgroundImage = global::Football_Game.Properties.Resources.greenback;
            this.listViewWhoScored.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewWhoScored.Enabled = false;
            this.listViewWhoScored.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listViewWhoScored.ForeColor = System.Drawing.Color.Black;
            this.listViewWhoScored.Location = new System.Drawing.Point(26, 33);
            this.listViewWhoScored.Name = "listViewWhoScored";
            this.listViewWhoScored.Size = new System.Drawing.Size(357, 547);
            this.listViewWhoScored.TabIndex = 35;
            this.listViewWhoScored.UseCompatibleStateImageBehavior = false;
            this.listViewWhoScored.View = System.Windows.Forms.View.List;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 150;
            // 
            // FootballGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(3184, 1669);
            this.Controls.Add(this.listViewWhoScored);
            this.Controls.Add(this.slashLabel);
            this.Controls.Add(this.goalLabel);
            this.Controls.Add(this.scoredGoalLabel);
            this.Controls.Add(this.whoScoredLabel);
            this.Controls.Add(this.secondTeamGoal);
            this.Controls.Add(this.firstTeamGoal);
            this.Controls.Add(this.rightForw);
            this.Controls.Add(this.centralForw);
            this.Controls.Add(this.leftForw);
            this.Controls.Add(this.secondTeamLabel);
            this.Controls.Add(this.firstTeamScoreLabel);
            this.Controls.Add(this.secondTeamScoreLabel);
            this.Controls.Add(this.firstTeamLabel);
            this.Controls.Add(this.Mid5);
            this.Controls.Add(this.Mid1);
            this.Controls.Add(this.Mid2);
            this.Controls.Add(this.Goalkeeper);
            this.Controls.Add(this.aBall);
            this.Controls.Add(this.rightBottomPictBox);
            this.Controls.Add(this.rightHighPictBox);
            this.Controls.Add(this.leftHighPictBox);
            this.Controls.Add(this.leftBottomPictBox);
            this.Controls.Add(this.bottomPictBox);
            this.Controls.Add(this.highBoundPictBox);
            this.Controls.Add(this.Mid4);
            this.Controls.Add(this.CentrDef2);
            this.Controls.Add(this.CentrDef1);
            this.Controls.Add(this.Mid3);
            this.Controls.Add(this.BottomRightpictureBox5);
            this.Controls.Add(this.TopRightpictureBox4);
            this.Controls.Add(this.TopLeftPB);
            this.Controls.Add(this.bottomLeftPB);
            this.Controls.Add(this.BottomPictureBox);
            this.Controls.Add(this.ToppictureBox);
            this.Controls.Add(this.aPitch);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(2558, 1544);
            this.Name = "FootballGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FootballGameForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FootballGameForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FootballGameForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.secondTeamGoal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstTeamGoal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightForw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.centralForw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftForw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mid5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Goalkeeper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aBall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightBottomPictBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightHighPictBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftHighPictBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftBottomPictBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomPictBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.highBoundPictBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mid4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CentrDef2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CentrDef1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mid3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRightpictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRightpictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopLeftPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomLeftPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToppictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPitch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox aPitch;
        private System.Windows.Forms.PictureBox ToppictureBox;
        private System.Windows.Forms.PictureBox BottomPictureBox;
        private System.Windows.Forms.PictureBox bottomLeftPB;
        private System.Windows.Forms.PictureBox TopLeftPB;
        private System.Windows.Forms.PictureBox TopRightpictureBox4;
        private System.Windows.Forms.PictureBox BottomRightpictureBox5;
        private System.Windows.Forms.PictureBox aBall;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox Mid3;
        private System.Windows.Forms.Timer PlayerTimer;
        private System.Windows.Forms.Timer ChangImage_timer;
        private System.Windows.Forms.Timer checktimer;
        private System.Windows.Forms.PictureBox CentrDef1;
        private System.Windows.Forms.PictureBox CentrDef2;
        private System.Windows.Forms.PictureBox Mid4;
        private System.Windows.Forms.PictureBox highBoundPictBox;
        private System.Windows.Forms.PictureBox bottomPictBox;
        private System.Windows.Forms.PictureBox leftBottomPictBox;
        private System.Windows.Forms.PictureBox leftHighPictBox;
        private System.Windows.Forms.PictureBox rightHighPictBox;
        private System.Windows.Forms.PictureBox rightBottomPictBox;
        private System.Windows.Forms.PictureBox Goalkeeper;
        private System.Windows.Forms.PictureBox Mid2;
        private System.Windows.Forms.PictureBox Mid1;
        private System.Windows.Forms.PictureBox Mid5;
        private System.Windows.Forms.Label firstTeamLabel;
        private System.Windows.Forms.Label secondTeamScoreLabel;
        private System.Windows.Forms.Label firstTeamScoreLabel;
        private System.Windows.Forms.Label secondTeamLabel;
        private System.Windows.Forms.PictureBox leftForw;
        private System.Windows.Forms.PictureBox centralForw;
        private System.Windows.Forms.PictureBox rightForw;
        private System.Windows.Forms.PictureBox firstTeamGoal;
        private System.Windows.Forms.PictureBox secondTeamGoal;
        private System.Windows.Forms.Label goalLabel;
        private System.Windows.Forms.Label whoScoredLabel;
        private System.Windows.Forms.Label scoredGoalLabel;
        private System.Windows.Forms.Label slashLabel;
        private System.Windows.Forms.ListView listViewWhoScored;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}

