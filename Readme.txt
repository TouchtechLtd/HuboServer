README

This repo is for the Hubo Server project

Report URL is on bitbucket, and project tasks/issues will be managed on inhouse JIRA



In case of Migration issues where Tables are not behaving properly (Will not add even though it doesn't exist in the DB anymore):

1. Manually delete DB (Backup any important data!)
2. Remove all migration files under Migrations/. Obviously do not delete the important classes.
3. Rebuild project (important step).
4. Run "Add-Migration Initial" -> "Update-Database" under Package manager console.
5. Voila