using _28_02_21_MongoDb_acquaintance_project._program_data.models;
using _28_02_21_MongoDb_acquaintance_project.Models;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _28_02_21_MongoDb_acquaintance_project
{
    public partial class Form1 : Form
    {
        private Random _rnd = new Random();
        private MongoConnector _connector;

        private ImageConverter _imageConverter = new ImageConverter();

        const string CONFIG_FILE_PATH = "_configuration.txt";
        const string NAMES_FILE_PATH = "_names.txt";
        const string CARS_FILR_PATH = "_car_brands.txt";

        private string[] _cars;
        private string[] _names;

        private List<int> _digitsKeys = null;
        private DriverModel _driverWhenEdited = null;
        private List<Guid> _driverCarIDs = new List<Guid>();
        private List<Guid> _driverRouteIDs = new List<Guid>();
        private int _cmbChangeDriverRoutes1SelectedIndex = -1;
        private int _cmbChangeDriverRoutes2SelectedIndex = -1;
        private int _cmbChangeDriverCarsSelectedIndexChanged = -1;



        private object _cmbEditAllDriversSelectedItem;
        private object _cmbEditTaxiesSelectedItem;
        private object _cmbEditTaxiesDriversAllDriversSelectedItem;

        private Dictionary<string, List<string>> _citiesAndStreetsForRoutes;

        public Form1()
        {
            InitializeComponent();
            Initiaize();


            /*var allCollections = connector.GetAllCollectionsNames();
            var doc = new BsonDocument(new BsonElement("Name", "John"));*/
            //connector.AddOrUpdateDocument(allCollections.First(), new Guid(), doc);
        }


        private void Initiaize()
        {
            _cars = Statics.ReadFromFile(CARS_FILR_PATH);
            _names = Statics.ReadFromFile(NAMES_FILE_PATH);

            Thread thread = new Thread(async() => 
            {
                _citiesAndStreetsForRoutes = await CSVParser.ParseCSVAsync("_streets.csv");
            });
            thread.Start();
            


            Dictionary<string, string> configs = getConnctionStringAndDBName();
            _connector = new MongoConnector(configs["connectionString"], configs["databaseName"]);

            _digitsKeys = _connector.GetDocumentById<KeysModel>("_program_data", new Guid("98ca8e37-1dce-46ca-afcd-b87bf455e0cc")).NumKeysValuesList;
            //var giud = _connector.GetAllDocuments<KeysModel>("_program_data");

            cmbTaxiManufacturer.Items.AddRange(_cars);
            var cars = _connector.GetAllDocuments<CarModel>("Cars").Select(x => new ComboCar(x)).ToArray();
            var routes = _connector.GetAllDocuments<RouteModel>("Routes").Select(x => new ComboRoute(x)).ToArray();
            cmbCars.Items.AddRange(cars);
            cmbRoutes.Items.AddRange(routes);
            cmbCars.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                lblCarLicense.Text = ((ComboCar)(sender as ComboBox).SelectedItem).License;
            };
            cmbEditAllDrivers.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                cmbEditAllDriversSelectedIndexChanged(sender, e);
                //_cmbEditAllDriversSelectedItem

            };

            cmbEditTaxies.SelectedIndexChanged += (object sender, EventArgs e) => 
            {
                cmbEditTaxiesSelectedIndexChanged(sender as ComboBox);
            };

            txtChangeDriverCarLicense.KeyDown += (object sender, KeyEventArgs e) =>
            {
                LicenseNumberTexBoxKeyDown(sender as TextBox, e);
            };

            txtEditTaxiesLicense.KeyDown += (object sender, KeyEventArgs e) =>
            {
                LicenseNumberTexBoxKeyDown(sender as TextBox, e);
            };



            InitializeAddCarsTab();
            InitializeAddDriversTab();
            InitializeAddRoutesTab();
            InitializeEditDriversTab();
            InitializeEtitTaxiesTab();


            editDriversTab.Leave += async (object sender, EventArgs e) =>
            {
                await editDriversTabLeave();
            };

            editTaxiesTab.Leave += async (object sender, EventArgs e) =>
            {
                await editDriversTabLeave();
            };

            editTaxiesTab.Enter += (object sender, EventArgs e) =>
            {
                InitializeEtitTaxiesTab();
            };

            btnAddDriver.Click += (object sender, EventArgs e) =>
            {

                DriverModel driver = new DriverModel
                {
                    Id = new Guid(),
                    FirstName = txtFirstName.Text,
                    Lastname = txtLastName.Text,
                    IdentityNumber = pnlLongNumberCreatorIdNumber.Number,
                    //Image = pbcDriverPicture.Image as Bitmap,
                    Image = (byte[])_imageConverter.ConvertTo(pbxDriverPicture.Image, typeof(byte[])),
                    CarIds = _driverCarIDs,
                    RouteIds = _driverRouteIDs
                };

                _connector.AddDocument("Drivers", driver);
                cmbEditAllDrivers.Items.Add(new ComboDriver(driver));

                InitializeAddDriversTab();
            };



            btnAddTaxi.Click += (object sender, EventArgs e) =>
            {
                List<Guid> driverIDs = new List<Guid>();
                driverIDs.Add((cmbTaxiDrivers.SelectedItem as ComboDriver).Driver.Id);

                CarModel car = new CarModel
                {
                    Id = new Guid(),
                    Manufacturer = (string)cmbTaxiManufacturer.SelectedItem,
                    LicenseNumber = pnlLongNumberCreatorTaxiLicenseNumber.Number,
                    DriverIds = driverIDs
                };

                _connector.AddDocument("Cars", car);

                InitializeAddCarsTab();
            };


            btnAddRoute.Click += (object sender, EventArgs e) =>
            {
                RouteModel route = new RouteModel
                {
                    Id = new Guid(),
                    DepartureAddress = txtDepartureAddress.Text,
                    DestinationAddress = txtDestinationAddress.Text
                };

                _connector.AddDocument("Routes", route);

                InitializeAddRoutesTab();
            };

            //List<DriverModel> lstDrivers = new List<DriverModel>();



            btnAddDriverRoutes.MouseHover += (object sender, EventArgs e) =>
            {
                cmbChangeDriverRoutes1.Text = GenerateAddress(_citiesAndStreetsForRoutes);
                cmbChangeDriverRoutes2.Text = GenerateAddress(_citiesAndStreetsForRoutes);
            };

           btnAddDriverRoutes.Click += (object sender, EventArgs e) =>
           {
                if(_driverWhenEdited == null)
                {
                    MessageBox.Show("Choose dreiver first");
                    return;
                }

                

                var routeId = Guid.NewGuid();
                RouteModel route = new RouteModel
                {
                    Id = routeId,
                    DepartureAddress = cmbChangeDriverRoutes1.Text,
                    DestinationAddress = cmbChangeDriverRoutes2.Text
                };

                _driverWhenEdited.RouteIds.Add(route.Id);

                _connector.AddDocument("Routes", route);

                _connector.UpdateDocument("Drivers", _driverWhenEdited.Id, _driverWhenEdited);

                cmbEditAllDriversSelectedIndexChanged(cmbEditAllDrivers, new EventArgs());

            };

            btnSaveDriverRoutes.Click += (object sender, EventArgs e) =>
            {
                if (_driverWhenEdited == null)
                {
                    MessageBox.Show("Choose driver first");
                    return;
                }

                

                if(cmbChangeDriverRoutes1.Items.Count == 0)
                {
                    MessageBox.Show("This driver has no routes");
                    return;
                }

                RouteModel route1 = (cmbChangeDriverRoutes1.Items[_cmbChangeDriverRoutes1SelectedIndex] as ComboRoute).Route;
                Guid route1ID = route1.Id;

                if(!string.IsNullOrEmpty(cmbChangeDriverRoutes1.Text) && !string.IsNullOrWhiteSpace(cmbChangeDriverRoutes1.Text))
                    route1.DepartureAddress = cmbChangeDriverRoutes1.Text;
                if (!string.IsNullOrEmpty(cmbChangeDriverRoutes2.Text) && !string.IsNullOrWhiteSpace(cmbChangeDriverRoutes2.Text))
                        route1.DestinationAddress = cmbChangeDriverRoutes2.Text;

                if (_driverWhenEdited.RouteIds.Contains(route1ID))
                {

                    _connector.UpdateDocument("Routes", route1ID, route1);

                    RouteModel route1Updated = _connector.GetDocumentById<RouteModel>("Routes", route1ID);



                    if (route1.Id == route1Updated.Id)
                    {
                        cmbEditAllDriversSelectedIndexChanged(cmbEditAllDrivers, new EventArgs());
                    }

                }
                else
                {
                    MessageBox.Show($"sorry, but this driver don't have a route \"${route1.DepartureAddress} - ${route1.DestinationAddress}\". The route won't be updated. ");
                }

            };

            btnDeleteDriverRoutes.Click += (object sender, EventArgs e) =>
            {
                if (_driverWhenEdited == null)
                {
                    MessageBox.Show("Choose dreiver first");
                    return;
                }

                

                if (cmbChangeDriverRoutes1.Items.Count == 0)
                {
                    MessageBox.Show("This driver has no routes");
                    return;
                }

                RouteModel route1 = (cmbChangeDriverRoutes1.Items[_cmbChangeDriverRoutes1SelectedIndex] as ComboRoute).Route;
                Guid route1ID = route1.Id;
                RouteModel route1Check = _connector.GetDocumentById<RouteModel>("Routes", route1ID);

                _connector.DeleteDocument<RouteModel>("Routes", route1ID);

                RouteModel route1Check2 = _connector.GetDocumentById<RouteModel>("Routes", route1ID);

                _driverWhenEdited.RouteIds.Remove(route1.Id);

                _connector.UpdateDocument("Drivers", _driverWhenEdited.Id, _driverWhenEdited);

                cmbEditAllDriversSelectedIndexChanged(cmbEditAllDrivers, new EventArgs());                
            };

            btnAddDriverCar.MouseHover += (object sender, EventArgs e) => 
            {
                cmbChangeDriverCars.Text = _cars[_rnd.Next(_cars.Length - 1)];
                string license = "";
                for(int i = 0; i < 6; i++)
                    license += _rnd.Next(9).ToString();
                
                txtChangeDriverCarLicense.Text = license;  
            };


            cmbEditTaxiesDriversAllDrivers.SelectedIndexChanged += (object sender, EventArgs e) => 
            {
                _cmbEditTaxiesDriversAllDriversSelectedItem = (sender as ComboBox).SelectedItem;
            };


        }

        private void cmbEditAllDriversSelectedIndexChanged(object sender, EventArgs e)
        {
            _cmbChangeDriverRoutes1SelectedIndex = -1;
            _cmbChangeDriverRoutes2SelectedIndex = -1;
            _cmbChangeDriverCarsSelectedIndexChanged = -1;
            cmbChangeDriverCars.Items.Clear();
            txtChangeDriverCarLicense.Text = string.Empty;

            if ((sender as ComboBox).SelectedItem != null)
                _cmbEditAllDriversSelectedItem = (sender as ComboBox).SelectedItem;

            _driverWhenEdited = (_cmbEditAllDriversSelectedItem as ComboDriver).Driver;
            Bitmap image = ImageProvider.ByteArrayToBitmap(_driverWhenEdited.Image);
            pbxEditDrivers.Width = image.Width;
            pbxEditDrivers.Height = image.Height;
            pbxEditDrivers.Image = image;

            txtChangeDriverFirstname.Text = _driverWhenEdited.FirstName;
            txtChangeDriverLastName.Text = _driverWhenEdited.Lastname;
            cmbChangeDriverCars.Items.Clear();
            _driverWhenEdited.CarIds.ForEach(x => { var car = _connector.GetDocumentById<CarModel>("Cars", x); if(car != null) cmbChangeDriverCars.Items.Add(new ComboCar(car)); }  );
            if (cmbChangeDriverCars.Items.Count > 0)
            {
                cmbChangeDriverCars.SelectedItem = cmbChangeDriverCars.Items[_rnd.Next(cmbChangeDriverCars.Items.Count - 1)];
                txtChangeDriverCarLicense.Text = (cmbChangeDriverCars.SelectedItem as ComboCar).License;
            }
            else
            {
                cmbChangeDriverCars.Items.Clear();
                cmbChangeDriverCars.Text = string.Empty;
                txtChangeDriverCarLicense.Text = string.Empty;
            }

            cmbChangeDriverCars.SelectedIndexChanged += (object sender2, EventArgs e2) =>
            {
                txtChangeDriverCarLicense.Text = ((sender2 as ComboBox).SelectedItem as ComboCar).License;
                _cmbChangeDriverCarsSelectedIndexChanged = (sender2 as ComboBox).SelectedIndex;

            };
            pnlLongNumberChangeDriverIDCertificate.Number = _driverWhenEdited.IdentityNumber;

            if (_driverWhenEdited.RouteIds != null)
            {
                cmbChangeDriverRoutes1.Enabled = cmbChangeDriverRoutes2.Enabled = true;
                cmbChangeDriverRoutes1.Text = cmbChangeDriverRoutes2.Text = string.Empty;
                btnSaveDriverRoutes.Enabled = btnDeleteDriverRoutes.Enabled = true;
                cmbChangeDriverRoutes1.Items.Clear();
                cmbChangeDriverRoutes2.Items.Clear();
                List<RouteModel> driverRoutes = new List<RouteModel>();
                _driverWhenEdited.RouteIds.ForEach(x => driverRoutes.Add(_connector.GetDocumentById<RouteModel>("Routes", x)));
                foreach (var s in driverRoutes)
                {
                    cmbChangeDriverRoutes1.Items.Add(new ComboRoute(s, IsDeparture.Departure));
                    cmbChangeDriverRoutes2.Items.Add(new ComboRoute(s, IsDeparture.Destination));
                }
                cmbChangeDriverRoutes1.SelectedIndexChanged += (object sender2, EventArgs e2) =>
                {
                    cmbChangeDriverRoutes2.SelectedItem = cmbChangeDriverRoutes2.Items[cmbChangeDriverRoutes1.SelectedIndex];
                    _cmbChangeDriverRoutes1SelectedIndex = cmbChangeDriverRoutes1.SelectedIndex;
                };
                cmbChangeDriverRoutes2.SelectedIndexChanged += (object sender2, EventArgs e2) =>
                {
                    cmbChangeDriverRoutes1.SelectedItem = cmbChangeDriverRoutes1.Items[cmbChangeDriverRoutes2.SelectedIndex];
                    _cmbChangeDriverRoutes2SelectedIndex = cmbChangeDriverRoutes2.SelectedIndex;
                };


            }
            else
            {
                cmbChangeDriverRoutes1.Text = cmbChangeDriverRoutes2.Text = "this driver has no routes";
            }

            InitializeEditDriversTab();
        }

        private void InitializeAddRoutesTab()
        {
            txtDepartureAddress.Text = GenerateAddress(_citiesAndStreetsForRoutes);
            txtDestinationAddress.Text = GenerateAddress(_citiesAndStreetsForRoutes);
        }

        private string GenerateAddress(Dictionary<string, List<string>> citiesAndStreets)
        {
            string randomStreet = citiesAndStreets[citiesAndStreets.Keys.ToArray()[2]][_rnd.Next(citiesAndStreets[citiesAndStreets.Keys.ToArray()[2]].Count - 1)];
            string randomCity = citiesAndStreets[citiesAndStreets.Keys.ToArray()[4]][_rnd.Next(citiesAndStreets[citiesAndStreets.Keys.ToArray()[4]].Count - 1)];
            return $"{randomCity} {_rnd.Next(1, _rnd.Next(10, 250))}/{_rnd.Next(1, _rnd.Next(10, 250))} ,{randomStreet}";
        }

        private void InitializeAddCarsTab()
        {
            cmbTaxiManufacturer.SelectedItem = cmbTaxiManufacturer.Items[_rnd.Next(cmbTaxiManufacturer.Items.Count - 1)];
            pnlLongNumberCreatorTaxiLicenseNumber.RandomNumber();
            var driversWithRoutes = _connector.FindAllWithOrWithout<DriverModel>("Drivers", "Routes", true).Select(x => new ComboDriver(x)).ToArray();
            cmbTaxiDrivers.Items.AddRange(driversWithRoutes);
            cmbTaxiDrivers.SelectedItem = cmbTaxiDrivers.Items[_rnd.Next(cmbTaxiDrivers.Items.Count - 1)];



        }
        private void InitializeAddDriversTab()
        {
            Bitmap image = ImageProvider.GetResizedPersonImageAsBitmap(8);
            pbxDriverPicture.Width = image.Width;
            pbxDriverPicture.Height = image.Height;
            pbxDriverPicture.Image = image;

            cmbCars.SelectedItem = cmbCars.Items[_rnd.Next(cmbCars.Items.Count - 1)];
            cmbRoutes.SelectedItem = cmbRoutes.Items[_rnd.Next(cmbRoutes.Items.Count - 1)];
            lblCarLicense.Text = ((ComboCar)cmbCars.SelectedItem).License;

            txtFirstName.Text = _names[_rnd.Next(_names.Length - 1)];
            txtLastName.Text = _names[_rnd.Next(_names.Length - 1)];
            pnlLongNumberCreatorIdNumber.RandomNumber();
        }


        private void InitializeEditDriversTab()
        {
            var allDrivers = _connector.GetAllDocuments<DriverModel>("Drivers").Select(x => new ComboDriver(x)).ToArray();
            cmbEditAllDrivers.Items.Clear();
            cmbEditAllDrivers.Items.AddRange(allDrivers);
            cmbEditAllDrivers.Text = "Choose driver";
        }

        private void InitializeEtitTaxiesTab()
        {
            cmbEditTaxies.Items.Clear();
            var allTaxies = _connector.GetAllDocuments<CarModel>("Cars").Select(_ => new ComboCar(_)).ToArray();
            cmbEditTaxies.Items.AddRange(allTaxies);
            //cmbEditTaxiesDriversAllDrivers.Items.AddRange(cmbEditAllDrivers.Items.to);
            foreach(ComboDriver s in cmbEditAllDrivers.Items)
            {
                cmbEditTaxiesDriversAllDrivers.Items.Add(s);
            }
        }

        private void cmbEditTaxiesSelectedIndexChanged(ComboBox sender)
        {
            _cmbEditTaxiesSelectedItem = (sender.SelectedItem as ComboCar).Car;

            CarModel car = (sender.SelectedItem as ComboCar).Car;

            txtEditTaxiesManufacturer.Text = car.Manufacturer;
            txtEditTaxiesLicense.Text = car.LicenseNumber;

            if (car.DriverIds != null)
            {
                cmbEditTaxiesDrivers.Items.Clear();
                foreach (var s in car.DriverIds)
                    cmbEditTaxiesDrivers.Items.Add(new ComboDriver(_connector.GetDocumentById<DriverModel>("Drivers", s)));
            }
            else
            {
                cmbEditTaxiesDrivers.Text = "This car has no drivers";
            }


            for(int i = 0; i < cmbEditTaxiesDriversAllDrivers.Items.Count; i++)
            {
                if ((cmbEditTaxiesDriversAllDrivers.Items[i] as ComboDriver).Driver.CarIds.Contains(car.Id))
                    cmbEditTaxiesDriversAllDrivers.Items.Remove(cmbEditTaxiesDriversAllDrivers.Items[i]);
            }
            

            InitializeEtitTaxiesTab();
        }

        private void LicenseNumberTexBoxKeyDown(TextBox sender, KeyEventArgs e)
        {
            if (!_digitsKeys.Contains(e.KeyValue))
                e.SuppressKeyPress = true;

            if (sender.Text.Length >= 6)
            {
                if (e.KeyValue != 8)
                    e.SuppressKeyPress = true;

                else { sender.Text = string.Empty; }
            }
        }









        private Dictionary<string, string> getConnctionStringAndDBName()
        {
            JObject res = null;
            string path = CONFIG_FILE_PATH;
            if (File.Exists(path))
            {
                try
                {
                    res = JObject.Parse(File.ReadAllText(path));
                }
                catch (Exception ex)
                {
                    Exception userEx = new Exception("The \"configuration.txt\" file isn't in a proper JSON format", ex);
                    throw userEx;
                }
            }
            else throw new Exception("The file \"configuration.txt\" doesn't exsists.");

            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (var s in res.Properties())
                dict.Add(s.Name, s.Value.ToString());

            return dict;

        }


        private void SafeInvoke(Action work, Control control)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(work);
            }
            else work();
        }

        private void btnAddDriverCar_Click(object sender, EventArgs e)
        {
            if (_driverWhenEdited == null)
            {
                MessageBox.Show("Choose dreiver first");
                return;
            }

            Guid carID = Guid.NewGuid();
            CarModel car = new CarModel
            {
                Id = carID,
                Manufacturer = cmbChangeDriverCars.Text,
                LicenseNumber = txtChangeDriverCarLicense.Text,
                DriverIds = new List<Guid>()
            };

            car.DriverIds.Add(_driverWhenEdited.Id);

            _connector.AddDocument("Cars", car);

            _driverWhenEdited.CarIds.Add(carID);

            _connector.UpdateDocument("Drivers", _driverWhenEdited.Id, _driverWhenEdited);

            cmbEditAllDriversSelectedIndexChanged(cmbEditAllDrivers, new EventArgs());
        }

        private void btnEditDriverCar_Click(object sender, EventArgs e)
        {
            CarModel currentCar = null;
            if (cmbChangeDriverCars.SelectedItem != null)
            {
                currentCar = (cmbChangeDriverCars.SelectedItem as ComboCar).Car;
            }
            else return;

            currentCar.Manufacturer = cmbChangeDriverCars.Text;
            currentCar.LicenseNumber = txtChangeDriverCarLicense.Text;

            _connector.UpdateDocument("Cars", currentCar.Id, currentCar);

            cmbEditAllDriversSelectedIndexChanged(cmbEditAllDrivers, new EventArgs());
        }

        private void btnDEleteDriverCar_Click(object sender, EventArgs e)
        {
            CarModel currentCar = null;
            if (cmbChangeDriverCars.SelectedItem != null)
            {
                currentCar = (cmbChangeDriverCars.SelectedItem as ComboCar).Car;
            }
            else return;

            if(_driverWhenEdited.CarIds.Contains(currentCar.Id))
            {
                _driverWhenEdited.CarIds.Remove(currentCar.Id);
                _connector.UpdateDocument("Drivers", _driverWhenEdited.Id, _driverWhenEdited);
                _connector.DeleteDocument<CarModel>("Cars", currentCar.Id);
            }



            cmbEditAllDriversSelectedIndexChanged(cmbEditAllDrivers, new EventArgs());
        }

        private void btnSaveDriver_Click(object sender, EventArgs e)
        {
            if (_driverWhenEdited == null)
            {
                MessageBox.Show("Choose dreiver first");
                return;
            }

            _driverWhenEdited.FirstName = txtChangeDriverFirstname.Text;
            _driverWhenEdited.Lastname = txtChangeDriverLastName.Text;
            _driverWhenEdited.IdentityNumber = pnlLongNumberChangeDriverIDCertificate.Number;



            if (_cmbChangeDriverRoutes2SelectedIndex != -1 && _cmbChangeDriverRoutes1SelectedIndex != -1) 
            {
                RouteModel route1 = (cmbChangeDriverRoutes1.Items[_cmbChangeDriverRoutes1SelectedIndex] as ComboRoute).Route;
                Guid route1ID = route1.Id;

                if (!string.IsNullOrEmpty(cmbChangeDriverRoutes1.Text) && !string.IsNullOrWhiteSpace(cmbChangeDriverRoutes1.Text))
                    route1.DepartureAddress = cmbChangeDriverRoutes1.Text;
                if (!string.IsNullOrEmpty(cmbChangeDriverRoutes2.Text) && !string.IsNullOrWhiteSpace(cmbChangeDriverRoutes2.Text))
                    route1.DestinationAddress = cmbChangeDriverRoutes2.Text;

                if (_driverWhenEdited.RouteIds.Contains(route1ID))
                {
                    _connector.UpdateDocument("Routes", route1ID, route1);
                }
            }
            if(_cmbChangeDriverCarsSelectedIndexChanged != -1)
            {
                CarModel currentCar = (cmbChangeDriverCars.Items[_cmbChangeDriverCarsSelectedIndexChanged] as ComboCar).Car; 

                currentCar.Manufacturer = cmbChangeDriverCars.Text;
                currentCar.LicenseNumber = txtChangeDriverCarLicense.Text;

                _connector.UpdateDocument("Cars", currentCar.Id, currentCar);
            }



            /*currentCar.Manufacturer = cmbChangeDriverCars.Text;
            currentCar.LicenseNumber = txtChangeDriverCarLicense.Text;

            _connector.UpdateDocument("Cars", currentCar.Id, currentCar);*/








            _connector.UpdateDocument("Drivers", _driverWhenEdited.Id, _driverWhenEdited);
            cmbEditAllDriversSelectedIndexChanged(cmbEditAllDrivers, new EventArgs());

        }

        private void btnDeleteDriver_Click(object sender, EventArgs e)
        {
            if (_driverWhenEdited == null)
            {
                MessageBox.Show("Choose dreiver first");
                return;
            }

            for(int i = 0; i < cmbEditAllDrivers.Items.Count; i++)
            {
                if ((cmbEditAllDrivers.Items[i] as ComboDriver).Driver.Id == _driverWhenEdited.Id)
                    cmbEditAllDrivers.Items.Remove(cmbEditAllDrivers.Items[i]);
            }
            pbxEditDrivers.Image = new Bitmap(10, 10);
            txtChangeDriverCarLicense.Text = string.Empty;
            txtChangeDriverFirstname.Text = string.Empty;
            txtChangeDriverLastName.Text = string.Empty; 
            cmbChangeDriverCars.Text = string.Empty;
            cmbChangeDriverRoutes1.Text = string.Empty;
            cmbChangeDriverRoutes2.Text = string.Empty;
            pnlLongNumberChangeDriverIDCertificate.Number = "0";

            _connector.DeleteDocument<DriverModel>("Drivers", _driverWhenEdited.Id);
            _driverWhenEdited = null;
        }

        private void btnEditTaxiesRemoveDriver_Click(object sender, EventArgs e)
        {
            var driver = (cmbEditTaxiesDrivers.SelectedItem as ComboDriver).Driver;
            var comboDriver = cmbEditTaxiesDrivers.SelectedItem as ComboDriver;
            var car = _cmbEditTaxiesSelectedItem as CarModel;

            if (car.DriverIds.Contains(driver.Id))
            {
                car.DriverIds.Remove(driver.Id);

                _connector.UpdateDocument("Cars", car.Id, car);
                cmbEditTaxiesDrivers.Text = string.Empty;
                cmbEditTaxiesDrivers.Items.Remove(comboDriver);
            }
            else MessageBox.Show("There no relationship between the car and the driver");

            InitializeLifetimeService();
        }

        private async Task editDriversTabLeave()
        {
            btnAddDriver.Enabled = false;

            Task tsk = Task.Run(() =>
            {
                Action act = () => cmbCars.Items.Clear();
                SafeInvoke(act, cmbCars);
                act = () => cmbCars.Items.AddRange(_connector.GetAllDocuments<CarModel>("Cars").Select(_ => new ComboCar(_)).ToArray());
                SafeInvoke(act, cmbCars);
                act = () => cmbCars.SelectedItem = cmbCars.Items[_rnd.Next(cmbCars.Items.Count - 1)];
                SafeInvoke(act, cmbCars);
                act = () => cmbRoutes.Items.Clear();
                SafeInvoke(act, cmbCars);
                act = () => cmbRoutes.Items.AddRange(_connector.GetAllDocuments<RouteModel>("Routes").Select(_ => new ComboRoute(_)).ToArray());
                SafeInvoke(act, cmbCars);
                act = () => cmbRoutes.SelectedItem = cmbRoutes.Items[_rnd.Next(cmbRoutes.Items.Count - 1)];
                SafeInvoke(act, cmbCars);

                act = () =>
                {
                    _driverCarIDs.Add((cmbCars.SelectedItem as ComboCar).Car.Id);
                    _driverRouteIDs.Add((cmbRoutes.SelectedItem as ComboRoute).Route.Id);
                };
                SafeInvoke(act, this);

            });

            await tsk;
            if (tsk.IsCompleted) btnAddDriver.Enabled = true;
        }

        private void btnEditTaxiesAddDriver_Click(object sender, EventArgs e)
        {
            var car = _cmbEditTaxiesSelectedItem as CarModel;
            if(car == null)
            {
                MessageBox.Show("קודם בחר מכונית");
                return;
            }

            var driver =  (_cmbEditTaxiesDriversAllDriversSelectedItem as ComboDriver).Driver;

            if (!car.DriverIds.Contains(driver.Id))
            {
                car.DriverIds.Add(driver.Id);
                _connector.UpdateDocument("Cars", car.Id, car);
            }
            else MessageBox.Show("The driver is already drives the car");

            InitializeLifetimeService();
        }
    }
}
