Install Visual Studio and while setup - use NUnit Framework
Include selenium extentions through Nuget Package Manager.
Attached are the 2 scenarios which I've written as automated test cases for the Computer Databse.
The path of the ChromeDriver.exe is given as in the D folder. Please ensure that the driver is located in the same path to avoid confusion.

Now, open Test -> Test Explorer and then select the 2 test cases or the project which contains these tests and select run the tests.

Then the test scripts open the chrome and then move to the Computer database.
Creates a new computer 'ThinkPad' - Message shown as "Done ! Computer ThinkPad has been created" 
Applies filter by name 'ThinkPad'- Message shown as "25 computers found"
Edits a compuer 'ThinkPad' - Message shown as "Done ! Computer ThinkPad has been updated"