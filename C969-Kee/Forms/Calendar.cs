using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C969_Kee.Appointments;


namespace C969_Kee.Forms
{
    public partial class Calendar : Form
    {
        private BindingSource appointmentBindingSource = new BindingSource();
        public Calendar()
        {
            InitializeComponent();
        }

        private void calendar_Load(object sender, EventArgs e)
        {
            //creates data access object
            AppointmentsDAO appointmentsDao = new AppointmentsDAO();
            // grabs all appointments in database via the DAO get request
            appointmentBindingSource.DataSource = appointmentsDao.GetAllAppointmentsList();
            //binds the data to the grid
            dataGridView1.DataSource = appointmentBindingSource;
        }

        private void Calendar_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            CreateAppointmentForm createAppointmentForm = new CreateAppointmentForm();
            createAppointmentForm.ShowDialog();
        }
    }
}
