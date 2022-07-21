# ArmyTech Task - Invoice Management

My implementation to the tasks for the interview. Tasks can be found in issue https://github.com/YoussefWaelMohamedLotfy/ArmyTechTask/issues/2.  
UI Design uses [Bootstrap 5.2.0](https://getbootstrap.com/)

## Project Requirements

In order to run the project, .NET 6.0.7 [(SDK 6.0.302)](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) is required to be installed on your machine in order to run the project.

## How to run

> Firstly, you have to create the Database and run the script, as mentioned in issue https://github.com/YoussefWaelMohamedLotfy/ArmyTechTask/issues/2.

The following steps shows how to run the project:

+ Clone the repo on your machine.
+ Navigate to the repo's folder on your machine.
+ Open `ArmyTechTask.sln` using Visual Studio Community 2022.
+ Make sure that the project `ArmyTechTask` is set as Startup Project.
+ Build the Solution using `Ctrl + Shift + B`, or Right-click on the solution file, then select `Build Solution`
+ Run the project using `Ctrl + F5`, or click on run located under the menu bar.
+ Navigate to [https://localhost:7217](https://localhost:7217)

## SQL View Script

The following Script is written at the end of the [given SQL Script](https://github.com/YoussefWaelMohamedLotfy/ArmyTechTask/blob/f1e72e70861737cd327a662ea525c5cca538dadb/ArmyTechTaskScript.sql#L200) for simplifying the evaluation process. 

```sql
CREATE View [dbo].[Invoices]
AS
SELECT DISTINCT h.*, (SELECT SUM(InvoiceDetails.ItemPrice) FROM InvoiceDetails WHERE h.ID = InvoiceDetails.InvoiceHeaderID) AS InvoiceTotal
FROM InvoiceHeader AS h
LEFT JOIN InvoiceDetails AS d ON h.ID = d.InvoiceHeaderID
WHERE (SELECT COUNT(details.ID) FROM InvoiceDetails AS details WHERE h.ID = details.InvoiceHeaderID) > 1
```
