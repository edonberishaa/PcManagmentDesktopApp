# PC Management Desktop App

## Overview
The **PC Management Desktop App** is a C# Windows Forms application integrated with an SQL Server database, designed to manage and track PC usage in a gaming center. It allows operators to start and stop timers for individual computers, automatically calculating usage duration and earnings. The system also maintains a history of PC usage, order transactions, and a financial summary for better management.

## Features
- **PC Usage Tracking**: Start and stop timers for each PC to track playtime.
- **Automated Billing**: Calculates the cost based on the duration of use.
- **Order Management**: Add and manage orders (e.g., snacks, drinks) per PC.
- **Real-time Price Updates**: Synchronizes product prices and calculates totals dynamically.
- **Financial Summary**: Displays total earnings per PC and overall revenue.
- **User Authentication**: Secure login system with an SQL Server database.
- **Data Persistence**: Stores and retrieves PC usage, earnings, and orders from the database.

## Installation
### Prerequisites
- Windows OS
- .NET Framework (version used in development)
- SQL Server (for database management)
- Visual Studio (for development and debugging)

### Steps
1. Clone this repository:
   ```sh
   git clone https://github.com/edonberishaa/PcManagmentDesktopApp
   ```
2. Open the solution in **Visual Studio**.
3. Restore NuGet packages and ensure all dependencies are installed.
4. Set up the **SQL Server database**:
5. Build and run the application.

## Database Schema
### Tables
- **Computers**: Stores computer details and statuses.
- **Orders**: Manages product orders for each session.
- **Users**: Stores authentication details.
- **UsageHistory**: Tracks time and earnings for each PC session.

## Usage
1. **Login** to access the dashboard.
2. Select a PC and click **Start Timer** to begin tracking usage.
3. Click **Stop Timer** when the session ends, and the total cost will be calculated.
4. Add orders (snacks, drinks) if required.
5. Double-click to get the invoice
6. Monitor revenue and PC usage history in the financial summary section.

## Technologies Used
- **C# (Windows Forms)** for the UI and business logic.
- **SQL Server** for data storage and management.

## Future Enhancements
- Adding **remote access features** to manage PCs from another device.
- Enhancing **UI/UX** with modern design elements.
- Adding **multi-user roles** for admin and operator management.

## Contributing
1. Fork the repository.
2. Create a new branch (`feature-branch`).
3. Commit your changes and push to GitHub.
4. Open a pull request for review.

## License
This project is licensed under the **MIT License**. See `LICENSE` for more details.

## Contact
For inquiries or contributions, contact **Edon Berisha** at edonberisha52@gmail.com

