# CustomDataGridView

CustomDataGridView is a versatile and customizable DataGridView control for .NET WinForms applications. This project aims to enhance the functionality and appearance of the standard DataGridView by providing additional features and customization options.

## Features

- **Column Types:** Supports various column types, including text, checkbox, button, and custom column types.

- **Cell Formatting:** Easily customize the appearance of cells using formatting options.

- **Sorting and Filtering:** Enable sorting and filtering capabilities for efficient data management.

- **Cell Validation:** Implement cell validation to ensure data integrity.

- **Custom Styling:** Tailor the appearance of the DataGridView to match your application's design.

- **Data Binding:** Seamlessly bind data from various sources to the CustomDataGridView.

- **Column Selection and Configuration:** Allow users to dynamically select columns, return a JSON configuration, and set the configuration via JSON.

## Getting Started

### Prerequisites

- .NET Framework 4.5 or later

### Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/joao-a-costa/CustomDataGridView.git
    ```

2. Reference the CustomDataGridView library in your project.

3. Build and run your project.

## Usage

1. **Adding CustomDataGridView to your Form:**

    ```csharp
    using CustomDataGridView;

    // ...

    CustomDataGridView customDataGridView1 = new CustomDataGridView();
    this.Controls.Add(customDataGridView1);
    ```

2. **Configuring Columns:**

    ```csharp
    customDataGridView1.Columns.Add("ID", "Item ID");
    customDataGridView1.Columns.Add("Name", "Item Name");
    customDataGridView1.Columns.Add("Price", "Item Price");

    // Customize column properties
    customDataGridView1.Columns["Price"].DefaultCellStyle.Format = "c";
    ```

3. **Data Binding:**

    ```csharp
    List<Item> itemList = GetItemList(); // Replace with your data source
    customDataGridView1.DataSource = itemList;
    ```

4. **Handling Events:**

    ```csharp
    private void customDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        // Handle cell click event
    }

    private void customDataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        // Handle cell validation
    }

    // Add more event handlers as needed
    ```

5. **Column Selection and Configuration:**

    Allow users to dynamically select columns and configure the grid. Return a JSON configuration and set the configuration via JSON.

    ```csharp
    // Get JSON configuration
    string jsonConfiguration = customDataGridView1.GetConfigurationAsJson();

    // Set configuration from JSON
    customDataGridView1.SetConfigurationFromJson(jsonConfiguration);
    ```

## Contributing

Contributions are welcome! Please follow these guidelines:

1. Fork the repository.
2. Create a branch: `git checkout -b feature/your-feature`.
3. Commit your changes: `git commit -m 'Add some feature'`.
4. Push to the branch: `git push origin feature/your-feature`.
5. Open a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Special thanks to contributors and users for their valuable feedback.

---

Feel free to explore and extend the functionality of CustomDataGridView for your WinForms applications! If you encounter any issues or have suggestions, please open an issue on the [GitHub repository](https://github.com/joao-a-costa/CustomDataGridView/issues).
