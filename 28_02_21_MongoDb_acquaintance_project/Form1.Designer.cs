
namespace _28_02_21_MongoDb_acquaintance_project
{
    partial class Form1
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.addDriverTab = new System.Windows.Forms.TabPage();
            this.cmbRoutes = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCarLicense = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbCars = new System.Windows.Forms.ComboBox();
            this.btnAddDriver = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlLongNumberCreatorIdNumber = new _28_02_21_MongoDb_acquaintance_project.pnlLongNumberCreatorPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.pbxDriverPicture = new System.Windows.Forms.PictureBox();
            this.addTaxiTab = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbTaxiDrivers = new System.Windows.Forms.ComboBox();
            this.btnAddTaxi = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTaxiManufacturer = new System.Windows.Forms.ComboBox();
            this.pnlLongNumberCreatorTaxiLicenseNumber = new _28_02_21_MongoDb_acquaintance_project.pnlLongNumberCreatorPanel();
            this.addRouteTab = new System.Windows.Forms.TabPage();
            this.btnAddRoute = new System.Windows.Forms.Button();
            this.txtDestinationAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDepartureAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.editDriversTab = new System.Windows.Forms.TabPage();
            this.btnAddDriverRoutes = new System.Windows.Forms.Button();
            this.btnAddDriverCar = new System.Windows.Forms.Button();
            this.btnDeleteDriver = new System.Windows.Forms.Button();
            this.btnSaveDriver = new System.Windows.Forms.Button();
            this.btnDeleteDriverRoutes = new System.Windows.Forms.Button();
            this.btnSaveDriverRoutes = new System.Windows.Forms.Button();
            this.cmbChangeDriverRoutes2 = new System.Windows.Forms.ComboBox();
            this.cmbChangeDriverRoutes1 = new System.Windows.Forms.ComboBox();
            this.btnDEleteDriverCar = new System.Windows.Forms.Button();
            this.btnEditDriverCar = new System.Windows.Forms.Button();
            this.txtChangeDriverCarLicense = new System.Windows.Forms.TextBox();
            this.cmbChangeDriverCars = new System.Windows.Forms.ComboBox();
            this.txtChangeDriverLastName = new System.Windows.Forms.TextBox();
            this.txtChangeDriverFirstname = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lblhangeCars = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pbxEditDrivers = new System.Windows.Forms.PictureBox();
            this.cmbEditAllDrivers = new System.Windows.Forms.ComboBox();
            this.pnlLongNumberChangeDriverIDCertificate = new _28_02_21_MongoDb_acquaintance_project.pnlLongNumberCreatorPanel();
            this.tabControl.SuspendLayout();
            this.addDriverTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDriverPicture)).BeginInit();
            this.addTaxiTab.SuspendLayout();
            this.addRouteTab.SuspendLayout();
            this.editDriversTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEditDrivers)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.addDriverTab);
            this.tabControl.Controls.Add(this.addTaxiTab);
            this.tabControl.Controls.Add(this.addRouteTab);
            this.tabControl.Controls.Add(this.editDriversTab);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(531, 476);
            this.tabControl.TabIndex = 0;
            // 
            // addDriverTab
            // 
            this.addDriverTab.Controls.Add(this.cmbRoutes);
            this.addDriverTab.Controls.Add(this.label9);
            this.addDriverTab.Controls.Add(this.lblCarLicense);
            this.addDriverTab.Controls.Add(this.label8);
            this.addDriverTab.Controls.Add(this.cmbCars);
            this.addDriverTab.Controls.Add(this.btnAddDriver);
            this.addDriverTab.Controls.Add(this.label3);
            this.addDriverTab.Controls.Add(this.pnlLongNumberCreatorIdNumber);
            this.addDriverTab.Controls.Add(this.label2);
            this.addDriverTab.Controls.Add(this.txtLastName);
            this.addDriverTab.Controls.Add(this.label1);
            this.addDriverTab.Controls.Add(this.txtFirstName);
            this.addDriverTab.Controls.Add(this.pbxDriverPicture);
            this.addDriverTab.Location = new System.Drawing.Point(4, 22);
            this.addDriverTab.Name = "addDriverTab";
            this.addDriverTab.Padding = new System.Windows.Forms.Padding(3);
            this.addDriverTab.Size = new System.Drawing.Size(523, 450);
            this.addDriverTab.TabIndex = 0;
            this.addDriverTab.Text = "Add Drivers";
            this.addDriverTab.UseVisualStyleBackColor = true;
            // 
            // cmbRoutes
            // 
            this.cmbRoutes.FormattingEnabled = true;
            this.cmbRoutes.Location = new System.Drawing.Point(6, 332);
            this.cmbRoutes.Name = "cmbRoutes";
            this.cmbRoutes.Size = new System.Drawing.Size(320, 21);
            this.cmbRoutes.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 316);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Route:";
            // 
            // lblCarLicense
            // 
            this.lblCarLicense.AutoSize = true;
            this.lblCarLicense.Location = new System.Drawing.Point(158, 291);
            this.lblCarLicense.Name = "lblCarLicense";
            this.lblCarLicense.Size = new System.Drawing.Size(0, 13);
            this.lblCarLicense.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 272);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Car:";
            // 
            // cmbCars
            // 
            this.cmbCars.FormattingEnabled = true;
            this.cmbCars.Location = new System.Drawing.Point(6, 288);
            this.cmbCars.Name = "cmbCars";
            this.cmbCars.Size = new System.Drawing.Size(146, 21);
            this.cmbCars.TabIndex = 8;
            // 
            // btnAddDriver
            // 
            this.btnAddDriver.Location = new System.Drawing.Point(12, 421);
            this.btnAddDriver.Name = "btnAddDriver";
            this.btnAddDriver.Size = new System.Drawing.Size(75, 23);
            this.btnAddDriver.TabIndex = 7;
            this.btnAddDriver.Text = "Add Driver";
            this.btnAddDriver.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Identity Certificate:";
            // 
            // pnlLongNumberCreatorIdNumber
            // 
            this.pnlLongNumberCreatorIdNumber.Location = new System.Drawing.Point(6, 241);
            this.pnlLongNumberCreatorIdNumber.Name = "pnlLongNumberCreatorIdNumber";
            this.pnlLongNumberCreatorIdNumber.Number = "572181887";
            this.pnlLongNumberCreatorIdNumber.NumberOfCombos = 9;
            this.pnlLongNumberCreatorIdNumber.RandomInitialValue = true;
            this.pnlLongNumberCreatorIdNumber.Size = new System.Drawing.Size(278, 21);
            this.pnlLongNumberCreatorIdNumber.SplitToSections = false;
            this.pnlLongNumberCreatorIdNumber.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Last Name:";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(6, 194);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(122, 20);
            this.txtLastName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "First Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(6, 152);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(122, 20);
            this.txtFirstName.TabIndex = 1;
            // 
            // pbxDriverPicture
            // 
            this.pbxDriverPicture.Location = new System.Drawing.Point(6, 6);
            this.pbxDriverPicture.Name = "pbxDriverPicture";
            this.pbxDriverPicture.Size = new System.Drawing.Size(123, 109);
            this.pbxDriverPicture.TabIndex = 0;
            this.pbxDriverPicture.TabStop = false;
            // 
            // addTaxiTab
            // 
            this.addTaxiTab.Controls.Add(this.label10);
            this.addTaxiTab.Controls.Add(this.cmbTaxiDrivers);
            this.addTaxiTab.Controls.Add(this.btnAddTaxi);
            this.addTaxiTab.Controls.Add(this.label5);
            this.addTaxiTab.Controls.Add(this.label4);
            this.addTaxiTab.Controls.Add(this.cmbTaxiManufacturer);
            this.addTaxiTab.Controls.Add(this.pnlLongNumberCreatorTaxiLicenseNumber);
            this.addTaxiTab.Location = new System.Drawing.Point(4, 22);
            this.addTaxiTab.Name = "addTaxiTab";
            this.addTaxiTab.Padding = new System.Windows.Forms.Padding(3);
            this.addTaxiTab.Size = new System.Drawing.Size(523, 450);
            this.addTaxiTab.TabIndex = 1;
            this.addTaxiTab.Text = "Add Taxies";
            this.addTaxiTab.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 128);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(257, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Drivers (you can coose only a driver that have route):";
            // 
            // cmbTaxiDrivers
            // 
            this.cmbTaxiDrivers.FormattingEnabled = true;
            this.cmbTaxiDrivers.Location = new System.Drawing.Point(6, 147);
            this.cmbTaxiDrivers.Name = "cmbTaxiDrivers";
            this.cmbTaxiDrivers.Size = new System.Drawing.Size(325, 21);
            this.cmbTaxiDrivers.TabIndex = 5;
            // 
            // btnAddTaxi
            // 
            this.btnAddTaxi.Location = new System.Drawing.Point(9, 176);
            this.btnAddTaxi.Name = "btnAddTaxi";
            this.btnAddTaxi.Size = new System.Drawing.Size(75, 23);
            this.btnAddTaxi.TabIndex = 4;
            this.btnAddTaxi.Text = "Add Taxi";
            this.btnAddTaxi.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "License number:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Manufacturer:";
            // 
            // cmbTaxiManufacturer
            // 
            this.cmbTaxiManufacturer.FormattingEnabled = true;
            this.cmbTaxiManufacturer.Location = new System.Drawing.Point(6, 35);
            this.cmbTaxiManufacturer.Name = "cmbTaxiManufacturer";
            this.cmbTaxiManufacturer.Size = new System.Drawing.Size(208, 21);
            this.cmbTaxiManufacturer.TabIndex = 0;
            // 
            // pnlLongNumberCreatorTaxiLicenseNumber
            // 
            this.pnlLongNumberCreatorTaxiLicenseNumber.Location = new System.Drawing.Point(7, 88);
            this.pnlLongNumberCreatorTaxiLicenseNumber.Name = "pnlLongNumberCreatorTaxiLicenseNumber";
            this.pnlLongNumberCreatorTaxiLicenseNumber.Number = "280857";
            this.pnlLongNumberCreatorTaxiLicenseNumber.NumberOfCombos = 6;
            this.pnlLongNumberCreatorTaxiLicenseNumber.RandomInitialValue = true;
            this.pnlLongNumberCreatorTaxiLicenseNumber.Size = new System.Drawing.Size(185, 21);
            this.pnlLongNumberCreatorTaxiLicenseNumber.SplitToSections = false;
            this.pnlLongNumberCreatorTaxiLicenseNumber.TabIndex = 3;
            // 
            // addRouteTab
            // 
            this.addRouteTab.Controls.Add(this.btnAddRoute);
            this.addRouteTab.Controls.Add(this.txtDestinationAddress);
            this.addRouteTab.Controls.Add(this.label7);
            this.addRouteTab.Controls.Add(this.txtDepartureAddress);
            this.addRouteTab.Controls.Add(this.label6);
            this.addRouteTab.Location = new System.Drawing.Point(4, 22);
            this.addRouteTab.Name = "addRouteTab";
            this.addRouteTab.Padding = new System.Windows.Forms.Padding(3);
            this.addRouteTab.Size = new System.Drawing.Size(523, 450);
            this.addRouteTab.TabIndex = 2;
            this.addRouteTab.Text = "Add Routes";
            this.addRouteTab.UseVisualStyleBackColor = true;
            // 
            // btnAddRoute
            // 
            this.btnAddRoute.Location = new System.Drawing.Point(10, 132);
            this.btnAddRoute.Name = "btnAddRoute";
            this.btnAddRoute.Size = new System.Drawing.Size(75, 23);
            this.btnAddRoute.TabIndex = 4;
            this.btnAddRoute.Text = "Add Route";
            this.btnAddRoute.UseVisualStyleBackColor = true;
            // 
            // txtDestinationAddress
            // 
            this.txtDestinationAddress.Location = new System.Drawing.Point(10, 82);
            this.txtDestinationAddress.Name = "txtDestinationAddress";
            this.txtDestinationAddress.Size = new System.Drawing.Size(217, 20);
            this.txtDestinationAddress.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Destination Address:";
            // 
            // txtDepartureAddress
            // 
            this.txtDepartureAddress.Location = new System.Drawing.Point(10, 24);
            this.txtDepartureAddress.Name = "txtDepartureAddress";
            this.txtDepartureAddress.Size = new System.Drawing.Size(217, 20);
            this.txtDepartureAddress.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Departure Address:";
            // 
            // editDriversTab
            // 
            this.editDriversTab.Controls.Add(this.btnAddDriverRoutes);
            this.editDriversTab.Controls.Add(this.btnAddDriverCar);
            this.editDriversTab.Controls.Add(this.btnDeleteDriver);
            this.editDriversTab.Controls.Add(this.btnSaveDriver);
            this.editDriversTab.Controls.Add(this.btnDeleteDriverRoutes);
            this.editDriversTab.Controls.Add(this.btnSaveDriverRoutes);
            this.editDriversTab.Controls.Add(this.cmbChangeDriverRoutes2);
            this.editDriversTab.Controls.Add(this.cmbChangeDriverRoutes1);
            this.editDriversTab.Controls.Add(this.btnDEleteDriverCar);
            this.editDriversTab.Controls.Add(this.btnEditDriverCar);
            this.editDriversTab.Controls.Add(this.txtChangeDriverCarLicense);
            this.editDriversTab.Controls.Add(this.cmbChangeDriverCars);
            this.editDriversTab.Controls.Add(this.txtChangeDriverLastName);
            this.editDriversTab.Controls.Add(this.txtChangeDriverFirstname);
            this.editDriversTab.Controls.Add(this.label15);
            this.editDriversTab.Controls.Add(this.lblhangeCars);
            this.editDriversTab.Controls.Add(this.label13);
            this.editDriversTab.Controls.Add(this.label12);
            this.editDriversTab.Controls.Add(this.label11);
            this.editDriversTab.Controls.Add(this.pbxEditDrivers);
            this.editDriversTab.Controls.Add(this.cmbEditAllDrivers);
            this.editDriversTab.Controls.Add(this.pnlLongNumberChangeDriverIDCertificate);
            this.editDriversTab.Location = new System.Drawing.Point(4, 22);
            this.editDriversTab.Name = "editDriversTab";
            this.editDriversTab.Padding = new System.Windows.Forms.Padding(3);
            this.editDriversTab.Size = new System.Drawing.Size(523, 450);
            this.editDriversTab.TabIndex = 3;
            this.editDriversTab.Text = "Edit Drivers";
            this.editDriversTab.UseVisualStyleBackColor = true;
            // 
            // btnAddDriverRoutes
            // 
            this.btnAddDriverRoutes.Location = new System.Drawing.Point(10, 365);
            this.btnAddDriverRoutes.Name = "btnAddDriverRoutes";
            this.btnAddDriverRoutes.Size = new System.Drawing.Size(49, 21);
            this.btnAddDriverRoutes.TabIndex = 21;
            this.btnAddDriverRoutes.Text = "Add";
            this.btnAddDriverRoutes.UseVisualStyleBackColor = true;
            // 
            // btnAddDriverCar
            // 
            this.btnAddDriverCar.Location = new System.Drawing.Point(172, 83);
            this.btnAddDriverCar.Name = "btnAddDriverCar";
            this.btnAddDriverCar.Size = new System.Drawing.Size(49, 21);
            this.btnAddDriverCar.TabIndex = 20;
            this.btnAddDriverCar.Text = "Add";
            this.btnAddDriverCar.UseVisualStyleBackColor = true;
            this.btnAddDriverCar.Click += new System.EventHandler(this.btnAddDriverCar_Click);
            // 
            // btnDeleteDriver
            // 
            this.btnDeleteDriver.Location = new System.Drawing.Point(133, 412);
            this.btnDeleteDriver.Name = "btnDeleteDriver";
            this.btnDeleteDriver.Size = new System.Drawing.Size(97, 23);
            this.btnDeleteDriver.TabIndex = 19;
            this.btnDeleteDriver.Text = "Delete Driver";
            this.btnDeleteDriver.UseVisualStyleBackColor = true;
            this.btnDeleteDriver.Click += new System.EventHandler(this.btnDeleteDriver_Click);
            // 
            // btnSaveDriver
            // 
            this.btnSaveDriver.Location = new System.Drawing.Point(10, 412);
            this.btnSaveDriver.Name = "btnSaveDriver";
            this.btnSaveDriver.Size = new System.Drawing.Size(97, 23);
            this.btnSaveDriver.TabIndex = 18;
            this.btnSaveDriver.Text = "Save Changes";
            this.btnSaveDriver.UseVisualStyleBackColor = true;
            this.btnSaveDriver.Click += new System.EventHandler(this.btnSaveDriver_Click);
            // 
            // btnDeleteDriverRoutes
            // 
            this.btnDeleteDriverRoutes.Location = new System.Drawing.Point(159, 365);
            this.btnDeleteDriverRoutes.Name = "btnDeleteDriverRoutes";
            this.btnDeleteDriverRoutes.Size = new System.Drawing.Size(49, 21);
            this.btnDeleteDriverRoutes.TabIndex = 17;
            this.btnDeleteDriverRoutes.Text = "Delete";
            this.btnDeleteDriverRoutes.UseVisualStyleBackColor = true;
            // 
            // btnSaveDriverRoutes
            // 
            this.btnSaveDriverRoutes.Location = new System.Drawing.Point(65, 365);
            this.btnSaveDriverRoutes.Name = "btnSaveDriverRoutes";
            this.btnSaveDriverRoutes.Size = new System.Drawing.Size(88, 21);
            this.btnSaveDriverRoutes.TabIndex = 16;
            this.btnSaveDriverRoutes.Text = "Save Changes";
            this.btnSaveDriverRoutes.UseVisualStyleBackColor = true;
            // 
            // cmbChangeDriverRoutes2
            // 
            this.cmbChangeDriverRoutes2.FormattingEnabled = true;
            this.cmbChangeDriverRoutes2.Location = new System.Drawing.Point(236, 338);
            this.cmbChangeDriverRoutes2.Name = "cmbChangeDriverRoutes2";
            this.cmbChangeDriverRoutes2.Size = new System.Drawing.Size(205, 21);
            this.cmbChangeDriverRoutes2.TabIndex = 15;
            // 
            // cmbChangeDriverRoutes1
            // 
            this.cmbChangeDriverRoutes1.FormattingEnabled = true;
            this.cmbChangeDriverRoutes1.Location = new System.Drawing.Point(10, 338);
            this.cmbChangeDriverRoutes1.Name = "cmbChangeDriverRoutes1";
            this.cmbChangeDriverRoutes1.Size = new System.Drawing.Size(220, 21);
            this.cmbChangeDriverRoutes1.TabIndex = 14;
            // 
            // btnDEleteDriverCar
            // 
            this.btnDEleteDriverCar.Location = new System.Drawing.Point(319, 82);
            this.btnDEleteDriverCar.Name = "btnDEleteDriverCar";
            this.btnDEleteDriverCar.Size = new System.Drawing.Size(49, 21);
            this.btnDEleteDriverCar.TabIndex = 13;
            this.btnDEleteDriverCar.Text = "Delete";
            this.btnDEleteDriverCar.UseVisualStyleBackColor = true;
            this.btnDEleteDriverCar.Click += new System.EventHandler(this.btnDEleteDriverCar_Click);
            // 
            // btnEditDriverCar
            // 
            this.btnEditDriverCar.Location = new System.Drawing.Point(227, 83);
            this.btnEditDriverCar.Name = "btnEditDriverCar";
            this.btnEditDriverCar.Size = new System.Drawing.Size(86, 21);
            this.btnEditDriverCar.TabIndex = 12;
            this.btnEditDriverCar.Text = "Save Changes";
            this.btnEditDriverCar.UseVisualStyleBackColor = true;
            this.btnEditDriverCar.Click += new System.EventHandler(this.btnEditDriverCar_Click);
            // 
            // txtChangeDriverCarLicense
            // 
            this.txtChangeDriverCarLicense.Location = new System.Drawing.Point(341, 56);
            this.txtChangeDriverCarLicense.Name = "txtChangeDriverCarLicense";
            this.txtChangeDriverCarLicense.Size = new System.Drawing.Size(100, 20);
            this.txtChangeDriverCarLicense.TabIndex = 11;
            // 
            // cmbChangeDriverCars
            // 
            this.cmbChangeDriverCars.FormattingEnabled = true;
            this.cmbChangeDriverCars.Location = new System.Drawing.Point(172, 56);
            this.cmbChangeDriverCars.Name = "cmbChangeDriverCars";
            this.cmbChangeDriverCars.Size = new System.Drawing.Size(162, 21);
            this.cmbChangeDriverCars.TabIndex = 10;
            // 
            // txtChangeDriverLastName
            // 
            this.txtChangeDriverLastName.Location = new System.Drawing.Point(7, 241);
            this.txtChangeDriverLastName.Name = "txtChangeDriverLastName";
            this.txtChangeDriverLastName.Size = new System.Drawing.Size(140, 20);
            this.txtChangeDriverLastName.TabIndex = 8;
            // 
            // txtChangeDriverFirstname
            // 
            this.txtChangeDriverFirstname.Location = new System.Drawing.Point(7, 192);
            this.txtChangeDriverFirstname.Name = "txtChangeDriverFirstname";
            this.txtChangeDriverFirstname.Size = new System.Drawing.Size(140, 20);
            this.txtChangeDriverFirstname.TabIndex = 7;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 321);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Change Routes:";
            // 
            // lblhangeCars
            // 
            this.lblhangeCars.AutoSize = true;
            this.lblhangeCars.Location = new System.Drawing.Point(172, 39);
            this.lblhangeCars.Name = "lblhangeCars";
            this.lblhangeCars.Size = new System.Drawing.Size(71, 13);
            this.lblhangeCars.TabIndex = 5;
            this.lblhangeCars.Text = "Change Cars:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 274);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(134, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Change Identity Certificate:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 225);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Change Last Name:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 175);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Change First Name:";
            // 
            // pbxEditDrivers
            // 
            this.pbxEditDrivers.Location = new System.Drawing.Point(7, 35);
            this.pbxEditDrivers.Name = "pbxEditDrivers";
            this.pbxEditDrivers.Size = new System.Drawing.Size(146, 133);
            this.pbxEditDrivers.TabIndex = 1;
            this.pbxEditDrivers.TabStop = false;
            // 
            // cmbEditAllDrivers
            // 
            this.cmbEditAllDrivers.FormattingEnabled = true;
            this.cmbEditAllDrivers.Location = new System.Drawing.Point(7, 7);
            this.cmbEditAllDrivers.Name = "cmbEditAllDrivers";
            this.cmbEditAllDrivers.Size = new System.Drawing.Size(327, 21);
            this.cmbEditAllDrivers.TabIndex = 0;
            // 
            // pnlLongNumberChangeDriverIDCertificate
            // 
            this.pnlLongNumberChangeDriverIDCertificate.Location = new System.Drawing.Point(10, 291);
            this.pnlLongNumberChangeDriverIDCertificate.Name = "pnlLongNumberChangeDriverIDCertificate";
            this.pnlLongNumberChangeDriverIDCertificate.Number = "000000000";
            this.pnlLongNumberChangeDriverIDCertificate.NumberOfCombos = 9;
            this.pnlLongNumberChangeDriverIDCertificate.RandomInitialValue = false;
            this.pnlLongNumberChangeDriverIDCertificate.Size = new System.Drawing.Size(278, 21);
            this.pnlLongNumberChangeDriverIDCertificate.SplitToSections = false;
            this.pnlLongNumberChangeDriverIDCertificate.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 500);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Text = "MongoDB Taxi management";
            this.tabControl.ResumeLayout(false);
            this.addDriverTab.ResumeLayout(false);
            this.addDriverTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDriverPicture)).EndInit();
            this.addTaxiTab.ResumeLayout(false);
            this.addTaxiTab.PerformLayout();
            this.addRouteTab.ResumeLayout(false);
            this.addRouteTab.PerformLayout();
            this.editDriversTab.ResumeLayout(false);
            this.editDriversTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEditDrivers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage addDriverTab;
        private System.Windows.Forms.TabPage addTaxiTab;
        private System.Windows.Forms.PictureBox pbxDriverPicture;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLastName;
        private pnlLongNumberCreatorPanel pnlLongNumberCreatorIdNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddDriver;
        private pnlLongNumberCreatorPanel pnlLongNumberCreatorTaxiLicenseNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTaxiManufacturer;
        private System.Windows.Forms.Button btnAddTaxi;
        private System.Windows.Forms.TabPage addRouteTab;
        private System.Windows.Forms.Button btnAddRoute;
        private System.Windows.Forms.TextBox txtDestinationAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDepartureAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCarLicense;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbCars;
        private System.Windows.Forms.ComboBox cmbRoutes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbTaxiDrivers;
        private System.Windows.Forms.TabPage editDriversTab;
        private System.Windows.Forms.ComboBox cmbEditAllDrivers;
        private System.Windows.Forms.ComboBox cmbChangeDriverCars;
        private pnlLongNumberCreatorPanel pnlLongNumberChangeDriverIDCertificate;
        private System.Windows.Forms.TextBox txtChangeDriverLastName;
        private System.Windows.Forms.TextBox txtChangeDriverFirstname;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblhangeCars;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pbxEditDrivers;
        private System.Windows.Forms.Button btnEditDriverCar;
        private System.Windows.Forms.TextBox txtChangeDriverCarLicense;
        private System.Windows.Forms.ComboBox cmbChangeDriverRoutes2;
        private System.Windows.Forms.ComboBox cmbChangeDriverRoutes1;
        private System.Windows.Forms.Button btnDEleteDriverCar;
        private System.Windows.Forms.Button btnDeleteDriver;
        private System.Windows.Forms.Button btnSaveDriver;
        private System.Windows.Forms.Button btnDeleteDriverRoutes;
        private System.Windows.Forms.Button btnSaveDriverRoutes;
        private System.Windows.Forms.Button btnAddDriverRoutes;
        private System.Windows.Forms.Button btnAddDriverCar;
    }
}

