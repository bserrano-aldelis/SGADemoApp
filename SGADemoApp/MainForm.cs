using SGADemoApp.Application;
using SGADemoApp.DAL;
using System;
using System.Windows.Forms;

namespace SGADemoApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Instanciamos el proveedor de base de datos
            var dbProvider = new DbProvider("Server=localhost;DatabaseBlahBlah");

            // Instanciamos el acceso a datos
            var dao = new WarehouseLocationDAO(dbProvider);

            // Instanciamos el manager de negocio
            var manager = new SGAManager(dao);

            // Obtenemos todas las ubicaciones
            var locations = manager.GetAll();

            // Otras operaciones necesarias
        }
    }
}
