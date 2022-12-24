//London Adams, Morgan Mischo, Brielle Fernelius
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.ComponentModel;

namespace Group_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Variables

        /// <summary>
        /// Create instance of wndSearch
        /// </summary>
        private wndSearch wndSearch;

        /// <summary>
        /// Creates an instance of the DataSet
        /// </summary>
        private DataSet ds;

        /// <summary>
        /// Create instance of wndItems Window
        /// </summary>
        private wndItems wndItems;

        /// <summary>
        /// Create instance of MainSql
        /// </summary>
        private Main.clsMainSQL MainSql;

        /// <summary>
        /// Create instance of clsItems
        /// </summary>
        private Main.clsItems Items;

        /// <summary>
        /// Create a list to hold the combobox selection
        /// </summary>
        public List<string> lstcboSelection = new List<string>();

        /// <summary>
        /// Create a list to hold Data
        /// </summary>
        public List<Main.clsItems> lstData;

        public List<Main.clsItems> lstInvoice { get; set; }

        public string invoiceNum;

        public double TotalCost;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
                wndSearch = new wndSearch();
                wndItems = new wndItems();
                MainSql = new Main.clsMainSQL();
                Items = new Main.clsItems();
                lstInvoice = new List<Main.clsItems>();

                updateItem();
                fillItemCbo();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Puts the info inside the datagrid
        /// </summary>
        public void dealWithDataGrid()
        {
            try
            {
                main_datagrid.ItemsSource = null;
                main_datagrid.ItemsSource = lstInvoice;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// What happens when the main window is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //main_datagrid.ItemsSource = MainSql.lstItems;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Updates the Items
        /// </summary>
        public void updateItem()
        {
            try
            {
                lstData = MainSql.GetItemDesc();
                Trace.WriteLine(lstData);
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Fills up the Items combobox
        /// </summary>
        public void fillItemCbo()
        {
            try
            {
                items_cbo.ItemsSource = lstData;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        #endregion Methods

        #region Add Button

        /// <summary>
        /// Adds the new item to the data grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Main.clsItems Items;

                Items = new Main.clsItems();

                Items.ItemDesc = lstData[items_cbo.SelectedIndex].ItemDesc;
                Items.ItemCode = lstData[items_cbo.SelectedIndex].ItemCode;
                Items.ItemCost = lstData[items_cbo.SelectedIndex].ItemCost;

                lstInvoice.Add(Items);
                dealWithDataGrid();

                Trace.WriteLine(lstInvoice.Count);

                TotalCost += Convert.ToDouble(Items.ItemCost);
                totalCost_lbl.Content = "Total Cost: " + TotalCost;
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        #endregion Add Button

        #region Delete Button

        /// <summary>
        /// Deletes the item from the data grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TotalCost -= Convert.ToDouble(lstInvoice[main_datagrid.SelectedIndex].ItemCost);
                totalCost_lbl.Content = "Total Cost: " + TotalCost;
                lstInvoice.RemoveAt(main_datagrid.SelectedIndex);
                dealWithDataGrid();
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        #endregion Delete Button

        #region Save Button

        /// <summary>
        /// Saves the invoice and adds to the combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void save_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime UpdatedTime = invoice_date.SelectedDate ?? DateTime.Now;
                MainSql.itemsInsert(UpdatedTime, TotalCost);
                //updateLineItems(); 
                //Update invoices
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        public void updateLineItems()
        {
            int myMax = MainSql.grabMax(); 
            for (int i = 0; i < lstInvoice.Count; i++)
            {
                MainSql.insertLineItems(myMax, i + 1, lstInvoice[i].ItemCode); 
            }
        }

        #endregion Save Button

        #region Items Combo box

        /// <summary>
        /// User selects an invoice item to add to their invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void items_cbo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //Load in the invoice items descriptions into the combo box from the database
                //When they select a descprition, display the cost of that item in the label
                //Once they select an item, the add, edit, and delete buttons can be enabled

                //When the user clickes the add/edit/delete button from the item window the list will be passed to the main window
                //into the combo box
                //Items = (Main.clsItems)items_cbo.SelectedItem;
                //items_cbo.ItemsSource = MainSql.GetItemDesc();
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        #endregion Items Combo box

        #region Menu

        /// <summary>
        /// When Search is selected from the menu drop down, the search window is opened
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuSearch_click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Opens up the search screen
                this.Hide();
                wndSearch.ShowDialog();

                //create a property in the search window will be used to determine if a invoice was selected
                //if so retrieve the invoice ID from the search window
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// When Update is selected from the menu drop down, the items window is opened
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuUpdate_click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Open the items window
                this.Hide();
                wndItems.ShowDialog();
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        #endregion Menu

        #region Create Invoice Button

        /// <summary>
        /// Create a new invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btnAddItem.IsEnabled = true;
                btnDeleteItem.IsEnabled = true;
                invoiceNum = "TBD";
                lblInvoiceNumber.Content = invoiceNum;
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        #endregion Create Invoice Button

        #region Error Handling

        /// <summary>
        /// Handle the error.
        /// </summary>
        /// <param name="sClass">The class in which the error occurred in.</param>
        /// <param name="sMethod">The method in which the error occurred in.</param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                //Would write to a file or database here.
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Error Handling
    }
}