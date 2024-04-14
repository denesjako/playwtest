# playwtest

Instructions:
-------------------------------
- TestScenario.cs file contains the test, where the credentials can be modified if necessary.
- Use 'dotnet test' command in Terminal/Command prompt to discover and run test.


Observations:
-------------------------------
- Dropdown elements that allows text inputs has no data-unique-ids or ids on the input tag.
- ng-select tags were not identified with Playwright's SelectAsync() method, it is targeting select tags only.
