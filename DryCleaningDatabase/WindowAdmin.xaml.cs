using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DryCleaningDatabase
{
    public partial class WindowAdmin : Window
    {
        List<Employee> employeesList { get; set; }
        List<AccessRule> accessRuleList { get; set; }
        List<Order> ordersList { get; set; }
        List<Client> clientsList { get; set; }
        List<int> clientsIdList { get; set; }
        List<Thing> thingsList { get; set; }
        List<Service> servicesList { get; set; }
        List<Progress> progressesList { get; set; }
        List<OrderState> orderStatesList { get; set; }

        public WindowAdmin()
        {
            InitializeComponent();

            using (DryCleaningDBContext database = new DryCleaningDBContext())
            {

                employeesList = database.Employees.ToList();
                accessRuleList = database.AccessRules.ToList();
                ordersList = database.Orders.ToList();
                clientsList = database.Clients.ToList();
                thingsList = database.Things.ToList();
                servicesList = database.Services.ToList();
                progressesList = database.Progresses.ToList();
                orderStatesList = database.OrderStates.ToList();

                List<int> rulesList = new List<int>(2);
                clientsIdList = new List<int>(2);
                List<int> serviceIdList = new List<int>(2);
                List<int> thingsIdList = new List<int>(2);
                List<int> progressIdList = new List<int>(2);
                List<int> orderStateIdList = new List<int>(2);

                foreach (var rule in accessRuleList)
                {
                    rulesList.Add(rule.Role);
                }

                foreach (var client in clientsList)
                {
                    clientsIdList.Add(client.ClientId);
                }

                foreach (var service in servicesList)
                {
                    serviceIdList.Add(service.ServiceId);
                }

                foreach (var thing in thingsList)
                {
                    thingsIdList.Add(thing.ThingId);
                }
                foreach (var progress in progressesList)
                {
                    progressIdList.Add(progress.ProgressId);
                }
                foreach (var orderState in orderStatesList)
                {
                    orderStateIdList.Add(orderState.OrderStateId);
                }

                employeesGrid.ItemsSource = employeesList;

                accessRulesGrid1.ItemsSource = accessRuleList;
                accessRulesGrid2.ItemsSource = accessRuleList;

                clientGrid.ItemsSource = clientsList;
                clientGrid1.ItemsSource = clientsList;

                thingGrid.ItemsSource = thingsList;

                serviceGrid.ItemsSource = servicesList;

                progressGrid.ItemsSource = progressesList;

                orderStateGrid.ItemsSource = orderStatesList;

                orderGrid.ItemsSource = ordersList;

                roleColumn.ItemsSource = rulesList;
                clientCombobox.ItemsSource = clientsIdList;
                serviceCombobox.ItemsSource = serviceIdList;
                thingCombobox.ItemsSource = thingsIdList;
                progressComboBox.ItemsSource = progressIdList;
                orderStateComboBox.ItemsSource = orderStateIdList;
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            using (DryCleaningDBContext database = new DryCleaningDBContext())
            {

                switch (Menu.SelectedIndex)
                {
                    case 0:
                        {

                            if (employeesGrid.SelectedItem != null)
                            {
                                try
                                {
                                    Employee saveInformation = employeesGrid.SelectedItem as Employee;

                                    database.Employees.Update(saveInformation);
                                    database.SaveChanges();

                                    employeesList = (List<Employee>)employeesGrid.ItemsSource;

                                    MessageBox.Show("Данные обновлены", "Обновление", MessageBoxButton.OK, MessageBoxImage.Information);

                                }
                                catch (Exception exception)
                                {
                                    MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Не было выделено ни одной строки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }


                            break;
                        }
                    case 1:
                        {
                            if (accessRulesGrid2.SelectedItem != null)
                            {
                                try
                                {
                                    AccessRule saveInformation = accessRulesGrid2.SelectedItem as AccessRule;

                                    database.AccessRules.Update(saveInformation);
                                    database.SaveChanges();

                                    accessRuleList = (List<AccessRule>)accessRulesGrid2.ItemsSource;

                                    accessRulesGrid1.ItemsSource = null;
                                    accessRulesGrid1.ItemsSource = accessRuleList;

                                    MessageBox.Show("Данные обновлены", "Обновление", MessageBoxButton.OK, MessageBoxImage.Information);

                                }
                                catch (Exception exception)
                                {
                                    MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Не было выделено ни одной строки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }


                            break;
                        }
                    case 2:
                        {

                            if (clientGrid.SelectedItem != null)
                            {
                                try
                                {
                                    Client saveInformation = clientGrid.SelectedItem as Client;

                                    database.Clients.Update(saveInformation);
                                    database.SaveChanges();

                                    clientsList = (List<Client>)clientGrid.ItemsSource;

                                    clientGrid1.ItemsSource = null;
                                    clientGrid1.ItemsSource = clientsList;
                                    
                                    clientGrid.ItemsSource = null;
                                    clientGrid.ItemsSource = clientsList;

                                    MessageBox.Show("Данные обновлены", "Обновление", MessageBoxButton.OK, MessageBoxImage.Information);

                                }
                                catch (Exception exception)
                                {
                                    MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Не было выделено ни одной строки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;
                        }
                    case 3:
                        {
                            if (thingGrid.SelectedItem != null)
                            {
                                try
                                {
                                    Thing saveInformation = thingGrid.SelectedItem as Thing;

                                    database.Things.Update(saveInformation);
                                    database.SaveChanges();

                                    thingsList = (List<Thing>)thingGrid.ItemsSource;

                                    MessageBox.Show("Данные обновлены", "Обновление", MessageBoxButton.OK, MessageBoxImage.Information);

                                }
                                catch (Exception exception)
                                {
                                    MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Не было выделено ни одной строки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }


                            break;
                        }
                    case 4:
                        {
                            if (serviceGrid.SelectedItem != null)
                            {
                                try
                                {
                                    Service saveInformation = serviceGrid.SelectedItem as Service;

                                    database.Services.Update(saveInformation);
                                    database.SaveChanges();

                                    servicesList = (List<Service>)serviceGrid.ItemsSource;

                                    MessageBox.Show("Данные обновлены", "Обновление", MessageBoxButton.OK, MessageBoxImage.Information);

                                }
                                catch (Exception exception)
                                {
                                    MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Не было выделено ни одной строки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;
                        }
                    case 5:
                        {
                            if (progressGrid.SelectedItem != null)
                            {
                                try
                                {
                                    Progress saveInformation = progressGrid.SelectedItem as Progress;

                                    database.Progresses.Update(saveInformation);
                                    database.SaveChanges();

                                    progressesList = (List<Progress>)progressGrid.ItemsSource;

                                    MessageBox.Show("Данные обновлены", "Обновление", MessageBoxButton.OK, MessageBoxImage.Information);

                                }
                                catch (Exception exception)
                                {
                                    MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Не было выделено ни одной строки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }


                            break;
                        }
                    case 6:
                        {
                            if (orderStateGrid.SelectedItem != null)
                            {
                                try
                                {
                                    OrderState saveInformation = orderStateGrid.SelectedItem as OrderState;

                                    database.OrderStates.Update(saveInformation);
                                    database.SaveChanges();

                                    orderStatesList = (List<OrderState>)orderStateGrid.ItemsSource;

                                    MessageBox.Show("Данные обновлены", "Обновление", MessageBoxButton.OK, MessageBoxImage.Information);

                                }
                                catch (Exception exception)
                                {
                                    MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Не было выделено ни одной строки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;
                        }
                    case 7:
                        {
                            if (orderGrid.SelectedItem != null)
                            {
                                try
                                {
                                    Order saveInformation = orderGrid.SelectedItem as Order;

                                    database.Orders.Update(saveInformation);
                                    database.SaveChanges();

                                    ordersList = (List<Order>)orderGrid.ItemsSource;

                                    MessageBox.Show("Данные обновлены", "Обновление", MessageBoxButton.OK, MessageBoxImage.Information);

                                }
                                catch (Exception exception)
                                {
                                    MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Не было выделено ни одной строки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;
                        }
                }
                
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            using (DryCleaningDBContext database = new DryCleaningDBContext())
            {

                switch (Menu.SelectedIndex)
                {
                    case 0:
                        {

                            if (employeesGrid.SelectedItem != null)
                            {
                                MessageBoxResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                                if (dialogResult == MessageBoxResult.Yes)
                                {

                                    try
                                    {
                                        Employee deleteInformation = employeesGrid.SelectedItem as Employee;



                                        foreach (Employee employee in employeesList)
                                        {
                                            if (employee == deleteInformation)
                                            {
                                                employeesList.Remove(employee);
                                                break;
                                            }
                                        }

                                        database.Employees.Remove(deleteInformation);
                                        database.SaveChanges();

                                        employeesGrid.ItemsSource = null;
                                        employeesGrid.ItemsSource = employeesList;

                                        MessageBox.Show("Данные удалены", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);

                                    }
                                    catch (Exception exception)
                                    {
                                        MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Операция прервана пользователем", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                                }
                            }
                            else
                            {
                                MessageBox.Show("Не было выделено ни одной строки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;
                        }
                    case 1:
                        {
                            if (accessRulesGrid2.SelectedItem != null)
                            {
                                MessageBoxResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                                if (dialogResult == MessageBoxResult.Yes)
                                {

                                    try
                                    {
                                        AccessRule deleteInformation = accessRulesGrid2.SelectedItem as AccessRule;

                                        foreach (AccessRule accessRule in accessRuleList)
                                        {
                                            if (accessRule == deleteInformation)
                                            {
                                                accessRuleList.Remove(accessRule);
                                                break;
                                            }
                                        }

                                        database.AccessRules.Remove(deleteInformation);
                                        database.SaveChanges();

                                        accessRulesGrid2.ItemsSource = null;
                                        accessRulesGrid2.ItemsSource = accessRuleList;

                                        accessRulesGrid1.ItemsSource = null;
                                        accessRulesGrid1.ItemsSource = accessRuleList;

                                        MessageBox.Show("Данные удалены", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);

                                    }
                                    catch (Exception exception)
                                    {
                                        MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Операция прервана пользователем", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                                }
                            }
                            else
                            {
                                MessageBox.Show("Не было выделено ни одной строки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;
                        }
                    case 2:
                        {
                            if (clientGrid.SelectedItem != null)
                            {
                                MessageBoxResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                                if (dialogResult == MessageBoxResult.Yes)
                                {

                                    try
                                    {
                                        Client deleteInformation = clientGrid.SelectedItem as Client;

                                        foreach (Client client in clientsList)
                                        {
                                            if (client == deleteInformation)
                                            {
                                                clientsList.Remove(client);
                                                break;
                                            }
                                        }

                                        database.Clients.Remove(deleteInformation);
                                        database.SaveChanges();

                                        clientGrid.ItemsSource = null;
                                        clientGrid.ItemsSource = clientsList;

                                        clientGrid1.ItemsSource = null;
                                        clientGrid1.ItemsSource = clientsList;

                                        MessageBox.Show("Данные удалены", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);

                                    }
                                    catch (Exception exception)
                                    {
                                        MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Операция прервана пользователем", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                                }
                            }
                            else
                            {
                                MessageBox.Show("Не было выделено ни одной строки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;
                        }

                    case 3:
                        {
                            if (thingGrid.SelectedItem != null)
                            {
                                MessageBoxResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                                if (dialogResult == MessageBoxResult.Yes)
                                {

                                    try
                                    {
                                        Thing deleteInformation = thingGrid.SelectedItem as Thing;

                                        foreach (Thing thing in thingsList)
                                        {
                                            if (thing == deleteInformation)
                                            {
                                                thingsList.Remove(thing);
                                                break;
                                            }
                                        }

                                        database.Things.Remove(deleteInformation);
                                        database.SaveChanges();

                                        thingGrid.ItemsSource = null;
                                        thingGrid.ItemsSource = thingsList;

                                        MessageBox.Show("Данные удалены", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);

                                    }
                                    catch (Exception exception)
                                    {
                                        MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Операция прервана пользователем", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                                }
                            }
                            else
                            {
                                MessageBox.Show("Не было выделено ни одной строки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;
                        }
                    case 4:
                        {
                            if (serviceGrid.SelectedItem != null)
                            {
                                MessageBoxResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                                if (dialogResult == MessageBoxResult.Yes)
                                {

                                    try
                                    {
                                        Service deleteInformation = serviceGrid.SelectedItem as Service;

                                        foreach (Service service in servicesList)
                                        {
                                            if (service == deleteInformation)
                                            {
                                                servicesList.Remove(service);
                                                break;
                                            }
                                        }

                                        database.Services.Remove(deleteInformation);
                                        database.SaveChanges();

                                        serviceGrid.ItemsSource = null;
                                        serviceGrid.ItemsSource = servicesList;

                                        MessageBox.Show("Данные удалены", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);

                                    }
                                    catch (Exception exception)
                                    {
                                        MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Операция прервана пользователем", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                                }
                            }
                            else
                            {
                                MessageBox.Show("Не было выделено ни одной строки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;
                        }
                    case 5:
                        {
                            if (progressGrid.SelectedItem != null)
                            {
                                MessageBoxResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                                if (dialogResult == MessageBoxResult.Yes)
                                {

                                    try
                                    {
                                        Progress deleteInformation = progressGrid.SelectedItem as Progress;

                                        foreach (Progress progress in progressesList)
                                        {
                                            if (progress == deleteInformation)
                                            {
                                                progressesList.Remove(progress);
                                                break;
                                            }
                                        }

                                        database.Progresses.Remove(deleteInformation);
                                        database.SaveChanges();

                                        progressGrid.ItemsSource = null;
                                        progressGrid.ItemsSource = progressesList;

                                        MessageBox.Show("Данные удалены", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);

                                    }
                                    catch (Exception exception)
                                    {
                                        MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Операция прервана пользователем", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                                }
                            }
                            else
                            {
                                MessageBox.Show("Не было выделено ни одной строки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;
                        }
                    case 6:
                        {
                            if (orderStateGrid.SelectedItem != null)
                            {
                                MessageBoxResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                                if (dialogResult == MessageBoxResult.Yes)
                                {

                                    try
                                    {
                                        OrderState deleteInformation = orderStateGrid.SelectedItem as OrderState;

                                        foreach (OrderState orderState in orderStatesList)
                                        {
                                            if (orderState == deleteInformation)
                                            {
                                                orderStatesList.Remove(orderState);
                                                break;
                                            }
                                        }

                                        database.OrderStates.Remove(deleteInformation);
                                        database.SaveChanges();

                                        orderStateGrid.ItemsSource = null;
                                        orderStateGrid.ItemsSource = orderStatesList;

                                        MessageBox.Show("Данные удалены", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);

                                    }
                                    catch (Exception exception)
                                    {
                                        MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Операция прервана пользователем", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                                }
                            }
                            else
                            {
                                MessageBox.Show("Не было выделено ни одной строки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;
                        }
                    case 7:
                        {
                            if (orderGrid.SelectedItem != null)
                            {
                                MessageBoxResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                                if (dialogResult == MessageBoxResult.Yes)
                                {

                                    try
                                    {
                                        Order deleteInformation = orderGrid.SelectedItem as Order;

                                        foreach (Order order in ordersList)
                                        {
                                            if (order == deleteInformation)
                                            {
                                                ordersList.Remove(order);
                                                break;
                                            }
                                        }

                                        database.Orders.Remove(deleteInformation);
                                        database.SaveChanges();

                                        orderGrid.ItemsSource = null;
                                        orderGrid.ItemsSource = ordersList;

                                        MessageBox.Show("Данные удалены", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);

                                    }
                                    catch (Exception exception)
                                    {
                                        MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Операция прервана пользователем", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                                }
                            }
                            else
                            {
                                MessageBox.Show("Не было выделено ни одной строки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;
                        }
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using (DryCleaningDBContext database = new DryCleaningDBContext())
            {
                switch (Menu.SelectedIndex)
                {
                    case 0:
                        {

                            if (employeesGrid.SelectedItem != null)
                            {
                                try
                                {
                                    Employee saveInformation = employeesGrid.SelectedItem as Employee;

                                    database.Employees.Add(saveInformation);
                                    database.SaveChanges();

                                    employeesList = (List<Employee>)employeesGrid.ItemsSource;

                                    MessageBox.Show("Данные сохранены", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);

                                }
                                catch (Exception exception)
                                {
                                    MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Не было выделено ни одной строки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;
                        }

                    case 1:
                        {
                            if (accessRulesGrid2.SelectedItem != null)
                            {
                                try
                                {
                                    AccessRule saveInformation = accessRulesGrid2.SelectedItem as AccessRule;

                                    database.AccessRules.Add(saveInformation);
                                    database.SaveChanges();

                                    accessRuleList = (List<AccessRule>)accessRulesGrid2.ItemsSource;

                                    accessRulesGrid1.ItemsSource = null;
                                    accessRulesGrid1.ItemsSource = accessRuleList;

                                    MessageBox.Show("Данные сохранены", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);

                                }
                                catch (Exception exception)
                                {
                                    MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Не было выделено ни одной строки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;
                        }
                    case 2:
                        {
                            if (clientGrid.SelectedItem != null)
                            {
                                try
                                {
                                    Client saveInformation = clientGrid.SelectedItem as Client;

                                    database.Clients.Add(saveInformation);
                                    database.SaveChanges();

                                    clientsIdList.Add(saveInformation.ClientId);

                                    clientCombobox.ItemsSource = null;
                                    clientCombobox.ItemsSource = clientsIdList;

                                    clientsList = (List<Client>)clientGrid.ItemsSource;

                                    clientGrid1.ItemsSource = null;
                                    clientGrid1.ItemsSource = clientsList;
                                    
                                    clientGrid.ItemsSource = null;
                                    clientGrid.ItemsSource = clientsList;

                                    MessageBox.Show("Данные сохранены", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);

                                }
                                catch (Exception exception)
                                {
                                    MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Не было выделено ни одной строки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;
                        }
                    case 3:
                        {
                            if (thingGrid.SelectedItem != null)
                            {
                                try
                                {
                                    Thing saveInformation = thingGrid.SelectedItem as Thing;

                                    database.Things.Add(saveInformation);
                                    database.SaveChanges();

                                    thingsList = (List<Thing>)thingGrid.ItemsSource;

                                    MessageBox.Show("Данные сохранены", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);

                                }
                                catch (Exception exception)
                                {
                                    MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Не было выделено ни одной строки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;
                        }
                    case 4:
                        {
                            if (serviceGrid.SelectedItem != null)
                            {
                                try
                                {
                                    Service saveInformation = serviceGrid.SelectedItem as Service;

                                    database.Services.Add(saveInformation);
                                    database.SaveChanges();

                                    servicesList = (List<Service>)serviceGrid.ItemsSource;

                                    MessageBox.Show("Данные сохранены", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);

                                }
                                catch (Exception exception)
                                {
                                    MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Не было выделено ни одной строки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;
                        }
                    case 5:
                        {
                            if (progressGrid.SelectedItem != null)
                            {
                                try
                                {
                                    Progress saveInformation = progressGrid.SelectedItem as Progress;

                                    database.Progresses.Add(saveInformation);
                                    database.SaveChanges();

                                    progressesList = (List<Progress>)progressGrid.ItemsSource;

                                    MessageBox.Show("Данные сохранены", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);

                                }
                                catch (Exception exception)
                                {
                                    MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Не было выделено ни одной строки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;
                        }
                    case 6:
                        {
                            if (orderStateGrid.SelectedItem != null)
                            {
                                try
                                {
                                    OrderState saveInformation = orderStateGrid.SelectedItem as OrderState;

                                    database.OrderStates.Add(saveInformation);
                                    database.SaveChanges();

                                    orderStatesList = (List<OrderState>)orderStateGrid.ItemsSource;

                                    MessageBox.Show("Данные сохранены", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);

                                }
                                catch (Exception exception)
                                {
                                    MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Не было выделено ни одной строки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;
                        }
                    case 7:
                        {
                            if (orderGrid.SelectedItem != null)
                            {
                                try
                                {
                                    Order saveInformation = orderGrid.SelectedItem as Order;

                                    database.Orders.Add(saveInformation);
                                    database.SaveChanges();

                                    ordersList = (List<Order>)orderGrid.ItemsSource;

                                    MessageBox.Show("Данные сохранены", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);

                                }
                                catch (Exception exception)
                                {
                                    MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Не было выделено ни одной строки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;
                        }
                }
            }
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {



            using (DryCleaningDBContext database = new DryCleaningDBContext())
            {
                switch (Menu.SelectedIndex)
                {
                    case 0:
                        {
                            try
                            {
                                var columns = employeesGrid.Columns.ToList();

                                List<string> columnsString = new List<string> { "ID сотрудника", "ФИО сотрудника", "Логин", "Роль" };

                                WindowFind windowFind = new WindowFind(columnsString);

                                var dialogResult = windowFind.ShowDialog();
                                if (dialogResult == true)
                                {
                                    Update.IsEnabled = false;
                                    Save.IsEnabled = false;
                                    Delete.IsEnabled = false;

                                    string selectedParameter = windowFind.selectedParameter;
                                    string textToSearch = windowFind.searchParameter;

                                    windowFind.Close();

                                    List<Employee> search = new List<Employee>(1);

                                    switch (selectedParameter)
                                    {
                                        case "ID сотрудника":
                                            {
                                                search = database.Employees.Where(data => data.EmployeeId.Equals(Convert.ToInt32(textToSearch))).ToList();

                                                break;
                                            }
                                        case "ФИО сотрудника":
                                            {
                                                search = database.Employees.Where(data => data.EmployeeFio.Contains(textToSearch)).ToList();

                                                break;
                                            }
                                        case "Логин":
                                            {
                                                search = database.Employees.Where(data => data.Login.Contains(textToSearch)).ToList();

                                                break;
                                            }
                                        case "Роль":
                                            {
                                                search = database.Employees.Where(data => data.RoleId.Equals(Convert.ToInt32(textToSearch))).ToList();

                                                break;
                                            }
                                    }

                                    Cancel.IsEnabled = true;

                                    employeesGrid.ItemsSource = null;
                                    employeesGrid.ItemsSource = search;
                                }
                            }
                            catch (Exception exception)
                            {
                                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;
                        }
                    case 1:
                        {
                            try
                            {
                                var columns = accessRulesGrid2.Columns.ToList();

                                List<string> columnsString = new List<string> { "Роль", "Права доступа"};

                                WindowFind windowFind = new WindowFind(columnsString);

                                var dialogResult = windowFind.ShowDialog();
                                if (dialogResult == true)
                                {
                                    Update.IsEnabled = false;
                                    Save.IsEnabled = false;
                                    Delete.IsEnabled = false;

                                    string selectedParameter = windowFind.selectedParameter;
                                    string textToSearch = windowFind.searchParameter;

                                    windowFind.Close();

                                    List<AccessRule> search = new List<AccessRule>(1);

                                    switch (selectedParameter)
                                    {
                                        case "Роль":
                                            {
                                                search = database.AccessRules.Where(data => data.Role.Equals(Convert.ToInt32(textToSearch))).ToList();

                                                break;
                                            }
                                        case "Права доступа":
                                            {
                                                search = database.AccessRules.Where(data => data.AccessRules.Contains(textToSearch)).ToList();

                                                break;
                                            }
                                    }

                                    Cancel.IsEnabled = true;

                                    accessRulesGrid2.ItemsSource = null;
                                    accessRulesGrid2.ItemsSource = search;
                                }
                            }
                            catch (Exception exception)
                            {
                                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;
                        }
                    case 2:
                        {
                            try
                            {
                                var columns = clientGrid.Columns.ToList();

                                List<string> columnsString = new List<string> { "ID клиента", "Наименование клиента", "ИНН", "Город" };

                                WindowFind windowFind = new WindowFind(columnsString);

                                var dialogResult = windowFind.ShowDialog();
                                if (dialogResult == true)
                                {
                                    Update.IsEnabled = false;
                                    Save.IsEnabled = false;
                                    Delete.IsEnabled = false;

                                    string selectedParameter = windowFind.selectedParameter;
                                    string textToSearch = windowFind.searchParameter;

                                    windowFind.Close();

                                    List<Client> search = new List<Client>(1);

                                    switch (selectedParameter)
                                    {
                                        case "ID клиента":
                                            {
                                                search = database.Clients.Where(data => data.ClientId.Equals(Convert.ToInt32(textToSearch))).ToList();

                                                break;
                                            }
                                        case "Наименование клиента":
                                            {
                                                search = database.Clients.Where(data => data.ClientName.Contains(textToSearch)).ToList();

                                                break;
                                            }
                                        case "ИНН":
                                            {
                                                search = database.Clients.Where(data => data.Inn.Contains(textToSearch)).ToList();

                                                break;
                                            }
                                        case "Город":
                                            {
                                                search = database.Clients.Where(data => data.City.Contains(textToSearch)).ToList();

                                                break;
                                            }
                                    }

                                    Cancel.IsEnabled = true;

                                    clientGrid.ItemsSource = null;
                                    clientGrid.ItemsSource = search;
                                }
                            }
                            catch (Exception exception)
                            {
                                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;
                        }
                    case 3:
                        {
                            try
                            {
                                var columns = thingGrid.Columns.ToList();

                                List<string> columnsString = new List<string> { "ID вещи", "Название вещи", "Описание вещи" };

                                WindowFind windowFind = new WindowFind(columnsString);

                                var dialogResult = windowFind.ShowDialog();
                                if (dialogResult == true)
                                {
                                    Update.IsEnabled = false;
                                    Save.IsEnabled = false;
                                    Delete.IsEnabled = false;

                                    string selectedParameter = windowFind.selectedParameter;
                                    string textToSearch = windowFind.searchParameter;

                                    windowFind.Close();

                                    List<Thing> search = new List<Thing>(1);

                                    switch (selectedParameter)
                                    {
                                        case "ID вещи":
                                            {
                                                search = database.Things.Where(data => data.ThingId.Equals(Convert.ToInt32(textToSearch))).ToList();

                                                break;
                                            }
                                        case "Название вещи":
                                            {
                                                search = database.Things.Where(data => data.ThingName.Contains(textToSearch)).ToList();

                                                break;
                                            }
                                        case "Описание вещи":
                                            {
                                                search = database.Things.Where(data => data.ThingDescription.Contains(textToSearch)).ToList();

                                                break;
                                            }
                                    }

                                    Cancel.IsEnabled = true;

                                    thingGrid.ItemsSource = null;
                                    thingGrid.ItemsSource = search;
                                }
                            }
                            catch (Exception exception)
                            {
                                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;
                        }
                    case 4:
                        {
                            try
                            {
                                var columns = serviceGrid.Columns.ToList();

                                List<string> columnsString = new List<string> { "ID услуги", "Название услуги", "Стоимость услуги" };

                                WindowFind windowFind = new WindowFind(columnsString);

                                var dialogResult = windowFind.ShowDialog();
                                if (dialogResult == true)
                                {
                                    Update.IsEnabled = false;
                                    Save.IsEnabled = false;
                                    Delete.IsEnabled = false;

                                    string selectedParameter = windowFind.selectedParameter;
                                    string textToSearch = windowFind.searchParameter;

                                    windowFind.Close();

                                    List<Service> search = new List<Service>(1);

                                    switch (selectedParameter)
                                    {
                                        case "ID услуги":
                                            {
                                                search = database.Services.Where(data => data.ServiceId.Equals(Convert.ToInt32(textToSearch))).ToList();

                                                break;
                                            }
                                        case "Название услуги":
                                            {
                                                search = database.Services.Where(data => data.ServiceName.Contains(textToSearch)).ToList();

                                                break;
                                            }
                                        case "Стоимость услуги":
                                            {
                                                search = database.Services.Where(data => data.ServicePrice.Equals(Convert.ToInt32(textToSearch))).ToList();

                                                break;
                                            }
                                    }

                                    Cancel.IsEnabled = true;

                                    serviceGrid.ItemsSource = null;
                                    serviceGrid.ItemsSource = search;
                                }
                            }
                            catch (Exception exception)
                            {
                                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;
                        }
                    case 5:
                        {
                            try
                            {
                                var columns = progressGrid.Columns.ToList();

                                List<string> columnsString = new List<string> { "ID прогресса выполнения", "Прогресс выполнения" };

                                WindowFind windowFind = new WindowFind(columnsString);

                                var dialogResult = windowFind.ShowDialog();
                                if (dialogResult == true)
                                {
                                    Update.IsEnabled = false;
                                    Save.IsEnabled = false;
                                    Delete.IsEnabled = false;

                                    string selectedParameter = windowFind.selectedParameter;
                                    string textToSearch = windowFind.searchParameter;

                                    windowFind.Close();

                                    List<Progress> search = new List<Progress>(1);

                                    switch (selectedParameter)
                                    {
                                        case "ID прогресса выполнения":
                                            {
                                                search = database.Progresses.Where(data => data.ProgressId.Equals(Convert.ToInt32(textToSearch))).ToList();

                                                break;
                                            }
                                        case "Прогресс выполнения":
                                            {
                                                search = database.Progresses.Where(data => data.ProgressName.Contains(textToSearch)).ToList();

                                                break;
                                            }
                                    }

                                    Cancel.IsEnabled = true;

                                    progressGrid.ItemsSource = null;
                                    progressGrid.ItemsSource = search;
                                }
                            }
                            catch (Exception exception)
                            {
                                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;
                        }
                    case 6:
                        {
                            try
                            {
                                var columns = orderStateGrid.Columns.ToList();

                                List<string> columnsString = new List<string> { "ID статуса заказа", "Статус оплаты", "Прогресс выполнения" };

                                WindowFind windowFind = new WindowFind(columnsString);

                                var dialogResult = windowFind.ShowDialog();
                                if (dialogResult == true)
                                {
                                    Update.IsEnabled = false;
                                    Save.IsEnabled = false;
                                    Delete.IsEnabled = false;

                                    string selectedParameter = windowFind.selectedParameter;
                                    string textToSearch = windowFind.searchParameter;

                                    windowFind.Close();

                                    List<OrderState> search = new List<OrderState>(1);

                                    switch (selectedParameter)
                                    {
                                        case "ID статуса заказа":
                                            {
                                                search = database.OrderStates.Where(data => data.OrderStateId.Equals(Convert.ToInt32(textToSearch))).ToList();

                                                break;
                                            }
                                        case "Статус оплаты":
                                            {
                                                search = database.OrderStates.Where(data => data.PaymentState.Equals(Convert.ToBoolean(textToSearch))).ToList();

                                                break;
                                            }                                        
                                        case "Прогресс выполнения":
                                            {
                                                search = database.OrderStates.Where(data => data.ProgressId.Equals(Convert.ToInt32(textToSearch))).ToList();

                                                break;
                                            }
                                    }

                                    Cancel.IsEnabled = true;

                                    orderStateGrid.ItemsSource = null;
                                    orderStateGrid.ItemsSource = search;
                                }
                            }
                            catch (Exception exception)
                            {
                                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;
                        }
                    case 7:
                        {
                            try
                            {
                                var columns = orderGrid.Columns.ToList();

                                List<string> columnsString = new List<string> { "ID заказа", "Клиент", "Услуга", "Вещь", "Дата заказа", "Дата выполнения", "Доставка", "Статус заказа", "Номер договора", "Стоимость" };

                                WindowFind windowFind = new WindowFind(columnsString);

                                var dialogResult = windowFind.ShowDialog();
                                if (dialogResult == true)
                                {
                                    Update.IsEnabled = false;
                                    Save.IsEnabled = false;
                                    Delete.IsEnabled = false;

                                    string selectedParameter = windowFind.selectedParameter;
                                    string textToSearch = windowFind.searchParameter;

                                    windowFind.Close();

                                    List<Order> search = new List<Order>(1);

                                    switch (selectedParameter)
                                    {
                                        case "ID заказа":
                                            {
                                                search = database.Orders.Where(data => data.OrderId.Equals(Convert.ToInt32(textToSearch))).ToList();

                                                break;
                                            }
                                        case "Клиент":
                                            {
                                                search = database.Orders.Where(data => data.ClientId.Equals(Convert.ToInt32(textToSearch))).ToList();

                                                break;
                                            }
                                        case "Услуга":
                                            {
                                                search = database.Orders.Where(data => data.ServiceId.Equals(Convert.ToInt32(textToSearch))).ToList();

                                                break;
                                            }
                                        case "Вещь":
                                            {
                                                search = database.Orders.Where(data => data.ThingId.Equals(Convert.ToInt32(textToSearch))).ToList();

                                                break;
                                            }                                        
                                        case "Дата заказа":
                                            {
                                                search = database.Orders.Where(data => data.OrderDate.Equals(Convert.ToDateTime(textToSearch))).ToList();

                                                break;
                                            }                                        
                                        case "Дата выполнения":
                                            {
                                                search = database.Orders.Where(data => data.IssueDate.Equals(Convert.ToDateTime(textToSearch))).ToList();

                                                break;
                                            }
                                        case "Доставка":
                                            {
                                                search = database.Orders.Where(data => data.Delivery.Equals(Convert.ToBoolean(textToSearch))).ToList();

                                                break;
                                            }
                                        case "Статус заказа":
                                            {
                                                search = database.Orders.Where(data => data.OrderStateId.Equals(Convert.ToInt32(textToSearch))).ToList();

                                                break;
                                            }
                                        case "Номер договора":
                                            {
                                                search = database.Orders.Where(data => data.Contract.Equals(textToSearch)).ToList();

                                                break;
                                            }
                                        case "Стоимость":
                                            {
                                                search = database.Orders.Where(data => data.Price.Equals(Convert.ToInt32(textToSearch))).ToList();

                                                break;
                                            }
                                    }

                                    Cancel.IsEnabled = true;

                                    orderGrid.ItemsSource = null;
                                    orderGrid.ItemsSource = search;
                                }
                            }
                            catch (Exception exception)
                            {
                                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;
                        }
                }

            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Cancel.IsEnabled = false;
            Update.IsEnabled = true;
            Save.IsEnabled = true;
            Delete.IsEnabled = true;

            switch (Menu.SelectedIndex)
            {
                case 0:
                    {
                        employeesGrid.ItemsSource = null;
                        employeesGrid.ItemsSource = employeesList;
                        
                        break;
                    }
                    case 1:
                    {
                        accessRulesGrid2.ItemsSource = null;
                        accessRulesGrid2.ItemsSource = accessRuleList;

                        break;
                    }
                case 2:
                    {
                        clientGrid.ItemsSource = null;
                        clientGrid.ItemsSource = clientsList;

                        break;
                    }
                case 3:
                    {
                        thingGrid.ItemsSource = null;
                        thingGrid.ItemsSource = thingsList;

                        break;
                    }
                case 4:
                    {
                        serviceGrid.ItemsSource = null;
                        serviceGrid.ItemsSource = servicesList;

                        break;
                    }
                case 5:
                    {
                        progressGrid.ItemsSource = null;
                        progressGrid.ItemsSource = progressesList;
                        
                        break;
                    }
                case 6:
                    {
                        orderStateGrid.ItemsSource = null;
                        orderStateGrid.ItemsSource = orderStatesList;
                        
                        break;
                    }
                case 7:
                    {
                        orderGrid.ItemsSource = null;
                        orderGrid.ItemsSource = ordersList;

                        break;
                    }
            }
        }

        //private void orderGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        //{
        //    using (DryCleaningDBContext database = new DryCleaningDBContext())
        //    {

        //        Order order = orderGrid.SelectedItem as Order;

        //        var row = DataGridHelper.GetRowIndex(DataGridHelper.GetCell(orderGrid.CurrentCell));
        //        var sourceCell = DataGridHelper.FindCell(row, 3, orderGrid);

        //        if (sourceCell != null)
        //        {
        //            var servicePrice = database.Services.Where(data => data.ServiceId.Equals(order.ServiceId)).Select(data => data.ServicePrice).FirstOrDefault();
        //            //order.Price = servicePrice;

        //            var destinationCell = DataGridHelper.FindCell(row, 9, orderGrid);

        //            if (destinationCell != null)
        //            {
        //                destinationCell.Content = servicePrice;

        //                MessageBox.Show(Convert.ToString(servicePrice));
        //            }
        //        }
        //    }
        //}
    }
}
