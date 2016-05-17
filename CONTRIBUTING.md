This file contains guidelines that should be followed when making any changes to the repository, and is visible with the Pull Request UI in Bitbucket by clicking the 'Pull Request Guidelines' Button.

All text before the first level 1 (L1) header will be ignored by the Pull request guidelines add-on in . 

# Important Guidelines to follow when adding code contributing to this project 

## All commits must have the issue number at the start of the commit message
This includes even partial commits on a separate branch.

## All development should be done in feature or hotfix branches and should have at least one approval before being merged into develop/master
Nothing should ever be committed directly to the develop or master branch. Everything that goes into develop / master should always be coming from a separate branch that has been approved by at least one other user.

## Everything should be unit tested
All new functionality that is added should have tests that can be run to check the functionality. Existing functionality that is changed should ideally require updates to existing tests OR additional tests being added.

Also please make sure all tests pass before creating a pull request

## TODO: Add other notes for contributing guidelines.








# Important Guidelines to follow when reviewing peoples pull requests
The following a list of guidelines to follow when reviewing someone's code, listed in order of priority from top to bottom. 

When the code does not meet the requirements of any items below labeled with a (1) or (2) the Pull request should be updated before it is approved

## Does the code build (1)
If the project doesn't build, obviously something is wrong. You can't proceed with testing / reviewing until the project builds.

## Does the code work (1)
When running the code does it do what it is supposed to. You should be able to read the related issue in JIRA/AC and the changes made in the pull request should be to achieve what was described in the JIRA issue.

## Do all the tests pass? (1)
If any tests fail, it is an immediate sign that either there is a bug in the code, or that the tests need to be updated to work with the new code base.

## Are there any obvious bugs / security flaws that can be identified in the code (1)
This is harder to spot as to identify these you really need to spend time reading each line of code. Some things to look for would be:

### Security

* Is the request restricted to authenticated users (people who are logged in).
* Is the request restricted to authorised users (people who have the correct permissions to be performing this action).
* Does the code protect against the OWASP top ten list of vunerabilities as defined by [https://www.owasp.org/index.php/Category:OWASP_Top_Ten_2013_Project](https://www.owasp.org/index.php/Category:OWASP_Top_Ten_2013_Project)

### Bugs

* If making a change to existing functionality, does this change introduce a bug/issue anywhere else in the application
* **TODO:** Add other common bugs to look for

## Are there any tests added? (2)
If there is no tests added/updated in the pull request, it should set off some warnings.

For any new functionality added there should be corresponding tests added. If the Pull Request is for a change to existing functionality the expectation is that there would have been an existing test that will most likely need to be updated. If there wasn't an existing test, now would be a good time to add one.

## Are exceptions / edge cases being handled correctly/safely (2)
Try to expect the unexpected. How does the code handle things like:

* When unhandled exceptions / errors occur are they logged / stored somewhere that can be easily retrieved by a developer.
* When unhandled exceptions / errors occur is a user friendly error message displayed to the user.
* When connecting to another system, if that system is not accessible what happens. 
* How does it handle things like timeouts / long running processes.


## Code analysis (2)
**TODO UPDATE:** Are there any warnings / errors that are detected by the code analysis. **@Lincoln** - please update to define the settings to be used for code analysis

This should include checking for:

* large functions - any function > 80 lines
* large files - any file > 500 lines 

## Naming convention and code formatting (3)
**TODO UPDATE:** We want to follow XXXX naming convention and code formatting. 

## Commenting (3)
* EVERY function (public/protected/private/internal) MUST be commented with at least the parameter descriptions. 
* EVERY public and protected function MUST have at least a short description included as well.



